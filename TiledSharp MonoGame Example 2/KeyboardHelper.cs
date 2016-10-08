using Microsoft.Xna.Framework.Input;

namespace TiledSharp_MonoGame_Example_2
{
    public static class KeyboardHelper
    {
        public static bool Down(params Keys[] keys)
        {
            var isKeyDown = true;

            foreach (var key in keys)
            {
                isKeyDown = Keyboard.GetState().IsKeyDown(key);
                if (!isKeyDown)
                    return false;
            }
            
            return true;
        }

        public static bool ShiftDown()
        {
            return (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift));
        }

        public static bool Press(KeyboardState previousState, Keys key)
        {
            return Keyboard.GetState().IsKeyDown(key) && !previousState.IsKeyDown(key);
        }

        public static bool AltPress(KeyboardState previousState, Keys key)
        {
            return (Keyboard.GetState().IsKeyDown(Keys.LeftAlt) || Keyboard.GetState().IsKeyDown(Keys.RightAlt))
                && Keyboard.GetState().IsKeyDown(key) && !previousState.IsKeyDown(key);
        }
    }
}