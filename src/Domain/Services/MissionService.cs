using Domain.Commands.Interfaces;
using Domain.Models;
using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class MissionService : IMissionService
    {
        private readonly IValidateMissionCommand _validateMissionCommand;
        private readonly IExecuteMissionCommand _executeMissionCommand;

        public MissionService(IValidateMissionCommand validateMissionCommand, IExecuteMissionCommand executeMissionCommand)
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
