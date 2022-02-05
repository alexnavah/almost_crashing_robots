using Domain.Entities;

namespace Domain.Data.Repositories.Interfaces
{
    public interface IMissionOutputRepository
    {
        MissionOutput Find(int id);
        MissionOutput Save(MissionOutput output);
    }
}