using System;
using System.Globalization;

namespace UnitRegistry.Formatting
{
    /// <summary>
    /// Formats DateTime values according to a fixed formatting intent.
    /// </summary>
    public sealed class DateTimeFormatter : IValueFormatter, IValueParser
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
            get { return typeof(DateTime); }
        }

        /// <summary>
        /// Gets the DateTime format string used by this formatter.
        /// </summary>
        public string FormatString { get; }

        /// <summary>
        /// Gets the default format provider used when none is provided at call time.
        /// </summary>
        public IFormatProvider FormatProvider { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeFormatter"/> class.
        /// </summary>
        /// <param name="id">Stable identity for the formatter.</param>
        /// <param name="formatString">DateTime format string for this formatter intent.</param>
        /// <param name="formatProvider">Default format provider. If null, current culture is used.</param>
        public DateTimeFormatter(FormatterId id, string formatString, IFormatProvider formatProvider = null)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (string.IsNullOrWhiteSpace(formatString))
            {
                throw new ArgumentException("Format string must not be null, empty, or whitespace.", nameof(formatString));
            }

            Id = id;
            FormatString = formatString;
            FormatProvider = formatProvider;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeFormatter"/> class.
        /// </summary>
        /// <param name="id">Stable identity value for the formatter.</param>
        /// <param name="formatString">DateTime format string for this formatter intent.</param>
        /// <param name="formatProvider">Default format provider. If null, current culture is used.</param>
        public DateTimeFormatter(string id, string formatString, IFormatProvider formatProvider = null)
            : this(new FormatterId(id), formatString, formatProvider)
        {
        }

        /// <summary>
        /// Formats a DateTime value.
        /// </summary>
        /// <param name="value">DateTime value to format.</param>
        /// <param name="formatProvider">Optional format provider override.</param>
        /// <returns>A formatted string representation of the value.</returns>
        public string Format(DateTime value, IFormatProvider formatProvider = null)
        {
            IFormatProvider provider = formatProvider ?? FormatProvider ?? CultureInfo.CurrentCulture;
            return value.ToString(FormatString, provider);
        }

        /// <summary>
        /// Formats an object value as DateTime.
        /// </summary>
        /// <param name="value">Value to format.</param>
        /// <param name="formatProvider">Optional format provider override.</param>
        /// <returns>A formatted string representation of the value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not a DateTime.</exception>
        public string Format(object value, IFormatProvider formatProvider = null)
        {
            if (!(value is DateTime))
            {
                throw new ArgumentException("Value must be of type DateTime.", nameof(value));
            }

            return Format((DateTime)value, formatProvider);
        }

        /// <summary>
        /// Attempts to parse text as a DateTime value.
        /// </summary>
        /// <param name="text">Input text to parse.</param>
        /// <param name="formatProvider">Optional format provider override.</param>
        /// <param name="value">When successful, receives the parsed DateTime.</param>
        /// <returns><c>true</c> when parsing succeeds; otherwise <c>false</c>.</returns>
        public bool TryParse(string text, IFormatProvider formatProvider, out object value)
        {
            value = null;

            if (text == null)
            {
                return false;
            }

            IFormatProvider provider = formatProvider ?? FormatProvider ?? CultureInfo.CurrentCulture;
            DateTime parsed;
            bool success = DateTime.TryParse(text, provider, DateTimeStyles.None, out parsed);
            if (!success)
            {
                return false;
            }

            value = parsed;
            return true;
        }
    }
}
