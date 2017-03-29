namespace Player
{
    public interface IEffect
    {
        int X { get; set; }
        int Y { get; set; }
        int Lifespan { get; set; }

        void Draw();
        void Update();
    }
}