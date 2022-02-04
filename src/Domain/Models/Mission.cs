using System.Collections.Generic;

namespace Domain.Models
{
    public class Mission
    {
        public Map Map { get; set; }
        public List<Robot> Robots { get; set; }

        public static Mission Create(Map map, List<Robot> robots)
        {
            return new Mission
            {
                Map = map,
                Robots = robots
            };
        }
    }
}
