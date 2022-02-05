using Domain.Models;

namespace Domain.Services.Interfaces
{
    public interface IMissionService
    {
        CommandResultOfT<Mission> LaunchMission(Mission mission);
        CommandResult ValidateMission(Mission mission);
    }
}