namespace Domain.Models.Validations
{
    public class GridSizeRule : IValidationRule
    {
        const int MaxGridSize = 100;

        private static GridSizeRule Current { get; set; }

        private GridSizeRule()
        {

        }

        public static GridSizeRule Instance => Current ??= new GridSizeRule();

        public void Run(PlanetMap map, ValidationResult validationResult)
        {
            var grid = map.Grid;

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
