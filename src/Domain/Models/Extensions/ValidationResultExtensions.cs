namespace Domain.Models.Extensions
{
    public static class ValidationResultExtensions
    {
        public static void AddErrorMessage(this ValidationResult result, string message)
        {
            result.AddMessage(message);
        }
    }
}
