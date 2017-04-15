using Player;
using xTile.Dimensions;

namespace RPGPlugin
{
    public static class LocationExtensions
    {
        public static Vector ToVector(this Location location)
        {
            return new Vector(location.X, location.Y);
        }
    }
}