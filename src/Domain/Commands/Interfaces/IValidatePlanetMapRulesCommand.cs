using Domain.Models;

namespace Domain.Commands.Interfaces
{
    public interface IValidatePlanetMapRulesCommandCommand
    {
        public CommandResult Execute(PlanetMap map);
    }
}
