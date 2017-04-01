using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Player;
using Player.Graphics;

namespace MonoGame.Manager
{
    public class DialogManager : IDialogManager
    {
        private readonly SpriteBatch _spriteBatch;
        private readonly Texture2D dialog;

        public DialogManager(ContentManager Content, SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;

            dialog = Content.Load<Texture2D>("dialog");
        }

        public void Draw(Rect targetRect, int index = 0)
        {
            new Dialog(this).Draw(targetRect, index);
        }

        public void Draw(Rect sourceRect, Rect targetRect, ColorStruct? color)
        {
            _spriteBatch.Draw(dialog, sourceRect.ToRectangle(), targetRect.ToRectangle(), color.ToColor());
        }

        public void DrawMessage(NPC n, int index = 0)
        {
            var targetRect = new Rect(0, 300, 640, 180);

            new Dialog(this).Draw(targetRect, index);
        }
    }
}
