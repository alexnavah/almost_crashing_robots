using Domain.Entities;
using System;

namespace Domain.Data.Repositories.Interfaces
{
    public interface IMissionInputRepository
    {
        MissionInput Find(Guid id);
        MissionInput Save(MissionInput input);
        void UpdateOutput(Guid inputId, Guid outputId);
    }
}