using Common;
using Player;
using System.Drawing;
using System.IO;
using System.Text;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
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
                        var color = GetTransparentColor(filepath);

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
            var myBitmap = new Bitmap(imagePath);
            var pixelColor = myBitmap.GetPixel(0, 0);

            return pixelColor.ToStruct();
        }
    }
}
