using Player.Graphics;
using Player.Inputs;

namespace Player.StateStack
{
    public class MenuState : IState
    {
        private IGraphics _graphics;
        private IDialogManager _dialogManager;
        private IInputManager _inputManager;
        private ISongManager _songManager;

        private MenuItem _menuItem = MenuItem.NewGame;

        public MenuState(IGraphics graphics, IDialogManager dialogManager, IInputManager inputManager, ISongManager songManager)
        {
            _dialogManager = dialogManager;
            _graphics = graphics;
            _inputManager = inputManager;
            _songManager = songManager;
        }

        public void OnLoad() {
            _songManager.Play("Losing Your Way");
        }

        public void OnClose() { }

        public bool Update(float elapsedTime)
        {
            if (_inputManager.JustPressedKey((int)Keys.Up))
            {
                _menuItem--;
                if (_menuItem < MenuItem.NewGame)
                    _menuItem = MenuItem.Exit;
            }
            if (_inputManager.JustPressedKey((int)Keys.Down))
            {
                _menuItem++;
                if (_menuItem > MenuItem.Exit)
                    _menuItem = MenuItem.NewGame;
            }
            if (_inputManager.IsPressedKey((int)Keys.Enter))
            {
                return false;
            }

            return true;
        }

        public void Draw()
        {
            _graphics.DrawSprite("menubg", new Rect(0, 0, Screen.Width, Screen.Height), new Rect(200, 200, Screen.Width + 200, Screen.Height + 200));
            _dialogManager.Draw(new Rect(160, 200, 130, 120));
            _graphics.DrawString("New Game", 180, 220);
            _graphics.DrawString("Load Game", 180, 240);
            _graphics.DrawString("Exit", 180, 260);
            _graphics.DrawSprite("cursor", 160, 223 + (int)_menuItem * 20);
        }
    }
}