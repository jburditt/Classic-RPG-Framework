using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Player;

namespace MonoGame.Effect
{
    public class DialogEffect : IEffect
    {
        private Graphics _graphics;
        private Dialog Dialog;
        private SpriteFont Font;

        public int X { get; set; }
        public int Y { get; set; }
        public int Lifespan { get; set; } = 100;

        private string Text;

        public DialogEffect(Graphics graphics, Dialog dialog, SpriteFont font, string text)
        {
            _graphics = graphics;
            Dialog = dialog;
            Font = font;
            Text = text;
        }

        public void Draw()
        {
            Dialog.Draw(new Rectangle(0, 0, 640, 45));
            _graphics.DrawString(Text, 50, 15);
        }

        public void Update()
        {
            Lifespan--;
        }
    }
}
