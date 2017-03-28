using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Player;

namespace MonoGame
{
    public class Player
    {
        public float x = 520, y = 610;
        public int step;
        public int speedX = 150, speedY = 150;
        public Direction direction;

        private InputManager InputManager;

        private Texture2D sprite;
        private WalkAnimation animation = new WalkAnimation();

        public Player(ContentManager Content, InputManager inputManager)
        {
            sprite = Content.Load<Texture2D>("charset\\Gus");
            InputManager = inputManager;
        }

        public void Update(Map map, float deltaTime)
        {
            if (InputManager.IsPressed(Input.FaceButtonLeft))
                speedX = speedY = 300;
            else
                speedX = speedY = 150;

            if (InputManager.IsPressed(Keys.Up) || InputManager.IsPressed(Keys.Down) || InputManager.IsPressed(Keys.Left) || InputManager.IsPressed(Keys.Right))
                animation.Step();
            else
                animation.frame = 1;

            if (InputManager.IsPressed(Keys.Up))
                MoveUp(map, deltaTime);

            if (InputManager.IsPressed(Keys.Down))
                MoveDown(map, deltaTime);

            if (InputManager.IsPressed(Keys.Left))
                MoveLeft(map, deltaTime);

            if (InputManager.IsPressed(Keys.Right))
                MoveRight(map, deltaTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animation.Y = (int)direction;

            int xPos = Screen.HalfWidth;
            if (x < Screen.HalfWidth) xPos = (int)x;
            if (x > Map.Width - Screen.HalfWidth)
                xPos = (int)x - Screen.Width - Screen.HalfWidth;

            int yPos = Screen.HalfHeight;
            if (y < Screen.HalfHeight) yPos = (int)y;
            if (y > Map.Height - Screen.HalfHeight)
                yPos = (int)y - Map.Height + Screen.Height;
             
            spriteBatch.Draw(sprite, animation.DrawRect(xPos, yPos).ToRectangle(), animation.SourceRect.ToRectangle(), Color.White);
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

            if (y > Map.Height) y = Map.Height;
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

            if (x > Map.Width) x = Map.Width;
        }
    }
}