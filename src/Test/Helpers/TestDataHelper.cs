using Domain.Models;
using System;
using System.Collections.Generic;

namespace Tests.Helpers
{
    public static class TestDataHelper
    {
        public static string GivenCodeChallengeSampleInput()
        {
            return "5 3\r\n1 1 E\r\nRFRFRFRF\r\n3 2 N\r\nFRRFLLFFRRFLL\r\n0 3 W\r\nLLFFFRFLFL";
        }

        public static string GivenCodeChallengeWrongGridCoordinates()
        {
            return "5 A\r\n1 1 E\r\nRFRFRFRF\r\n3 2 N\r\nFRRFLLFFRRFLL\r\n0 3 W\r\nLLFFFRFLFL";
        }

        public static string GivenCodeChallengeWrongRobotCoordinates()
        {
            return "5 3\r\n1 2 E\r\nRFRFRFRF\r\nE 2 N\r\nFRRFLLFFRRFLL\r\n0 3 W\r\nLLFFFRFLFL";
        }

        public static PlanetMap GivenValidMapConfiguration()
        {
            return PlanetMap.Create(GivenValidGridConfiguration(), GivenValidRobotsConfiguration());
        }

        private static List<Robot> GivenValidRobotsConfiguration()
        {
            return new List<Robot>
            {
                Robot.Create(1, 1, OrientationType.East, "FRFR"),
                Robot.Create(3, 2, OrientationType.North, ""),
                Robot.Create(0, 3, OrientationType.West)
            };
        }

        private static Grid GivenValidGridConfiguration()
        {
            return Grid.Create(5, 3);
        }
    }
}
