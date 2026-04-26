using System;
using System.Collections.Generic;

namespace UnitRegistry
{
    /// <summary>
    /// Provides explicit registration, lookup, and discovery for known units.
    /// </summary>
    public class UnitsRegistry
    {
        private static readonly Lazy<UnitsRegistry> s_default = new Lazy<UnitsRegistry>(CreateDefault);

        private readonly Dictionary<Dimension, Dictionary<UnitId, Unit>> unitsByDimension;
        private readonly Dictionary<Dimension, Unit> baseUnitsByDimension;

        public UnitsRegistry()
        {
            unitsByDimension = new Dictionary<Dimension, Dictionary<UnitId, Unit>>();
            baseUnitsByDimension = new Dictionary<Dimension, Unit>();
        }

        /// <summary>
        /// Gets the lazily initialized built-in registry.
        /// </summary>
        public static UnitsRegistry Default
        {
            get { return s_default.Value; }
        }

        /// <summary>
        /// Gets a value indicating whether this registry can still be mutated.
        /// </summary>
        public bool IsReadOnly { get; private set; }

        /// <summary>
        /// Registers a non-base unit in the registry.
        /// </summary>
        public void Register(Unit unit)
        {
            Register(unit, false);
        }

        /// <summary>
        /// Registers the canonical base unit for a dimension.
        /// </summary>
        public void RegisterBaseUnit(Unit unit)
        {
            Register(unit, true);
        }

        /// <summary>
        /// Prevents any further mutation of this registry.
        /// </summary>
        public void Freeze()
        {
            foreach (var entry in unitsByDimension)
            {
                if (!baseUnitsByDimension.ContainsKey(entry.Key))
                {
                    throw new InvalidOperationException(
                        "A base unit must be registered for each dimension before the registry can be frozen.");
                }
            }

            IsReadOnly = true;
        }

        /// <summary>
        /// Looks up a unit by dimension and stable unit identifier.
        /// </summary>
        public bool TryGetUnit(Dimension dimension, UnitId unitId, out Unit unit)
        {
            ValidateDimension(dimension);
            ValidateUnitId(unitId);

            Dictionary<UnitId, Unit> units;
            if (unitsByDimension.TryGetValue(dimension, out units))
            {
                return units.TryGetValue(unitId, out unit);
            }

            unit = null;
            return false;
        }

        /// <summary>
        /// Gets a unit by dimension and stable unit identifier.
        /// </summary>
        public Unit GetUnit(Dimension dimension, UnitId unitId)
        {
            Unit unit;
            if (TryGetUnit(dimension, unitId, out unit))
            {
                return unit;
            }

            throw new KeyNotFoundException("The requested unit is not registered for the specified dimension.");
        }

        /// <summary>
        /// Gets the canonical base unit for the specified dimension.
        /// </summary>
        public Unit GetBaseUnit(Dimension dimension)
        {
            ValidateDimension(dimension);

            Unit unit;
            if (baseUnitsByDimension.TryGetValue(dimension, out unit))
            {
                return unit;
            }

            throw new InvalidOperationException("No base unit is registered for the specified dimension.");
        }

        /// <summary>
        /// Gets the units registered for the specified dimension.
        /// </summary>
        public IEnumerable<Unit> GetUnits(Dimension dimension)
        {
            ValidateDimension(dimension);

            Dictionary<UnitId, Unit> units;
            if (!unitsByDimension.TryGetValue(dimension, out units))
            {
                return Array.Empty<Unit>();
            }

            var values = new Unit[units.Count];
            units.Values.CopyTo(values, 0);
            return values;
        }

        private void Register(Unit unit, bool isBaseUnit)
        {
            EnsureMutable();

            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit));
            }

            ValidateDimension(unit.Dimension);

            Dictionary<UnitId, Unit> units;
            if (!unitsByDimension.TryGetValue(unit.Dimension, out units))
            {
                units = new Dictionary<UnitId, Unit>();
                unitsByDimension.Add(unit.Dimension, units);
            }

            if (units.ContainsKey(unit.Id))
            {
                throw new InvalidOperationException(
                    "A unit with the same identifier is already registered for the specified dimension.");
            }

            if (isBaseUnit && baseUnitsByDimension.ContainsKey(unit.Dimension))
            {
                throw new InvalidOperationException(
                    "A base unit is already registered for the specified dimension.");
            }

            units.Add(unit.Id, unit);

            if (isBaseUnit)
            {
                baseUnitsByDimension.Add(unit.Dimension, unit);
            }
        }

        private void EnsureMutable()
        {
            if (IsReadOnly)
            {
                throw new InvalidOperationException("This registry is read-only.");
            }
        }

        private static void ValidateDimension(Dimension dimension)
        {
            if (dimension == null)
            {
                throw new ArgumentNullException(nameof(dimension));
            }
        }

        private static void ValidateUnitId(UnitId unitId)
        {
            if (unitId == null)
            {
                throw new ArgumentNullException(nameof(unitId));
            }
        }

        private static UnitsRegistry CreateDefault()
        {
            var registry = new UnitsRegistry();

            registry.RegisterBaseUnit(Units.Length.Meter);
            registry.Register(Units.Length.Millimeter);
            registry.Register(Units.Length.Foot);

            registry.RegisterBaseUnit(Units.Time.Second);
            registry.Register(Units.Time.Minute);
            registry.Register(Units.Time.Hour);

            registry.Freeze();
            return registry;
        }
    }
}