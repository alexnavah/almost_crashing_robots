using Domain.Models.Extensions;
using Domain.Models.Interfaces;

namespace Domain.Models
{
    public class RotateRightInstruction : IRobotInstruction
    {
        private static RotateRightInstruction Current { get; set; }

        private RotateRightInstruction() { }

        public static RotateRightInstruction Instance => Current ??= new RotateRightInstruction();

        public void Execute(Mission mission, Robot robot)
        {
            robot.RotateRight();
        }
    }
}
