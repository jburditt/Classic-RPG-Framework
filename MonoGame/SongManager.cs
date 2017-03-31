using Common;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Player;
using System.Collections.Generic;
using System.IO;

namespace MonoGame
{
    public class SongManager : ISongManager
    {
        private Dictionary<string, Song> Songs { get; set; } = new Dictionary<string, Song>();

        public SongManager(ContentManager Content)
        {
            var filepaths = FileManager.GetFilepaths("../../../Content/song");

            foreach (var filepath in filepaths)
            {
                var filename = Path.GetFileNameWithoutExtension(filepath);
                Songs.Add(filename, Content.Load<Song>("song\\" + filename));
            }

            MediaPlayer.IsRepeating = true;
        }

        public void Play(string songname)
        {
            MediaPlayer.Play(Songs[songname]);
        }

        public void Stop()
        {
            MediaPlayer.Stop();
        }
    }
}