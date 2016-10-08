using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TiledSharp_MonoGame_Example_2
{
    public class Player
    {
        public float x = 800, y = 1200;
        public int step;
        public int speedX = 150, speedY = 150;
        public Direction direction;

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

            int xPos = Screen.HalfWidth - 12;
            if (x < Screen.HalfWidth - 12) xPos = (int)x;
            if (x > Map.Width - Screen.HalfWidth)
                xPos = (int)x - Screen.Width - Screen.HalfWidth - 12;

            int yPos = Screen.HalfHeight - 16;
            if (y < Screen.HalfHeight - 16) yPos = (int)y;
            if (y > Map.Height - Screen.HalfHeight)
                yPos = (int)y - Map.Height + Screen.Height - 16;
             
            spriteBatch.Draw(sprite, new Rectangle(xPos, yPos, spriteWidth, spriteHeight), rect, Color.White);
        }

        public void MoveUp(Map map, float deltaTime)
        {
            direction = Direction.Up;
            y -= deltaTime * speedY;
            if (y < 0) y = 0;
        }

        public void MoveDown(Map map, float deltaTime)
        {
            direction = Direction.Down;
            y += deltaTime * speedY;
            if (y > Map.Height) y = Map.Height;
        }

        public void MoveLeft(Map map, float deltaTime)
        {
            direction = Direction.Left;
            x -= deltaTime * speedX;
            if (x < 0) x = 0;
        }

        public void MoveRight(Map map, float deltaTime)
        {
            direction = Direction.Right;
            x += deltaTime * speedX;
            if (x > Map.Width) x = Map.Width;
        }
    }
}