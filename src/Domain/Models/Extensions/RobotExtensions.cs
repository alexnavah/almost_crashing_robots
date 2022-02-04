using Domain.Models.Interfaces;
using System.Collections.Generic;

namespace Domain.Models.Extensions
{
    public static class RobotExtensions
    {
        public static void RotateLeft(this Robot robot)
        {
            robot.SetOrientation(robot.Orientation.RotateCounterclockwise());
        }

        public static void RotateRight(this Robot robot)
        {
            robot.SetOrientation(robot.Orientation.RotateClockwise());
        }

        public static Coordinates GetForwardCoordinates(this Robot robot)
        {
            var orientation = robot.Orientation;

            // When robot faces West or East it moves in axis X, as it would happen on axis Y with North and South orientation
            var yAxisTiles = orientation.Equals(OrientationType.North) || orientation.Equals(OrientationType.South) ? robot.Steps : 0;
            var xAxisTiles = orientation.Equals(OrientationType.West) || orientation.Equals(OrientationType.East) ? robot.Steps : 0;

            // When moving towards South or West, we are facing a negative vector from a (0,0) to (-1, 0), for example
            if (orientation.Equals(OrientationType.South))
            {
                yAxisTiles *= -1;
            }

            if (orientation.Equals(OrientationType.West))
            {
                xAxisTiles *= -1;
            }

            return robot.Coordinates + Coordinates.Create(xAxisTiles, yAxisTiles);
        }

        public static Queue<IRobotInstruction> GetCommands(this Robot robot)
        {
            var commandsQueue = new Queue<IRobotInstruction>();

            foreach(var command in robot.Commands)
            {
                var robotCommandType = command.ToString().GetRobotCommandFromKeyCode();
                var robotCommand = robotCommandType.GetRobotCommandInstance();
                commandsQueue.Enqueue(robotCommand);
            }

            return commandsQueue;
        }

    }
}
