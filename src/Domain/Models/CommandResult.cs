using System.Collections.Generic;

namespace Domain.Models
{
    public class CommandResult
    {
        public CommandResult()
        {
            Messages = new List<string>();
        }

        public bool Success => Messages.Count.Equals(0);
        public List<string> Messages { get; set; }

        public static CommandResult Create()
        {
            return new CommandResult();
        }

        public void AddMessages(IEnumerable<string> messages)
        {
            Messages.AddRange(messages);
        }
    }
}
