﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using xTile;
using xTile.Format;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using xTile.Tiles;
using xTile.Layers;

namespace tIDE.Format
{
    internal class MappyFmapFormat: IMapFormat
    {
        #region Public Methods

        public CompatibilityReport DetermineCompatibility(xTile.Map map)
        {
            List<CompatibilityNote> compatibilityNotes = new List<CompatibilityNote>();

            if (map.TileSheets.Count != 1)
                compatibilityNotes.Add(
                    new CompatibilityNote(CompatibilityLevel.None, "Map must use exactly one tile sheet"));

            if (map.Layers.Count == 0)
                compatibilityNotes.Add(
                    new CompatibilityNote(CompatibilityLevel.None, "Map must have at least one layer"));

            if (map.Layers.Count > 8)
                compatibilityNotes.Add(
                    new CompatibilityNote(CompatibilityLevel.None, "Map must have no more than 8 layers"));

            xTile.Dimensions.Size layerSize = map.Layers[0].LayerSize;

            foreach (Layer layer in map.Layers)
                if (layer.LayerSize != layerSize)
                {
                    compatibilityNotes.Add(
                        new CompatibilityNote(CompatibilityLevel.None, "All layers must be of the same size"));
                    break;
                }

            xTile.Dimensions.Size tileSize = map.Layers[0].TileSize;
            foreach (Layer layer in map.Layers)
                if (layer.TileSize != tileSize)
                {
                    compatibilityNotes.Add
                        (new CompatibilityNote(CompatibilityLevel.None,
                            "All layers must share a common tile size dictated by the tile sheet"));
                    break;
                }

            string[] descriptionParagraphs = map.Description.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (descriptionParagraphs.Length > 4)
                compatibilityNotes.Add(new CompatibilityNote(CompatibilityLevel.None, "Map description should not exceed 4 paragraphs"));

            compatibilityNotes.Add(
                new CompatibilityNote(CompatibilityLevel.Partial, "Tile, layer and map attributes will not be stored"));

            compatibilityNotes.Add(
                new CompatibilityNote(CompatibilityLevel.Partial, "Auto-tiling definitions will not be stored"));

            compatibilityNotes.Add(
                new CompatibilityNote(CompatibilityLevel.Partial, "Brush definitions will not be stored"));

            CompatibilityReport compatibilityReport = new CompatibilityReport(compatibilityNotes);
            return compatibilityReport;
        }

        public Map Load(Stream stream)
        {
            ReadHeader(stream);

            MphdRecord mphdRecord = null;
            string[] authorLines = null;
            Color[] colourMap = null;
            BlockRecord[] blockRecords = null;
            AnimationRecord[] animationRecords = null;
            Image imageSource = null;
            short[][] layers = new short[8][];

            Dictionary<string, Chunk> chunks = MapChunks(stream);

            if (!chunks.ContainsKey("MPHD"))
                throw new Exception("Header chunk MPHD missing");
            Chunk mphdChunk = chunks["MPHD"];
            mphdRecord = ReadChunkMPHD(stream, mphdChunk);

            if (mphdRecord.BlockDepth == 8)
            {
                if (!chunks.ContainsKey("CMAP"))
                    throw new Exception("Colour map chuck CMAP is required for 8bit graphics blocks");
                Chunk cmapChunk = chunks["CMAP"];
                colourMap = ReadChunkCMAP(stream, cmapChunk);
            }

            if (chunks.ContainsKey("ATHR"))
                authorLines = ReadChunkATHR(stream, chunks["ATHR"]);

            if (!chunks.ContainsKey("BKDT"))
                throw new Exception("Block data chunk BKDT missing");
            Chunk bkdtChunk = chunks["BKDT"];
            blockRecords = ReadChunkBKDT(stream, bkdtChunk, mphdRecord);

            // optional ?
            if (chunks.ContainsKey("ANDT"))
            {
                Chunk andtChunk = chunks["ANDT"];
                animationRecords = ReadChunkANDT(stream, andtChunk, mphdRecord);
            }

            if (!chunks.ContainsKey("BGFX"))
                throw new Exception("Block graphics chunk BGFX missing");
            Chunk bgfxChunk = chunks["BGFX"];
            imageSource = ReadChunkBGFX(stream, bgfxChunk, mphdRecord, colourMap);

            if (!chunks.ContainsKey("BODY"))
                throw new Exception("Body chunk BODY missing");
            Chunk bodyChunk = chunks["BODY"];
            layers[0] = ReadChunkLayer(stream, bodyChunk, mphdRecord);

            // additional layers
            for (int layer = 1; layer <= 7; layer++)
            {
                string chunkId = "LYR" + layer;
                if (chunks.ContainsKey(chunkId))
                {
                    Chunk layerChuck = chunks[chunkId];
                    layers[layer] = ReadChunkLayer(stream, layerChuck, mphdRecord);
                }
            }

            // new map
            Map map = new Map();

            // attach ATHR lines as description
            if (authorLines != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (string authorLine in authorLines)
                    stringBuilder.AppendLine(authorLine);
                map.Description = stringBuilder.ToString();
            }

            // prompt user to save tilesheet image source
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.Filter = "Portable Network Geaphics (*.png)|*.png";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.Title = "Save tile sheet image source as";
            saveFileDialog.ValidateNames = true;
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                throw new Exception("Mappy FMAP file import aborted");

            string tileSheetImageSource = saveFileDialog.FileName;

            imageSource.Save(tileSheetImageSource, ImageFormat.Png);

            // determine global tile size
            xTile.Dimensions.Size tileSize = new xTile.Dimensions.Size(mphdRecord.BlockWidth, mphdRecord.BlockHeight);

            // add tilesheet
            TileSheet tileSheet = new TileSheet("BGFX", map, tileSheetImageSource,
                new xTile.Dimensions.Size(1, mphdRecord.NumBlockGfx), tileSize);
            map.AddTileSheet(tileSheet);

            // determine global map size
            xTile.Dimensions.Size mapSize = new xTile.Dimensions.Size(mphdRecord.MapWidth, mphdRecord.MapHeight);

            // create layers
            for (int layerIndex = 0; layerIndex < 8; layerIndex++)
            {
                if (layers[layerIndex] == null)
                    continue;

                string layerId = layerIndex == 0 ? "BODY" : "LYR" + layerIndex;
                Layer layer = new Layer(layerId, map, mapSize, tileSize);
                map.AddLayer(layer);
                for (int tileY = 0; tileY < mapSize.Height; tileY++)
                {
                    for (int tileX = 0; tileX < mapSize.Width; tileX++)
                    {
                        int layerOffset = tileY * mapSize.Width + tileX;
                        int tileIndex = layers[layerIndex][layerOffset];
                        if (tileIndex >= 0)
                        {
                            layer.Tiles[tileX, tileY] = new StaticTile(layer, tileSheet, BlendMode.Alpha, tileIndex);
                        }
                        else
                        {
                            AnimationRecord animationRecord = animationRecords[-tileIndex - 1];
                            StaticTile[] tileFrames = new StaticTile[animationRecord.Frames.Length];

                            for (int frameIndex = 0; frameIndex < animationRecord.Frames.Length; frameIndex++)
                                tileFrames[frameIndex] = new StaticTile(layer, tileSheet, BlendMode.Alpha, animationRecord.Frames[frameIndex]);

                            // process loop types
                            switch (animationRecord.Type)
                            {
                                case 2: // LOOPR: loop backward
                                    Array.Reverse(tileFrames);
                                    break;
                                case 5: // PPFF -+
                                case 6: // PPRR  | - different states for ping-pong animation
                                case 7: // PPRF  | - treat all the same
                                case 8: // PPFR -+
                                    StaticTile[] pingPongFrames = new StaticTile[tileFrames.Length * 2 - 1];
                                    Array.Copy(tileFrames, pingPongFrames, tileFrames.Length);
                                    Array.Copy(tileFrames, 0, pingPongFrames, tileFrames.Length, tileFrames.Length - 1);
                                    Array.Reverse(pingPongFrames, tileFrames.Length, tileFrames.Length - 1);
                                    tileFrames = pingPongFrames;
                                    break;
                                default: // treat all other cases as LOOPF
                                    // 0 = NONE
                                    // 1 = LOOPF: loop forward
                                    // 3 = ONCE, 4 = ONCEH: one-off animations
                                    // 9 = ONCES: one-off animations
                                    break;
                            }

                            AnimatedTile animatedTile = new AnimatedTile(layer, tileFrames, (long)animationRecord.Delay * 20);
                            layer.Tiles[tileX, tileY] = animatedTile;
                        }
                    }
                }
            }

            return map;
        }

        public void Store(Map map, Stream stream)
        {
            // main file header
            WriteHeader(stream);

            // ATHR chunk
            WriteChunkATHR(stream, map);

            // MPHD chunk
            WriteChunkMPHD(stream, map);

            // no CMAP chunk

            // BKDT chunk
            WriteChunkBKDT(stream, map);

            // ANDT chunk
            AnimatedTile[] animatedTiles = WriteChunkANDT(stream, map);

            // BGFX chunk
            WriteChunkBGFX(stream, map);

            // BODY chunk
            WriteChunkLayer(stream, map.Layers[0], "BODY", animatedTiles);

            // LYR? chunks
            for (int layerIndex = 1; layerIndex < map.Layers.Count; layerIndex++)
            {
                string chunkId = "LYR" + layerIndex;
                WriteChunkLayer(stream, map.Layers[layerIndex], chunkId, animatedTiles);
            }

            // update header
            long dataEnd = stream.Position;
            long contentLength = dataEnd - 8;
            stream.Position = 4;
            WriteMsb(stream, contentLength);
            stream.Position = dataEnd;
        }

        #endregion

        #region Public Properties

        public string Name
        {
            get { return "Mappy FMP Format"; }
        }

        public string FileExtensionDescriptor
        {
            get { return "Mappy FMP Files (*.fmp)"; }
        }

        public string FileExtension
        {
            get { return "fmp"; }
        }

        #endregion

        #region Private Methods

        private byte ReadUnsignedByte(Stream stream)
        {
            int byt = stream.ReadByte();
            if (byt < 0)
                throw new Exception("Unexpected end of file while reading unsigned byte");
            return (byte)byt;
        }

        private sbyte ReadSignedByte(Stream stream)
        {
            int byt = stream.ReadByte();
            if (byt < 0)
                throw new Exception("Unexpected end of file while reading signed byte");
            return (sbyte)byt;
        }

        private short ReadShortMsb(Stream stream)
        {
            byte[] shortBytes = new byte[2];

            long position = stream.Position;
            if (stream.Read(shortBytes, 0, 2) != 2)
                throw new Exception("Error reading MSB short int at position " + position);

            short value = (short)((shortBytes[0] << 8) | shortBytes[1]);

            return value;
        }

        private short ReadShortLsb(Stream stream)
        {
            byte[] shortBytes = new byte[2];

            long position = stream.Position;
            if (stream.Read(shortBytes, 0, 2) != 2)
                throw new Exception("Error reading MSB short int at position " + position);

            short value = (short)((shortBytes[1] << 8) | shortBytes[0]);

            return value;
        }

        private short ReadShort(Stream stream, bool lsb)
        {
            return lsb ? ReadShortLsb(stream) : ReadShortMsb(stream);
        }

        private ushort ReadUnsignedShortMsb(Stream stream)
        {
            byte[] shortBytes = new byte[2];

            long position = stream.Position;
            if (stream.Read(shortBytes, 0, 2) != 2)
                throw new Exception("Error reading MSB short int at position " + position);

            ushort value = (ushort)((shortBytes[0] << 8) | shortBytes[1]);

            return value;
        }

        private ushort ReadUnsignedShortLsb(Stream stream)
        {
            byte[] shortBytes = new byte[2];

            long position = stream.Position;
            if (stream.Read(shortBytes, 0, 2) != 2)
                throw new Exception("Error reading MSB short int at position " + position);

            ushort value = (ushort)((shortBytes[1] << 8) | shortBytes[0]);

            return value;
        }

        private ushort ReadUnsignedShort(Stream stream, bool lsb)
        {
            return lsb ? ReadUnsignedShortLsb(stream) : ReadUnsignedShortMsb(stream);
        }

        private ulong ReadUnsignedLongMsb(Stream stream)
        {
            byte[] longBytes = new byte[4];

            long position = stream.Position;
            if (stream.Read(longBytes, 0, 4) != 4)
                throw new Exception("Error reading MSB long at position " + position);

            ulong value = (ulong)((longBytes[0] << 24) | (longBytes[1] << 16)
                | (longBytes[2] << 8) | longBytes[3]);

            return value;
        }

        private ulong ReadUnsignedLongLsb(Stream stream)
        {
            byte[] longBytes = new byte[4];

            long position = stream.Position;
            if (stream.Read(longBytes, 0, 4) != 4)
                throw new Exception("Error reading LSB long at position " + position);

            ulong value = (ulong)((longBytes[3] << 24) | (longBytes[2] << 16)
                | (longBytes[1] << 8) | longBytes[0]);

            return value;
        }

        private ulong ReadUnsignedLong(Stream stream, bool lsb)
        {
            return lsb ? ReadUnsignedLongLsb(stream) : ReadUnsignedLongMsb(stream);
        }

        private long ReadSignedLongMsb(Stream stream)
        {
            byte[] longBytes = new byte[4];

            long position = stream.Position;
            if (stream.Read(longBytes, 0, 4) != 4)
                throw new Exception("Error reading MSB long at position " + position);

            long value = (longBytes[0] << 24) | (longBytes[1] << 16)
                | (longBytes[2] << 8) | longBytes[3];

            return value;
        }

        private long ReadSignedLongLsb(Stream stream)
        {
            byte[] longBytes = new byte[4];

            long position = stream.Position;
            if (stream.Read(longBytes, 0, 4) != 4)
                throw new Exception("Error reading LSB long at position " + position);

            long value = (longBytes[3] << 24) | (longBytes[2] << 16)
                | (longBytes[1] << 8) | longBytes[0];

            return value;
        }

        private long ReadSignedLong(Stream stream, bool lsb)
        {
            return lsb ? ReadSignedLongLsb(stream) : ReadSignedLongMsb(stream);
        }

        private string ReadSequence(Stream stream, int count)
        {
            try
            {
                byte[] byteSequence = new byte[count];

                long position = stream.Position;
                if (stream.Read(byteSequence, 0, count) != count)
                    throw new Exception("Unexpected end of file while reading sequence of " + count + " bytes at position " + position);

                return ASCIIEncoding.ASCII.GetString(byteSequence);
            }
            catch (Exception exception)
            {
                throw new Exception("Error while reading char sequence of lengh " + count, exception);
            }
        }

        private void ReadSequence(Stream stream, string sequence)
        {
            try
            {
                long position = stream.Position;
                string readSequence = ReadSequence(stream, sequence.Length);

                if (readSequence != sequence)
                    throw new Exception("Expected sequence '" + sequence + "' at position " + position);
            }
            catch (Exception exception)
            {
                throw new Exception("Error wile matching char sequence '" + sequence + "'", exception);
            }
        }

        private void Write(Stream stream, byte value)
        {
            stream.WriteByte(value);
        }

        private void Write(Stream stream, sbyte value)
        {
            stream.WriteByte((byte)value);
        }

        private void WriteMsb(Stream stream, short value)
        {
            byte[] shortBytes = new byte[2];

            shortBytes[0] = (byte) (value >> 8);
            shortBytes[1] = (byte) (value & 0xFF);

            stream.Write(shortBytes, 0, 2);
        }

        private void WriteLsb(Stream stream, short value)
        {
            byte[] shortBytes = new byte[2];

            shortBytes[0] = (byte)(value & 0xFF);
            shortBytes[1] = (byte)(value >> 8);

            stream.Write(shortBytes, 0, 2);
        }

        private void Write(Stream stream, bool lsb, short value)
        {
            if (lsb)
                WriteLsb(stream, value);
            else
                WriteMsb(stream, value);
        }

        private void WriteMsb(Stream stream, ushort value)
        {
            byte[] shortBytes = new byte[2];

            shortBytes[0] = (byte)(value >> 8);
            shortBytes[1] = (byte)(value & 0xFF);

            stream.Write(shortBytes, 0, 2);
        }

        private void WriteLsb(Stream stream, ushort value)
        {
            byte[] shortBytes = new byte[2];

            shortBytes[0] = (byte)(value & 0xFF);
            shortBytes[1] = (byte)(value >> 8);

            stream.Write(shortBytes, 0, 2);
        }

        private void Write(Stream stream, bool lsb, ushort value)
        {
            if (lsb)
                WriteLsb(stream, value);
            else
                WriteMsb(stream, value);
        }

        private void WriteMsb(Stream stream, long value)
        {
            byte[] longBytes = new byte[4];

            longBytes[0] = (byte)(value >> 24);
            longBytes[1] = (byte)((value >> 16) & 0xFF);
            longBytes[2] = (byte)((value >> 8) & 0xFF);
            longBytes[3] = (byte)(value & 0xFF);

            stream.Write(longBytes, 0, 4);
        }

        private void WriteLsb(Stream stream, long value)
        {
            byte[] longBytes = new byte[4];

            longBytes[0] = (byte)(value & 0xFF);
            longBytes[1] = (byte)((value >> 8) & 0xFF);
            longBytes[2] = (byte)((value >> 16) & 0xFF);
            longBytes[3] = (byte)(value >> 24);

            stream.Write(longBytes, 0, 4);
        }

        private void Write(Stream stream, bool lsb, long value)
        {
            if (lsb)
                WriteLsb(stream, value);
            else
                WriteMsb(stream, value);
        }

        private void WriteMsb(Stream stream, ulong value)
        {
            byte[] longBytes = new byte[4];

            longBytes[0] = (byte)(value >> 24);
            longBytes[1] = (byte)((value >> 16) & 0xFF);
            longBytes[2] = (byte)((value >> 8) & 0xFF);
            longBytes[3] = (byte)(value & 0xFF);

            stream.Write(longBytes, 0, 4);
        }

        private void WriteLsb(Stream stream, ulong value)
        {
            byte[] longBytes = new byte[4];

            longBytes[0] = (byte)(value & 0xFF);
            longBytes[1] = (byte)((value >> 8) & 0xFF);
            longBytes[2] = (byte)((value >> 16) & 0xFF);
            longBytes[3] = (byte)(value >> 24);

            stream.Write(longBytes, 0, 4);
        }

        private void Write(Stream stream, bool lsb, ulong value)
        {
            if (lsb)
                WriteLsb(stream, value);
            else
                WriteMsb(stream, value);
        }

        private void WriteSequence(Stream stream, string sequence)
        {
            byte[] byteSequence = ASCIIEncoding.ASCII.GetBytes(sequence);
            stream.Write(byteSequence, 0, byteSequence.Length);
        }

        private void WriteNullTerminatedString(Stream stream, string sequence)
        {
            WriteSequence(stream, sequence);
            stream.WriteByte(0);
        }

        private void ReadHeader(Stream stream)
        {
            ReadSequence(stream, "FORM");
            long storedLength = ReadSignedLongMsb(stream);
            long actualLength = stream.Length - 8;
            if (storedLength != actualLength)
                throw new Exception(
                    "Mappy Header: File body length mismatch: stored = " + storedLength + ", actual = " + actualLength);
            ReadSequence(stream, "FMAP");
        }

        private void WriteHeader(Stream stream)
        {
            WriteSequence(stream, "FORM");
            // file length place holder
            WriteMsb(stream, (long)0);
            WriteSequence(stream, "FMAP");
        }

        private Chunk MapChunk(Stream stream)
        {
            string chunkId = ReadSequence(stream, 4);
            long chunkLength = ReadSignedLongMsb(stream);
            if (chunkLength > int.MaxValue)
                throw new Exception("Chunk sizes greater than " + int.MaxValue + " not supported");
            if (stream.Position + chunkLength > stream.Length)
                throw new Exception("Lenght of chunk '" + chunkId + "' exceeds end of file");

            Chunk chunk = new Chunk();
            chunk.Id = chunkId;
            chunk.FilePosition = stream.Position;
            chunk.Length = (int) chunkLength;

            stream.Position += chunkLength;

            return chunk;
        }

        private Dictionary<string, Chunk> MapChunks(Stream stream)
        {
            Dictionary<string, Chunk> chunks = new Dictionary<string, Chunk>();
            while (stream.Position < stream.Length)
            {
                Chunk chunk = MapChunk(stream);
                chunks[chunk.Id] = chunk;
            }
            return chunks;
        }

        private string[] ReadChunkATHR(Stream stream, Chunk chunk)
        {
            stream.Position = chunk.FilePosition;
            byte[] chunkData = new byte[chunk.Length];
            stream.Read(chunkData, 0, chunk.Length);
            string authors = ASCIIEncoding.ASCII.GetString(chunkData);
            string[] authorLines = authors.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            return authorLines;
        }

        private void WriteChunkATHR(Stream stream, Map map)
        {
            // ATHR chunk
            string[] authorLines = map.Description.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int athrChunkLength = 0;
            foreach (string authorLine in authorLines)
                athrChunkLength += authorLine.Length + 1;

            bool athrPadding = false;
            if (athrChunkLength % 2 != 0)
            {
                ++athrChunkLength;
                athrPadding = true;
            }

            WriteSequence(stream, "ATHR");
            WriteMsb(stream, (long)athrChunkLength);
            foreach (string authorLine in authorLines)
                WriteNullTerminatedString(stream, authorLine);
            if (athrPadding)
                Write(stream, (byte)0);
        }

        private MphdRecord ReadChunkMPHD(Stream stream, Chunk chunk)
        {
            MphdRecord mphdRecord = new MphdRecord();

            stream.Position = chunk.FilePosition;
            mphdRecord.VersionHigh = ReadSignedByte(stream);
            mphdRecord.VersionLow = ReadSignedByte(stream);
            mphdRecord.LSB = ReadSignedByte(stream) != 0;
            mphdRecord.MapType = ReadSignedByte(stream);

            if (mphdRecord.MapType != 0)
                throw new Exception("Only MapType = 0 is supported");

            mphdRecord.MapWidth = ReadShort(stream, mphdRecord.LSB);
            mphdRecord.MapHeight = ReadShort(stream, mphdRecord.LSB);
            mphdRecord.Reserved1 = ReadShort(stream, mphdRecord.LSB);
            mphdRecord.Reserved2 = ReadShort(stream, mphdRecord.LSB);
            mphdRecord.BlockWidth = ReadShort(stream, mphdRecord.LSB);
            mphdRecord.BlockHeight = ReadShort(stream, mphdRecord.LSB);
            mphdRecord.BlockDepth = ReadShort(stream, mphdRecord.LSB);
            mphdRecord.BlockStructSize = ReadShort(stream, mphdRecord.LSB);
            mphdRecord.NumBlockStruct = ReadShort(stream, mphdRecord.LSB);
            mphdRecord.NumBlockGfx = ReadShort(stream, mphdRecord.LSB);

            if (chunk.Length > 24)
            {
                mphdRecord.ColourKeyIndex = ReadUnsignedByte(stream);
                mphdRecord.ColourKeyRed = ReadUnsignedByte(stream);
                mphdRecord.ColourKeyGreen = ReadUnsignedByte(stream);
                mphdRecord.ColourKeyBlue = ReadUnsignedByte(stream);

                if (chunk.Length > 28)
                {
                    mphdRecord.BlockGapX = ReadShort(stream, mphdRecord.LSB);
                    mphdRecord.BlockGapY = ReadShort(stream, mphdRecord.LSB);
                    mphdRecord.BlockStaggerX = ReadShort(stream, mphdRecord.LSB);
                    mphdRecord.BlockStaggerY = ReadShort(stream, mphdRecord.LSB);

                    if (chunk.Length > 36)
                    {
                        mphdRecord.ClickMask = ReadShort(stream, mphdRecord.LSB);
                        mphdRecord.Pillars = ReadShort(stream, mphdRecord.LSB);
                    }
                }
            }

            return mphdRecord;
        }

        private void WriteChunkMPHD(Stream stream, Map map)
        {
            WriteSequence(stream, "MPHD");

            // write dummy length
            long chunkLengthPosition = stream.Position;
            WriteMsb(stream, (long)0);

            long chunkDataStart = stream.Position;

            // write version (1.0)
            Write(stream, (sbyte)1);
            Write(stream, (sbyte)0);

            // write LSB (true)
            Write(stream, (sbyte)1);

            // write map type (0)
            Write(stream, (sbyte)0);

            // write map dimensions
            short mapWidth = (short)map.Layers[0].LayerWidth;
            short mapHeight = (short)map.Layers[0].LayerHeight;
            WriteLsb(stream, mapWidth);
            WriteLsb(stream, mapHeight);

            // write 2 reserved shorts (0)
            WriteLsb(stream, (short)0);
            WriteLsb(stream, (short)0);

            // write tile dimensions
            short blockWidth = (short)map.TileSheets[0].TileWidth;
            short blockHeight = (short)map.TileSheets[0].TileHeight;
            WriteLsb(stream, blockWidth);
            WriteLsb(stream, blockHeight);

            // write blockdepth (forced to 32bpp)
            WriteLsb(stream, (short)32);

            // write block struct size (forced to 32 bytes)
            WriteLsb(stream, (short)32);

            // write num blocks and gfx blocks (= tile count)
            short blockCount = (short)map.TileSheets[0].TileCount;
            WriteLsb(stream, blockCount);
            WriteLsb(stream, blockCount);

            // do not write colour key indices/values, block gaps/staggers
            // and click mask, pillars

            long chunkDataEnd = stream.Position;
            long chunkLength = chunkDataEnd - chunkDataStart;

            // update chunk length
            stream.Position = chunkLengthPosition;
            WriteMsb(stream, chunkLength);

            // restore stream to end of chunk
            stream.Position = chunkDataEnd;
        }

        private Color[] ReadChunkCMAP(Stream stream, Chunk chunk)
        {
            stream.Position = chunk.FilePosition;
            int colourCount = chunk.Length / 3;
            Color[] colourMap = new Color[colourCount];
            for (int index = 0; index < colourCount; index++)
            {
                byte red = ReadUnsignedByte(stream);
                byte green = ReadUnsignedByte(stream);
                byte blue = ReadUnsignedByte(stream);
                Color colour = Color.FromArgb(red, green, blue);
                colourMap[index] = colour;
            }

            return colourMap;
        }

        private BlockRecord[] ReadChunkBKDT(Stream stream, Chunk chunk, MphdRecord mphdRecord)
        {
            BlockRecord[] blockRecords = new BlockRecord[mphdRecord.NumBlockStruct];
            bool lsb = mphdRecord.LSB;
            for(int index = 0; index < mphdRecord.NumBlockStruct; index++)
            {
                stream.Position = chunk.FilePosition + mphdRecord.BlockStructSize * index;

                BlockRecord blockRecord = new BlockRecord();
                blockRecord.BackgroundOffset = ReadSignedLong(stream, lsb);
                blockRecord.ForegroundOffset = ReadSignedLong(stream, lsb);
                blockRecord.BackgroundOffset2 = ReadSignedLong(stream, lsb);
                blockRecord.ForegroundOffset2 = ReadSignedLong(stream, lsb);
                blockRecord.User1 = ReadUnsignedLong(stream, lsb);
                blockRecord.User2 = ReadUnsignedLong(stream, lsb);
                blockRecord.User3 = ReadUnsignedShort(stream, lsb);
                blockRecord.User4 = ReadUnsignedShort(stream, lsb);
                blockRecord.User5 = ReadUnsignedByte(stream);
                blockRecord.User6 = ReadUnsignedByte(stream);
                blockRecord.User7 = ReadUnsignedByte(stream);
                blockRecord.Flags = ReadUnsignedByte(stream);
                blockRecords[index] = blockRecord;
            }

            return blockRecords;
        }

        private void WriteChunkBKDT(Stream stream, Map map)
        {
            short blockCount = (short) map.TileSheets[0].TileCount;

            WriteSequence(stream, "BKDT");
            // block records asumed 32 bytes
            WriteMsb(stream, blockCount * 32);

            // block size assumes 32bpp
            xTile.Dimensions.Size blockSize = map.TileSheets[0].TileSize;
            int blockByteSize = blockSize.Width * blockSize.Height * 4;

            for (int index = 0; index < blockCount; index++)
            {
                // bg, f2, bg2, fg2 offsets
                WriteLsb(stream, (long) (index * blockByteSize));
                WriteLsb(stream, (long) 0);
                WriteLsb(stream, (long) 0);
                WriteLsb(stream, (long) 0);

                // user1, user2 ulongs
                WriteLsb(stream, (ulong)0);
                WriteLsb(stream, (ulong)0);

                // user3, user4 ushorts
                WriteLsb(stream, (ushort)0);
                WriteLsb(stream, (ushort)0);

                // user5 - user7, flags unsigned bytes
                Write(stream, (byte)0);
                Write(stream, (byte)0);
                Write(stream, (byte)0);
                Write(stream, (byte)0);
            }
        }

        private AnimationRecord[] ReadChunkANDT(Stream stream, Chunk chunk, MphdRecord mphdRecord)
        {
            bool lsb = mphdRecord.LSB;

            // count structures backwards
            stream.Position = chunk.FilePosition + chunk.Length - AnimationRecord.SIZE;
            int animationCount = 0;
            while (ReadSignedByte(stream) != -1)
            {
                ++animationCount;
                stream.Position -= (AnimationRecord.SIZE + 1);
            }

            AnimationRecord[] animationRecords = new AnimationRecord[animationCount];

            stream.Position = chunk.FilePosition + chunk.Length - AnimationRecord.SIZE;
            int animationIndex = 0;
            while (true)
            {
                long recordPosition = stream.Position;
                AnimationRecord animationRecord = new AnimationRecord();

                animationRecord.Type = ReadSignedByte(stream);
                if (animationRecord.Type == -1)
                    break;

                animationRecord.Delay = ReadSignedByte(stream);
                animationRecord.Counter = ReadSignedByte(stream);
                animationRecord.UserInfo = ReadSignedByte(stream);
                animationRecord.CurrentOffset = ReadSignedLong(stream, lsb);
                animationRecord.StartOffset = ReadSignedLong(stream, lsb);
                animationRecord.EndOffset = ReadSignedLong(stream, lsb);

                // offsets are negative offsets into a list of frame indices (32bit) at the beginning of the chunk
                int frameCount = (int)((animationRecord.EndOffset - animationRecord.StartOffset) / 4);

                // move (backwards) to frame indices at beginning of chunk
                animationRecord.Frames = new int[frameCount];
                //stream.Position += animationRecord.StartOffset;
                stream.Position = chunk.FilePosition + chunk.Length + animationRecord.StartOffset;
                for (int frameIndex = 0; frameIndex < frameCount; frameIndex++)
                {
                    animationRecord.Frames[frameIndex] = (int)ReadSignedLong(stream, lsb);
                    if (mphdRecord.VersionHigh < 1)
                         animationRecord.Frames[frameIndex] /= mphdRecord.BlockStructSize;
                }

                animationRecords[animationIndex++] = animationRecord;

                stream.Position = recordPosition - AnimationRecord.SIZE;
            }

            stream.Position = chunk.FilePosition + chunk.Length;

            return animationRecords;
        }

        private bool AnimationsMatch(AnimatedTile animatedTile1, AnimatedTile animatedTile2)
        {
            if (animatedTile1.FrameInterval != animatedTile2.FrameInterval)
                return false;
            if (animatedTile1.TileFrames.Length != animatedTile2.TileFrames.Length)
                return false;

            for (int index = 0; index < animatedTile1.TileFrames.Length; index++)
            {
                StaticTile tileFrame1 = animatedTile1.TileFrames[index];
                StaticTile tileFrame2 = animatedTile2.TileFrames[index];
                if (tileFrame1.TileSheet != tileFrame2.TileSheet)
                    return false;
                if (tileFrame1.TileIndex != tileFrame2.TileIndex)
                    return false;
            }

            return true;
        }

        private AnimatedTile[] WriteChunkANDT(Stream stream, Map map)
        {
            // build list of unique animations
            List<AnimatedTile> animatedTiles = new List<AnimatedTile>();
            foreach (Layer layer in map.Layers)
            {
                for (int tileY = 0; tileY < layer.LayerHeight; tileY++)
                {
                    for (int tileX = 0; tileX < layer.LayerWidth; tileX++)
                    {
                        Tile tile = layer.Tiles[tileX, tileY];
                        if (tile == null || !(tile is AnimatedTile))
                            continue;
                        AnimatedTile newAnimatedTile = (AnimatedTile)tile;

                        bool matches = false;
                        foreach (AnimatedTile animatedTile in animatedTiles)
                            if (AnimationsMatch(animatedTile, newAnimatedTile))
                            {
                                matches = true;
                                break;
                            }
                        if (!matches)
                            animatedTiles.Add(newAnimatedTile);
                    }
                }
            }

            // if there are no animations, do not write ANDT chunk at all
            if (animatedTiles.Count == 0)
                return null;

            // determine offsets length
            int offsetsLength = 0;
            foreach (AnimatedTile animatedTile in animatedTiles)
                offsetsLength += (animatedTile.TileFrames.Length + 1) * 4; // +1 is for anim ref tile

            // chunk length is space for offsets + termination ani record + all ani records
            int chunkLength = offsetsLength + (animatedTiles.Count + 1) * AnimationRecord.SIZE;

            // write chunk header
            WriteSequence(stream, "ANDT");
            WriteMsb(stream, (long)chunkLength);

            long chunkStart = stream.Position;

            // write animation offsets
            List<long> animationPositions = new List<long>();
            foreach (AnimatedTile animatedTile in animatedTiles)
            {
                // animation ref tile
                WriteLsb(stream, (long)(animatedTile.TileFrames[0].TileIndex * 32));

                // keep track of stream pos to compute anim offsets
                animationPositions.Add(stream.Position - chunkStart);

                // animation indices * block struct size
                foreach (StaticTile tileFrame in animatedTile.TileFrames)
                    WriteLsb(stream, (long) (tileFrame.TileIndex * 32));
            }

            // write termination animation record
            Write(stream, (sbyte)-1);    // type = end of animations
            Write(stream, (sbyte)0);     // delay
            Write(stream, (sbyte)0);     // counter
            Write(stream, (sbyte)0);     // user info
            WriteLsb(stream, (long)0);   // current offset
            WriteLsb(stream, (long)0);   // start offset
            WriteLsb(stream, (long)0);   // end offset

            // write animation records
            for (int index = 0; index < animatedTiles.Count; index++)
            {
                AnimatedTile animatedTile = animatedTiles[index];
                long animationPosition = animationPositions[index];

                sbyte delay = (sbyte)(animatedTile.FrameInterval / 20);
                long animationOffsetStart = animationPosition - chunkLength;
                long animationOffsetend = animationOffsetStart + animatedTile.TileFrames.Length * 4;

                Write(stream, (byte)1);                   // type = LOOPF
                Write(stream, delay);                     // delay
                Write(stream, (sbyte)0);                  // counter
                Write(stream, (sbyte)0);                  // user info
                WriteLsb(stream, animationOffsetStart);   // current offset
                WriteLsb(stream, animationOffsetStart);   // start offset
                WriteLsb(stream, animationOffsetend);     // end offset
            }

            return animatedTiles.ToArray();
        }

        private Image ReadChunkBGFX(Stream stream, Chunk chunk, MphdRecord mphdRecord, Color[] colourMap)
        {
            int tileCount = mphdRecord.NumBlockStruct;
            int imageWidth = mphdRecord.BlockWidth;
            int imageHeight = mphdRecord.BlockHeight * tileCount;

            byte[] imageData = new byte[chunk.Length];
            stream.Position = chunk.FilePosition;
            stream.Read(imageData, 0, chunk.Length);

            bool applyColourKeying = false;
            if (mphdRecord.BlockDepth < 32)
            {
                applyColourKeying = MessageBox.Show(
                    "Apply colour keying?", "Mappy BGFX Chunk",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            }

            Bitmap imageSource = new Bitmap(imageWidth, imageHeight, PixelFormat.Format32bppArgb);
            int pixelIndex = 0;
            if (mphdRecord.BlockDepth == 8)
            {
                for (int pixelY = 0; pixelY < imageHeight; pixelY++)
                {
                    for (int pixelX = 0; pixelX < imageWidth; pixelX++)
                    {
                        byte colourIndex = imageData[pixelIndex++];
                        if (!applyColourKeying || colourIndex != mphdRecord.ColourKeyIndex)
                            imageSource.SetPixel(pixelX, pixelY, colourMap[colourIndex]);
                    }
                }
            }
            else if (mphdRecord.BlockDepth == 15)
            {
                for (int pixelY = 0; pixelY < imageHeight; pixelY++)
                {
                    for (int pixelX = 0; pixelX < imageWidth; pixelX++)
                    {
                        ushort colourValue = (ushort)(imageData[pixelIndex++] | (imageData[pixelIndex++] << 8));
                        byte alpha = 255;
                        byte red = (byte)(colourValue & 31);
                        byte green = (byte)((colourValue >> 5) & 31);
                        byte blue = (byte)((colourValue >> 10) & 31);
                        red *= 4;
                        green *= 4;
                        blue *= 4;
                        if (applyColourKeying
                            && red == mphdRecord.ColourKeyRed
                            && green == mphdRecord.ColourKeyGreen
                            && blue == mphdRecord.ColourKeyBlue)
                            alpha = 0;
                        Color colour = Color.FromArgb(alpha, red, green, blue);
                        imageSource.SetPixel(pixelX, pixelY, colour);
                    }
                }
            }
            else if (mphdRecord.BlockDepth == 16)
            {
                for (int pixelY = 0; pixelY < imageHeight; pixelY++)
                {
                    for (int pixelX = 0; pixelX < imageWidth; pixelX++)
                    {
                        ushort colourValue = (ushort)(imageData[pixelIndex++] | (imageData[pixelIndex++] << 8));
                        byte alpha = 255;
                        byte red = (byte)(colourValue & 31);
                        byte green = (byte)((colourValue >> 5) & 63);
                        byte blue = (byte)((colourValue >> 11) & 31);
                        red *= 8;
                        green *= 4;
                        blue *= 8;
                        if (applyColourKeying
                            && red == mphdRecord.ColourKeyRed
                            && green == mphdRecord.ColourKeyGreen
                            && blue == mphdRecord.ColourKeyBlue)
                            alpha = 0;
                        Color colour = Color.FromArgb(alpha, red, green, blue);
                        imageSource.SetPixel(pixelX, pixelY, colour);
                    }
                }
            }
            else if (mphdRecord.BlockDepth == 24)
            {
                for (int pixelY = 0; pixelY < imageHeight; pixelY++)
                {
                    for (int pixelX = 0; pixelX < imageWidth; pixelX++)
                    {
                        byte alpha = 255;
                        byte red   = imageData[pixelIndex++];
                        byte green = imageData[pixelIndex++];
                        byte blue  = imageData[pixelIndex++];
                        if (applyColourKeying
                            && red == mphdRecord.ColourKeyRed
                            && green == mphdRecord.ColourKeyGreen
                            && blue == mphdRecord.ColourKeyBlue)
                            alpha = 0;
                        Color colour = Color.FromArgb(alpha, red, green, blue);
                        imageSource.SetPixel(pixelX, pixelY, colour);
                    }
                }
            }
            else if (mphdRecord.BlockDepth == 32)
            {
                for (int pixelY = 0; pixelY < imageHeight; pixelY++)
                {
                    for (int pixelX = 0; pixelX < imageWidth; pixelX++)
                    {
                        byte alpha = imageData[pixelIndex++];
                        byte red = imageData[pixelIndex++];
                        byte green = imageData[pixelIndex++];
                        byte blue = imageData[pixelIndex++];
                        Color colour = Color.FromArgb(alpha, red, green, blue);
                        imageSource.SetPixel(pixelX, pixelY, colour);
                    }
                }
            }

            return imageSource;
        }

        private void WriteChunkBGFX(Stream stream, Map map)
        {
            TileImageCache tileImageCache = TileImageCache.Instance;
            TileSheet tileSheet = map.TileSheets[0];
            xTile.Dimensions.Size tileSize = tileSheet.TileSize;
            int tileCount = tileSheet.TileCount;
            Rectangle tileRectangle = new Rectangle(0, 0, tileSize.Width, tileSize.Height);

            // assume 32bpp
            int blockSizeBytes = tileSize.Area * 4;

            WriteSequence(stream, "BGFX");
            // assume 32bpp gfx
            WriteMsb(stream, (long)(blockSizeBytes * tileCount));

            for (int tileIndex = 0; tileIndex < tileCount; tileIndex++)
            {
                Bitmap tileBitmap = tileImageCache.GetTileBitmap(tileSheet, tileIndex);

                for (int pixelY = 0; pixelY < tileSize.Height; pixelY++)
                {
                    for (int pixelX = 0; pixelX < tileSize.Width; pixelX++)
                    {
                        Color color = tileBitmap.GetPixel(pixelX, pixelY);
                        Write(stream, color.A);
                        Write(stream, color.R);
                        Write(stream, color.G);
                        Write(stream, color.B);
                    }
                }                
            }
        }

        private short[] ReadChunkLayer(Stream stream, Chunk chunk, MphdRecord mphdRecord)
        {
            bool lsb = mphdRecord.LSB;
            short[] offsets = new short[chunk.Length / 2];
            stream.Position = chunk.FilePosition;
            for (int index = 0; index < offsets.Length; index++)
            {
                short offset = ReadShort(stream, lsb);
                if (mphdRecord.VersionHigh < 1)
                {
                    if (offset >= 0)
                        offset /= mphdRecord.BlockStructSize;
                    else
                        offset /= AnimationRecord.SIZE;
                }
                offsets[index] = offset;
            }
            return offsets;
        }

        private void WriteChunkLayer(Stream stream, Layer layer, string chunkId, AnimatedTile[] animatedTiles)
        {
            // BODY or LYR1 .. LYR7
            WriteSequence(stream, chunkId);

            // size is array of shorts
            int layerWidth = layer.LayerWidth;
            int layerHeight = layer.LayerHeight;
            WriteMsb(stream, (long)(layerWidth * layerHeight * 2));

            for (int tileY = 0; tileY < layerHeight; tileY++)
            {
                for (int tileX = 0; tileX < layerWidth; tileX++)
                {
                    Tile tile = layer.Tiles[tileX, tileY];
                    if (tile == null)
                        WriteLsb(stream, (short)0);
                    else if (tile is StaticTile)
                        WriteLsb(stream, (short)(tile.TileIndex * 32));
                    else if (tile is AnimatedTile)
                    {
                        if (animatedTiles == null)
                            WriteLsb(stream, (short)0);
                        else
                        {
                            AnimatedTile animatedTile = (AnimatedTile)tile;
                            int animationIndex = -1;
                            for (int listIndex = 0; listIndex < animatedTiles.Length; listIndex++)
                            {
                                if (AnimationsMatch(animatedTile, animatedTiles[listIndex]))
                                {
                                    animationIndex = listIndex;
                                    break;
                                }
                            }
                            if (animationIndex < 0)
                                WriteLsb(stream, (short)0);
                            else
                            {
                                short animationOffset = (short)((animationIndex - animatedTiles.Length) * AnimationRecord.SIZE);
                                WriteLsb(stream, animationOffset);
                            }
                        }
                    }
                    else
                        throw new Exception("Unknown tile type: " + tile.GetType());
                }
            }
        }

        #endregion

        #region Private Classes

        private struct Chunk
        {
            internal string Id;
            internal long FilePosition;
            internal int Length;
        }

        private class MphdRecord
        {
            internal sbyte VersionHigh;
            internal sbyte VersionLow;
            internal bool LSB;
            internal sbyte MapType;
            internal short MapWidth;
            internal short MapHeight;
            internal short Reserved1;
            internal short Reserved2;
            internal short BlockWidth;
            internal short BlockHeight;
            internal short BlockDepth;
            internal short BlockStructSize;
            internal short NumBlockStruct;
            internal short NumBlockGfx;
            internal byte ColourKeyIndex;
            internal byte ColourKeyRed;
            internal byte ColourKeyGreen;
            internal byte ColourKeyBlue;
            internal short BlockGapX;
            internal short BlockGapY;
            internal short BlockStaggerX;
            internal short BlockStaggerY;
            internal short ClickMask;
            internal short Pillars;
        }

        private class BlockRecord
        {
            internal long BackgroundOffset, ForegroundOffset;
            internal long BackgroundOffset2, ForegroundOffset2;
            internal ulong User1, User2;
            internal ushort User3, User4;
            internal byte User5, User6, User7;
            internal byte Flags;
        }

        private class AnimationRecord
        {
            internal const int SIZE = 16;
            internal sbyte Type;
            internal sbyte Delay;
            internal sbyte Counter;
            internal sbyte UserInfo;
            internal long  CurrentOffset;
            internal long  StartOffset;
            internal long  EndOffset;
            internal int[] Frames;
        }

        #endregion
    }
}
