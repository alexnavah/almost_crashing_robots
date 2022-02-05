using Domain.Models;

namespace Domain.Queries.Interfaces
{
    public interface IGetStatisticsQuery
    {
        QueryResultOfT<MissionResult> Execute(int inputId);
    }
}