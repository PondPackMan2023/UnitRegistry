using System;

namespace UnitRegistry
{
    /// <summary>
    /// Represents a specific measurement unit within a single <see cref="Dimension"/>.
    /// </summary>
    public sealed class Unit : IEquatable<Unit>
    {
        /// <summary>
        /// Gets the stable identity key for this unit.
        /// </summary>
        public string Key { get; }

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
        /// Initializes a new instance of the <see cref="Unit"/> class.
        /// </summary>
        /// <param name="key">Stable identity key for the unit.</param>
        /// <param name="dimension">The dimension this unit belongs to.</param>
        /// <param name="conversionFactor">
        /// Multiplier that converts a value in this unit to the canonical base unit.
        /// Must be a finite positive number.
        /// </param>
        public Unit(string key, Dimension dimension, double conversionFactor)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Unit key must not be null, empty, or whitespace.", nameof(key));
            }

            if (dimension == null)
            {
                throw new ArgumentNullException(nameof(dimension));
            }

            if (double.IsNaN(conversionFactor) || double.IsInfinity(conversionFactor) || conversionFactor <= 0.0)
            {
                throw new ArgumentOutOfRangeException(nameof(conversionFactor), "Conversion factor must be a finite positive number.");
            }

            Key = key;
            Dimension = dimension;
            ConversionFactor = conversionFactor;
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

            return string.Equals(Key, other.Key, StringComparison.Ordinal);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Unit);
        }

        public override int GetHashCode()
        {
            return StringComparer.Ordinal.GetHashCode(Key);
        }

        public override string ToString()
        {
            return Key;
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
