using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Shapes;

namespace TiledSharp_MonoGame_Example_2
{
    public class Player
    {
        public float x = 520, y = 610;
        public int step;
        public int speedX = 150, speedY = 150;
        public Direction direction;
        public RectangleF Bounds => new RectangleF(x, y, x + spriteWidth, y + spriteHeight);

        private int spriteWidth = 24, spriteHeight = 32;
        
        private Texture2D sprite;
        private Animation animation = new Animation();

        public Player(ContentManager Content)
        {
            sprite = Content.Load<Texture2D>("Crono");
        }

        public void Update(Map map, float deltaTime)
        {
            if (KeyboardHelper.ShiftDown())
                speedX = speedY = 300;
            else
                speedX = speedY = 150;

            if (KeyboardHelper.Down(Keys.Up) || KeyboardHelper.Down(Keys.Down) || KeyboardHelper.Down(Keys.Left) || KeyboardHelper.Down(Keys.Right))
                animation.Step();
            else
                animation.frame = 1;

            if (KeyboardHelper.Down(Keys.Up))
                MoveUp(map, deltaTime);

            if (KeyboardHelper.Down(Keys.Down))
                MoveDown(map, deltaTime);

            if (KeyboardHelper.Down(Keys.Left))
                MoveLeft(map, deltaTime);

            if (KeyboardHelper.Down(Keys.Right))
                MoveRight(map, deltaTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int frameX = animation.x * spriteWidth;
            int frameY = (int)direction * spriteHeight;

            Rectangle rect = new Rectangle(frameX, frameY, spriteWidth, spriteHeight);

            int xPos = Screen.HalfWidth;
            if (x < Screen.HalfWidth) xPos = (int)x;
            if (x > Map.Width - Screen.HalfWidth)
                xPos = (int)x - Screen.Width - Screen.HalfWidth;

            int yPos = Screen.HalfHeight;
            if (y < Screen.HalfHeight) yPos = (int)y;
            if (y > Map.Height - Screen.HalfHeight)
                yPos = (int)y - Map.Height + Screen.Height;
             
            spriteBatch.Draw(sprite, new Rectangle(xPos, yPos, spriteWidth, spriteHeight), rect, Color.White);
            //spriteBatch.DrawRectangle(new Rectangle(xPos, yPos, spriteWidth, spriteHeight), Color.White);
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