using Domain.Helpers;
using Domain.Models;
using Domain.Models.Extensions;
using System;
using Xunit;

namespace Tests.Domain.Parsers
{
    public class InputParserTests
    {
        public InputParserTests()
        {

        }

        [Theory]
        [InlineData(1, 1, "E")]
        [InlineData(3, 2, "N")]
        [InlineData(0, 3, "W")]
        public void ShouldParseRobotCoordinates(int x, int y, string orientation)
        {
            // Arrange
            var output = Robot.Create(x, y, orientation.GetOrientationFromKeyCode());

            // Act
            var result = InputParser.ParseRobotCoordinates($"{x} {y} {orientation}");

            // Assert
            Assert.True(result.Equals(output));
        }

        [Theory]
        [InlineData(1, 1, "A")]
        [InlineData(3, 2, "J")]
        [InlineData(0, 3, "O")]
        public void ShouldThrowExceptionOnWrongRobotCoordinates(int x, int y, string orientation)
        {
            // Arrange
            var input = $"{x} {y} {orientation}";

            // Assert
            Assert.Throws<ArgumentException>(() => InputParser.ParseRobotCoordinates(input));
        }

        [Theory]
        [InlineData("Wrong")]
        [InlineData("Tomato 3")]
        [InlineData("4 Potato 5")]
        public void ShouldThrowExceptionOnWrongRobotInput(string input)
        {
            // Assert
            Assert.Throws<ArgumentException>(() => InputParser.ParseRobotCoordinates(input));
        }
    }
}
