using Domain.Models.Extensions;
using Domain.Models.Interfaces;

namespace Domain.Models
{
    public class RotateLeftInstruction : IRobotInstruction
    {
        private static RotateLeftInstruction Current { get; set; }

        private RotateLeftInstruction() { }

        public static RotateLeftInstruction Instance => Current ??= new RotateLeftInstruction();

        public void Execute(Mission mission, Robot robot)
        {
            robot.RotateLeft();
        }
    }
}
