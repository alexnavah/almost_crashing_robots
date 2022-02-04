using Domain.Models.Interfaces;
using System;

namespace Domain.Models.Extensions
{
    public static class RobotCommandTypeExtensions
    {
        public static RobotCommandType GetRobotCommandFromKeyCode(this string code) => code.ToUpper() switch
        {
            "F" => RobotCommandType.Forward,
            "R" => RobotCommandType.RotateRight,
            "L" => RobotCommandType.RotateLeft,
            _ => throw new ArgumentException($"Valid robot commands are F R L"),
        };
        public static IRobotInstruction GetRobotCommandInstance(this RobotCommandType type) => type switch
        {
            RobotCommandType.Forward => MoveForwardInstruction.Instance,
            RobotCommandType.RotateRight => RotateRightInstruction.Instance,
            RobotCommandType.RotateLeft => RotateLeftInstruction.Instance,
            _ => throw new ArgumentException($"Valid robot commands are F R L"),
        };
    }
}
