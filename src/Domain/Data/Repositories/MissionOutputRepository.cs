using Domain.Contexts;
using Domain.Data.Repositories.Interfaces;
using Domain.Entities;

namespace Domain.Data.Repositories
{
    public class MissionOutputRepository : IMissionOutputRepository
    {
        private readonly CoreContext _coreContext;

        public MissionOutputRepository(CoreContext coreContext)
        {
            _coreContext = coreContext;
        }

        public MissionOutput Find(int id)
        {
            return _coreContext.MissionOutputs.Find(id);
        }

        public MissionOutput Save(MissionOutput output)
        {
            _coreContext.MissionOutputs.Add(output);
            _coreContext.SaveChanges();

            return output;
        }
    }
}
