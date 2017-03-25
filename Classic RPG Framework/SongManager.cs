using Common;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System.IO;

namespace Player
{
    public class SongManager
    {
        private Dictionary<string, Song> Songs { get; set; }

        public SongManager(ContentManager Content)
        {
            var filepaths = FileManager.GetFilepaths("../../../Content/song");

            foreach (var filepath in filepaths)
            {
                var filename = Path.GetFileNameWithoutExtension(filepath);
                Songs.Add(filename, Content.Load<Song>("song\\" + filename));
            }
        }
    }
}