using Domain.Models.Extensions;
using Domain.Models.Interfaces;

namespace Domain.Models
{
    public class RotateLeftAction : IRobotMovementAction
    {
        private static RotateLeftAction Current { get; set; }

        private RotateLeftAction() { }

        public static RotateLeftAction Instance => Current ??= new RotateLeftAction();

        public void Execute(Grid grid, Robot robot)
        {
            robot.RotateLeft();
        }
    }
}
