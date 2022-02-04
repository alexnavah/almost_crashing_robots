using Domain.Commands;
using Domain.Models;
using System.Linq;
using Tests.Helpers;
using Xunit;

namespace Tests.Domain.Commands
{
    public class ExecuteMissionCommandTests
    {
        private ExecuteMissionCommand _executeMissionCommand;

        public ExecuteMissionCommandTests()
        {
            //TODO: Dependency injection
            _executeMissionCommand = new ExecuteMissionCommand();
        }

        [Theory]
        [InlineData(0, 1, 1, OrientationType.East, false)]
        [InlineData(1, 3, 3, OrientationType.North, true)]
        [InlineData(2, 4, 2, OrientationType.North, false)]
        public void ShouldSuccessOnMissionExecutionGivenSampleInput(int index, int x, int y, OrientationType orientation, bool isLost)
        {
            // Arrange
            var sampleMission = TestDataHelper.GivenSampleMissionConfiguration();

            // Act
            var commandResult = _executeMissionCommand.Execute(sampleMission);
            var robots = commandResult.Result.Robots;

            // Assert
            Assert.True(robots.ElementAt(index).Equals(Robot.Create(x, y, orientation)));
            Assert.True(robots.ElementAt(index).IsLost.Equals(isLost));
        }

        [Theory]
        [InlineData(0, 3, 3, OrientationType.North, true)]
        [InlineData(1, 3, 2, OrientationType.North, false)]
        public void ShouldSuccessOnMissionExecutionGivenWithRobotsFollowingSamePath(int index, int x, int y, OrientationType orientation, bool isLost)
        {
            // Arrange
            var sampleMission = TestDataHelper.GivenValidMissionWithRobotsFollowingSamePath();

            // Act
            var commandResult = _executeMissionCommand.Execute(sampleMission);
            var robots = commandResult.Result.Robots;

            // Assert
            Assert.True(robots.ElementAt(index).Equals(Robot.Create(x, y, orientation)));
            Assert.True(robots.ElementAt(index).IsLost.Equals(isLost));
        }
    }
}
