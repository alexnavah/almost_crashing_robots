using System.Text;

namespace Domain.Models.Extensions
{
    public static class CommandResultExtensions
    {
        public static string GetMessagesAsString(this CommandResult commandResult)
        {
            var stringBuilder = new StringBuilder();
            commandResult.Messages.ForEach(m => stringBuilder.AppendLine(m));

            return stringBuilder.ToString();
        }
    }
}
