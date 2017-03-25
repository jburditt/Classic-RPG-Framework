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
            var filepaths = FileManager.GetFilepaths("../../../Data");

            using (var fileStream = File.Create("Content.mgcb"))
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
                    if (filepath.IsImage())
                    {
                        var color = GetTransparentColor(filepath);
                        var filename = filepath.Substring(14);

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
