using Microsoft.Xna.Framework.Input;

namespace TiledSharp_MonoGame_Example
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