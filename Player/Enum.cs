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
        WorldMenu,
        Exit
    }

    public enum MenuItem
    {
        NewGame,
        LoadGame,
        Exit
    }

    public enum BattleState
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
}