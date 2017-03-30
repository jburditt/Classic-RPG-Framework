using Player.Inputs;
using Player.Manager;

namespace Player
{
    public class GamePlayer
    {
        public bool IsMoving { get; set; }

        public float x = 520, y = 610;
        public float step;
        public int speedX = 150, speedY = 150;
        public Direction direction;

        private IInputManager _inputManager;
        private IActorManager _actorManager;
        private WalkAnimation animation = new WalkAnimation();
        private string _charSetName;

        public GamePlayer(string charSetName, IInputManager inputManager, IActorManager actorManager)
        {
            _charSetName = charSetName;
            _inputManager = inputManager;
            _actorManager = actorManager;
        }

        public void Update(Map map, float deltaTime)
        {
            if (_inputManager.IsPressedInput((int)Input.FaceButtonLeft))
                speedX = speedY = 300;
            else
                speedX = speedY = 150;

            if (_inputManager.IsPressedKey((int)Keys.Up) || _inputManager.IsPressedKey((int)Keys.Down) || _inputManager.IsPressedKey((int)Keys.Left) || _inputManager.IsPressedKey((int)Keys.Right))
            {
                animation.Step();
                IsMoving = true;
                step += deltaTime;
                if (_inputManager.IsPressedInput((int)Input.FaceButtonLeft))
                    step += deltaTime;
            }
            else
            {
                animation.frame = 1;
                IsMoving = false;
            }

            if (_inputManager.IsPressedKey((int)Keys.Up))
                MoveUp(map, deltaTime);

            if (_inputManager.IsPressedKey((int)Keys.Down))
                MoveDown(map, deltaTime);

            if (_inputManager.IsPressedKey((int)Keys.Left))
                MoveLeft(map, deltaTime);

            if (_inputManager.IsPressedKey((int)Keys.Right))
                MoveRight(map, deltaTime);
        }

        public void Draw(Map map)
        {
            animation.Y = (int)direction;

            int xPos = Screen.HalfWidth;
            if (x < Screen.HalfWidth) xPos = (int)x;
            if (x > map.Width - Screen.HalfWidth)
                xPos = (int)x - Screen.Width - Screen.HalfWidth;

            int yPos = Screen.HalfHeight;
            if (y < Screen.HalfHeight) yPos = (int)y;
            if (y > map.Height - Screen.HalfHeight)
                yPos = (int)y - map.Height + Screen.Height;
             
            _actorManager.Draw(_charSetName, animation.DrawRect(xPos, yPos), animation.SourceRect);
        }

        public void MoveUp(Map map, float deltaTime)
        {
            direction = Direction.Up;

            if (!map.IsCollision((int)x, (int)(y - deltaTime * speedX), direction))
                y -= deltaTime * speedY;

            if (y < 0) y = 0;
        }

        public void MoveDown(Map map, float deltaTime)
        {
            direction = Direction.Down;

            if (!map.IsCollision((int)x, (int)(y + deltaTime * speedX), direction))
                y += deltaTime * speedY;

            if (y > map.Height) y = map.Height;
        }

        public void MoveLeft(Map map, float deltaTime)
        {
            direction = Direction.Left;

            if (!map.IsCollision((int)(x - deltaTime * speedX), (int)y, direction))
                x -= deltaTime * speedX;

            if (x < 0) x = 0;
        }

        public void MoveRight(Map map, float deltaTime)
        {
            direction = Direction.Right;

            if (!map.IsCollision((int)(x + deltaTime * speedX), (int)y, direction))
                x += deltaTime * speedX;

            if (x > map.Width) x = map.Width;
        }
    }
}