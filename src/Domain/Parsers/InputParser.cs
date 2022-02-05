using Domain.Models;
using Domain.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Domain.Helpers
{
    public static class InputParser
    {
        const int CoordinateXIndex = 1;
        const int CoordinateYIndex = 2;
        const int OrientationIndex = 3;
        const int CommandsIndex = 4;

        /// <summary>
        /// Parses map and robots user input, validating string format
        /// </summary>
        /// <param name="input">The user input</param>
        /// <returns><see cref="Mission"/> object</returns>
        public static Mission ParseInput(string input)
        {
            var mapMatch = Regex.Match(input, GetInputParseRegexForMapInstructions(), RegexOptions.IgnoreCase);
            var robotMatches = Regex.Matches(input, GetInputParseRegexForRobotInstructions(), RegexOptions.Multiline | RegexOptions.IgnoreCase);

            var map = HandleMapMatch(mapMatch);
            var robots = HandleRobotsMatches(robotMatches);
            
            return Mission.Create(map, robots);
        }

        private static Map HandleMapMatch(Match match)
        {
            if (!match.Success || match.Groups.Count != 3)
            {
                throw new ArgumentException("Map input coordinates should go by {X value} {Y value} format");
            }

            return Map.Create(match.Groups[CoordinateXIndex].Value.AsInteger(), match.Groups[CoordinateYIndex].Value.AsInteger());
        }

        private static List<Robot> HandleRobotsMatches(MatchCollection matches)
        {
            var robots = new List<Robot>();
            foreach (Match match in matches)
            {
                if (!match.Success || match.Groups.Count != 5)
                {
                    throw new ArgumentException("Robot input coordinates and orientation should go by {X value} {Y value} {Orientation [NSEW]} format");
                }

                var robot = Robot.Create(match.Groups[CoordinateXIndex].Value.AsInteger(),
                    match.Groups[CoordinateYIndex].Value.AsInteger(),
                    match.Groups[OrientationIndex].Value.GetOrientationFromKeyCode(),
                    match.Groups[CommandsIndex].Value);

                robots.Add(robot);
            }

            return robots;
        }

        private static string GetInputParseRegexForRobotInstructions()
        {
            // \d matches a digit(equivalent to[0 - 9])
            // * matches the previous token between zero and unlimited times, as many times as possible, giving back as needed (greedy)
            // \s matches any whitespace character(equivalent to[\r\n\t\f\v])
            // + matches the previous token between one and unlimited times, as many times as possible, giving back as needed (greedy)
            // [NSEW] matches a single character in the list NSEW
            // [RFL] matches a single character in the list RFL(case sensitive)

            //TODO: FIX adding a character out of the given, breaks regex
            return @"(\d*)\s(\d*)\s([NSEW])\s+([RFL]+)";
        }

        private static string GetInputParseRegexForMapInstructions()
        {
            // \d matches a digit(equivalent to[0 - 9])
            // * matches the previous token between zero and unlimited times, as many times as possible, giving back as needed (greedy)
            // \s matches any whitespace character(equivalent to[\r\n\t\f\v])
            // + matches the previous token between one and unlimited times, as many times as possible, giving back as needed (greedy)

            return @"(\d*)\s(\d*)\s";
        }
    }
}
