using System;

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
    }
}
