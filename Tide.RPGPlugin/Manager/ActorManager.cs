using System;
using Player;
using Player.Manager;
using System.Drawing;
using System.Collections.Generic;
using Common;
using System.IO;

namespace RPGPlugin.Manager
{
    public class ActorManager : IActorManager
    {
        public Graphics Graphics { get; set; }
        public Dictionary<string, Bitmap> Actors = new Dictionary<string, Bitmap>();

        public ActorManager(string folderPath)
        {
            var files = FileManager.GetFilepaths(folderPath);

            foreach (var filePath in files) {
                var filename = Path.GetFileNameWithoutExtension(filePath);
                var bitmap = (Bitmap)Image.FromFile(filePath);
                //var pixelColor = bitmap.GetPixel(0, 0);
                //return pixelColor.ToStruct();
                bitmap.MakeTransparent();
                Actors.Add(filename, bitmap);
            }
        }

        public void Draw(string actorName, Rect sourceRect, Rect targetRect, ColorStruct? color = default(ColorStruct?))
        {
            Graphics.DrawImage(Actors[actorName], targetRect.ToRectangle(), sourceRect.ToRectangle(), GraphicsUnit.Pixel);
        }

        public void DrawBattle(string actorName, Rect sourceRect, Rect targetRect, ColorStruct? color = default(ColorStruct?))
        {
            throw new NotImplementedException();
        }
    }
}