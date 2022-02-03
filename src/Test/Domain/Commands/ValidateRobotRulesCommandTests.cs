using Domain.Commands;
using System.Linq;
using Tests.Helpers;
using Xunit;

namespace Test.Domain.Commands
{
    public class ValidateRobotRulesCommandTests
    {
        private readonly ValidatePlanetMapRulesCommand _validatePlanetMapRulesCommand;

        public ValidateRobotRulesCommandTests()
        {
            // TODO: Dependency injection
            _validatePlanetMapRulesCommand = new ValidatePlanetMapRulesCommand();
        }

        [Fact]
        public void ShouldValidateInputWithSuccuessResult()
        {
            // Arrange
            var validMap = TestDataHelper.GivenValidMapConfiguration();

            // Act
            var commandResult = _validatePlanetMapRulesCommand.Execute(validMap);

            // Assert
            Assert.True(commandResult.Success);
        }

        [Theory]
        [InlineData(150)]
        [InlineData(-50)]
        public void ShouldFailOnMapSizeInput(int xCoordinate)
        {
            // Arrange
            var map = TestDataHelper.GivenValidMapConfiguration();
            map.Grid.TopRight.X = xCoordinate;

            // Act
            var commandResult = _validatePlanetMapRulesCommand.Execute(map);

            // Assert
            Assert.False(commandResult.Success);
        }

        [Theory]
        [InlineData('F', 250)]
        public void ShouldFailOnRobotInstructionsLengthInput(char instruction, int times)
        {
            // Arrange
            var map = TestDataHelper.GivenValidMapConfiguration();
            map.Robots.First().Commands = new string(instruction, times);

            // Act
            var commandResult = _validatePlanetMapRulesCommand.Execute(map);

            // Assert
            Assert.False(commandResult.Success);
        }
    }
}
