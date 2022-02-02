using System;

namespace Domain.Models.Extensions
{
    public static class StringExtension
    {
        public static int AsInteger(this string value)
        {
            if (int.TryParse(value, out var result))
            {
                return result;
            }

            throw new ArgumentException($"Can not parse {value} to {typeof(int)}");
        }
    }
}
