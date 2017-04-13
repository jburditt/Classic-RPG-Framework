namespace Player.Events
{
    public class MoveEventArgs
    {
        public Vector OldPos;
        public Vector NewPos;

        public MoveEventArgs(Vector oldPos, Vector newPos)
        {
            OldPos = oldPos;
            NewPos = newPos;
        }
    }
}