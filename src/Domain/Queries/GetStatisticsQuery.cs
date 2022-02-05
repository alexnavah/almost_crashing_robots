using Domain.Data.Repositories.Interfaces;
using Domain.Models;
using Domain.Queries.Interfaces;
using System;

namespace Domain.Queries
{
    public class GetStatisticsQuery : IGetStatisticsQuery
    {
        private readonly IMissionInputRepository _missionInputRepository;

        public GetStatisticsQuery(IMissionInputRepository missionInputRepository)
        {
            _missionInputRepository = missionInputRepository;
        }

        public QueryResultOfT<MissionResult> Execute(Guid inputId)
        {
            var result = QueryResultOfT<MissionResult>.Create();
            var input = _missionInputRepository.Find(inputId);

            var missionResult = new MissionResult
            {
                Input = input.RawString
            };

            var output = input.Output;
            if (output != null)
            {
                missionResult.Output = output.RawString;
                missionResult.ExploredPercentage = output.ExploredPercentage;
                missionResult.SuccessPercentage = output.SuccessPercentage;
            }

            result.SetResult(missionResult);

            return result;
        }
    }
}
