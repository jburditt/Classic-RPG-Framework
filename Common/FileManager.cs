using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Common
{
    public static class FileManager
    {
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG", ".TGA" };
        public static readonly List<string> SongExtensions = new List<string> { ".MP3", ".OGG", ".WAV", ".MID", ".MIDI" };
        public static readonly List<string> FontExtensions = new List<string> { ".FONT", ".SPRITEFONT" };

        public static List<string> GetFilepaths(string targetDirectory, bool includeSubFolders = true)
        {
            var filepaths = new List<string>();

            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);

            foreach (string fileName in fileEntries)
                filepaths.Add(fileName);

            // Recurse into subdirectories of this directory.
            if (includeSubFolders)
            {
                string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);

                foreach (string subdirectory in subdirectoryEntries)
                    filepaths.AddRange(GetFilepaths(subdirectory));
            }

            return filepaths;
        }

        public static List<Asset> ToFileList(this List<string> filePaths)
        {
            return filePaths.Select(n => new Asset { Name = n.Substring(n.LastIndexOf("\\") + 1), FilePath = n }).ToList();
        }

        public static bool IsImage(this string filepath)
        {
            return ImageExtensions.Contains(Path.GetExtension(filepath).ToUpperInvariant());
        }

        public static bool IsSong(this string filepath)
        {
            return SongExtensions.Contains(Path.GetExtension(filepath).ToUpperInvariant());
        }

        public static bool IsFont(this string filepath)
        {
            return FontExtensions.Contains(Path.GetExtension(filepath).ToUpperInvariant());
        }
    }

    public class Asset
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
    }
}