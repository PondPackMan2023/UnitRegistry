using System;
using System.Globalization;

namespace UnitRegistry.Formatting
{
    /// <summary>
    /// Stateless helpers for creating standard numeric format specifier strings.
    /// </summary>
    public static class NumericFormat
    {
        public static string General()
        {
            return "G";
        }

        public static string Fixed(int precision)
        {
            if (precision < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(precision), "Precision must be non-negative.");
            }

            return "F" + precision.ToString(CultureInfo.InvariantCulture);
        }

        public static string Scientific(int precision)
        {
            if (precision < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(precision), "Precision must be non-negative.");
            }

            return "E" + precision.ToString(CultureInfo.InvariantCulture);
        }

        public static string FixedTrimZeros(int maxDecimals)
        {
            if (maxDecimals < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(maxDecimals),
                    "maxDecimals must be non-negative.");
            }

            return maxDecimals == 0
                ? "0"
                : "0." + new string('#', maxDecimals);
        }        
    }
}