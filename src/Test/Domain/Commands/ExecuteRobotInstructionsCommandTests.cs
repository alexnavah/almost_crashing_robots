using Domain.Models;
using Tests.Helpers;
using Xunit;

namespace Tests.Domain.Commands
{
    public class ExecuteRobotInstructionsCommandTests
    {
        public ExecuteRobotInstructionsCommandTests()
        {

        }

        [Fact]
        public void Should_work_with_sample_given()
        {
            var givenInput = Initializer.GetCodeChallengeSampleInput();

            var robot1Output = Robot.Create(1, 1, OrientationType.East);
            var robot2Output = Robot.Create(3, 3, OrientationType.North, true);
            var robot3Output = Robot.Create(4, 2, OrientationType.North);

            //Assert.True(robot1Output == );
        }
    }
}
