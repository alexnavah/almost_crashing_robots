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

        public static Mission GivenSampleMissionConfiguration()
        {
            return Mission.Create(GivenSampleMapConfiguration(), GivenSampleRobotsConfiguration());
        }

        public static Mission GivenValidMissionConfiguration()
        {
            return Mission.Create(GivenValidMapConfiguration(), GivenValidRobotsConfiguration());
        }

        public static Mission GivenValidMissionWithRobotsFollowingSamePath()
        {
            return Mission.Create(GivenSampleMapConfiguration(), GivenRobotsWithSamePathConfiguration());
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

        private static List<Robot> GivenSampleRobotsConfiguration()
        {
            return new List<Robot>
            {
                Robot.Create(1, 1, OrientationType.East, "RFRFRFRF"),
                Robot.Create(3, 2, OrientationType.North, "FRRFLLFFRRFLL"),
                Robot.Create(0, 3, OrientationType.West, "LLFFFRFLFL")
            };
        }
        private static List<Robot> GivenRobotsWithSamePathConfiguration()
        {
            return new List<Robot>
            {
                Robot.Create(3, 2, OrientationType.North, "FRRFLLFFRRFLL"),
                Robot.Create(3, 2, OrientationType.North, "FRRFLLFFRRFLL"),
                Robot.Create(3, 2, OrientationType.North, "FRRFLLFFRRFLL")
            };
        }

        private static Map GivenValidMapConfiguration()
        {
            return Map.Create(8, 4);
        }
        private static Map GivenSampleMapConfiguration()
        {
            return Map.Create(5, 3);
        }
    }
}
