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
registry.RegisterBaseUnit(Units.NoDimension.None);
registry.RegisterBaseUnit(Units.Volume.CubicMeters);
registry.Register(Units.Volume.AcreFeet);
registry.Register(Units.Volume.AcreInches);
registry.Register(Units.Volume.CubicCentimeters);
registry.Register(Units.Volume.CubicFeet);
registry.Register(Units.Volume.CubicInches);
registry.Register(Units.Volume.CubicYards);
registry.Register(Units.Volume.Gallons);
registry.Register(Units.Volume.ImpGallons);
registry.Register(Units.Volume.Liters);
registry.Register(Units.Volume.MillionGallons);
registry.Register(Units.Volume.MillionLiters);
registry.Register(Units.Volume.ThousandGallons);
registry.Register(Units.Volume.ThousandLiters);
registry.RegisterBaseUnit(Units.Flow.CubicMetersPerSecond);
registry.Register(Units.Flow.AcreFeetPerDay);
registry.Register(Units.Flow.AcreFeetPerHour);
registry.Register(Units.Flow.AcreFeetPerMinute);
registry.Register(Units.Flow.AcreInchPerHour);
registry.Register(Units.Flow.AcreInchPerMinute);
registry.Register(Units.Flow.Cfm);
registry.Register(Units.Flow.Cfs);
registry.Register(Units.Flow.CubicFeetPerDay);
registry.Register(Units.Flow.CubicFeetPerMinute);
registry.Register(Units.Flow.CubicFeetPerSecond);
registry.Register(Units.Flow.CubicMetersPerDay);
registry.Register(Units.Flow.CubicMetersPerHour);
registry.Register(Units.Flow.CubicMetersPerMinute);
registry.Register(Units.Flow.GallonsPerDay);
registry.Register(Units.Flow.GallonsPerMinute);
registry.Register(Units.Flow.GallonsPerSecond);
registry.Register(Units.Flow.Gpm);
registry.Register(Units.Flow.ImperialGallonsPerDay);
registry.Register(Units.Flow.ImperialGallonsPerMinute);
registry.Register(Units.Flow.ImperialGallonsPerSecond);
registry.Register(Units.Flow.LitersPerDay);
registry.Register(Units.Flow.LitersPerMinute);
registry.Register(Units.Flow.LitersPerSecond);
registry.Register(Units.Flow.MegaLitersPerDay);
registry.Register(Units.Flow.Mgd);
registry.Register(Units.Flow.MgdImperial);
registry.Register(Units.Flow.MillionLitersPerDay);
registry.Register(Units.Flow.Gpd);
registry.Register(Units.Flow.LitersPerHour);
registry.RegisterBaseUnit(Units.Area.SquareMeters);
registry.Register(Units.Area.Acres);
registry.Register(Units.Area.Hectares);
registry.Register(Units.Area.SquareCentimeters);
registry.Register(Units.Area.SquareFeet);
registry.Register(Units.Area.SquareInches);
registry.Register(Units.Area.SquareKilometers);
registry.Register(Units.Area.SquareMiles);
registry.Register(Units.Area.SquareMillimeters);
registry.Register(Units.Area.SquareYards);
registry.Register(Units.Area.ThousandSquareFeet);
registry.RegisterBaseUnit(Units.Angle.AngleRadians);
registry.Register(Units.Angle.AngleDegrees);
registry.Register(Units.Angle.AngleMinutes);
registry.Register(Units.Angle.AngleQuadrants);
registry.Register(Units.Angle.AngleRevolutions);
registry.Register(Units.Angle.AngleSeconds);
registry.RegisterBaseUnit(Units.Pressure.KiloPascals);
registry.Register(Units.Pressure.Atmospheres);
registry.Register(Units.Pressure.Bars);
registry.Register(Units.Pressure.FeetOfH2O);
registry.Register(Units.Pressure.KilogramsPerSquareCentimeter);
registry.Register(Units.Pressure.MetersOfH2O);
registry.Register(Units.Pressure.MillimetersOfH2O);
registry.Register(Units.Pressure.NewtonsPerSquareMeter);
registry.Register(Units.Pressure.PoundsPerSquareFoot);
registry.Register(Units.Pressure.PoundsPerSquareInch);
registry.Register(Units.Pressure.Psi);
registry.Register(Units.Pressure.KilogramsPerSquareMeter);
registry.Register(Units.Pressure.Pascals);
registry.Register(Units.Pressure.HektoPascals);
registry.Register(Units.Pressure.MegaPascals);
registry.Register(Units.Pressure.MilliBars);
registry.RegisterBaseUnit(Units.Population.Capita);
registry.Register(Units.Population.Customer);
registry.Register(Units.Population.Employee);
registry.Register(Units.Population.Guest);
registry.Register(Units.Population.HundredCapita);
registry.Register(Units.Population.Passenger);
registry.Register(Units.Population.Person);
registry.Register(Units.Population.Resident);
registry.Register(Units.Population.Student);
registry.Register(Units.Population.ThousandCapita);
registry.RegisterBaseUnit(Units.Length.Meters);
registry.Register(Units.Length.Centimeters);
registry.Register(Units.Length.Decimeters);
registry.Register(Units.Length.Feet);
registry.Register(Units.Length.Inches);
registry.Register(Units.Length.Kilometers);
registry.Register(Units.Length.Mfeet);
registry.Register(Units.Length.Miles);
registry.Register(Units.Length.Millifeet);
registry.Register(Units.Length.Millimeters);
registry.Register(Units.Length.Yards);
registry.Register(Units.Length.UsSurveyFoot);
registry.RegisterBaseUnit(Units.RainfallIntensity.MilliMetersPerMinute);
registry.Register(Units.RainfallIntensity.CentimetersPerDay);
registry.Register(Units.RainfallIntensity.CentimetersPerHour);
registry.Register(Units.RainfallIntensity.CentimetersPerMinute);
registry.Register(Units.RainfallIntensity.InchesPerDay);
registry.Register(Units.RainfallIntensity.InchesPerHour);
registry.Register(Units.RainfallIntensity.InchesPerMinute);
registry.Register(Units.RainfallIntensity.MilliMetersPerDay);
registry.Register(Units.RainfallIntensity.MilliMetersPerHour);
registry.Register(Units.RainfallIntensity.MicrometersPerSecond);
registry.RegisterBaseUnit(Units.Diffusivity.SquareMetersPerSecond);
registry.Register(Units.Diffusivity.Centistokes);
registry.Register(Units.Diffusivity.SquareFeetPerSecond);
registry.Register(Units.Diffusivity.Stokes);
registry.RegisterBaseUnit(Units.FlowDensityPerArea.LitersPerSquareMeterPerDay);
registry.Register(Units.FlowDensityPerArea.CfsPerAcres);
registry.Register(Units.FlowDensityPerArea.CfsPerSquareFeet);
registry.Register(Units.FlowDensityPerArea.CfsPerSquareMiles);
registry.Register(Units.FlowDensityPerArea.CubicMetersPerHectaresPerDay);
registry.Register(Units.FlowDensityPerArea.CubicMetersPerSquareKilometerPerDay);
registry.Register(Units.FlowDensityPerArea.CubicMetersPerSquareMeterPerDay);
registry.Register(Units.FlowDensityPerArea.GpdPerAcres);
registry.Register(Units.FlowDensityPerArea.GpdPerSquareFeet);
registry.Register(Units.FlowDensityPerArea.GpdPerSquareMiles);
registry.Register(Units.FlowDensityPerArea.GpmPerAcres);
registry.Register(Units.FlowDensityPerArea.GpmPerSquareFeet);
registry.Register(Units.FlowDensityPerArea.GpmPerSquareMiles);
registry.Register(Units.FlowDensityPerArea.LitersPerHectaresPerDay);
registry.Register(Units.FlowDensityPerArea.LitersPerSquareKilometerPerDay);
registry.Register(Units.FlowDensityPerArea.LitersPerHectaresPerSecond);
registry.RegisterBaseUnit(Units.Time.Hours);
registry.Register(Units.Time.Days);
registry.Register(Units.Time.Minutes);
registry.Register(Units.Time.Seconds);
registry.Register(Units.Time.Years);
registry.Register(Units.Time.Milliseconds);
registry.RegisterBaseUnit(Units.Currency.Dollars);
registry.RegisterBaseUnit(Units.CurrencyPerLength.DollarsPerMeter);
registry.Register(Units.CurrencyPerLength.DollarsPerFoot);
registry.RegisterBaseUnit(Units.CurrencyPerEnergy.DollarsPerKiloWattHour);
registry.RegisterBaseUnit(Units.SurfaceReactionRate.MetersPerSecond);
registry.Register(Units.SurfaceReactionRate.FeetPerDay);
registry.Register(Units.SurfaceReactionRate.MetersPerDay);
registry.RegisterBaseUnit(Units.Scale.MetersPerCm);
registry.Register(Units.Scale.FeetPerInch);
registry.RegisterBaseUnit(Units.Energy.Joules);
registry.Register(Units.Energy.FootPoundals);
registry.Register(Units.Energy.KiloJoules);
registry.Register(Units.Energy.KiloWattHours);
registry.Register(Units.Energy.MegaJoules);
registry.Register(Units.Energy.GigaJoules);
registry.Register(Units.Energy.WattSeconds);
registry.Register(Units.Energy.MegaWattHours);
registry.Register(Units.Energy.GigaWattHours);
registry.RegisterBaseUnit(Units.FlowDensityPerCapita.LitersPerCapitaPerDay);
registry.Register(Units.FlowDensityPerCapita.GpdPerCapita);
registry.RegisterBaseUnit(Units.Mass.Kilograms);
registry.Register(Units.Mass.Gram);
registry.Register(Units.Mass.Milligram);
registry.Register(Units.Mass.Pounds);
registry.Register(Units.Mass.Tons);
registry.RegisterBaseUnit(Units.MassRate.MilliGramsPerSecond);
registry.Register(Units.MassRate.GramsPerDay);
registry.Register(Units.MassRate.GramsPerHour);
registry.Register(Units.MassRate.GramsPerMinute);
registry.Register(Units.MassRate.GramsPerSecond);
registry.Register(Units.MassRate.KilogramsPerDay);
registry.Register(Units.MassRate.KilogramsPerHour);
registry.Register(Units.MassRate.KilogramsPerMinute);
registry.Register(Units.MassRate.KilogramsPerSecond);
registry.Register(Units.MassRate.MicrogramsPerDay);
registry.Register(Units.MassRate.MicrogramsPerHour);
registry.Register(Units.MassRate.MicrogramsPerMinute);
registry.Register(Units.MassRate.MicrogramsPerSecond);
registry.Register(Units.MassRate.MilliGramsPerDay);
registry.Register(Units.MassRate.MilliGramsPerHour);
registry.Register(Units.MassRate.MilliGramsPerMinute);
registry.Register(Units.MassRate.PoundsPerDay);
registry.Register(Units.MassRate.PoundsPerHour);
registry.Register(Units.MassRate.PoundsPerMinute);
registry.Register(Units.MassRate.PoundsPerSecond);
registry.Register(Units.MassRate.TonnesPerYear);
registry.RegisterBaseUnit(Units.ElectricalFrequency.Hertz);
registry.RegisterBaseUnit(Units.Power.Kilowatts);
registry.Register(Units.Power.Horsepower);
registry.Register(Units.Power.Watts);
registry.Register(Units.Power.MegaWatts);
registry.Register(Units.Power.GigaWatts);
registry.RegisterBaseUnit(Units.InfiltrationRate.InfiltrationRateMillimetersPerMinute);
registry.Register(Units.InfiltrationRate.InfiltrationRateCentimetersPerDay);
registry.Register(Units.InfiltrationRate.InfiltrationRateCentimetersPerHour);
registry.Register(Units.InfiltrationRate.InfiltrationRateCentimetersPerMinute);
registry.Register(Units.InfiltrationRate.InfiltrationRateInchesPerDay);
registry.Register(Units.InfiltrationRate.InfiltrationRateInchesPerHour);
registry.Register(Units.InfiltrationRate.InfiltrationRateInchesPerMinute);
registry.Register(Units.InfiltrationRate.InfiltrationRateMillimetersPerDay);
registry.Register(Units.InfiltrationRate.InfiltrationRateMillimetersPerHour);
registry.RegisterBaseUnit(Units.SpecificWeight.NewtonsPerCubicMeter);
registry.Register(Units.SpecificWeight.KiloNewtonsPerCubicMeter);
registry.Register(Units.SpecificWeight.PoundsForcePerCubicFoot);
registry.RegisterBaseUnit(Units.Concentration.MilliGramsPerLiter);
registry.Register(Units.Concentration.MicrogramsPerLiter);
registry.Register(Units.Concentration.PartsPerBillion);
registry.Register(Units.Concentration.PartsPerMillion);
registry.Register(Units.Concentration.PoundsPerCubicFoot);
registry.Register(Units.Concentration.PoundsPerMillionGallons);
registry.RegisterBaseUnit(Units.NthOrderBulkReactionRate.MilliGramsPerLiterNPerSecond);
registry.Register(Units.NthOrderBulkReactionRate.MicrogramsPerLiterNPerDay);
registry.Register(Units.NthOrderBulkReactionRate.MicrogramsPerLiterNPerSecond);
registry.Register(Units.NthOrderBulkReactionRate.MilliGramsPerLiterNPerDay);
registry.Register(Units.NthOrderBulkReactionRate.PartsPerBillionNPerDay);
registry.Register(Units.NthOrderBulkReactionRate.PartsPerBillionNPerSecond);
registry.Register(Units.NthOrderBulkReactionRate.PartsPerMillionNPerDay);
registry.Register(Units.NthOrderBulkReactionRate.PartsPerMillionNPerSecond);
registry.Register(Units.NthOrderBulkReactionRate.PoundsPerCubicFootNPerDay);
registry.Register(Units.NthOrderBulkReactionRate.PoundsPerCubicFootNPerSecond);
registry.Register(Units.NthOrderBulkReactionRate.PoundsPerMillionGallonsNPerDay);
registry.Register(Units.NthOrderBulkReactionRate.PoundsPerMillionGallonsNPerSecond);
registry.RegisterBaseUnit(Units.ZeroOrderSurfaceReactionRate.MilliGramsPerSquareMeterPerSecond);
registry.Register(Units.ZeroOrderSurfaceReactionRate.MicrogramsPerSquareFeetPerDay);
registry.Register(Units.ZeroOrderSurfaceReactionRate.MicrogramsPerSquareMeterPerDay);
registry.Register(Units.ZeroOrderSurfaceReactionRate.MicrogramsPerSquareMeterPerSecond);
registry.Register(Units.ZeroOrderSurfaceReactionRate.MilliGramsPerSquareFeetPerDay);
registry.Register(Units.ZeroOrderSurfaceReactionRate.MilliGramsPerSquareMeterPerDay);
registry.RegisterBaseUnit(Units.ReactionRate.PerSecond);
registry.Register(Units.ReactionRate.PerDay);
registry.Register(Units.ReactionRate.PerMinute);
registry.Register(Units.ReactionRate.PerHour);
registry.RegisterBaseUnit(Units.Percent.PercentPercent);
registry.Register(Units.Percent.UnitlessPercent);
registry.RegisterBaseUnit(Units.PopulationDensityPerArea.PersonsPerSquareMeter);
registry.Register(Units.PopulationDensityPerArea.PersonsPerAcre);
registry.Register(Units.PopulationDensityPerArea.PersonsPerSquareFeet);
registry.Register(Units.PopulationDensityPerArea.PersonsPerSquareKilometer);
registry.Register(Units.PopulationDensityPerArea.PersonsPerHectares);
registry.Register(Units.PopulationDensityPerArea.PersonsPerSquareMile);
registry.RegisterBaseUnit(Units.RotationalFrequency.Rpm);
registry.RegisterBaseUnit(Units.Unitless.UnitlessUnit);
registry.RegisterBaseUnit(Units.Velocity.VelocityMetersPerSecond);
registry.Register(Units.Velocity.VelocityCentimetersPerHour);
registry.Register(Units.Velocity.VelocityCentimetersPerMinute);
registry.Register(Units.Velocity.VelocityCentimetersPerSecond);
registry.Register(Units.Velocity.VelocityFeetPerHour);
registry.Register(Units.Velocity.VelocityFeetPerMinute);
registry.Register(Units.Velocity.VelocityFeetPerSecond);
registry.Register(Units.Velocity.VelocityInchesPerHour);
registry.Register(Units.Velocity.VelocityInchesPerMinute);
registry.Register(Units.Velocity.VelocityInchesPerSecond);
registry.Register(Units.Velocity.VelocityKilometersPerHour);
registry.Register(Units.Velocity.VelocityKnot);
registry.Register(Units.Velocity.VelocityKnotInternational);
registry.Register(Units.Velocity.VelocityMetersPerHour);
registry.Register(Units.Velocity.VelocityMetersPerMinute);
registry.Register(Units.Velocity.VelocityMilePerHour);
registry.RegisterBaseUnit(Units.WeirCoefficient.WeircoefficientUs);
registry.Register(Units.WeirCoefficient.WeircoefficientSi);
registry.RegisterBaseUnit(Units.DiameterLength.InchMiles);
registry.Register(Units.DiameterLength.InchFeet);
registry.Register(Units.DiameterLength.FootMiles);
registry.Register(Units.DiameterLength.FootFeet);
registry.Register(Units.DiameterLength.MillimeterMeters);
registry.Register(Units.DiameterLength.MillimeterKilometers);
registry.Register(Units.DiameterLength.MeterMeters);
registry.Register(Units.DiameterLength.MeterKilometers);
registry.Register(Units.DiameterLength.InchMeters);
registry.Register(Units.DiameterLength.MillimeterMiles);
registry.RegisterBaseUnit(Units.MassPerArea.PoundsPerAcre);
registry.Register(Units.MassPerArea.KilogramsPerHectare);
registry.Register(Units.MassPerArea.MilligramsPerSquareFeet);
registry.Register(Units.MassPerArea.MicrogramsPerSquareFeet);
registry.Register(Units.MassPerArea.MilligramsPerSquareMeter);
registry.Register(Units.MassPerArea.MicrogramsPerSquareMeter);
registry.Register(Units.MassPerArea.MilligramsPerSquareCentimeter);
registry.Register(Units.MassPerArea.MicrogramsPerSquareCentimeter);
registry.RegisterBaseUnit(Units.CurrencyPerPower.DollarsPerKiloWatt);
registry.Register(Units.CurrencyPerPower.DollarsPerHorsepower);
registry.RegisterBaseUnit(Units.Inertia.PoundSquareFeet);
registry.Register(Units.Inertia.NewtonSquareMeters);
registry.Register(Units.Inertia.KilogramSquareMeters);
registry.RegisterBaseUnit(Units.CostPerUnitVolume.DollarsPerCubicMeters);
registry.Register(Units.CostPerUnitVolume.DollarsPerCubicCentimeters);
registry.Register(Units.CostPerUnitVolume.DollarsPerLiters);
registry.Register(Units.CostPerUnitVolume.DollarsPerCubicInches);
registry.Register(Units.CostPerUnitVolume.DollarsPerGallons);
registry.Register(Units.CostPerUnitVolume.DollarsPerImpGallons);
registry.Register(Units.CostPerUnitVolume.DollarsPerCubicFeet);
registry.Register(Units.CostPerUnitVolume.DollarsPerCubicYards);
registry.Register(Units.CostPerUnitVolume.DollarsPerAcreInches);
registry.Register(Units.CostPerUnitVolume.DollarsPerAcreFeet);
registry.Register(Units.CostPerUnitVolume.DollarsPerMillionGallons);
registry.Register(Units.CostPerUnitVolume.DollarsPerThousandGallons);
registry.Register(Units.CostPerUnitVolume.DollarsPerThousandLiters);
registry.Register(Units.CostPerUnitVolume.DollarsPerMillionLiters);
registry.RegisterBaseUnit(Units.EnergyPerUnitVolume.KiloWattHourPerCubicMeters);
registry.Register(Units.EnergyPerUnitVolume.KiloWattHourPerMillionGallons);
registry.Register(Units.EnergyPerUnitVolume.KiloWattHourPerMillionLiters);
registry.Register(Units.EnergyPerUnitVolume.KiloWattHourPerCubicFeet);
registry.RegisterBaseUnit(Units.Torque.NewtonMeters);
registry.Register(Units.Torque.PoundFeet);
registry.RegisterBaseUnit(Units.SpringConstant.PoundPerInch);
registry.Register(Units.SpringConstant.NewtonPerMillimeter);
registry.RegisterBaseUnit(Units.Force.PoundForce);
registry.Register(Units.Force.KiloPoundForce);
registry.Register(Units.Force.Newton);
registry.Register(Units.Force.KiloNewton);
registry.RegisterBaseUnit(Units.Density.SlugPerCubicFoot);
registry.Register(Units.Density.PoundPerCubicFoot);
registry.Register(Units.Density.KilogramPerCubicMeter);
registry.RegisterBaseUnit(Units.DischargePerPressureDrop.CmsPerSquareRootMeterH20);
registry.Register(Units.DischargePerPressureDrop.CfsPerSquareRootFooH20);
registry.Register(Units.DischargePerPressureDrop.LPerSecPerSquareRootKpa);
registry.Register(Units.DischargePerPressureDrop.GpmPerSquareRootPsi);
registry.RegisterBaseUnit(Units.SideWeirCoefficient.SideWeirCoefficientUs);
registry.Register(Units.SideWeirCoefficient.SideWeirCoefficientSi);
registry.RegisterBaseUnit(Units.VolumePerLength.CubicMetersPerMeter);
registry.Register(Units.VolumePerLength.CubicFeetPerFoot);
registry.RegisterBaseUnit(Units.DynamicViscosity.KilogramsPerMeterPerSecond);
registry.Register(Units.DynamicViscosity.PoundSecondPerSquareFoot);
registry.RegisterBaseUnit(Units.PerPressure.PerPascals);
registry.Register(Units.PerPressure.PerBars);
registry.Register(Units.PerPressure.PerPSI);
registry.RegisterBaseUnit(Units.PerLength.PerMeter);
registry.Register(Units.PerLength.PerMillimeter);
registry.RegisterBaseUnit(Units.MassPerLength.KilogramsPerMeter);
registry.Register(Units.MassPerLength.PoundsPerFoot);
registry.RegisterBaseUnit(Units.PressurePerLength.PascalsPerMeter);
registry.Register(Units.PressurePerLength.BarsPerKilometer);
registry.Register(Units.PressurePerLength.PSIPerFoot);
registry.Register(Units.PressurePerLength.PSIPerInch);
registry.RegisterBaseUnit(Units.CalorificValue.JoulesPerCubicMeters);
registry.Register(Units.CalorificValue.KiloJoulesPerCubicMeters);
registry.Register(Units.CalorificValue.MegaJoulesPerCubicMeters);
registry.Register(Units.CalorificValue.KiloWattHoursPerCubicMeters);
registry.RegisterBaseUnit(Units.SnowMeltCoefficient.MillimetersPerHourPerDegreeCelsius);
registry.Register(Units.SnowMeltCoefficient.InchesPerHourPerDegreeFahrenheit);
registry.RegisterBaseUnit(Units.BreakRate.BreakRatePerKm);
registry.Register(Units.BreakRate.BreakRatePerMi);
registry.Register(Units.BreakRate.BreakRatePer1000Ft);
registry.Register(Units.BreakRate.BreakRatePer100Mi);
registry.RegisterBaseUnit(Units.MassPerEnergy.PoundsPerKilowattHour);
registry.Register(Units.MassPerEnergy.KilogramsPerKilowattHour);
registry.Register(Units.MassPerEnergy.TonnesPerMegaJoule);
registry.RegisterBaseUnit(Units.ValveOpenCloseRateCoefficient.PercentPerSecondPerKiloPascal);
registry.Register(Units.ValveOpenCloseRateCoefficient.PercentPerSecondPerMeterH2O);
registry.Register(Units.ValveOpenCloseRateCoefficient.PercentPerSecondPerFtH2O);
registry.Register(Units.ValveOpenCloseRateCoefficient.PercentPerSecondPerPSI);
registry.RegisterBaseUnit(Units.EnergyPerPower.KilowattHoursPerKilowatt);
registry.RegisterBaseUnit(Units.NumberPerVolume.NumbersPerLiter);
registry.Register(Units.NumberPerVolume.ThousandNumbersPerLiter);
registry.Register(Units.NumberPerVolume.MillionNumbersPerLiter);
registry.RegisterBaseUnit(Units.NumberPerArea.NumbersPerSquareMeter);
registry.Register(Units.NumberPerArea.ThousandNumbersPerSquareMeter);
registry.Register(Units.NumberPerArea.MillionNumbersPerSquareMeter);
registry.Register(Units.NumberPerArea.NumbersPerSquareFeet);
registry.Register(Units.NumberPerArea.ThousandNumbersPerSquareFeet);
registry.Register(Units.NumberPerArea.MillionNumbersPerSquareFeet);
registry.Register(Units.NumberPerArea.NumbersPerSquareCentimeter);
registry.Register(Units.NumberPerArea.ThousandNumbersPerSquareCentimeter);
registry.Register(Units.NumberPerArea.MillionNumbersPerSquareCentimeter);
registry.RegisterBaseUnit(Units.MolesPerVolume.MolesPerLiter);
registry.Register(Units.MolesPerVolume.MilliMolesPerLiter);
registry.RegisterBaseUnit(Units.MolesPerArea.MolesPerSquareMeter);
registry.Register(Units.MolesPerArea.MilliMolesPerSquareMeter);
registry.Register(Units.MolesPerArea.MolesPerSquareFeet);
registry.Register(Units.MolesPerArea.MilliMolesPerSquareFeet);
registry.Register(Units.MolesPerArea.MolesPerSquareCentimeter);
registry.Register(Units.MolesPerArea.MilliMolesPerSquareCentimeter);
registry.RegisterBaseUnit(Units.ValveOpenCloseRateCoefficientPerFlow.PercentPerSecondPerCubicMeterPerSecond);
registry.Register(Units.ValveOpenCloseRateCoefficientPerFlow.PercentPerSecondPerCubicFeetPerSecond);
registry.Register(Units.ValveOpenCloseRateCoefficientPerFlow.PercentPerSecondPerCubicFeetPerMinute);
registry.Register(Units.ValveOpenCloseRateCoefficientPerFlow.PercentPerSecondPerCubicMeterPerMinute);
registry.Register(Units.ValveOpenCloseRateCoefficientPerFlow.PercentPerSecondPerLiterPerSecond);
registry.Register(Units.ValveOpenCloseRateCoefficientPerFlow.PercentPerSecondPerLiterPerMinute);
registry.Register(Units.ValveOpenCloseRateCoefficientPerFlow.PercentPerSecondPerGalPerSecond);
registry.Register(Units.ValveOpenCloseRateCoefficientPerFlow.PercentPerSecondPerGalPerMinute);
registry.RegisterBaseUnit(Units.FlowPerUnitLength.CubicFeetPerMilePerSecond);
registry.Register(Units.FlowPerUnitLength.LitersPerKilometerPerSecond);
registry.Register(Units.FlowPerUnitLength.QuadFeetPerSecond);
registry.Register(Units.FlowPerUnitLength.GallonsPerFootPerMinute);
registry.Register(Units.FlowPerUnitLength.GallonsPerMilePerMinute);
registry.Register(Units.FlowPerUnitLength.QuadMetersPerSecond);
registry.Register(Units.FlowPerUnitLength.CubicMetersPerKilometerPerSecond);
registry.Register(Units.FlowPerUnitLength.LitersPerMeterPerSecond);
registry.RegisterBaseUnit(Units.Acceleration.Meterspersquaresecond);
registry.Register(Units.Acceleration.Feetpersquaresecond);


            registry.Freeze();
            return registry;
        }
    }
}
