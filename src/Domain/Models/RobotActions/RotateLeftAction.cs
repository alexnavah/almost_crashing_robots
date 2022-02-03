using Domain.Models.Extensions;
using Domain.Models.Interfaces;

namespace Domain.Models
{
    public class RotateLeftAction : IRobotRotationAction
    {
        private static RotateLeftAction Current { get; set; }

        private RotateLeftAction() { }

        public static RotateLeftAction Instance => Current ??= new RotateLeftAction();

        public void Execute(Robot robot)
        {
            robot.RotateLeft();
        }
    }
}
