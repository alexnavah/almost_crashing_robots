using Domain.Models;

namespace Domain.Commands.Interfaces
{
    public interface ISaveMissionResultCommand
    {
        void Execute(Mission mission, MissionParameters missionParameters);
    }
}