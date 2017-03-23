using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Player
{
    public class Dialog
    {
        Texture2D dialog;
        int width = 318;
        int height = 84;
        int chipsize = 13; // 13 - 40

        public Dialog(ContentManager Content)
        {
            dialog = Content.Load<Texture2D>("dialog");
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle targetRect, int index)
        {
            int x = 0, y = 7;
            var topleft = new Rectangle(x, y, chipsize, chipsize);
            var top = new Rectangle(x + chipsize, y, chipsize, chipsize);
            var topright = new Rectangle(x + width - chipsize, y, chipsize, chipsize);
            
            spriteBatch.Draw(dialog, new Rectangle(targetRect.X, targetRect.Y, chipsize, chipsize), topleft, Color.White * 0.5f);
            for (var i = 1; i < targetRect.Width / chipsize - 1; i++)
                spriteBatch.Draw(dialog, new Rectangle(targetRect.X + i * chipsize, targetRect.Y, chipsize, chipsize), top, Color.White * 0.5f);
            spriteBatch.Draw(dialog, new Rectangle(targetRect.X + targetRect.Width - chipsize, targetRect.Y, chipsize, chipsize), topright, Color.White * 0.5f);

            topleft.Y += chipsize;
            top.Y += chipsize;
            topright.Y += chipsize;

            for (var j = 1; j < targetRect.Height / chipsize - 1; j++)
            {
                spriteBatch.Draw(dialog, new Rectangle(targetRect.X, targetRect.Y + j*chipsize, chipsize, chipsize), topleft, Color.White * 0.5f);
                for (var i = 1; i < targetRect.Width / chipsize - 1; i++)
                    spriteBatch.Draw(dialog, new Rectangle(targetRect.X + i * chipsize, targetRect.Y + j*chipsize, chipsize, chipsize), top, Color.White * 0.5f);
                spriteBatch.Draw(dialog, new Rectangle(targetRect.X + targetRect.Width - chipsize, targetRect.Y + j*chipsize, chipsize, chipsize), topright, Color.White * 0.5f);
            }

            topleft.Y = height - chipsize;
            top.Y = height - chipsize;
            topright.Y = height - chipsize;

            spriteBatch.Draw(dialog, new Rectangle(targetRect.X, targetRect.Y + targetRect.Height - chipsize, chipsize, chipsize), topleft, Color.White * 0.5f);
            for (var i = 1; i < targetRect.Width / chipsize - 1; i++)
                spriteBatch.Draw(dialog, new Rectangle(targetRect.X + i * chipsize, targetRect.Y + targetRect.Height - chipsize, chipsize, chipsize), top, Color.White * 0.5f);
            spriteBatch.Draw(dialog, new Rectangle(targetRect.X + targetRect.Width - chipsize, targetRect.Y + targetRect.Height - chipsize, chipsize, chipsize), topright, Color.White * 0.5f);
        }
    }
}