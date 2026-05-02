using System;
using System.Globalization;

namespace UnitRegistry.Formatting
{
    /// <summary>
    /// Formats TimeSpan values using a clock-style duration format.
    /// </summary>
    public sealed class DurationClockFormatter : IValueFormatter, IValueParser
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

        /// <summary>
        /// Attempts to parse explicit clock-style duration text.
        /// </summary>
        /// <param name="text">Input text to parse.</param>
        /// <param name="formatProvider">Optional format provider override.</param>
        /// <param name="value">When successful, receives the parsed TimeSpan.</param>
        /// <returns><c>true</c> when parsing succeeds; otherwise <c>false</c>.</returns>
        public bool TryParse(string text, IFormatProvider formatProvider, out object value)
        {
            value = null;

            if (text == null)
            {
                return false;
            }

            string trimmed = text.Trim();
            if (trimmed.Length == 0)
            {
                return false;
            }

            string[] tokens = trimmed.Split(':');
            if (tokens.Length == 0 || tokens.Length > 4)
            {
                return false;
            }

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i].Length == 0)
                {
                    return false;
                }
            }

            IFormatProvider provider = formatProvider ?? CultureInfo.CurrentCulture;
            long[] components = new long[tokens.Length];
            for (int i = 0; i < tokens.Length; i++)
            {
                long component;
                bool parsed = long.TryParse(tokens[i], NumberStyles.Integer, provider, out component);
                if (!parsed || component < 0)
                {
                    return false;
                }

                components[i] = component;
            }

            long days = 0;
            long hours = 0;
            long minutes = 0;
            long seconds = 0;

            if (components.Length == 1)
            {
                seconds = components[0];
            }
            else if (components.Length == 2)
            {
                minutes = components[0];
                seconds = components[1];
            }
            else if (components.Length == 3)
            {
                hours = components[0];
                minutes = components[1];
                seconds = components[2];
            }
            else
            {
                days = components[0];
                hours = components[1];
                minutes = components[2];
                seconds = components[3];
            }

            if (seconds > 59 || minutes > 59)
            {
                return false;
            }

            if (components.Length == 4 && hours > 23)
            {
                return false;
            }

            try
            {
                checked
                {
                    long totalSeconds = seconds + (minutes * 60L) + (hours * 3600L) + (days * 86400L);
                    long ticks = totalSeconds * TimeSpan.TicksPerSecond;
                    value = new TimeSpan(ticks);
                    return true;
                }
            }
            catch (OverflowException)
            {
                return false;
            }
        }
    }
}
