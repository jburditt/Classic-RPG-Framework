using Player.Inputs;
using Player.Manager;
using System.Collections.Generic;

namespace Player
{
    public class GamePlayer
    {
        public bool IsMoving { get; set; }

        public VectorF Pos;
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

            if (_inputManager.AnyPressedKey((int)Keys.Up, (int)Keys.Down, (int)Keys.Left, (int)Keys.Right))
                map.UpdateCamera(Pos.ToVector());
        }

        public void Action(Map map)
        {
            foreach (var npc in map.NPC)
            {
                if (Vector.Distance(npc.Pos, Pos.ToVector()) < 10)
                    npc.Talk();
            }
        }

        public void Draw(Map map)
        {
            animation.Y = (int)direction;

            //int xPos = map.TransformX(x);
            //int yPos = map.TransformY(y);
            var pos = map.Transform(Pos);
            
            _actorManager.Draw(_charSetName, animation.DrawRect(pos), animation.SourceRect);
        }

        public void MoveUp(Map map, float deltaTime)
        {
            direction = Direction.Up;

            var dest = Pos;
            dest.Y -= deltaTime * speedY;

            if (!map.IsCollision(dest.ToVector(), direction))
                Pos.Y -= deltaTime * speedY;

            if (Pos.Y < 0) Pos.Y = 0;
        }

        public void MoveDown(Map map, float deltaTime)
        {
            direction = Direction.Down;

            var dest = Pos;
            dest.Y += deltaTime * speedY;

            if (!map.IsCollision(dest.ToVector(), direction))
                Pos.Y += deltaTime * speedY;

            if (Pos.Y > map.Height) Pos.Y = map.Height;
        }

        public void MoveLeft(Map map, float deltaTime)
        {
            direction = Direction.Left;

            var dest = Pos;
            dest.X -= deltaTime * speedX;

            if (!map.IsCollision(dest.ToVector(), direction))
                Pos.X -= deltaTime * speedX;

            if (Pos.X < 0) Pos.X = 0;
        }

        public void MoveRight(Map map, float deltaTime)
        {
            direction = Direction.Right;

            var dest = Pos;
            dest.X += deltaTime * speedX;

            if (!map.IsCollision(dest.ToVector(), direction))
                Pos.X += deltaTime * speedX;

            if (Pos.X > map.Width) Pos.X = map.Width;
        }
    }
}