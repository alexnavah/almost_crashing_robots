using Domain.Entities;

namespace Domain.Data.Repositories.Interfaces
{
    public interface IMissionInputRepository
    {
        MissionInput Find(int id);
        MissionInput Save(MissionInput input);
        void UpdateOutput(int inputId, int outputId);
    }
}