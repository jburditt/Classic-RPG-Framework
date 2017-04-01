using Player;
using Player.Graphics;

namespace Player
{
    public class Dialog
    {
        private readonly IDialogManager _dialogManager;

        int width = 318;
        int height = 86;
        int chipsize = 15; // 13 - 40

        public Dialog(IDialogManager dialogManager)
        {
            _dialogManager = dialogManager;
        }

        public void Draw(Rect targetRect, int index = 0)
        {
            int x = 0, y = 7;
            var topleft = new Rect(x, y, chipsize, chipsize);
            var top = new Rect(x + chipsize, y, chipsize, chipsize);
            var topright = new Rect(x + width - chipsize, y, chipsize, chipsize);
            var mod = new Rect(x + chipsize, y, targetRect.Width%chipsize, chipsize);

            _dialogManager.Draw(new Rect(targetRect.X, targetRect.Y, chipsize, chipsize), topleft, ColorStruct.White * 0.5f);
            for (var i = 1; i < targetRect.Width / chipsize - 1; i++)
                _dialogManager.Draw(new Rect(targetRect.X + i * chipsize, targetRect.Y, chipsize, chipsize), top, ColorStruct.White * 0.5f);
            if (targetRect.Width % chipsize != 0)
                _dialogManager.Draw(new Rect(targetRect.X + targetRect.Width - chipsize - targetRect.Width % chipsize, targetRect.Y, targetRect.Width % chipsize, chipsize), mod, ColorStruct.White * 0.5f);
            _dialogManager.Draw(new Rect(targetRect.X + targetRect.Width - chipsize, targetRect.Y, chipsize, chipsize), topright, ColorStruct.White * 0.5f);

            topleft.Y += chipsize;
            top.Y += chipsize;
            topright.Y += chipsize;
            mod.Y += chipsize;

            for (var j = 1; j < targetRect.Height / chipsize - 1; j++)
            {
                _dialogManager.Draw(new Rect(targetRect.X, targetRect.Y + j*chipsize, chipsize, chipsize), topleft, ColorStruct.White * 0.5f);
                for (var i = 1; i < targetRect.Width / chipsize - 1; i++)
                    _dialogManager.Draw(new Rect(targetRect.X + i * chipsize, targetRect.Y + j*chipsize, chipsize, chipsize), top, ColorStruct.White * 0.5f);
                _dialogManager.Draw(new Rect(targetRect.X + targetRect.Width - chipsize, targetRect.Y + j*chipsize, chipsize, chipsize), topright, ColorStruct.White * 0.5f);
                if (targetRect.Width % chipsize != 0)
                    _dialogManager.Draw(new Rect(targetRect.X + targetRect.Width - chipsize - targetRect.Width % chipsize, targetRect.Y + j * chipsize, targetRect.Width % chipsize, chipsize), mod, ColorStruct.White * 0.5f);
            }

            topleft.Y = height - chipsize;
            top.Y = height - chipsize;
            topright.Y = height - chipsize;
            mod.Y = height - chipsize;

            _dialogManager.Draw(new Rect(targetRect.X, targetRect.Y + targetRect.Height - chipsize, chipsize, chipsize), topleft, ColorStruct.White * 0.5f);
            for (var i = 1; i < targetRect.Width / chipsize - 1; i++) {
                _dialogManager.Draw(new Rect(targetRect.X + i * chipsize, targetRect.Y + targetRect.Height - chipsize, chipsize, chipsize), top, ColorStruct.White * 0.5f);
            }
            if (targetRect.Width % chipsize != 0)
                _dialogManager.Draw(new Rect(targetRect.X + targetRect.Width - chipsize - targetRect.Width % chipsize, targetRect.Y + targetRect.Height - chipsize, targetRect.Width % chipsize, chipsize), mod, ColorStruct.White * 0.5f);
            _dialogManager.Draw(new Rect(targetRect.X + targetRect.Width - chipsize, targetRect.Y + targetRect.Height - chipsize, chipsize, chipsize), topright, ColorStruct.White * 0.5f);
        }
    }
}