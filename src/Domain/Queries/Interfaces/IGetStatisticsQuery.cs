using System;

namespace Domain.Queries.Interfaces
{
    public interface IGetStatisticsQuery
    {
        void Execute(Guid inputId);
    }
}