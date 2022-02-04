namespace Domain.Models.Interfaces
{
    public interface IValidationRule
    {
        public void Run(Mission map, ValidationResult validationResult);
    }
}