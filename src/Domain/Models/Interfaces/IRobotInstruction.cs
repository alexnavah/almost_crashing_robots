namespace Domain.Models.Interfaces
{
    public interface IRobotInstruction
    {
        public void Execute(Mission mission, Robot robot);
    }
}
