namespace Domain.Models.Validations
{
    public class MaxGridSizeRule : IValidationRule
    {
        const int MaxGridSize = 100;

        private static MaxGridSizeRule Current { get; set; }

        private MaxGridSizeRule()
        {

        }

        public static MaxGridSizeRule Instance => Current ??= new MaxGridSizeRule();

        public void Run(PlanetMap map, ValidationResult validationResult)
        {
            if (map.Grid.TopRight.X > MaxGridSize)
            {
                validationResult.AddMessage($"Maximum grid size coordinate is {MaxGridSize} and given {nameof(Coordinates.X)} is {map.Grid.TopRight.X}");
            }

            if (map.Grid.TopRight.Y > MaxGridSize)
            {
                validationResult.AddMessage($"Maximum grid size coordinate is {MaxGridSize} and given {nameof(Coordinates.Y)} is {map.Grid.TopRight.Y}");
            }
        }
    }
}
