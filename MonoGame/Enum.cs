namespace Player
{
    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    };

    public enum GameState
    {
        StartMenu,
        World,
        Battle,
        WorldMenu
    }

    public enum MenuItem
    {
        NewGame,
        LoadGame,
        Exit
    }
}