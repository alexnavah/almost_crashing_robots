using Domain.Contexts;
using Domain.Data.Repositories.Interfaces;
using Domain.Entities;

namespace Domain.Data.Repositories
{
    public class MissionInputRepository : IMissionInputRepository
    {
        private readonly CoreContext _coreContext;

        public MissionInputRepository(CoreContext coreContext)
        {
            _coreContext = coreContext;
        }

        public MissionInput Find(int id)
        {
            return _coreContext.MissionInputs.Find(id);
        }

        public MissionInput Save(MissionInput input)
        {
            _coreContext.MissionInputs.Add(input);
            _coreContext.SaveChanges();

            return input;
        }

        public void UpdateOutput(int inputId, int outputId)
        {
            var input = Find(inputId);
            input.OutputId = outputId;

            _coreContext.SaveChanges();
        }
    }
}
