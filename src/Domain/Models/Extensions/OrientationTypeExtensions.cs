using System;
using System.Linq;

namespace Domain.Models.Extensions
{
    public static class OrientationTypeExtensions
    {
        public static OrientationType GetOrientationFromKeyCode(this string code) => code.ToUpper() switch
        {
            "N" => OrientationType.North,
            "S" => OrientationType.South,
            "E" => OrientationType.East,
            "W" => OrientationType.West,
            _ => throw new ArgumentException($"Valid orientations are N S E W"),
        };
        
        public static string GetKeyCode(this OrientationType type) => type switch
        {
            OrientationType.North => "N",
            OrientationType.South => "S",
            OrientationType.East => "E",
            OrientationType.West => "W",
            _ => throw new ArgumentException($"Valid orientations are N S E W"),
        };

        public static OrientationType RotateCounterclockwise(this OrientationType orientationType)
        {
            return Rotate(orientationType, -1);
        }

        public static OrientationType RotateClockwise(this OrientationType orientationType)
        {
            return Rotate(orientationType, 1);
        }

        private static OrientationType Rotate(OrientationType orientationType, int rotationTimes)
        {
            var minEnumValue = (int)Enum.GetValues(typeof(OrientationType)).Cast<OrientationType>().Min();
            var maxEnumValue = (int)Enum.GetValues(typeof(OrientationType)).Cast<OrientationType>().Max();
            var nextOrientation = (int)orientationType + rotationTimes;

            if (nextOrientation > maxEnumValue)
            {
                nextOrientation = minEnumValue;
            }
            else if (nextOrientation < minEnumValue)
            {
                nextOrientation = maxEnumValue;
            }

            return (OrientationType)nextOrientation;
        }
    }
}
