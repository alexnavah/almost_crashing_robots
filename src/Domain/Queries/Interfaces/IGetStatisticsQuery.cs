using Domain.Models;
using System;

namespace Domain.Queries.Interfaces
{
    public interface IGetStatisticsQuery
    {
        QueryResultOfT<MissionResult> Execute(Guid inputId);
    }
}