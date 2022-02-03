using Domain.Helpers;
using Domain.Models;
using System;
using Tests.Helpers;
using Xunit;

namespace Tests.Domain.Parsers
{
    public class InputParserTests
    {
        public InputParserTests()
        {

        }

        [Fact]
        public void ShouldParseGivenInput()
        {
            // Arrange
            var givenInput = TestDataHelper.GivenCodeChallengeSampleInput();

            var gridInputCoordinates = Coordinates.Create(5, 3);

            var robot1Input = Robot.Create(1, 1, OrientationType.East, "RFRFRFRF");
            var robot2Input = Robot.Create(3, 2, OrientationType.North, "FRRFLLFFRRFLL");
            var robot3Input = Robot.Create(0, 3, OrientationType.West, "LLFFFRFLFL");

            // Act
            var map = InputParser.ParseInput(givenInput);

            // Assert
            Assert.True(map.Grid.TopRight.Equals(gridInputCoordinates));

            Assert.True(robot1Input.Equals(map.Robots[0]));
            Assert.True(robot1Input.Commands.Equals(map.Robots[0].Commands));

            Assert.True(robot2Input.Equals(map.Robots[1]));
            Assert.True(robot2Input.Commands.Equals(map.Robots[1].Commands));

            Assert.True(robot3Input.Equals(map.Robots[2]));
            Assert.True(robot3Input.Commands.Equals(map.Robots[2].Commands));
        }

        [Fact]
        public void ShouldThrowGridException()
        {
            // Arrange
            var givenInput = TestDataHelper.GivenCodeChallengeWrongGridCoordinates();

            // Assert
            Assert.Throws<ArgumentException>(() => InputParser.ParseInput(givenInput));
        }

        [Fact]
        public void ShouldThrowRobotException()
        {
            // Arrange
            var givenInput = TestDataHelper.GivenCodeChallengeWrongRobotCoordinates();

            // Assert
            Assert.Throws<ArgumentException>(() => InputParser.ParseInput(givenInput));
        }
    }
}
