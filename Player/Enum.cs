namespace Player
{
    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    };

    public enum State
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

    public enum BattleStateEnum
    {
        Running,
        Idle
    }

    public enum EnemyState
    {
        Waiting,
        Ready,
        Dead
    }

    public enum ActorState
    {
        Waiting,
        Ready,
        Dead
    }

    public enum Movement
    {
        None,
        Walking,
        Running,
        Path,
        Follow
    }
}