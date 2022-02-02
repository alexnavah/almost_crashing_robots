using Domain.Models;
using Domain.Models.Extensions;
using System;
using System.Text.RegularExpressions;

namespace Domain.Helpers
{
    public static class InputParser
    {
        public static void ParseInput(string input, int maxGridSize = 50, int maxRobotInstructionsLength = 100)
        {

        }

        public static Robot ParseRobotCoordinates(string input)
        {
            // Pattern number-whitespace-number-whitespace-orientation separated into groups for easier use later
            const string robotPattern = @"^(\d*)\s(\d*)\s([NSEW])$";

            var match = Regex.Match(input, robotPattern, RegexOptions.IgnoreCase);

            if (!match.Success || match.Groups.Count != 4)
            {
                throw new ArgumentException("Robot input coordinates and orientation should go by {X value} {Y value} {Orientation [NSEW]} format");
            }

            var orientation = match.Groups[3].Value.GetOrientationFromKeyCode();

            return Robot.Create(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value), orientation);       
        }
    }
}
