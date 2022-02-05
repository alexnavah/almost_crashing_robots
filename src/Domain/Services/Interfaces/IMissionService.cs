using Domain.Models;
using System;

namespace Domain.Services.Interfaces
{
    public interface IMissionService
    {
        CommandResultOfT<Mission> LaunchMission(Mission mission);
        CommandResult ValidateMission(Mission mission);
        Guid SaveMissionInput(string input, string name);
        Guid SaveMissionOutput(string output, Guid inputId, Mission mission);
        void SetMissionOutput(Guid inputId, Guid outputId);
    }
}