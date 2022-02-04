using Domain.Models;

namespace Domain.Commands.Interfaces
{
    public interface IExecuteMissionCommand
    {
        public CommandResultOfT<Mission> Execute(Mission mission);
    }
}
