using Common;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Player;
using System.Collections.Generic;
using System.IO;

namespace MonoGame.Manager
{
    public class SongManager : ISongManager
    {
        private Dictionary<string, Song> Songs { get; set; } = new Dictionary<string, Song>();

        public SongManager(ContentManager contentManager)
        {
            Songs = ManagerHelper.LoadFolder<Song>("song", contentManager);

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