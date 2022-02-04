using Domain.Models.Interfaces;

namespace Domain.Models.Rules
{
    public class MapSizeRule : IValidationRule
    {
        const int MaxGridSize = 100;

        private static MapSizeRule Current { get; set; }

        private MapSizeRule()
        {

        }

        public static MapSizeRule Instance => Current ??= new MapSizeRule();

        public void Run(Mission map, ValidationResult validationResult)
        {
            var grid = map.Map;

            if (grid.TopRight.X > MaxGridSize || grid.TopRight.X < grid.BottomLeft.X)
            {
                validationResult.AddMessage($"Grid size coordinate should be between {MaxGridSize} and {grid.BottomLeft.X}. Given {nameof(Coordinates.X)} is {grid.TopRight.X}");
            }

            if (grid.TopRight.Y > MaxGridSize || grid.TopRight.Y < grid.BottomLeft.Y)
            {
                validationResult.AddMessage($"Grid size coordinate should be between {MaxGridSize} and {grid.BottomLeft.Y}. Given {nameof(Coordinates.Y)} is {grid.TopRight.Y}");
            }
        }
    }
}
