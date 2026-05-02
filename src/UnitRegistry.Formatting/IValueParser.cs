using System;

namespace UnitRegistry.Formatting
{
    /// <summary>
    /// Defines an optional parsing capability for formatter types.
    /// </summary>
    public interface IValueParser
    {
        /// <summary>
        /// Gets the supported input and output value type.
        /// </summary>
        Type ValueType { get; }

        /// <summary>
        /// Attempts to parse text into a strongly-typed value.
        /// </summary>
        /// <param name="text">Input text to parse.</param>
        /// <param name="formatProvider">Optional format provider override.</param>
        /// <param name="value">When successful, receives the parsed value.</param>
        /// <returns><c>true</c> when parsing succeeds; otherwise <c>false</c>.</returns>
        bool TryParse(string text, IFormatProvider formatProvider, out object value);
    }
}
