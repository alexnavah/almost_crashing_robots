namespace Domain.Models.Interfaces
{
    public interface IRobotMovementAction
    {
        public void Execute(Grid grid, Robot robot);
    }
}
