using System.Collections.Generic;

namespace Domain.Models
{
    public class PlanetMap
    {
        public Grid Grid { get; set; }
        public List<Robot> Robots { get; set; }

        public static PlanetMap Create(Grid grid, List<Robot> robots)
        {
            return new PlanetMap
            {
                Grid = grid,
                Robots = robots
            };
        }
    }
}
