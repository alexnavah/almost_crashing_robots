using Domain.Models.Extensions;
using Domain.Models.Interfaces;

namespace Domain.Models
{
    public class RotateRightAction : IRobotRotationAction
    {
        private static RotateRightAction Current { get; set; }

        private RotateRightAction() { }

        public static RotateRightAction Instance => Current ??= new RotateRightAction();

        public void Execute(Robot robot)
        {
            robot.RotateRight();
        }
    }
}
