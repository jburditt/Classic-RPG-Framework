using Player.Manager;

namespace Player
{
    public class NPC
    {
        private IActorManager _actorManager;
        private WalkAnimation animation = new WalkAnimation();

        public Direction direction;

        public string Name { get; set; }
        public string CharSet { get; set; }
        public string Dialog { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public NPC(IActorManager actorManager)
        {
            _actorManager = actorManager;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            animation.Y = (int)direction;

            _actorManager.Draw(CharSet, animation.DrawRect(X, Y), animation.SourceRect);
        }
    }
}