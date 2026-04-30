using System;

namespace UnitRegistry.Formatting
{
    /// <summary>
    /// Represents a numeric formatter with explicit identity and formatting policy.
    /// </summary>
    /// <remarks>
    /// A NumericFormatter is responsible for combining numeric values with display units
    /// and presentation rules. It serves as the extension point for formatting behavior
    /// while keeping the core unit and dimension semantics in UnitRegistry.Core.
    /// </remarks>
    public class NumericFormatter
    {
        /// <summary>
        /// Gets the stable identity of this formatter.
        /// </summary>
        public NumericFormatterId Id { get; }

        /// <summary>
        /// Gets the unit registry used for unit lookups and conversion.
        /// </summary>
        public UnitsRegistry UnitRegistry { get; }

        /// <summary>
        /// Gets the required display label for this formatter.
        /// </summary>
        public string Label { get; }

        /// <summary>
        /// Gets the numeric format specifier used by this formatter.
        /// </summary>
        /// <remarks>
        /// Examples: "F2" for fixed with 2 decimal places, "E3" for scientific notation,
        /// "G" for general format, "N" for number format, etc.
        /// </remarks>
        public string FormatSpecifier { get; }

        /// <summary>
        /// Gets the format provider (culture) used by this formatter.
        /// </summary>
        /// <remarks>
        /// If null, the current culture is used for formatting.
        /// </remarks>
        public IFormatProvider FormatProvider { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumericFormatter"/> class.
        /// </summary>
        /// <param name="id">Stable identity for the formatter.</param>
        /// <param name="unitRegistry">Unit registry for unit lookups and conversion.</param>
        /// <param name="label">Display label for the formatter. Must not be null or empty.</param>
        /// <param name="formatSpecifier">Numeric format specifier (e.g., "F2", "E3", "G"). Defaults to "G".</param>
        /// <param name="formatProvider">Format provider for culture-specific formatting. If null, uses current culture.</param>
        public NumericFormatter(
            NumericFormatterId id,
            UnitsRegistry unitRegistry,
            string label,
            string formatSpecifier = "G",
            IFormatProvider formatProvider = null)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (unitRegistry == null)
            {
                throw new ArgumentNullException(nameof(unitRegistry));
            }

            if (label == null)
            {
                throw new ArgumentNullException(nameof(label));
            }

            if (label.Length == 0)
            {
                throw new ArgumentException("Label must not be empty.", nameof(label));
            }

            if (string.IsNullOrWhiteSpace(formatSpecifier))
            {
                throw new ArgumentException("Format specifier must not be null, empty, or whitespace.", nameof(formatSpecifier));
            }

            Id = id;
            UnitRegistry = unitRegistry;
            Label = label;
            FormatSpecifier = formatSpecifier;
            FormatProvider = formatProvider;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumericFormatter"/> class.
        /// </summary>
        /// <param name="id">Stable identity value for the formatter.</param>
        /// <param name="unitRegistry">Unit registry for unit lookups and conversion.</param>
        /// <param name="label">Display label for the formatter. Must not be null or empty.</param>
        /// <param name="formatSpecifier">Numeric format specifier (e.g., "F2", "E3", "G"). Defaults to "G".</param>
        /// <param name="formatProvider">Format provider for culture-specific formatting. If null, uses current culture.</param>
        public NumericFormatter(
            string id,
            UnitsRegistry unitRegistry,
            string label,
            string formatSpecifier = "G",
            IFormatProvider formatProvider = null)
            : this(new NumericFormatterId(id), unitRegistry, label, formatSpecifier, formatProvider)
        {
        }

        /// <summary>
        /// Formats a numeric value.
        /// </summary>
        /// <param name="value">The numeric value to format.</param>
        /// <returns>A formatted string representation of the value.</returns>
        public string Format(double value)
        {
            return value.ToString(FormatSpecifier, FormatProvider);
        }

        /// <summary>
        /// Formats a numeric value by converting it from the source unit to a display unit.
        /// </summary>
        /// <param name="value">The numeric value to format, expressed in the source unit.</param>
        /// <param name="sourceUnit">The unit the value is expressed in.</param>
        /// <param name="displayUnit">The unit to convert and display the value in.</param>
        /// <returns>A formatted string representation of the converted value.</returns>
        /// <exception cref="InvalidOperationException">Thrown if source and display units belong to different dimensions.</exception>
        public string Format(double value, Unit sourceUnit, Unit displayUnit)
        {
            if (sourceUnit == null)
            {
                throw new ArgumentNullException(nameof(sourceUnit));
            }

            if (displayUnit == null)
            {
                throw new ArgumentNullException(nameof(displayUnit));
            }

            if (!sourceUnit.Dimension.Equals(displayUnit.Dimension))
            {
                throw new InvalidOperationException(
                    "Source unit and display unit must belong to the same dimension.");
            }

            // Convert: value in source unit -> base unit -> display unit
            double baseValue = sourceUnit.ToBaseValue(value);
            double displayValue = displayUnit.FromBaseValue(baseValue);

            return displayValue.ToString(FormatSpecifier, FormatProvider);
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
