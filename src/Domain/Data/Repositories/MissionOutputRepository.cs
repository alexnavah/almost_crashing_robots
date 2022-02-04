using Domain.Contexts;

namespace Domain.Data.Repositories
{
    public class MissionOutputRepository
    {
        private readonly CoreContext _coreContext;

        public MissionOutputRepository(CoreContext coreContext)
        {
            _coreContext = coreContext;
        }
    }
}
