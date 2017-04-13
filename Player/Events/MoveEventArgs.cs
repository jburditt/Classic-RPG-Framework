namespace Player.Events
{
    public class MoveEventArgs
    {
        public GamePlayer GamePlayer;
        public Vector OldPos;
        public Vector NewPos;

        public MoveEventArgs(GamePlayer gamePlayer, Vector oldPos, Vector newPos)
        {
            GamePlayer = gamePlayer;
            OldPos = oldPos;
            NewPos = newPos;
        }
    }
}