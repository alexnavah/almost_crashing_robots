using System.Collections.Generic;

namespace Domain.Models
{
    public class Grid
    {
        private Grid()
        {
            LostRobotTiles = new List<Coordinates>();
            SafeTiles = new List<Coordinates>();
        }

        public Coordinates BottomLeft => Coordinates.ZeroZero;
        public Coordinates TopRight { get; set; }
        public List<Coordinates> LostRobotTiles { get; set; }
        public List<Coordinates> SafeTiles { get; set; }

        public static Grid Create(int x, int y)
        {
            return new Grid
            {
                TopRight = Coordinates.Create(x, y)
            };
        }
    }
}
