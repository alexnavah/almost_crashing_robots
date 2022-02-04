using Domain.Commands;
using Domain.Helpers;
using Domain.Models.Extensions;
using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var sampleInput = "5 3\r\n1 1 E\r\nRFRFRFRF\r\n3 2 N\r\nFRRFLLFFRRFLL\r\n0 3 W\r\nLLFFFRFLFL";

            Console.WriteLine($"Sample input\r\n{sampleInput}\r\n");

            var parsedInput = InputParser.ParseInput(sampleInput);

            var inputValidationResult = new ValidateMissionCommand().Execute(parsedInput);

            if (!inputValidationResult.Success)
            {
                return;
            }

            var executeMissionResult = new ExecuteMissionCommand().Execute(parsedInput);

            var writtenMissionReport = executeMissionResult.Result.GetWrittenMissionReport();

            Console.WriteLine(writtenMissionReport);
        }
    }
}
