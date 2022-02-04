using Domain.Models;

namespace Domain.Commands.Interfaces
{
    /// <summary>
    /// Execute mission command
    /// </summary>
    public interface IExecuteMissionCommand
    {
        /// <summary>
        /// Execute mission launch with every robot secuencially
        /// </summary>
        /// <param name="mission">The <see cref="Mission"/></param>
        /// <returns>The <see cref="CommandResultOfT{Mission}"/>. Result of the mission</returns>
        public CommandResultOfT<Mission> Execute(Mission mission);
    }
}
