using Domain.Contexts;
using Domain.Entities;
using System;

namespace Domain.Data.Repositories
{
    public class MissionInputRepository
    {
        private readonly CoreContext _coreContext;

        public MissionInputRepository(CoreContext coreContext)
        {
            _coreContext = coreContext;
        }

        public MissionInput Get(Guid id)
        {
            return _coreContext.MissionInputs.Find(id);
        }

        public MissionInput Save(MissionInput input)
        {
            _coreContext.MissionInputs.Add(input);
            _coreContext.SaveChanges();

            return input;
        }
    }
}
