using System;

namespace UnitRegistry.Formatting
{
    /// <summary>
    /// Defines a common contract for value formatters.
    /// </summary>
    public interface IValueFormatter
    {
        /// <summary>
        /// Gets the formatter identity.
        /// </summary>
        FormatterId Id { get; }

        /// <summary>
        /// Gets the supported input value type.
        /// </summary>
        Type ValueType { get; }

        /// <summary>
        /// Formats the supplied value.
        /// </summary>
        /// <param name="value">Value to format.</param>
        /// <param name="formatProvider">Optional format provider override.</param>
        /// <returns>Formatted text.</returns>
        string Format(object value, IFormatProvider formatProvider = null);
    }
}
