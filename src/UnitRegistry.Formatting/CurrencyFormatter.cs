using System;
using System.Globalization;

namespace UnitRegistry.Formatting
{
    /// <summary>
    /// Formats decimal values using currency formatting conventions.
    /// </summary>
    public sealed class CurrencyFormatter : IValueFormatter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyFormatter"/> class.
        /// </summary>
        /// <param name="id">Stable identity for the formatter.</param>
        /// <param name="formatString">Currency format string for this formatter intent. Defaults to "C2".</param>
        /// <param name="formatProvider">Default format provider. If null, current culture is used.</param>
        public CurrencyFormatter(FormatterId id, string formatString = "C2", IFormatProvider formatProvider = null)
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
        /// Initializes a new instance of the <see cref="CurrencyFormatter"/> class.
        /// </summary>
        /// <param name="id">Stable identity value for the formatter.</param>
        /// <param name="formatString">Currency format string for this formatter intent. Defaults to "C2".</param>
        /// <param name="formatProvider">Default format provider. If null, current culture is used.</param>
        public CurrencyFormatter(string id, string formatString = "C2", IFormatProvider formatProvider = null)
            : this(new FormatterId(id), formatString, formatProvider)
        {
        }

        /// <summary>
        /// Gets the stable identity of this formatter.
        /// </summary>
        public FormatterId Id { get; }

        /// <summary>
        /// Gets the supported value type.
        /// </summary>
        public Type ValueType
        {
            get { return typeof(decimal); }
        }

        /// <summary>
        /// Gets the currency format string used by this formatter.
        /// </summary>
        public string FormatString { get; }

        /// <summary>
        /// Gets the default format provider used when none is provided at call time.
        /// </summary>
        public IFormatProvider FormatProvider { get; }

        /// <summary>
        /// Formats a decimal value as currency.
        /// </summary>
        /// <param name="value">Decimal value to format.</param>
        /// <param name="formatProvider">Optional format provider override.</param>
        /// <returns>A formatted string representation of the value.</returns>
        public string Format(decimal value, IFormatProvider formatProvider = null)
        {
            IFormatProvider provider = formatProvider ?? FormatProvider ?? CultureInfo.CurrentCulture;
            return value.ToString(FormatString, provider);
        }

        /// <summary>
        /// Formats an object value as currency.
        /// </summary>
        /// <param name="value">Value to format.</param>
        /// <param name="formatProvider">Optional format provider override.</param>
        /// <returns>A formatted string representation of the value.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not a decimal.</exception>
        public string Format(object value, IFormatProvider formatProvider = null)
        {
            if (!(value is decimal))
            {
                throw new ArgumentException("Value must be of type decimal.", nameof(value));
            }

            return Format((decimal)value, formatProvider);
        }
    }
}
