using System;
using System.Globalization;

namespace UnitRegistry.Formatting
{
    /// <summary>
    /// Formats TimeSpan values using a clock-style duration format.
    /// </summary>
    public sealed class DurationClockFormatter : IValueFormatter
    {
        /// <summary>
        /// Gets the stable identity of this formatter.
        /// </summary>
        public FormatterId Id { get; }

        /// <summary>
        /// Gets the supported value type.
        /// </summary>
        public Type ValueType
        {
            get { return typeof(TimeSpan); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DurationClockFormatter"/> class.
        /// </summary>
        /// <param name="id">Stable identity for the formatter.</param>
        public DurationClockFormatter(FormatterId id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Id = id;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DurationClockFormatter"/> class.
        /// </summary>
        /// <param name="id">Stable identity value for the formatter.</param>
        public DurationClockFormatter(string id)
            : this(new FormatterId(id))
        {
        }

        /// <summary>
        /// Formats a TimeSpan value as HH:mm:ss.
        /// </summary>
        /// <param name="value">TimeSpan value to format.</param>
        /// <returns>A clock-style duration string.</returns>
        public string Format(TimeSpan value)
        {
            bool isNegative = value < TimeSpan.Zero;
            TimeSpan normalized = isNegative ? value.Duration() : value;
            long totalHours = (long)normalized.TotalHours;

            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}{1:00}:{2:00}:{3:00}",
                isNegative ? "-" : string.Empty,
                totalHours,
                normalized.Minutes,
                normalized.Seconds);
        }

        /// <summary>
        /// Formats an object value as TimeSpan.
        /// </summary>
        /// <param name="value">Value to format.</param>
        /// <param name="formatProvider">Ignored. Included to satisfy IValueFormatter.</param>
        /// <returns>A clock-style duration string.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not a TimeSpan.</exception>
        public string Format(object value, IFormatProvider formatProvider = null)
        {
            if (!(value is TimeSpan))
            {
                throw new ArgumentException("Value must be of type TimeSpan.", nameof(value));
            }

            return Format((TimeSpan)value);
        }
    }
}
