using Player.Graphics;
using System;

namespace Player.Effect
{
    public class HpEffect : IEffect
    {
        private IGraphics _graphics;

        public int X { get; set; }
        public int Y { get; set; }
        public int Lifespan { get; set; } = 100;

        private string Text;

        public HpEffect(IGraphics graphics, string text, int x, int y)
        {
            _graphics = graphics;

            X = x;
            Y = y;
            Text = text;
        }

        public void Draw()
        {
            _graphics.DrawString(Text, X, Y);
        }

        public void Update()
        {
            Lifespan--;
            if (Y > 1)
                Y--;
        }


    }
}
