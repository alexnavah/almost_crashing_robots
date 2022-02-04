using Domain.Commands;
using System.Linq;
using Tests.Helpers;
using Xunit;

namespace Test.Domain.Commands
{
    public class ValidateRobotRulesCommandTests
    {
        private readonly ValidateMissionRulesCommand _validateMissionRulesCommand;

        public ValidateRobotRulesCommandTests()
        {
            // TODO: Dependency injection
            _validateMissionRulesCommand = new ValidateMissionRulesCommand();
        }

        [Fact]
        public void ShouldValidateInputWithSuccuessResult()
        {
            // Arrange
            var validMission = TestDataHelper.GivenValidMissionConfiguration();

            // Act
            var commandResult = _validateMissionRulesCommand.Execute(validMission);

            // Assert
            Assert.True(commandResult.Success);
        }

        [Theory]
        [InlineData(150)]
        [InlineData(-50)]
        public void ShouldFailOnMapSizeInput(int xCoordinate)
        {
            // Arrange
            var mission = TestDataHelper.GivenValidMissionConfiguration();
            mission.Map.TopRight.X = xCoordinate;

            // Act
            var commandResult = _validateMissionRulesCommand.Execute(mission);

            // Assert
            Assert.False(commandResult.Success);
        }

        [Theory]
        [InlineData('F', 250)]
        public void ShouldFailOnRobotInstructionsLengthInput(char instruction, int times)
        {
            // Arrange
            var mission = TestDataHelper.GivenValidMissionConfiguration();
            mission.Robots.First().Commands = new string(instruction, times);

            // Act
            var commandResult = _validateMissionRulesCommand.Execute(mission);

            // Assert
            Assert.False(commandResult.Success);
        }
    }
}
