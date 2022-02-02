namespace Tests.Helpers
{
    public static class TestDataHelper
    {
        public static string GetCodeChallengeSampleInput()
        {
            return "5 3\r\n1 1 E\r\nRFRFRFRF\r\n3 2 N\r\nFRRFLLFFRRFLL\r\n0 3 W\r\nLLFFFRFLFL";
        }

        public static string GetCodeChallengeWrongGridCoordinates()
        {
            return "5 A\r\n1 1 E\r\nRFRFRFRF\r\n3 2 N\r\nFRRFLLFFRRFLL\r\n0 3 W\r\nLLFFFRFLFL";
        }

        public static string GetCodeChallengeWrongRobotCoordinates()
        {
            return "5 3\r\n1 2 E\r\nRFRFRFRF\r\nE 2 N\r\nFRRFLLFFRRFLL\r\n0 3 W\r\nLLFFFRFLFL";
        }
    }
}
