using Domain.Models;
using System.Collections.Generic;

namespace Tests.Helpers
{
    public static class TestDataHelper
    {
        public static string GivenCodeChallengeSampleInput()
        {
            return "5 3\r\n1 1 E\r\nRFRFRFRF\r\n3 2 N\r\nFRRFLLFFRRFLL\r\n0 3 W\r\nLLFFFRFLFL";
        }

        public static string GivenCodeChallengeWrongMapCoordinates()
        {
            return "5 A\r\n1 1 E\r\nRFRFRFRF\r\n3 2 N\r\nFRRFLLFFRRFLL\r\n0 3 W\r\nLLFFFRFLFL";
        }

        public static string GivenCodeChallengeWrongRobotCoordinates()
        {
            return "5 3\r\n1 2 E\r\nRFRFRFRF\r\nE 2 N\r\nFRRFLLFFRRFLL\r\n0 3 W\r\nLLFFFRFLFL";
        }

        public static Mission GivenValidMissionConfiguration()
        {
            return Mission.Create(GivenValidMapConfiguration(), GivenValidRobotsConfiguration());
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

        private static Map GivenValidMapConfiguration()
        {
            return Map.Create(5, 3);
        }
    }
}
