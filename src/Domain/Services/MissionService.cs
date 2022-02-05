using Domain.Commands.Interfaces;
using Domain.Data.Repositories.Interfaces;
using Domain.Entities;
using Domain.Models;
using Domain.Models.Extensions;
using Domain.Services.Interfaces;
using System;

namespace Domain.Services
{
    public class MissionService : IMissionService
    {
        private readonly IValidateMissionCommand _validateMissionCommand;
        private readonly IExecuteMissionCommand _executeMissionCommand;
        private readonly IMissionInputRepository _missionInputRepository;
        private readonly IMissionOutputRepository _missionOutputRepository;

        public MissionService(IValidateMissionCommand validateMissionCommand, IExecuteMissionCommand executeMissionCommand, 
            IMissionInputRepository missionInputRepository, IMissionOutputRepository missionOutputRepository)
        {
            _validateMissionCommand = validateMissionCommand;
            _executeMissionCommand = executeMissionCommand;
            _missionInputRepository = missionInputRepository;
            _missionOutputRepository = missionOutputRepository;
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

        public Guid SaveMissionInput(string input, string name)
        {
            var missionInput = new MissionInput
            {
                Id = Guid.NewGuid(),
                Name = name,
                RawString = input
            };

            _missionInputRepository.Save(missionInput);

            return missionInput.Id;
        }

        public Guid SaveMissionOutput(string output, Guid inputId, Mission mission)
        {
            var missionOutput = new MissionOutput
            {
                Id = Guid.NewGuid(),
                RawString = output,
                InputId = inputId,
                SuccessPercentage = mission.GetSuccessPercentage(),
                ExploredPercentage = mission.GetExploredPercentage()
            };

            _missionOutputRepository.Save(missionOutput);

            return missionOutput.Id;
        }

        public void SetMissionOutput(Guid inputId, Guid outputId)
        {
            _missionInputRepository.UpdateOutput(inputId, outputId);
        }
    }
}
