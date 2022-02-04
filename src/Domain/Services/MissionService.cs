using Domain.Commands;
using Domain.Models;

namespace Domain.Services
{
    public class MissionService
    {
        private readonly ValidateMissionCommand _validateMissionCommand;
        private readonly ExecuteMissionCommand _executeMissionCommand;

        public MissionService(ValidateMissionCommand validateMissionCommand, ExecuteMissionCommand executeMissionCommand)
        {
            _validateMissionCommand = validateMissionCommand;
            _executeMissionCommand = executeMissionCommand;
        }

        public CommandResult ValidateMission(Mission mission)
        {
            var validation = _validateMissionCommand.Execute(mission);

            return validation;
        }

        public CommandResultOfT<Mission> LaunchMission(Mission mission)
        {
            var missionResult = _executeMissionCommand.Execute(mission);

            return missionResult;
        }
    }
}
