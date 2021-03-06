﻿using System;
using Common;
using Player;
using System.Drawing;
using System.IO;
using System.Text;
using TiledSharp;
using Player.Maps;
using xTile;

namespace Console
{
    class Program
    {
        private static SerializableDictionary<string, TileSheetMeta> TilesetMetas = new SerializableDictionary<string, TileSheetMeta>();

        static void Main(string[] args)
        {
            //LoadTilesetMeta("../../../Data/map/Start.tmx");
            LoadTideTilesetMeta("../../../Data/Game/map/World.tide");

            var filepaths = FileManager.GetFilepaths("../../../MonoGame/Content");

            using (var fileStream = File.Create("../../../MonoGame/Content/Content.mgcb"))
            {
                var info = new UTF8Encoding(true).GetBytes(@"
#----------------------------- Global Properties ----------------------------#

/outputDir:bin/WindowsGL
/intermediateDir:obj/WindowsGL
/platform:WindowsGL
/config:
/profile:Reach
/compress:False

#-------------------------------- References --------------------------------#


#---------------------------------- Content ---------------------------------#");

                fileStream.Write(info, 0, info.Length);

                foreach (var filepath in filepaths)
                {
                    var filename = filepath.Substring(26);

                    // write images
                    if (filepath.IsImage())
                    {
                        ColorStruct color;
                        if (string.Compare(filename.Right(3), "TGA", StringComparison.OrdinalIgnoreCase) == 0)
                            color = new ColorStruct(255, 255, 255, 255);
                        else
                            color = GetTransparentColor(filepath);

                        info = new UTF8Encoding(true).GetBytes($@"

#begin {filename}
/importer:TextureImporter
/processor:TextureProcessor
/processorParam:ColorKeyColor={color.ToString()}
/processorParam:ColorKeyEnabled=True
/processorParam:GenerateMipmaps=False
/processorParam:PremultiplyAlpha=True
/processorParam:ResizeToPowerOfTwo=False
/processorParam:TextureFormat=Color
/build:{filename}");

                        fileStream.Write(info, 0, info.Length);
                    } else if (filepath.IsSong())
                    {
                        info = new UTF8Encoding(true).GetBytes($@"

#begin {filename}
/importer:Mp3Importer
/processor:SongProcessor
/processorParam:Quality=Best
/build:{filename}");

                        fileStream.Write(info, 0, info.Length);
                    } else if (filepath.IsFont()) {
                        info = new UTF8Encoding(true).GetBytes($@"

#begin {filename}
/importer:FontDescriptionImporter
/processor:FontDescriptionProcessor
/processorParam:TextureFormat=Compressed
/build:{filename}");

                        fileStream.Write(info, 0, info.Length);
                    }
                }
            }
        }

        private static ColorStruct GetTransparentColor(string imagePath)
        {
            // load transparency color from saved meta (loaded from Tiled map)
            if (imagePath.Contains("tileset"))
            {
                var tilesetName = imagePath.Substring(imagePath.IndexOf("tileset\\") + 8);
                tilesetName = tilesetName.Left(tilesetName.Length - 4);
                if (TilesetMetas.ContainsKey(tilesetName))
                    return TilesetMetas[tilesetName].TransparencyColor;
            }

            // use the pixel at top left for transparency
            var myBitmap = new Bitmap(imagePath);
            var pixelColor = myBitmap.GetPixel(0, 0);

            return pixelColor.ToStruct();
        }

        // TODO Move to TileReader or something
        private static void LoadTiledTilesetMeta(string mapFilePath)
        {
            var tiledMap = new TmxMap(mapFilePath);
            foreach (var tileset in tiledMap.Tilesets) {
                var trans = tileset.Image.Trans;
                TilesetMetas.Add(tileset.Name, new TileSheetMeta { TransparencyColor = new ColorStruct(trans.R, trans.G, trans.B) });
            }
        }

        private static void LoadTideTilesetMeta(string mapFilePath)
        {
            var tiledMap = MapLoader.LoadMap(mapFilePath);

            foreach (var tileset in tiledMap.TileSheets)
            {
                // TODO
                //var bitmap = (Bitmap)Image.FromFile(tileset.ImageSource);
                //bitmap.MakeTransparent();

                var trans = Color.White;
                TilesetMetas.Add(tileset.Id, new TileSheetMeta { TransparencyColor = new ColorStruct(trans.R, trans.G, trans.B) });
            }
        }
    }
}
