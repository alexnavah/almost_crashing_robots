namespace Domain.Models.Interfaces
{
    public interface IValidation
    {
        public void Run(Mission mission, ValidationResult validationResult);
    }
}