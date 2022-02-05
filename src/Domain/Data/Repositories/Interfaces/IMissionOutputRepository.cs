using Domain.Entities;
using System;

namespace Domain.Data.Repositories.Interfaces
{
    public interface IMissionOutputRepository
    {
        MissionOutput Find(Guid id);
        MissionOutput Save(MissionOutput output);
    }
}