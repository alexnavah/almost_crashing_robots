using System.Collections.Generic;

namespace Domain.Models
{
    public class ValidationResult
    {
        private ValidationResult()
        {
            Messages = new List<string>();
        }

        public bool Success => Messages.Count.Equals(0);
        public List<string> Messages { get; set; }

        public static ValidationResult Create()
        {
            return new ValidationResult();
        }

        public void AddMessage(string message)
        {
            Messages.Add(message);
        }
    }
}
