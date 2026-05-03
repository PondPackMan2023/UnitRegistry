using System;
using System.Diagnostics;

namespace UnitRegistry
{
    /// <summary>
    /// Represents a specific measurement unit within a single <see cref="Dimension"/>.
    /// </summary>
    [DebuggerDisplay("{Label} ({Id})")]
    public sealed class Unit : IEquatable<Unit>, ILabel
    {
        /// <summary>
        /// Gets the stable identity of this unit.
        /// </summary>
        public UnitId Id { get; }

        /// <summary>
        /// Gets the dimension this unit belongs to.
        /// </summary>
        public Dimension Dimension { get; }

        /// <summary>
        /// Gets the factor by which a value in this unit must be multiplied to obtain the
        /// equivalent value in the canonical base unit of its dimension.
        /// </summary>
        public double ConversionFactor { get; }

        /// <summary>
        /// Gets the display label for this unit.
        /// </summary>
        public string Label { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Unit"/> class.
        /// </summary>
        /// <param name="id">Stable identity for the unit.</param>
        /// <param name="dimension">The dimension this unit belongs to.</param>
        /// <param name="conversionFactor">
        /// Multiplier that converts a value in this unit to the canonical base unit.
        /// Must be a finite positive number.
        /// </param>
        /// <param name="label">Display label for the unit. May be empty but not null.</param>
        public Unit(UnitId id, Dimension dimension, double conversionFactor, string label)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (dimension == null)
            {
                throw new ArgumentNullException(nameof(dimension));
            }

            if (double.IsNaN(conversionFactor) || double.IsInfinity(conversionFactor) || conversionFactor <= 0.0)
            {
                throw new ArgumentOutOfRangeException(nameof(conversionFactor), "Conversion factor must be a finite positive number.");
            }

            if (label == null)
            {
                throw new ArgumentNullException(nameof(label));
            }

            Id = id;
            Dimension = dimension;
            ConversionFactor = conversionFactor;
            Label = label;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Unit"/> class.
        /// </summary>
        /// <param name="id">Stable identity value for the unit.</param>
        /// <param name="dimension">The dimension this unit belongs to.</param>
        /// <param name="conversionFactor">
        /// Multiplier that converts a value in this unit to the canonical base unit.
        /// Must be a finite positive number.
        /// </param>
        /// <param name="label">Display label for the unit. May be empty but not null.</param>
        public Unit(string id, Dimension dimension, double conversionFactor, string label)
            : this(new UnitId(id), dimension, conversionFactor, label)
        {
        }

        /// <summary>
        /// Converts a value expressed in this unit to the canonical base unit of this unit's dimension.
        /// </summary>
        public double ToBaseValue(double value)
        {
            return value * ConversionFactor;
        }

        /// <summary>
        /// Converts a value expressed in the canonical base unit of this unit's dimension back to this unit.
        /// </summary>
        public double FromBaseValue(double value)
        {
            return value / ConversionFactor;
        }

        public bool Equals(Unit other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Unit);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Label;
        }

        public static bool operator ==(Unit left, Unit right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Unit left, Unit right)
        {
            return !Equals(left, right);
        }
    }
}
