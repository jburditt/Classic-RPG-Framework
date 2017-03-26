using Microsoft.Xna.Framework.Input;

namespace Player
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
            var state = Keyboard.GetState();
            return (state.IsKeyDown(Keys.LeftShift) || state.IsKeyDown(Keys.RightShift));
        }

        public static bool Press(KeyboardState previousState, Keys key)
        {
            return Keyboard.GetState().IsKeyDown(key) && !previousState.IsKeyDown(key);
        }

        public static bool AltPress(KeyboardState previousState, Keys key)
        {
            var state = Keyboard.GetState();
            return (state.IsKeyDown(Keys.LeftAlt) || state.IsKeyDown(Keys.RightAlt))
                && state.IsKeyDown(key) && !previousState.IsKeyDown(key);
        }
    }
}