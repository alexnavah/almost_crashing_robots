using System.Collections.Generic;

namespace Domain.Models
{
    public class Grid
    {
        private Grid()
        {
            LostRobotMarks = new List<Coordinates>();
        }

        public Coordinates BottomLeft => Coordinates.GetZeroZero();
        public Coordinates TopRight { get; set; }
        public List<Coordinates> LostRobotMarks { get; set; }

        public static Grid Create(int x, int y)
        {
            return new Grid
            {
                TopRight = Coordinates.Create(x, y)
            };
        }
    }
}
