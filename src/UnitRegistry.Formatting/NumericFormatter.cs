using System;

namespace UnitRegistry.Formatting
{
    /// <summary>
    /// Represents a numeric formatter with explicit identity.
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
        public UnitRegistry UnitRegistry { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumericFormatter"/> class.
        /// </summary>
        /// <param name="id">Stable identity for the formatter.</param>
        /// <param name="unitRegistry">Unit registry for unit lookups and conversion.</param>
        public NumericFormatter(NumericFormatterId id, UnitRegistry unitRegistry)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (unitRegistry == null)
            {
                throw new ArgumentNullException(nameof(unitRegistry));
            }

            Id = id;
            UnitRegistry = unitRegistry;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumericFormatter"/> class.
        /// </summary>
        /// <param name="id">Stable identity value for the formatter.</param>
        /// <param name="unitRegistry">Unit registry for unit lookups and conversion.</param>
        public NumericFormatter(string id, UnitRegistry unitRegistry)
            : this(new NumericFormatterId(id), unitRegistry)
        {
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
