namespace Common
{
    public class Random
    {
        private static System.Random r = new System.Random();

        public static int Next(int max)
        {
            return r.Next(0, max);
        }

        public static int Sign()
        {
            return r.Next(0, 1) == 0 ? 1 : -1;
        }
    }
}