namespace Domain.Models.Validations
{
    public interface IValidationRule
    {
        public void Run(PlanetMap map, ValidationResult validationResult);
    }
}