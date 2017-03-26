using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace Player
{
    public class Audio
    {
        Song song;

        public Audio(ContentManager Content)
        {
            song = Content.Load<Song>("I3-Epic-Brave Heart");
            //MediaPlayer.Play(song);
            //MediaPlayer.IsRepeating = true;
            //MediaPlayer.Volume = 0.2f;
        }
    }
}