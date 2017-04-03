using Common;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Player;
using Player.Manager;
using System.Collections.Generic;
using System.IO;

namespace MonoGame.Manager
{
    public class IconManager : IIconManager
    {
        private readonly SpriteBatch _spriteBatch;

        public Dictionary<string, Texture2D> Icons = new Dictionary<string, Texture2D>();

        public IconManager(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;

            Icons = ManagerHelper.LoadFolder<Texture2D>("icon", contentManager);
        }

        public void Draw(string iconName, Vector vector, ColorStruct? color = null)
        {
            _spriteBatch.DrawTexture(Icons[iconName], vector, color.ToColor());
        }

        public void Draw(string iconName, Rect sourceRect, Rect targetRect, ColorStruct? color = null)
        {
            _spriteBatch.Draw(Icons[iconName], targetRect.ToRectangle(), sourceRect.ToRectangle(), color.ToColor());
        }
    }
}