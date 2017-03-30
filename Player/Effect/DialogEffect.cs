using Player.Graphics;

namespace Player.Effect
{
    public class DialogEffect : IEffect
    {
        private IGraphics _graphics;
        private IDialog _dialog;

        public int X { get; set; }
        public int Y { get; set; }
        public int Lifespan { get; set; } = 100;

        private string Text;

        public DialogEffect(IGraphics graphics, IDialog dialog, string text)
        {
            _graphics = graphics;
            _dialog = dialog;
            Text = text;
        }

        public void Draw()
        {
            _dialog.Draw(new Rect(0, 0, 640, 45));
            _graphics.DrawString(Text, 50, 15);
        }

        public void Update()
        {
            Lifespan--;
        }
    }
}