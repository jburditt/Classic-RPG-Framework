using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Player;

namespace MonoGame.Effect
{
    public class DialogEffect : IEffect
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Lifespan { get; set; } = 100;

        private SpriteBatch SpriteBatch;
        private Dialog Dialog;
        private SpriteFont Font;
        private string Text;

        public DialogEffect(SpriteBatch spriteBatch, Dialog dialog, SpriteFont font, string text)
        {
            SpriteBatch = spriteBatch;
            Dialog = dialog;
            Font = font;
            Text = text;
        }

        public void Draw()
        {
            Dialog.Draw(new Rectangle(0, 0, 640, 45));
            SpriteBatch.DrawString(Font, Text, 50, 15);
        }

        public void Update()
        {
            Lifespan--;
        }
    }
}
