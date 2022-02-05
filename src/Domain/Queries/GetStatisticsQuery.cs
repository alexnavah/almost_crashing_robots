using Domain.Data.Repositories.Interfaces;
using Domain.Queries.Interfaces;
using System;

namespace Domain.Queries
{
    public class GetStatisticsQuery : IGetStatisticsQuery
    {
        private readonly IMissionInputRepository _missionInputRepository;
        private readonly IMissionOutputRepository _missionOutputrepository;

        public GetStatisticsQuery(IMissionInputRepository missionInputRepository, IMissionOutputRepository missionOutputRepository)
        {
            _missionInputRepository = missionInputRepository;
            _missionOutputrepository = missionOutputRepository;
        }

        public void Execute(Guid inputId)
        {

        }
    }
}
