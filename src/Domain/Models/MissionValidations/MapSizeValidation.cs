using Domain.Models.Interfaces;

namespace Domain.Models.Rules
{
    public class MapSizeValidation : IValidation
    {
        const int MaxMapSize = 100;

        private static MapSizeValidation Current { get; set; }

        private MapSizeValidation()
        {

        }

        public static MapSizeValidation Instance => Current ??= new MapSizeValidation();

        public void Run(Mission mission, ValidationResult validationResult)
        {
            var map = mission.Map;

            if (map.TopRight.X > MaxMapSize || map.TopRight.X < map.BottomLeft.X)
            {
                validationResult.AddMessage($"Map size coordinate should be between {MaxMapSize} and {map.BottomLeft.X}. Given {nameof(Coordinates.X)} is {map.TopRight.X}");
            }

            if (map.TopRight.Y > MaxMapSize || map.TopRight.Y < map.BottomLeft.Y)
            {
                validationResult.AddMessage($"Map size coordinate should be between {MaxMapSize} and {map.BottomLeft.Y}. Given {nameof(Coordinates.Y)} is {map.TopRight.Y}");
            }
        }
    }
}
