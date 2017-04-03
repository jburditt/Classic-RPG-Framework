using Common;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;

namespace MonoGame.Manager
{
    public class ManagerHelper
    {
        public static Dictionary<string, T> LoadFolder<T>(string folder, ContentManager contentManager)
        {
            var textures = new Dictionary<string, T>();
            var filepaths = FileManager.GetFilepaths($"../../../Content/{folder}");

            foreach (var filepath in filepaths)
            {
                var filename = Path.GetFileNameWithoutExtension(filepath);
                textures.Add(filename, contentManager.Load<T>($"{folder}\\" + filename));
            }

            return textures;
        }
    }
}