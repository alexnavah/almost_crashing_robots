using Domain.Commands.Interfaces;
using Domain.Data.Repositories.Interfaces;
using Domain.Entities;
using Domain.Models;
using Domain.Models.Extensions;

namespace Domain.Commands
{
    public class SaveMissionResultCommand : ISaveMissionResultCommand
    {
        private readonly IMissionInputRepository _missionInputRepository;
        private readonly IMissionOutputRepository _missionOutputRepository;

        public SaveMissionResultCommand(IMissionInputRepository missionInputRepository, IMissionOutputRepository missionOutputRepository)
        {
            _missionInputRepository = missionInputRepository;
            _missionOutputRepository = missionOutputRepository;
        }

        public void Execute(Mission mission, MissionParameters missionParameters)
        {
            var missionInput = new MissionInput
            {
                Name = missionParameters.Name,
                RawString = missionParameters.Input
            };

            _missionInputRepository.Save(missionInput);

            var missionOutput = new MissionOutput
            {
                RawString = mission.GetRawOutput(),
                InputId = missionInput.Id,
                SuccessPercentage = mission.GetSuccessPercentage(),
                ExploredPercentage = mission.GetExploredPercentage()
            };

            _missionOutputRepository.Save(missionOutput);

            _missionInputRepository.UpdateOutput(missionInput.Id, missionOutput.Id);
        }
    }
}
