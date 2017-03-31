using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace MonoGame
{
    public class SoundManager
    {
        public Dictionary<string, SoundEffect> Sounds = new Dictionary<string, SoundEffect>();

        public SoundManager(ContentManager Content)
        {
            //song = Content.Load<Song>("I3-Epic-Brave Heart");
            //MediaPlayer.Play(song);
            //MediaPlayer.IsRepeating = true;
            //MediaPlayer.Volume = 0.2f;
        }
    }
}