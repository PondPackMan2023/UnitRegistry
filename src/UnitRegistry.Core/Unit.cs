using System;

namespace UnitRegistry
{
    /// <summary>
    /// Represents a specific measurement unit within a single <see cref="Dimension"/>.
    /// </summary>
    public sealed class Unit : IEquatable<Unit>
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
        /// Initializes a new instance of the <see cref="Unit"/> class.
        /// </summary>
        /// <param name="id">Stable identity for the unit.</param>
        /// <param name="dimension">The dimension this unit belongs to.</param>
        /// <param name="conversionFactor">
        /// Multiplier that converts a value in this unit to the canonical base unit.
        /// Must be a finite positive number.
        /// </param>
        public Unit(UnitId id, Dimension dimension, double conversionFactor)
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

            Id = id;
            Dimension = dimension;
            ConversionFactor = conversionFactor;
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
        public Unit(string id, Dimension dimension, double conversionFactor)
            : this(new UnitId(id), dimension, conversionFactor)
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
            return Id.ToString();
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
