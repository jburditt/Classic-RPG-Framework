namespace Player
{
    public interface IInputManager
    {
        bool IsPressedKey(int key);
        bool JustPressedKey(int key, params int[] keys);
        bool JustPressedInput(int input, params int[] inputs);
    }
}