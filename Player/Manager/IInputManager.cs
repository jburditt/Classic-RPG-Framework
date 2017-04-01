namespace Player
{
    public interface IInputManager
    {
        bool AnyPressedKey(params int[] keys);
        bool IsPressedKey(int key);
        bool IsPressedInput(int input);
        bool JustPressedKey(int key, params int[] keys);
        bool JustPressedInput(int input, params int[] inputs);
    }
}