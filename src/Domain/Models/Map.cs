using System.Collections.Generic;

namespace Domain.Models
{
    public class Map
    {
        private Map()
        {
            LostRobotVectors = new List<DirectionVector>();
            ExploredTiles = new HashSet<Coordinates>();
        }

        public Coordinates BottomLeft => Coordinates.ZeroZero;
        public Coordinates TopRight { get; set; }
        public List<DirectionVector> LostRobotVectors { get; set; }
        public HashSet<Coordinates> ExploredTiles { get; set; }

        public static Map Create(int x, int y)
        {
            return new Map
            {
                TopRight = Coordinates.Create(x, y)
            };
        }
    }
}
