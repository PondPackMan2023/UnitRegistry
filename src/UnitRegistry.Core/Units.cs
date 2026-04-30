namespace UnitRegistry
{
    /// <summary>
    /// Transcribed from Haestad linear units. 
    /// Unsupported categories: temperature/offset, slope/nonlinear reciprocal, emitter coefficient/stateful, infiltration per unit depth, drainage coefficient, parameterized weir coefficient.
    /// </summary>
    public static class Units
    {
        public static class NoDimension
        {
            public static readonly Unit None = new Unit("none", Dimensions.None, 1.0 / (1.0), "None");
            public static readonly Unit[] All = new Unit[] { None };
        }

        public static class Volume
        {
            public static readonly Unit AcreFeet = new Unit("acreFeet", Dimensions.Volume, 1.0 / (8.1071319e-4), "ac-ft");
            public static readonly Unit AcreInches = new Unit("acreInches", Dimensions.Volume, 1.0 / (9.728558e-3), "ac-in");
            public static readonly Unit CubicCentimeters = new Unit("cubicCentimeters", Dimensions.Volume, 1.0 / (1.0e6), "cm³");
            public static readonly Unit CubicFeet = new Unit("cubicFeet", Dimensions.Volume, 1.0 / (35.314667), "ft³");
            public static readonly Unit CubicInches = new Unit("cubicInches", Dimensions.Volume, 1.0 / (61023.74), "in³");
            public static readonly Unit CubicMeters = new Unit("cubicMeters", Dimensions.Volume, 1.0 / (1.0), "m³");
            public static readonly Unit CubicYards = new Unit("cubicYards", Dimensions.Volume, 1.0 / (1.3079506), "yd³");
            public static readonly Unit Gallons = new Unit("gallons", Dimensions.Volume, 1.0 / (264.17205), "gal");
            public static readonly Unit ImpGallons = new Unit("impGallons", Dimensions.Volume, 1.0 / (219.9694), "Imp gal");
            public static readonly Unit Liters = new Unit("liters", Dimensions.Volume, 1.0 / (1000.0), "L");
            public static readonly Unit MillionGallons = new Unit("millionGallons", Dimensions.Volume, 1.0 / (2.6417205e-4), "MG");
            public static readonly Unit MillionLiters = new Unit("millionLiters", Dimensions.Volume, 1.0 / (1.0e-3), "ML");
            public static readonly Unit ThousandGallons = new Unit("thousandGallons", Dimensions.Volume, 1.0 / (2.6417205e-1), "gal x 10³");
            public static readonly Unit ThousandLiters = new Unit("thousandLiters", Dimensions.Volume, 1.0 / (1.0), "L × 10³");
            public static readonly Unit[] All = new Unit[] { AcreFeet, AcreInches, CubicCentimeters, CubicFeet, CubicInches, CubicMeters, CubicYards, Gallons, ImpGallons, Liters, MillionGallons, MillionLiters, ThousandGallons, ThousandLiters };
        }

        public static class Flow
        {
            public static readonly Unit AcreFeetPerDay = new Unit("acreFeetPerDay", Dimensions.Flow, 1.0 / (70.04561962), "acreft/day");
            public static readonly Unit AcreFeetPerHour = new Unit("acreFeetPerHour", Dimensions.Flow, 1.0 / (2.918567484), "acre-ft/h");
            public static readonly Unit AcreFeetPerMinute = new Unit("acreFeetPerMinute", Dimensions.Flow, 1.0 / (4.86427914e-2), "acreft/min");
            public static readonly Unit AcreInchPerHour = new Unit("acreInchPerHour", Dimensions.Flow, 1.0 / (35.022809808), "acre-in/h");
            public static readonly Unit AcreInchPerMinute = new Unit("acreInchPerMinute", Dimensions.Flow, 1.0 / (0.5837134968), "acrein/min");
            public static readonly Unit Cfm = new Unit("cfm", Dimensions.Flow, 1.0 / (2118.88002), "cfm");
            public static readonly Unit Cfs = new Unit("cfs", Dimensions.Flow, 1.0 / (35.314667), "cfs");
            public static readonly Unit CubicFeetPerDay = new Unit("cubicFeetPerDay", Dimensions.Flow, 1.0 / (3051187.229), "ft³/day");
            public static readonly Unit CubicFeetPerMinute = new Unit("cubicFeetPerMinute", Dimensions.Flow, 1.0 / (2118.88002), "ft³/min");
            public static readonly Unit CubicFeetPerSecond = new Unit("cubicFeetPerSecond", Dimensions.Flow, 1.0 / (35.314667), "ft³/s");
            public static readonly Unit CubicMetersPerDay = new Unit("cubicMetersPerDay", Dimensions.Flow, 1.0 / (86400.0), "m³/day");
            public static readonly Unit CubicMetersPerHour = new Unit("cubicMetersPerHour", Dimensions.Flow, 1.0 / (3600.0), "m³/h");
            public static readonly Unit CubicMetersPerMinute = new Unit("cubicMetersPerMinute", Dimensions.Flow, 1.0 / (60.0), "m³/min");
            public static readonly Unit CubicMetersPerSecond = new Unit("cubicMetersPerSecond", Dimensions.Flow, 1.0 / (1.0), "m³/s");
            public static readonly Unit GallonsPerDay = new Unit("gallonsPerDay", Dimensions.Flow, 1.0 / (22824465.12), "gal/day");
            public static readonly Unit GallonsPerMinute = new Unit("gallonsPerMinute", Dimensions.Flow, 1.0 / (15850.323), "gal/min");
            public static readonly Unit GallonsPerSecond = new Unit("gallonsPerSecond", Dimensions.Flow, 1.0 / (264.17205), "gal/s");
            public static readonly Unit Gpm = new Unit("gpm", Dimensions.Flow, 1.0 / (15850.323), "gpm");
            public static readonly Unit ImperialGallonsPerDay = new Unit("imperialGallonsPerDay", Dimensions.Flow, 1.0 / (19005356.16), "Imp gpd");
            public static readonly Unit ImperialGallonsPerMinute = new Unit("imperialGallonsPerMinute", Dimensions.Flow, 1.0 / (13198.164), "Imp gpm");
            public static readonly Unit ImperialGallonsPerSecond = new Unit("imperialGallonsPerSecond", Dimensions.Flow, 1.0 / (219.9694), "Imp gps");
            public static readonly Unit LitersPerDay = new Unit("litersPerDay", Dimensions.Flow, 1.0 / (86400000.0), "L/day");
            public static readonly Unit LitersPerMinute = new Unit("litersPerMinute", Dimensions.Flow, 1.0 / (60000), "L/min");
            public static readonly Unit LitersPerSecond = new Unit("litersPerSecond", Dimensions.Flow, 1.0 / (1000.0), "L/s");
            public static readonly Unit MegaLitersPerDay = new Unit("megaLitersPerDay", Dimensions.Flow, 1.0 / (86.4), "ML/day");
            public static readonly Unit Mgd = new Unit("mgd", Dimensions.Flow, 1.0 / (22.82446512), "MGD");
            public static readonly Unit MgdImperial = new Unit("mgdImperial", Dimensions.Flow, 1.0 / (19.00535616), "Imp mgd");
            public static readonly Unit MillionLitersPerDay = new Unit("millionLitersPerDay", Dimensions.Flow, 1.0 / (86.40), "MLD");
            public static readonly Unit Gpd = new Unit("gpd", Dimensions.Flow, 1.0 / (22824465.12), "gpd");
            public static readonly Unit LitersPerHour = new Unit("litersPerHour", Dimensions.Flow, 1.0 / (3600000.0), "L/h");
            public static readonly Unit[] All = new Unit[] { AcreFeetPerDay, AcreFeetPerHour, AcreFeetPerMinute, AcreInchPerHour, AcreInchPerMinute, Cfm, Cfs, CubicFeetPerDay, CubicFeetPerMinute, CubicFeetPerSecond, CubicMetersPerDay, CubicMetersPerHour, CubicMetersPerMinute, CubicMetersPerSecond, GallonsPerDay, GallonsPerMinute, GallonsPerSecond, Gpm, ImperialGallonsPerDay, ImperialGallonsPerMinute, ImperialGallonsPerSecond, LitersPerDay, LitersPerMinute, LitersPerSecond, MegaLitersPerDay, Mgd, MgdImperial, MillionLitersPerDay, Gpd, LitersPerHour };
        }

        public static class Area
        {
            public static readonly Unit Acres = new Unit("acres", Dimensions.Area, 1.0 / (2.47105381e-4), "acres");
            public static readonly Unit Hectares = new Unit("hectares", Dimensions.Area, 1.0 / (1.0e-4), "ha");
            public static readonly Unit SquareCentimeters = new Unit("squareCentimeters", Dimensions.Area, 1.0 / (10000.0), "cm²");
            public static readonly Unit SquareFeet = new Unit("squareFeet", Dimensions.Area, 1.0 / (10.7639104), "ft²");
            public static readonly Unit SquareInches = new Unit("squareInches", Dimensions.Area, 1.0 / (1550.0031), "in²");
            public static readonly Unit SquareKilometers = new Unit("squareKilometers", Dimensions.Area, 1.0 / (1.0e-6), "km²");
            public static readonly Unit SquareMeters = new Unit("squareMeters", Dimensions.Area, 1.0 / (1.0), "m²");
            public static readonly Unit SquareMiles = new Unit("squareMiles", Dimensions.Area, 1.0 / (3.86102159e-7), "mile²");
            public static readonly Unit SquareMillimeters = new Unit("squareMillimeters", Dimensions.Area, 1.0 / (1000000.0), "mm²");
            public static readonly Unit SquareYards = new Unit("squareYards", Dimensions.Area, 1.0 / (1.19599005), "yd²");
            public static readonly Unit ThousandSquareFeet = new Unit("thousandSquareFeet", Dimensions.Area, 1.0 / (1.076391e-2), "TSF");
            public static readonly Unit[] All = new Unit[] { Acres, Hectares, SquareCentimeters, SquareFeet, SquareInches, SquareKilometers, SquareMeters, SquareMiles, SquareMillimeters, SquareYards, ThousandSquareFeet };
        }

        public static class Angle
        {
            public static readonly Unit AngleDegrees = new Unit("angleDegrees", Dimensions.Angle, 1.0 / (57.295779), "degrees");
            public static readonly Unit AngleMinutes = new Unit("angleMinutes", Dimensions.Angle, 1.0 / (3437.7468), "minutes");
            public static readonly Unit AngleQuadrants = new Unit("angleQuadrants", Dimensions.Angle, 1.0 / (0.63661977), "quadrants");
            public static readonly Unit AngleRadians = new Unit("angleRadians", Dimensions.Angle, 1.0 / (1.0), "radians");
            public static readonly Unit AngleRevolutions = new Unit("angleRevolutions", Dimensions.Angle, 1.0 / (0.15915494), "revolutions");
            public static readonly Unit AngleSeconds = new Unit("angleSeconds", Dimensions.Angle, 1.0 / (206264.81), "seconds");
            public static readonly Unit[] All = new Unit[] { AngleDegrees, AngleMinutes, AngleQuadrants, AngleRadians, AngleRevolutions, AngleSeconds };
        }

        public static class Pressure
        {
            public static readonly Unit Atmospheres = new Unit("atmospheres", Dimensions.Pressure, 1.0 / (9.86923267e-3), "atm");
            public static readonly Unit Bars = new Unit("bars", Dimensions.Pressure, 1.0 / (0.01), "bars");
            public static readonly Unit FeetOfH2O = new Unit("feetOfH2O", Dimensions.Pressure, 1.0 / (0.33455255), "feet H2O");
            public static readonly Unit KilogramsPerSquareCentimeter = new Unit("kilogramsPerSquareCentimeter", Dimensions.Pressure, 1.0 / (1.019716e-2), "kg/cm²");
            public static readonly Unit KiloPascals = new Unit("kiloPascals", Dimensions.Pressure, 1.0 / (1.0), "kPa");
            public static readonly Unit MetersOfH2O = new Unit("metersOfH2O", Dimensions.Pressure, 1.0 / (0.101972), "m H2O");
            public static readonly Unit MillimetersOfH2O = new Unit("millimetersOfH2O", Dimensions.Pressure, 1.0 / (101.972), "mm H2O");
            public static readonly Unit NewtonsPerSquareMeter = new Unit("newtonsPerSquareMeter", Dimensions.Pressure, 1.0 / (1000.0), "N/m²");
            public static readonly Unit PoundsPerSquareFoot = new Unit("poundsPerSquareFoot", Dimensions.Pressure, 1.0 / (20.8854), "lbs/ft²");
            public static readonly Unit PoundsPerSquareInch = new Unit("poundsPerSquareInch", Dimensions.Pressure, 1.0 / (1.45037738e-1), "lbs/in²");
            public static readonly Unit Psi = new Unit("psi", Dimensions.Pressure, 1.0 / (1.45037738e-1), "psi");
            public static readonly Unit KilogramsPerSquareMeter = new Unit("kilogramsPerSquareMeter", Dimensions.Pressure, 1.0 / (101.971621), "kg/m²");
            public static readonly Unit Pascals = new Unit("pascals", Dimensions.Pressure, 1.0 / (1000.0), "Pascals");
            public static readonly Unit HektoPascals = new Unit("hektoPascals", Dimensions.Pressure, 1.0 / (10.0), "hPa");
            public static readonly Unit MegaPascals = new Unit("megaPascals", Dimensions.Pressure, 1.0 / (0.001), "MPa");
            public static readonly Unit MilliBars = new Unit("milliBars", Dimensions.Pressure, 1.0 / (10.0), "mbar");
            public static readonly Unit[] All = new Unit[] { Atmospheres, Bars, FeetOfH2O, KilogramsPerSquareCentimeter, KiloPascals, MetersOfH2O, MillimetersOfH2O, NewtonsPerSquareMeter, PoundsPerSquareFoot, PoundsPerSquareInch, Psi, KilogramsPerSquareMeter, Pascals, HektoPascals, MegaPascals, MilliBars };
        }

        public static class Population
        {
            public static readonly Unit Capita = new Unit("capita", Dimensions.Population, 1.0 / (1.0), "Capita");
            public static readonly Unit Customer = new Unit("customer", Dimensions.Population, 1.0 / (1.0), "Customer");
            public static readonly Unit Employee = new Unit("employee", Dimensions.Population, 1.0 / (1.0), "Employee");
            public static readonly Unit Guest = new Unit("guest", Dimensions.Population, 1.0 / (1.0), "Guest");
            public static readonly Unit HundredCapita = new Unit("hundredCapita", Dimensions.Population, 1.0 / (0.01), "Capita x 10²");
            public static readonly Unit Passenger = new Unit("passenger", Dimensions.Population, 1.0 / (1.0), "Passenger");
            public static readonly Unit Person = new Unit("person", Dimensions.Population, 1.0 / (1.0), "Person");
            public static readonly Unit Resident = new Unit("resident", Dimensions.Population, 1.0 / (1.0), "Resident");
            public static readonly Unit Student = new Unit("student", Dimensions.Population, 1.0 / (1.0), "Student");
            public static readonly Unit ThousandCapita = new Unit("thousandCapita", Dimensions.Population, 1.0 / (0.001), "Capita x 10³");
            public static readonly Unit[] All = new Unit[] { Capita, Customer, Employee, Guest, HundredCapita, Passenger, Person, Resident, Student, ThousandCapita };
        }

        public static class Length
        {
            public static readonly Unit Centimeters = new Unit("centimeters", Dimensions.Length, 1.0 / (100.0), "cm");
            public static readonly Unit Decimeters = new Unit("decimeters", Dimensions.Length, 1.0 / (10.0), "dm");
            public static readonly Unit Feet = new Unit("feet", Dimensions.Length, 1.0 / (3.280839895), "ft");
            public static readonly Unit Inches = new Unit("inches", Dimensions.Length, 1.0 / (39.37007874), "in");
            public static readonly Unit Kilometers = new Unit("kilometers", Dimensions.Length, 1.0 / (0.001), "km");
            public static readonly Unit Meters = new Unit("meters", Dimensions.Length, 1.0 / (1.0), "m");
            public static readonly Unit Mfeet = new Unit("mfeet", Dimensions.Length, 1.0 / (3280.839895), "mft");
            public static readonly Unit Miles = new Unit("miles", Dimensions.Length, 1.0 / (6.213711922e-4), "miles");
            public static readonly Unit Millifeet = new Unit("millifeet", Dimensions.Length, 1.0 / (3280.839895), "millifeet");
            public static readonly Unit Millimeters = new Unit("millimeters", Dimensions.Length, 1.0 / (1000.0), "mm");
            public static readonly Unit Yards = new Unit("yards", Dimensions.Length, 1.0 / (1.0936133), "yd");
            public static readonly Unit UsSurveyFoot = new Unit("usSurveyFoot", Dimensions.Length, 1.0 / (39.37 / 12.0), "US Survey Ft");
            public static readonly Unit[] All = new Unit[] { Centimeters, Decimeters, Feet, Inches, Kilometers, Meters, Mfeet, Miles, Millifeet, Millimeters, Yards, UsSurveyFoot };

            public static Unit Meter { get { return Meters; } }
            public static Unit Millimeter { get { return Millimeters; } }
            public static Unit Foot { get { return Feet; } }
        }

        public static class RainfallIntensity
        {
            public static readonly Unit CentimetersPerDay = new Unit("centimetersPerDay", Dimensions.RainfallIntensity, 1.0 / (144), "cm/day");
            public static readonly Unit CentimetersPerHour = new Unit("centimetersPerHour", Dimensions.RainfallIntensity, 1.0 / (6), "cm/h");
            public static readonly Unit CentimetersPerMinute = new Unit("centimetersPerMinute", Dimensions.RainfallIntensity, 1.0 / (0.1), "cm/min");
            public static readonly Unit InchesPerDay = new Unit("inchesPerDay", Dimensions.RainfallIntensity, 1.0 / (56.69291376), "in/day");
            public static readonly Unit InchesPerHour = new Unit("inchesPerHour", Dimensions.RainfallIntensity, 1.0 / (2.36220474), "in/h");
            public static readonly Unit InchesPerMinute = new Unit("inchesPerMinute", Dimensions.RainfallIntensity, 1.0 / (0.039370079), "in/min");
            public static readonly Unit MilliMetersPerDay = new Unit("milliMetersPerDay", Dimensions.RainfallIntensity, 1.0 / (1440), "mm/day");
            public static readonly Unit MilliMetersPerHour = new Unit("milliMetersPerHour", Dimensions.RainfallIntensity, 1.0 / (60), "mm/h");
            public static readonly Unit MilliMetersPerMinute = new Unit("milliMetersPerMinute", Dimensions.RainfallIntensity, 1.0 / (1), "mm/min");
            public static readonly Unit MicrometersPerSecond = new Unit("micrometersPerSecond", Dimensions.RainfallIntensity, 1.0 / (1.0 / 0.06), "µm/s");
            public static readonly Unit[] All = new Unit[] { CentimetersPerDay, CentimetersPerHour, CentimetersPerMinute, InchesPerDay, InchesPerHour, InchesPerMinute, MilliMetersPerDay, MilliMetersPerHour, MilliMetersPerMinute, MicrometersPerSecond };
        }

        public static class Diffusivity
        {
            public static readonly Unit Centistokes = new Unit("centistokes", Dimensions.Diffusivity, 1.0 / (1.0e6), "Centistokes");
            public static readonly Unit SquareFeetPerSecond = new Unit("squareFeetPerSecond", Dimensions.Diffusivity, 1.0 / (10.76391), "ft²/s");
            public static readonly Unit SquareMetersPerSecond = new Unit("squareMetersPerSecond", Dimensions.Diffusivity, 1.0 / (1), "m²/s");
            public static readonly Unit Stokes = new Unit("stokes", Dimensions.Diffusivity, 1.0 / (1.0e4), "Stokes");
            public static readonly Unit[] All = new Unit[] { Centistokes, SquareFeetPerSecond, SquareMetersPerSecond, Stokes };
        }

        public static class FlowDensityPerArea
        {
            public static readonly Unit CfsPerAcres = new Unit("cfsPerAcres", Dimensions.FlowDensityPerArea, 1.0 / (1.6540967e-3), "cfs/acre");
            public static readonly Unit CfsPerSquareFeet = new Unit("cfsPerSquareFeet", Dimensions.FlowDensityPerArea, 1.0 / (3.797265e-8), "cfs/ft²");
            public static readonly Unit CfsPerSquareMiles = new Unit("cfsPerSquareMiles", Dimensions.FlowDensityPerArea, 1.0 / (1.05861767), "cfs/mile²");
            public static readonly Unit CubicMetersPerHectaresPerDay = new Unit("cubicMetersPerHectaresPerDay", Dimensions.FlowDensityPerArea, 1.0 / (10), "m³/ha/day");
            public static readonly Unit CubicMetersPerSquareKilometerPerDay = new Unit("cubicMetersPerSquareKilometerPerDay", Dimensions.FlowDensityPerArea, 1.0 / (1.0e3), "m³/km²/day");
            public static readonly Unit CubicMetersPerSquareMeterPerDay = new Unit("cubicMetersPerSquareMeterPerDay", Dimensions.FlowDensityPerArea, 1.0 / (1.0e-3), "m³/m²/day");
            public static readonly Unit GpdPerAcres = new Unit("gpdPerAcres", Dimensions.FlowDensityPerArea, 1.0 / (1069.070643), "gpd/acre");
            public static readonly Unit GpdPerSquareFeet = new Unit("gpdPerSquareFeet", Dimensions.FlowDensityPerArea, 1.0 / (2.45423867e-2), "gpd/ft²");
            public static readonly Unit GpdPerSquareMiles = new Unit("gpdPerSquareMiles", Dimensions.FlowDensityPerArea, 1.0 / (684202.474691), "gpd/mile²");
            public static readonly Unit GpmPerAcres = new Unit("gpmPerAcres", Dimensions.FlowDensityPerArea, 1.0 / (0.742410169), "gpm/acre");
            public static readonly Unit GpmPerSquareFeet = new Unit("gpmPerSquareFeet", Dimensions.FlowDensityPerArea, 1.0 / (1.7043324e-5), "gpm/ft²");
            public static readonly Unit GpmPerSquareMiles = new Unit("gpmPerSquareMiles", Dimensions.FlowDensityPerArea, 1.0 / (475.1406074), "gpm/mile²");
            public static readonly Unit LitersPerHectaresPerDay = new Unit("litersPerHectaresPerDay", Dimensions.FlowDensityPerArea, 1.0 / (1e4), "L/ha/day");
            public static readonly Unit LitersPerSquareKilometerPerDay = new Unit("litersPerSquareKilometerPerDay", Dimensions.FlowDensityPerArea, 1.0 / (1e6), "L/km²/day");
            public static readonly Unit LitersPerSquareMeterPerDay = new Unit("litersPerSquareMeterPerDay", Dimensions.FlowDensityPerArea, 1.0 / (1.0), "L/m²/day");
            public static readonly Unit LitersPerHectaresPerSecond = new Unit("litersPerHectaresPerSecond", Dimensions.FlowDensityPerArea, 1.0 / (0.11574074074), "L/ha/sec");
            public static readonly Unit[] All = new Unit[] { CfsPerAcres, CfsPerSquareFeet, CfsPerSquareMiles, CubicMetersPerHectaresPerDay, CubicMetersPerSquareKilometerPerDay, CubicMetersPerSquareMeterPerDay, GpdPerAcres, GpdPerSquareFeet, GpdPerSquareMiles, GpmPerAcres, GpmPerSquareFeet, GpmPerSquareMiles, LitersPerHectaresPerDay, LitersPerSquareKilometerPerDay, LitersPerSquareMeterPerDay, LitersPerHectaresPerSecond };
        }

        public static class Time
        {
            public static readonly Unit Days = new Unit("days", Dimensions.Time, 1.0 / (1.0 / 24.0), "days");
            public static readonly Unit Hours = new Unit("hours", Dimensions.Time, 1.0 / (1.0), "hours");
            public static readonly Unit Minutes = new Unit("minutes", Dimensions.Time, 1.0 / (60.0), "min");
            public static readonly Unit Seconds = new Unit("seconds", Dimensions.Time, 1.0 / (3600.0), "sec");
            public static readonly Unit Years = new Unit("years", Dimensions.Time, 1.0 / (1.0 / 8760.0), "years");
            public static readonly Unit Milliseconds = new Unit("milliseconds", Dimensions.Time, 1.0 / (3600000.0), "ms");
            public static readonly Unit[] All = new Unit[] { Days, Hours, Minutes, Seconds, Years, Milliseconds };

            public static Unit Hour { get { return Hours; } }
            public static Unit Minute { get { return Minutes; } }
            public static Unit Second { get { return Seconds; } }
        }

        public static class Currency
        {
            public static readonly Unit Dollars = new Unit("dollars", Dimensions.Currency, 1.0 / (1.0), "%1");
            public static readonly Unit[] All = new Unit[] { Dollars };
        }

        public static class CurrencyPerLength
        {
            public static readonly Unit DollarsPerFoot = new Unit("dollarsPerFoot", Dimensions.CurrencyPerLength, 1.0 / (0.3048), "%1/ft");
            public static readonly Unit DollarsPerMeter = new Unit("dollarsPerMeter", Dimensions.CurrencyPerLength, 1.0 / (1.0), "%1/m");
            public static readonly Unit[] All = new Unit[] { DollarsPerFoot, DollarsPerMeter };
        }

        public static class CurrencyPerEnergy
        {
            public static readonly Unit DollarsPerKiloWattHour = new Unit("dollarsPerKiloWattHour", Dimensions.CurrencyPerEnergy, 1.0 / (1.0), "%1/kWh");
            public static readonly Unit[] All = new Unit[] { DollarsPerKiloWattHour };
        }

        public static class SurfaceReactionRate
        {
            public static readonly Unit FeetPerDay = new Unit("feetPerDay", Dimensions.SurfaceReactionRate, 1.0 / (283464.56736), "ft/day");
            public static readonly Unit MetersPerDay = new Unit("metersPerDay", Dimensions.SurfaceReactionRate, 1.0 / (86400), "m/day");
            public static readonly Unit MetersPerSecond = new Unit("metersPerSecond", Dimensions.SurfaceReactionRate, 1.0 / (1), "m/s");
            public static readonly Unit[] All = new Unit[] { FeetPerDay, MetersPerDay, MetersPerSecond };
        }

        public static class Scale
        {
            public static readonly Unit FeetPerInch = new Unit("feetPerInch", Dimensions.Scale, 1.0 / (8.333333333), "ft/in");
            public static readonly Unit MetersPerCm = new Unit("metersPerCm", Dimensions.Scale, 1.0 / (1.0), "m/cm");
            public static readonly Unit[] All = new Unit[] { FeetPerInch, MetersPerCm };
        }

        public static class Energy
        {
            public static readonly Unit FootPoundals = new Unit("footPoundals", Dimensions.Energy, 1.0 / (23.73), "ft-pdl");
            public static readonly Unit Joules = new Unit("joules", Dimensions.Energy, 1.0 / (1), "J");
            public static readonly Unit KiloJoules = new Unit("kiloJoules", Dimensions.Energy, 1.0 / (1.0e-3), "kJ");
            public static readonly Unit KiloWattHours = new Unit("kiloWattHours", Dimensions.Energy, 1.0 / (1.0 / 3600000), "kWh");
            public static readonly Unit MegaJoules = new Unit("megaJoules", Dimensions.Energy, 1.0 / (0.000001), "MJ");
            public static readonly Unit GigaJoules = new Unit("gigaJoules", Dimensions.Energy, 1.0 / (0.000000001), "GJ");
            public static readonly Unit WattSeconds = new Unit("wattSeconds", Dimensions.Energy, 1.0 / (1.0), "Ws");
            public static readonly Unit MegaWattHours = new Unit("megaWattHours", Dimensions.Energy, 1.0 / (1 / 3600.0 / 1000000.0), "MWh");
            public static readonly Unit GigaWattHours = new Unit("gigaWattHours", Dimensions.Energy, 1.0 / (1 / 3600.0 / 1000000000.0), "GWh");
            public static readonly Unit[] All = new Unit[] { FootPoundals, Joules, KiloJoules, KiloWattHours, MegaJoules, GigaJoules, WattSeconds, MegaWattHours, GigaWattHours };
        }

        public static class FlowDensityPerCapita
        {
            public static readonly Unit GpdPerCapita = new Unit("gpdPerCapita", Dimensions.FlowDensityPerCapita, 1.0 / (0.264172), "gpd/capita");
            public static readonly Unit LitersPerCapitaPerDay = new Unit("litersPerCapitaPerDay", Dimensions.FlowDensityPerCapita, 1.0 / (1.0), "L/capita/day");
            public static readonly Unit[] All = new Unit[] { GpdPerCapita, LitersPerCapitaPerDay };
        }

        public static class Mass
        {
            public static readonly Unit Gram = new Unit("gram", Dimensions.Mass, 1.0 / (/*0.001*/1000), "g");
            public static readonly Unit Kilograms = new Unit("kilograms", Dimensions.Mass, 1.0 / (1.0), "kg");
            public static readonly Unit Milligram = new Unit("milligram", Dimensions.Mass, 1.0 / (/*0.000001*/1000000), "mg");
            public static readonly Unit Pounds = new Unit("pounds", Dimensions.Mass, 1.0 / (2.2046226), "lbs");
            public static readonly Unit Tons = new Unit("tons", Dimensions.Mass, 1.0 / (0.001), "t");
            public static readonly Unit[] All = new Unit[] { Gram, Kilograms, Milligram, Pounds, Tons };
        }

        public static class MassRate
        {
            public static readonly Unit GramsPerDay = new Unit("gramsPerDay", Dimensions.MassRate, 1.0 / (86.4), "g/day");
            public static readonly Unit GramsPerHour = new Unit("gramsPerHour", Dimensions.MassRate, 1.0 / (3.6), "g/h");
            public static readonly Unit GramsPerMinute = new Unit("gramsPerMinute", Dimensions.MassRate, 1.0 / (6.0e-2), "g/min");
            public static readonly Unit GramsPerSecond = new Unit("gramsPerSecond", Dimensions.MassRate, 1.0 / (1.0e-3), "g/s");
            public static readonly Unit KilogramsPerDay = new Unit("kilogramsPerDay", Dimensions.MassRate, 1.0 / (8.64e-2), "kg/day");
            public static readonly Unit KilogramsPerHour = new Unit("kilogramsPerHour", Dimensions.MassRate, 1.0 / (3.6e-3), "kg/h");
            public static readonly Unit KilogramsPerMinute = new Unit("kilogramsPerMinute", Dimensions.MassRate, 1.0 / (6.0e-5), "kg/min");
            public static readonly Unit KilogramsPerSecond = new Unit("kilogramsPerSecond", Dimensions.MassRate, 1.0 / (1.0e-6), "kg/s");
            public static readonly Unit MicrogramsPerDay = new Unit("microgramsPerDay", Dimensions.MassRate, 1.0 / (8.64e7), "µg/day");
            public static readonly Unit MicrogramsPerHour = new Unit("microgramsPerHour", Dimensions.MassRate, 1.0 / (3600000.0), "µg/h");
            public static readonly Unit MicrogramsPerMinute = new Unit("microgramsPerMinute", Dimensions.MassRate, 1.0 / (60000.0), "µg/min");
            public static readonly Unit MicrogramsPerSecond = new Unit("microgramsPerSecond", Dimensions.MassRate, 1.0 / (1000.0), "µg/s");
            public static readonly Unit MilliGramsPerDay = new Unit("milliGramsPerDay", Dimensions.MassRate, 1.0 / (86400.0), "mg/day");
            public static readonly Unit MilliGramsPerHour = new Unit("milliGramsPerHour", Dimensions.MassRate, 1.0 / (3600.0), "mg/h");
            public static readonly Unit MilliGramsPerMinute = new Unit("milliGramsPerMinute", Dimensions.MassRate, 1.0 / (60.0), "mg/min");
            public static readonly Unit MilliGramsPerSecond = new Unit("milliGramsPerSecond", Dimensions.MassRate, 1.0 / (1.0), "mg/s");
            public static readonly Unit PoundsPerDay = new Unit("poundsPerDay", Dimensions.MassRate, 1.0 / (0.1904793926), "lb/day");
            public static readonly Unit PoundsPerHour = new Unit("poundsPerHour", Dimensions.MassRate, 1.0 / (7.93664136e-3), "lb/h");
            public static readonly Unit PoundsPerMinute = new Unit("poundsPerMinute", Dimensions.MassRate, 1.0 / (1.32277356e-4), "lb/min");
            public static readonly Unit PoundsPerSecond = new Unit("poundsPerSecond", Dimensions.MassRate, 1.0 / (2.2046226e-6), "lb/s");
            public static readonly Unit TonnesPerYear = new Unit("tonnesPerYear", Dimensions.MassRate, 1.0 / (0.031556926), "t/yr");
            public static readonly Unit[] All = new Unit[] { GramsPerDay, GramsPerHour, GramsPerMinute, GramsPerSecond, KilogramsPerDay, KilogramsPerHour, KilogramsPerMinute, KilogramsPerSecond, MicrogramsPerDay, MicrogramsPerHour, MicrogramsPerMinute, MicrogramsPerSecond, MilliGramsPerDay, MilliGramsPerHour, MilliGramsPerMinute, MilliGramsPerSecond, PoundsPerDay, PoundsPerHour, PoundsPerMinute, PoundsPerSecond, TonnesPerYear };
        }

        public static class ElectricalFrequency
        {
            public static readonly Unit Hertz = new Unit("hertz", Dimensions.ElectricalFrequency, 1.0 / (1.0), "hertz");
            public static readonly Unit[] All = new Unit[] { Hertz };
        }

        public static class Power
        {
            public static readonly Unit Horsepower = new Unit("horsepower", Dimensions.Power, 1.0 / (1.34124), "Horsepower");
            public static readonly Unit Kilowatts = new Unit("kilowatts", Dimensions.Power, 1.0 / (1.0), "kW");
            public static readonly Unit Watts = new Unit("watts", Dimensions.Power, 1.0 / (1000.0), "W");
            public static readonly Unit MegaWatts = new Unit("megaWatts", Dimensions.Power, 1.0 / (0.001), "MW");
            public static readonly Unit GigaWatts = new Unit("gigaWatts", Dimensions.Power, 1.0 / (0.000001), "GW");
            public static readonly Unit[] All = new Unit[] { Horsepower, Kilowatts, Watts, MegaWatts, GigaWatts };
        }

        public static class InfiltrationRate
        {
            public static readonly Unit InfiltrationRateCentimetersPerDay = new Unit("infiltrationRateCentimetersPerDay", Dimensions.InfiltrationRate, 1.0 / (144), "cm/day");
            public static readonly Unit InfiltrationRateCentimetersPerHour = new Unit("infiltrationRateCentimetersPerHour", Dimensions.InfiltrationRate, 1.0 / (6), "cm/h");
            public static readonly Unit InfiltrationRateCentimetersPerMinute = new Unit("infiltrationRateCentimetersPerMinute", Dimensions.InfiltrationRate, 1.0 / (0.1), "cm/min");
            public static readonly Unit InfiltrationRateInchesPerDay = new Unit("infiltrationRateInchesPerDay", Dimensions.InfiltrationRate, 1.0 / (56.69291376), "in/day");
            public static readonly Unit InfiltrationRateInchesPerHour = new Unit("infiltrationRateInchesPerHour", Dimensions.InfiltrationRate, 1.0 / (2.36220474), "in/h");
            public static readonly Unit InfiltrationRateInchesPerMinute = new Unit("infiltrationRateInchesPerMinute", Dimensions.InfiltrationRate, 1.0 / (0.039370079), "in/min");
            public static readonly Unit InfiltrationRateMillimetersPerDay = new Unit("infiltrationRateMillimetersPerDay", Dimensions.InfiltrationRate, 1.0 / (1440), "mm/day");
            public static readonly Unit InfiltrationRateMillimetersPerHour = new Unit("infiltrationRateMillimetersPerHour", Dimensions.InfiltrationRate, 1.0 / (60), "mm/h");
            public static readonly Unit InfiltrationRateMillimetersPerMinute = new Unit("infiltrationRateMillimetersPerMinute", Dimensions.InfiltrationRate, 1.0 / (1), "mm/min");
            public static readonly Unit[] All = new Unit[] { InfiltrationRateCentimetersPerDay, InfiltrationRateCentimetersPerHour, InfiltrationRateCentimetersPerMinute, InfiltrationRateInchesPerDay, InfiltrationRateInchesPerHour, InfiltrationRateInchesPerMinute, InfiltrationRateMillimetersPerDay, InfiltrationRateMillimetersPerHour, InfiltrationRateMillimetersPerMinute };
        }

        public static class SpecificWeight
        {
            public static readonly Unit KiloNewtonsPerCubicMeter = new Unit("kiloNewtonsPerCubicMeter", Dimensions.SpecificWeight, 1.0 / (0.001), "kN/m³");
            public static readonly Unit NewtonsPerCubicMeter = new Unit("newtonsPerCubicMeter", Dimensions.SpecificWeight, 1.0 / (1.0), "N/m³");
            public static readonly Unit PoundsForcePerCubicFoot = new Unit("poundsForcePerCubicFoot", Dimensions.SpecificWeight, 1.0 / (6.365882e-3), "lbf/ft³");
            public static readonly Unit[] All = new Unit[] { KiloNewtonsPerCubicMeter, NewtonsPerCubicMeter, PoundsForcePerCubicFoot };
        }

        public static class Concentration
        {
            public static readonly Unit MicrogramsPerLiter = new Unit("microgramsPerLiter", Dimensions.Concentration, 1.0 / (1000), "µg/L");
            public static readonly Unit MilliGramsPerLiter = new Unit("milliGramsPerLiter", Dimensions.Concentration, 1.0 / (1), "mg/L");
            public static readonly Unit PartsPerBillion = new Unit("partsPerBillion", Dimensions.Concentration, 1.0 / (1000), "ppb");
            public static readonly Unit PartsPerMillion = new Unit("partsPerMillion", Dimensions.Concentration, 1.0 / (1), "ppm");
            public static readonly Unit PoundsPerCubicFoot = new Unit("poundsPerCubicFoot", Dimensions.Concentration, 1.0 / (6.242621e-5), "lb/ft³");
            public static readonly Unit PoundsPerMillionGallons = new Unit("poundsPerMillionGallons", Dimensions.Concentration, 1.0 / (8.3452), "lb/milliongal");
            public static readonly Unit[] All = new Unit[] { MicrogramsPerLiter, MilliGramsPerLiter, PartsPerBillion, PartsPerMillion, PoundsPerCubicFoot, PoundsPerMillionGallons };
        }

        public static class NthOrderBulkReactionRate
        {
            public static readonly Unit MicrogramsPerLiterNPerDay = new Unit("microgramsPerLiterNPerDay", Dimensions.NthOrderBulkReactionRate, 1.0 / (86400000.0), "(µg/L)^(1-n)/day");
            public static readonly Unit MicrogramsPerLiterNPerSecond = new Unit("microgramsPerLiterNPerSecond", Dimensions.NthOrderBulkReactionRate, 1.0 / (1000), "(µg/L)^(1-n)/s");
            public static readonly Unit MilliGramsPerLiterNPerDay = new Unit("milliGramsPerLiterNPerDay", Dimensions.NthOrderBulkReactionRate, 1.0 / (86400.0), "(mg/L)^(1-n)/day");
            public static readonly Unit MilliGramsPerLiterNPerSecond = new Unit("milliGramsPerLiterNPerSecond", Dimensions.NthOrderBulkReactionRate, 1.0 / (1.0), "(mg/L)^(1-n)/s");
            public static readonly Unit PartsPerBillionNPerDay = new Unit("partsPerBillionNPerDay", Dimensions.NthOrderBulkReactionRate, 1.0 / (86400000.0), "ppb^(1-n)/day");
            public static readonly Unit PartsPerBillionNPerSecond = new Unit("partsPerBillionNPerSecond", Dimensions.NthOrderBulkReactionRate, 1.0 / (1000), "ppb^(1-n)/s");
            public static readonly Unit PartsPerMillionNPerDay = new Unit("partsPerMillionNPerDay", Dimensions.NthOrderBulkReactionRate, 1.0 / (86400.0), "ppm^(1-n)/day");
            public static readonly Unit PartsPerMillionNPerSecond = new Unit("partsPerMillionNPerSecond", Dimensions.NthOrderBulkReactionRate, 1.0 / (1.0), "ppm^(1-n)/s");
            public static readonly Unit PoundsPerCubicFootNPerDay = new Unit("poundsPerCubicFootNPerDay", Dimensions.NthOrderBulkReactionRate, 1.0 / (9.11336779), "(lb/ft³)^(1-n)/day");
            public static readonly Unit PoundsPerCubicFootNPerSecond = new Unit("poundsPerCubicFootNPerSecond", Dimensions.NthOrderBulkReactionRate, 1.0 / (6.242621e-5), "(lb/ft³)^(1-n)/s");
            public static readonly Unit PoundsPerMillionGallonsNPerDay = new Unit("poundsPerMillionGallonsNPerDay", Dimensions.NthOrderBulkReactionRate, 1.0 / (721025.28), "(lb/milliongal)^(1-n)/day");
            public static readonly Unit PoundsPerMillionGallonsNPerSecond = new Unit("poundsPerMillionGallonsNPerSecond", Dimensions.NthOrderBulkReactionRate, 1.0 / (8.3452), "(lb/milliongal)^(1-n)/s");
            public static readonly Unit[] All = new Unit[] { MicrogramsPerLiterNPerDay, MicrogramsPerLiterNPerSecond, MilliGramsPerLiterNPerDay, MilliGramsPerLiterNPerSecond, PartsPerBillionNPerDay, PartsPerBillionNPerSecond, PartsPerMillionNPerDay, PartsPerMillionNPerSecond, PoundsPerCubicFootNPerDay, PoundsPerCubicFootNPerSecond, PoundsPerMillionGallonsNPerDay, PoundsPerMillionGallonsNPerSecond };
        }

        public static class ZeroOrderSurfaceReactionRate
        {
            public static readonly Unit MicrogramsPerSquareFeetPerDay = new Unit("microgramsPerSquareFeetPerDay", Dimensions.ZeroOrderSurfaceReactionRate, 1.0 / (8026822.967), "µg/ft²/day");
            public static readonly Unit MicrogramsPerSquareMeterPerDay = new Unit("microgramsPerSquareMeterPerDay", Dimensions.ZeroOrderSurfaceReactionRate, 1.0 / (86400000.0), "µg/m²/day");
            public static readonly Unit MicrogramsPerSquareMeterPerSecond = new Unit("microgramsPerSquareMeterPerSecond", Dimensions.ZeroOrderSurfaceReactionRate, 1.0 / (1000.0), "µg/m²/s");
            public static readonly Unit MilliGramsPerSquareFeetPerDay = new Unit("milliGramsPerSquareFeetPerDay", Dimensions.ZeroOrderSurfaceReactionRate, 1.0 / (8026.822967), "mg/ft²/day");
            public static readonly Unit MilliGramsPerSquareMeterPerDay = new Unit("milliGramsPerSquareMeterPerDay", Dimensions.ZeroOrderSurfaceReactionRate, 1.0 / (86400.0), "mg/m²/day");
            public static readonly Unit MilliGramsPerSquareMeterPerSecond = new Unit("milliGramsPerSquareMeterPerSecond", Dimensions.ZeroOrderSurfaceReactionRate, 1.0 / (1.0), "mg/m²/s");
            public static readonly Unit[] All = new Unit[] { MicrogramsPerSquareFeetPerDay, MicrogramsPerSquareMeterPerDay, MicrogramsPerSquareMeterPerSecond, MilliGramsPerSquareFeetPerDay, MilliGramsPerSquareMeterPerDay, MilliGramsPerSquareMeterPerSecond };
        }

        public static class ReactionRate
        {
            public static readonly Unit PerDay = new Unit("perDay", Dimensions.ReactionRate, 1.0 / (86400), "/day");
            public static readonly Unit PerSecond = new Unit("perSecond", Dimensions.ReactionRate, 1.0 / (1), "/sec");
            public static readonly Unit PerMinute = new Unit("perMinute", Dimensions.ReactionRate, 1.0 / (60), "/min");
            public static readonly Unit PerHour = new Unit("perHour", Dimensions.ReactionRate, 1.0 / (3600), "/hour");
            public static readonly Unit[] All = new Unit[] { PerDay, PerSecond, PerMinute, PerHour };
        }

        public static class Percent
        {
            public static readonly Unit PercentPercent = new Unit("percentPercent", Dimensions.Percent, 1.0 / (1.0), "%%");
            public static readonly Unit UnitlessPercent = new Unit("unitlessPercent", Dimensions.Percent, 1.0 / (0.01), "");
            public static readonly Unit[] All = new Unit[] { PercentPercent, UnitlessPercent };
        }

        public static class PopulationDensityPerArea
        {
            public static readonly Unit PersonsPerAcre = new Unit("personsPerAcre", Dimensions.PopulationDensityPerArea, 1.0 / (4046.8564464278), "pop/acre");
            public static readonly Unit PersonsPerSquareFeet = new Unit("personsPerSquareFeet", Dimensions.PopulationDensityPerArea, 1.0 / (0.09290304), "pop/ft²");
            public static readonly Unit PersonsPerSquareKilometer = new Unit("personsPerSquareKilometer", Dimensions.PopulationDensityPerArea, 1.0 / (1e6), "pop/km²");
            public static readonly Unit PersonsPerHectares = new Unit("personsPerHectares", Dimensions.PopulationDensityPerArea, 1.0 / (1e4), "pop/ha");
            public static readonly Unit PersonsPerSquareMeter = new Unit("personsPerSquareMeter", Dimensions.PopulationDensityPerArea, 1.0 / (1.0), "pop/m²");
            public static readonly Unit PersonsPerSquareMile = new Unit("personsPerSquareMile", Dimensions.PopulationDensityPerArea, 1.0 / (2589988.1005586708), "pop/mile²");
            public static readonly Unit[] All = new Unit[] { PersonsPerAcre, PersonsPerSquareFeet, PersonsPerSquareKilometer, PersonsPerHectares, PersonsPerSquareMeter, PersonsPerSquareMile };
        }

        public static class RotationalFrequency
        {
            public static readonly Unit Rpm = new Unit("rpm", Dimensions.RotationalFrequency, 1.0 / (1.0), "rpm");
            public static readonly Unit[] All = new Unit[] { Rpm };
        }

        public static class Unitless
        {
            public static readonly Unit UnitlessUnit = new Unit("unitlessUnit", Dimensions.Unitless, 1.0 / (1), "");
            public static readonly Unit[] All = new Unit[] { UnitlessUnit };
        }

        public static class Velocity
        {
            public static readonly Unit VelocityCentimetersPerHour = new Unit("velocityCentimetersPerHour", Dimensions.Velocity, 1.0 / (3.6e5), "cm/h");
            public static readonly Unit VelocityCentimetersPerMinute = new Unit("velocityCentimetersPerMinute", Dimensions.Velocity, 1.0 / (6.0e3), "cm/min");
            public static readonly Unit VelocityCentimetersPerSecond = new Unit("velocityCentimetersPerSecond", Dimensions.Velocity, 1.0 / (100.0), "cm/s");
            public static readonly Unit VelocityFeetPerHour = new Unit("velocityFeetPerHour", Dimensions.Velocity, 1.0 / (1.18110234e4), "ft/h");
            public static readonly Unit VelocityFeetPerMinute = new Unit("velocityFeetPerMinute", Dimensions.Velocity, 1.0 / (196.85039), "ft/min");
            public static readonly Unit VelocityFeetPerSecond = new Unit("velocityFeetPerSecond", Dimensions.Velocity, 1.0 / (3.2808399), "ft/s");
            public static readonly Unit VelocityInchesPerHour = new Unit("velocityInchesPerHour", Dimensions.Velocity, 1.0 / (1.417323e5), "in/h");
            public static readonly Unit VelocityInchesPerMinute = new Unit("velocityInchesPerMinute", Dimensions.Velocity, 1.0 / (2.36220474e3), "in/min");
            public static readonly Unit VelocityInchesPerSecond = new Unit("velocityInchesPerSecond", Dimensions.Velocity, 1.0 / (39.370079), "in/s");
            public static readonly Unit VelocityKilometersPerHour = new Unit("velocityKilometersPerHour", Dimensions.Velocity, 1.0 / (3.6), "km/h");
            public static readonly Unit VelocityKnot = new Unit("velocityKnot", Dimensions.Velocity, 1.0 / (1.942606763), "kn(UK)");
            public static readonly Unit VelocityKnotInternational = new Unit("velocityKnotInternational", Dimensions.Velocity, 1.0 / (1.94384448), "kn(Int)");
            public static readonly Unit VelocityMetersPerHour = new Unit("velocityMetersPerHour", Dimensions.Velocity, 1.0 / (3600), "m/h");
            public static readonly Unit VelocityMetersPerMinute = new Unit("velocityMetersPerMinute", Dimensions.Velocity, 1.0 / (60.0), "m/min");
            public static readonly Unit VelocityMetersPerSecond = new Unit("velocityMetersPerSecond", Dimensions.Velocity, 1.0 / (1.0), "m/s");
            public static readonly Unit VelocityMilePerHour = new Unit("velocityMilePerHour", Dimensions.Velocity, 1.0 / (2.2369363), "mile/h");
            public static readonly Unit[] All = new Unit[] { VelocityCentimetersPerHour, VelocityCentimetersPerMinute, VelocityCentimetersPerSecond, VelocityFeetPerHour, VelocityFeetPerMinute, VelocityFeetPerSecond, VelocityInchesPerHour, VelocityInchesPerMinute, VelocityInchesPerSecond, VelocityKilometersPerHour, VelocityKnot, VelocityKnotInternational, VelocityMetersPerHour, VelocityMetersPerMinute, VelocityMetersPerSecond, VelocityMilePerHour };
        }

        public static class WeirCoefficient
        {
            public static readonly Unit WeircoefficientSi = new Unit("weircoefficientSi", Dimensions.WeirCoefficient, 1.0 / (0.5520735), "m^(1/2)/s");
            public static readonly Unit WeircoefficientUs = new Unit("weircoefficientUs", Dimensions.WeirCoefficient, 1.0 / (1.0), "ft^(1/2)/s");
            public static readonly Unit[] All = new Unit[] { WeircoefficientSi, WeircoefficientUs };
        }

        public static class DiameterLength
        {
            public static readonly Unit InchMiles = new Unit("inchMiles", Dimensions.DiameterLength, 1.0 / (1.0), "in-mile");
            public static readonly Unit InchFeet = new Unit("inchFeet", Dimensions.DiameterLength, 1.0 / (5280.0), "in-ft");
            public static readonly Unit FootMiles = new Unit("footMiles", Dimensions.DiameterLength, 1.0 / ((1.0 / 12.0)), "ft-mile");
            public static readonly Unit FootFeet = new Unit("footFeet", Dimensions.DiameterLength, 1.0 / (440.0), "ft-ft");
            public static readonly Unit MillimeterMeters = new Unit("millimeterMeters", Dimensions.DiameterLength, 1.0 / (40877.3376), "mm-m");
            public static readonly Unit MillimeterKilometers = new Unit("millimeterKilometers", Dimensions.DiameterLength, 1.0 / (40.8773376), "mm-km");
            public static readonly Unit MeterMeters = new Unit("meterMeters", Dimensions.DiameterLength, 1.0 / (40.8773376), "m-m");
            public static readonly Unit MeterKilometers = new Unit("meterKilometers", Dimensions.DiameterLength, 1.0 / (0.040877338), "m-km");
            public static readonly Unit InchMeters = new Unit("inchMeters", Dimensions.DiameterLength, 1.0 / (1609.34400), "in-m");
            public static readonly Unit MillimeterMiles = new Unit("millimeterMiles", Dimensions.DiameterLength, 1.0 / (25.4000000), "mm-mile");
            public static readonly Unit[] All = new Unit[] { InchMiles, InchFeet, FootMiles, FootFeet, MillimeterMeters, MillimeterKilometers, MeterMeters, MeterKilometers, InchMeters, MillimeterMiles };
        }

        public static class MassPerArea
        {
            public static readonly Unit PoundsPerAcre = new Unit("poundsPerAcre", Dimensions.MassPerArea, 1.0 / (1.0), "lbs/acre");
            public static readonly Unit KilogramsPerHectare = new Unit("kilogramsPerHectare", Dimensions.MassPerArea, 1.0 / (1.12085116518377), "kg/ha");
            public static readonly Unit MilligramsPerSquareFeet = new Unit("milligramsPerSquareFeet", Dimensions.MassPerArea, 1.0 / (0.010413048), "mg/ft²");
            public static readonly Unit MicrogramsPerSquareFeet = new Unit("microgramsPerSquareFeet", Dimensions.MassPerArea, 1.0 / (10.41304806), "µg/ft²");
            public static readonly Unit MilligramsPerSquareMeter = new Unit("milligramsPerSquareMeter", Dimensions.MassPerArea, 1.0 / (0.1120851165), "mg/m²");
            public static readonly Unit MicrogramsPerSquareMeter = new Unit("microgramsPerSquareMeter", Dimensions.MassPerArea, 1.0 / (112.0851165), "µg/m²");
            public static readonly Unit MilligramsPerSquareCentimeter = new Unit("milligramsPerSquareCentimeter", Dimensions.MassPerArea, 1.0 / (1120.851165), "mg/cm²");
            public static readonly Unit MicrogramsPerSquareCentimeter = new Unit("microgramsPerSquareCentimeter", Dimensions.MassPerArea, 1.0 / (1120851.165), "µg/cm²");
            public static readonly Unit[] All = new Unit[] { PoundsPerAcre, KilogramsPerHectare, MilligramsPerSquareFeet, MicrogramsPerSquareFeet, MilligramsPerSquareMeter, MicrogramsPerSquareMeter, MilligramsPerSquareCentimeter, MicrogramsPerSquareCentimeter };
        }

        public static class CurrencyPerPower
        {
            public static readonly Unit DollarsPerKiloWatt = new Unit("dollarsPerKiloWatt", Dimensions.CurrencyPerPower, 1.0 / (1.0), "%1/kW");
            public static readonly Unit DollarsPerHorsepower = new Unit("dollarsPerHorsepower", Dimensions.CurrencyPerPower, 1.0 / (0.745699872), "%1/Horsepower");
            public static readonly Unit[] All = new Unit[] { DollarsPerKiloWatt, DollarsPerHorsepower };
        }

        public static class Inertia
        {
            public static readonly Unit PoundSquareFeet = new Unit("poundSquareFeet", Dimensions.Inertia, 1.0 / (1.0), "lb·ft²");
            public static readonly Unit NewtonSquareMeters = new Unit("newtonSquareMeters", Dimensions.Inertia, 1.0 / (0.41325322), "N·m²");
            public static readonly Unit KilogramSquareMeters = new Unit("kilogramSquareMeters", Dimensions.Inertia, 1.0 / (0.04214011), "kg·m²");
            public static readonly Unit[] All = new Unit[] { PoundSquareFeet, NewtonSquareMeters, KilogramSquareMeters };
        }

        public static class CostPerUnitVolume
        {
            public static readonly Unit DollarsPerCubicCentimeters = new Unit("dollarsPerCubicCentimeters", Dimensions.CostPerUnitVolume, 1.0 / (1 / 1000000.0000000), "%1/cm³");
            public static readonly Unit DollarsPerLiters = new Unit("dollarsPerLiters", Dimensions.CostPerUnitVolume, 1.0 / (1 / 1000.0000000), "%1/L");
            public static readonly Unit DollarsPerCubicMeters = new Unit("dollarsPerCubicMeters", Dimensions.CostPerUnitVolume, 1.0 / (1 / 1.0000000), "%1/m³");
            public static readonly Unit DollarsPerCubicInches = new Unit("dollarsPerCubicInches", Dimensions.CostPerUnitVolume, 1.0 / (1 / 61023.7400000), "%1/in³");
            public static readonly Unit DollarsPerGallons = new Unit("dollarsPerGallons", Dimensions.CostPerUnitVolume, 1.0 / (1 / 264.1720500), "%1/gal");
            public static readonly Unit DollarsPerImpGallons = new Unit("dollarsPerImpGallons", Dimensions.CostPerUnitVolume, 1.0 / (1 / 219.9694000), "%1/Imp Gal");
            public static readonly Unit DollarsPerCubicFeet = new Unit("dollarsPerCubicFeet", Dimensions.CostPerUnitVolume, 1.0 / (1 / 35.3146670), "%1/ft³");
            public static readonly Unit DollarsPerCubicYards = new Unit("dollarsPerCubicYards", Dimensions.CostPerUnitVolume, 1.0 / (1 / 1.3079506), "%1/yards³");
            public static readonly Unit DollarsPerAcreInches = new Unit("dollarsPerAcreInches", Dimensions.CostPerUnitVolume, 1.0 / (1 / 0.0097286), "%1/acre-in");
            public static readonly Unit DollarsPerAcreFeet = new Unit("dollarsPerAcreFeet", Dimensions.CostPerUnitVolume, 1.0 / (1 / 0.0008107), "%1/acre-ft");
            public static readonly Unit DollarsPerMillionGallons = new Unit("dollarsPerMillionGallons", Dimensions.CostPerUnitVolume, 1.0 / (1 / 0.0002642), "%1/MG");
            public static readonly Unit DollarsPerThousandGallons = new Unit("dollarsPerThousandGallons", Dimensions.CostPerUnitVolume, 1.0 / (1 / 0.2641721), "%1/(gal x 10³)");
            public static readonly Unit DollarsPerThousandLiters = new Unit("dollarsPerThousandLiters", Dimensions.CostPerUnitVolume, 1.0 / (1 / 1.0000000), "%1/(L x 10³)");
            public static readonly Unit DollarsPerMillionLiters = new Unit("dollarsPerMillionLiters", Dimensions.CostPerUnitVolume, 1.0 / (1 / 0.0010000), "%1/ML");
            public static readonly Unit[] All = new Unit[] { DollarsPerCubicCentimeters, DollarsPerLiters, DollarsPerCubicMeters, DollarsPerCubicInches, DollarsPerGallons, DollarsPerImpGallons, DollarsPerCubicFeet, DollarsPerCubicYards, DollarsPerAcreInches, DollarsPerAcreFeet, DollarsPerMillionGallons, DollarsPerThousandGallons, DollarsPerThousandLiters, DollarsPerMillionLiters };
        }

        public static class EnergyPerUnitVolume
        {
            public static readonly Unit KiloWattHourPerMillionGallons = new Unit("kiloWattHourPerMillionGallons", Dimensions.EnergyPerUnitVolume, 1.0 / (1 / 0.0002642), "kWh/MG");
            public static readonly Unit KiloWattHourPerMillionLiters = new Unit("kiloWattHourPerMillionLiters", Dimensions.EnergyPerUnitVolume, 1.0 / (1 / 0.0010000), "kWh/ML");
            public static readonly Unit KiloWattHourPerCubicMeters = new Unit("kiloWattHourPerCubicMeters", Dimensions.EnergyPerUnitVolume, 1.0 / (1.0), "kWh/m³");
            public static readonly Unit KiloWattHourPerCubicFeet = new Unit("kiloWattHourPerCubicFeet", Dimensions.EnergyPerUnitVolume, 1.0 / (1 / 35.3146670), "kWh/ft³");
            public static readonly Unit[] All = new Unit[] { KiloWattHourPerMillionGallons, KiloWattHourPerMillionLiters, KiloWattHourPerCubicMeters, KiloWattHourPerCubicFeet };
        }

        public static class Torque
        {
            public static readonly Unit NewtonMeters = new Unit("newtonMeters", Dimensions.Torque, 1.0 / (1.0), "N·m");
            public static readonly Unit PoundFeet = new Unit("poundFeet", Dimensions.Torque, 1.0 / (0.737562), "lb·ft");
            public static readonly Unit[] All = new Unit[] { NewtonMeters, PoundFeet };
        }

        public static class SpringConstant
        {
            public static readonly Unit PoundPerInch = new Unit("poundPerInch", Dimensions.SpringConstant, 1.0 / (1.0), "lb/in");
            public static readonly Unit NewtonPerMillimeter = new Unit("newtonPerMillimeter", Dimensions.SpringConstant, 1.0 / (0.175126797), "N/mm");
            public static readonly Unit[] All = new Unit[] { PoundPerInch, NewtonPerMillimeter };
        }

        public static class Force
        {
            public static readonly Unit PoundForce = new Unit("poundForce", Dimensions.Force, 1.0 / (1.0), "lb");
            public static readonly Unit KiloPoundForce = new Unit("kiloPoundForce", Dimensions.Force, 1.0 / (0.001), "klb");
            public static readonly Unit Newton = new Unit("newton", Dimensions.Force, 1.0 / (4.4488222), "N");
            public static readonly Unit KiloNewton = new Unit("kiloNewton", Dimensions.Force, 1.0 / (0.0044488222), "kN");
            public static readonly Unit[] All = new Unit[] { PoundForce, KiloPoundForce, Newton, KiloNewton };
        }

        public static class Density
        {
            public static readonly Unit SlugPerCubicFoot = new Unit("slugPerCubicFoot", Dimensions.Density, 1.0 / (1.0), "slug/ft³");
            public static readonly Unit PoundPerCubicFoot = new Unit("poundPerCubicFoot", Dimensions.Density, 1.0 / (32.174054), "lb/ft³");
            public static readonly Unit KilogramPerCubicMeter = new Unit("kilogramPerCubicMeter", Dimensions.Density, 1.0 / (515.3788), "kg/m³");
            public static readonly Unit[] All = new Unit[] { SlugPerCubicFoot, PoundPerCubicFoot, KilogramPerCubicMeter };
        }

        public static class DischargePerPressureDrop
        {
            public static readonly Unit CfsPerSquareRootFooH20 = new Unit("cfsPerSquareRootFooH20", Dimensions.DischargePerPressureDrop, 1.0 / (19.5), "cfs/(ft H2O)^0.5");
            public static readonly Unit CmsPerSquareRootMeterH20 = new Unit("cmsPerSquareRootMeterH20", Dimensions.DischargePerPressureDrop, 1.0 / (1), "m³/s/(m H2O)^0.5");
            public static readonly Unit LPerSecPerSquareRootKpa = new Unit("lPerSecPerSquareRootKpa", Dimensions.DischargePerPressureDrop, 1.0 / (319.3305497), "L/s/kPa^0.5");
            public static readonly Unit GpmPerSquareRootPsi = new Unit("gpmPerSquareRootPsi", Dimensions.DischargePerPressureDrop, 1.0 / (13290.37762), "gpm/psi^0.5");
            public static readonly Unit[] All = new Unit[] { CfsPerSquareRootFooH20, CmsPerSquareRootMeterH20, LPerSecPerSquareRootKpa, GpmPerSquareRootPsi };
        }

        public static class SideWeirCoefficient
        {
            public static readonly Unit SideWeirCoefficientSi = new Unit("sideWeirCoefficientSi", Dimensions.SideWeirCoefficient, 1.0 / (0.672984385), "m^(1/3)/s");
            public static readonly Unit SideWeirCoefficientUs = new Unit("sideWeirCoefficientUs", Dimensions.SideWeirCoefficient, 1.0 / (1.0), "ft^(1/3)/s");
            public static readonly Unit[] All = new Unit[] { SideWeirCoefficientSi, SideWeirCoefficientUs };
        }

        public static class VolumePerLength
        {
            public static readonly Unit CubicFeetPerFoot = new Unit("cubicFeetPerFoot", Dimensions.VolumePerLength, 1.0 / (10.7639104), "ft³/ft");
            public static readonly Unit CubicMetersPerMeter = new Unit("cubicMetersPerMeter", Dimensions.VolumePerLength, 1.0 / (1.0), "m³/m");
            public static readonly Unit[] All = new Unit[] { CubicFeetPerFoot, CubicMetersPerMeter };
        }

        public static class DynamicViscosity
        {
            public static readonly Unit KilogramsPerMeterPerSecond = new Unit("kilogramsPerMeterPerSecond", Dimensions.DynamicViscosity, 1.0 / (1.0), "kg/(m·s)");
            public static readonly Unit PoundSecondPerSquareFoot = new Unit("poundSecondPerSquareFoot", Dimensions.DynamicViscosity, 1.0 / (47.8831726), "lbf·s/ft²");
            public static readonly Unit[] All = new Unit[] { KilogramsPerMeterPerSecond, PoundSecondPerSquareFoot };
        }

        public static class PerPressure
        {
            public static readonly Unit PerPascals = new Unit("perPascals", Dimensions.PerPressure, 1.0 / (1.0), "1/Pa");
            public static readonly Unit PerBars = new Unit("perBars", Dimensions.PerPressure, 1.0 / (100000.0), "1/bar");
            public static readonly Unit PerPSI = new Unit("perPSI", Dimensions.PerPressure, 1.0 / (6894.75728), "1/psi");
            public static readonly Unit[] All = new Unit[] { PerPascals, PerBars, PerPSI };
        }

        public static class PerLength
        {
            public static readonly Unit PerMeter = new Unit("perMeter", Dimensions.PerLength, 1.0 / (1.0), "1/m");
            public static readonly Unit PerMillimeter = new Unit("perMillimeter", Dimensions.PerLength, 1.0 / (1000.0), "1/mm");
            public static readonly Unit[] All = new Unit[] { PerMeter, PerMillimeter };
        }

        public static class MassPerLength
        {
            public static readonly Unit KilogramsPerMeter = new Unit("kilogramsPerMeter", Dimensions.MassPerLength, 1.0 / (1.0), "kg/m");
            public static readonly Unit PoundsPerFoot = new Unit("poundsPerFoot", Dimensions.MassPerLength, 1.0 / (0.6719689685), "lb/ft");
            public static readonly Unit[] All = new Unit[] { KilogramsPerMeter, PoundsPerFoot };
        }

        public static class PressurePerLength
        {
            public static readonly Unit PascalsPerMeter = new Unit("pascalsPerMeter", Dimensions.PressurePerLength, 1.0 / (1), "Pa/m");
            public static readonly Unit BarsPerKilometer = new Unit("barsPerKilometer", Dimensions.PressurePerLength, 1.0 / (0.01), "bar/km");
            public static readonly Unit PSIPerFoot = new Unit("PSIPerFoot", Dimensions.PressurePerLength, 1.0 / (4.42075E-5), "psi/ft");
            public static readonly Unit PSIPerInch = new Unit("PSIPerInch", Dimensions.PressurePerLength, 1.0 / (3.68396E-6), "psi/in");
            public static readonly Unit[] All = new Unit[] { PascalsPerMeter, BarsPerKilometer, PSIPerFoot, PSIPerInch };
        }

        public static class CalorificValue
        {
            public static readonly Unit JoulesPerCubicMeters = new Unit("joulesPerCubicMeters", Dimensions.CalorificValue, 1.0 / (1), "J/m³");
            public static readonly Unit KiloJoulesPerCubicMeters = new Unit("kiloJoulesPerCubicMeters", Dimensions.CalorificValue, 1.0 / (0.001), "kJ/m³");
            public static readonly Unit MegaJoulesPerCubicMeters = new Unit("megaJoulesPerCubicMeters", Dimensions.CalorificValue, 1.0 / (0.000001), "MJ/m³");
            public static readonly Unit KiloWattHoursPerCubicMeters = new Unit("kiloWattHoursPerCubicMeters", Dimensions.CalorificValue, 1.0 / (1 / 3600.0 / 1000.0), "kWh/m³");
            public static readonly Unit[] All = new Unit[] { JoulesPerCubicMeters, KiloJoulesPerCubicMeters, MegaJoulesPerCubicMeters, KiloWattHoursPerCubicMeters };
        }

        public static class SnowMeltCoefficient
        {
            public static readonly Unit MillimetersPerHourPerDegreeCelsius = new Unit("millimetersPerHourPerDegreeCelsius", Dimensions.SnowMeltCoefficient, 1.0 / (1.0), "mm/h/C");
            public static readonly Unit InchesPerHourPerDegreeFahrenheit = new Unit("inchesPerHourPerDegreeFahrenheit", Dimensions.SnowMeltCoefficient, 1.0 / (((9.0 / 5.0) / 25.4)), "in/h/F");
            public static readonly Unit[] All = new Unit[] { MillimetersPerHourPerDegreeCelsius, InchesPerHourPerDegreeFahrenheit };
        }

        public static class BreakRate
        {
            public static readonly Unit BreakRatePerKm = new Unit("breakRatePerKm", Dimensions.BreakRate, 1.0 / (1.0), "breaks/yr/km");
            public static readonly Unit BreakRatePerMi = new Unit("breakRatePerMi", Dimensions.BreakRate, 1.0 / (1.609344), "breaks/yr/mi");
            public static readonly Unit BreakRatePer1000Ft = new Unit("breakRatePer1000Ft", Dimensions.BreakRate, 1.0 / (0.304800), "breaks/yr/1000 ft");
            public static readonly Unit BreakRatePer100Mi = new Unit("breakRatePer100Mi", Dimensions.BreakRate, 1.0 / (0.6213712), "breaks/yr/100 mi");
            public static readonly Unit[] All = new Unit[] { BreakRatePerKm, BreakRatePerMi, BreakRatePer1000Ft, BreakRatePer100Mi };
        }

        public static class MassPerEnergy
        {
            public static readonly Unit PoundsPerKilowattHour = new Unit("poundsPerKilowattHour", Dimensions.MassPerEnergy, 1.0 / (1.0), "lb/kWh");
            public static readonly Unit KilogramsPerKilowattHour = new Unit("kilogramsPerKilowattHour", Dimensions.MassPerEnergy, 1.0 / (0.45359237), "kg/kWh");
            public static readonly Unit TonnesPerMegaJoule = new Unit("tonnesPerMegaJoule", Dimensions.MassPerEnergy, 1.0 / (1.2599788e-4), "t/MJ");
            public static readonly Unit[] All = new Unit[] { PoundsPerKilowattHour, KilogramsPerKilowattHour, TonnesPerMegaJoule };
        }

        public static class ValveOpenCloseRateCoefficient
        {
            public static readonly Unit PercentPerSecondPerMeterH2O = new Unit("percentPerSecondPerMeterH2O", Dimensions.ValveOpenCloseRateCoefficient, 1.0 / (1.0 / 0.101972), "%%/s/(m H2O)");
            public static readonly Unit PercentPerSecondPerFtH2O = new Unit("percentPerSecondPerFtH2O", Dimensions.ValveOpenCloseRateCoefficient, 1.0 / (1.0 / 0.33455), "%%/s/(ft H2O)");
            public static readonly Unit PercentPerSecondPerKiloPascal = new Unit("percentPerSecondPerKiloPascal", Dimensions.ValveOpenCloseRateCoefficient, 1.0 / (1.0), "%%/s/kPa");
            public static readonly Unit PercentPerSecondPerPSI = new Unit("percentPerSecondPerPSI", Dimensions.ValveOpenCloseRateCoefficient, 1.0 / (1.0 / 0.1450377), "%%/s/psi");
            public static readonly Unit[] All = new Unit[] { PercentPerSecondPerMeterH2O, PercentPerSecondPerFtH2O, PercentPerSecondPerKiloPascal, PercentPerSecondPerPSI };
        }

        public static class EnergyPerPower
        {
            public static readonly Unit KilowattHoursPerKilowatt = new Unit("kilowattHoursPerKilowatt", Dimensions.EnergyPerPower, 1.0 / (1.0), "kWh/kW");
            public static readonly Unit[] All = new Unit[] { KilowattHoursPerKilowatt };
        }

        public static class NumberPerVolume
        {
            public static readonly Unit NumbersPerLiter = new Unit("numbersPerLiter", Dimensions.NumberPerVolume, 1.0 / (1.0), "Count/L");
            public static readonly Unit ThousandNumbersPerLiter = new Unit("thousandNumbersPerLiter", Dimensions.NumberPerVolume, 1.0 / (0.001), "Thousand/L");
            public static readonly Unit MillionNumbersPerLiter = new Unit("millionNumbersPerLiter", Dimensions.NumberPerVolume, 1.0 / (0.000001), "Million/L");
            public static readonly Unit[] All = new Unit[] { NumbersPerLiter, ThousandNumbersPerLiter, MillionNumbersPerLiter };
        }

        public static class NumberPerArea
        {
            public static readonly Unit NumbersPerSquareMeter = new Unit("numbersPerSquareMeter", Dimensions.NumberPerArea, 1.0 / (1.0), "Count/m²");
            public static readonly Unit ThousandNumbersPerSquareMeter = new Unit("thousandNumbersPerSquareMeter", Dimensions.NumberPerArea, 1.0 / (0.001), "Thousand/m²");
            public static readonly Unit MillionNumbersPerSquareMeter = new Unit("millionNumbersPerSquareMeter", Dimensions.NumberPerArea, 1.0 / (0.000001), "Million/m²");
            public static readonly Unit NumbersPerSquareFeet = new Unit("numbersPerSquareFeet", Dimensions.NumberPerArea, 1.0 / (0.09290304), "Count/ft²");
            public static readonly Unit ThousandNumbersPerSquareFeet = new Unit("thousandNumbersPerSquareFeet", Dimensions.NumberPerArea, 1.0 / (9.290304E-5), "Thousand/ft²");
            public static readonly Unit MillionNumbersPerSquareFeet = new Unit("millionNumbersPerSquareFeet", Dimensions.NumberPerArea, 1.0 / (9.290304E-8), "Million/ft²");
            public static readonly Unit NumbersPerSquareCentimeter = new Unit("numbersPerSquareCentimeter", Dimensions.NumberPerArea, 1.0 / (1.0E-4), "Count/cm²");
            public static readonly Unit ThousandNumbersPerSquareCentimeter = new Unit("thousandNumbersPerSquareCentimeter", Dimensions.NumberPerArea, 1.0 / (1.0E-7), "Thousand/cm²");
            public static readonly Unit MillionNumbersPerSquareCentimeter = new Unit("millionNumbersPerSquareCentimeter", Dimensions.NumberPerArea, 1.0 / (1.0E-10), "Million/cm²");
            public static readonly Unit[] All = new Unit[] { NumbersPerSquareMeter, ThousandNumbersPerSquareMeter, MillionNumbersPerSquareMeter, NumbersPerSquareFeet, ThousandNumbersPerSquareFeet, MillionNumbersPerSquareFeet, NumbersPerSquareCentimeter, ThousandNumbersPerSquareCentimeter, MillionNumbersPerSquareCentimeter };
        }

        public static class MolesPerVolume
        {
            public static readonly Unit MolesPerLiter = new Unit("molesPerLiter", Dimensions.MolesPerVolume, 1.0 / (1), "mole/L");
            public static readonly Unit MilliMolesPerLiter = new Unit("milliMolesPerLiter", Dimensions.MolesPerVolume, 1.0 / (1000), "mmole/L");
            public static readonly Unit[] All = new Unit[] { MolesPerLiter, MilliMolesPerLiter };
        }

        public static class MolesPerArea
        {
            public static readonly Unit MolesPerSquareMeter = new Unit("molesPerSquareMeter", Dimensions.MolesPerArea, 1.0 / (1.0), "mole/m²");
            public static readonly Unit MilliMolesPerSquareMeter = new Unit("milliMolesPerSquareMeter", Dimensions.MolesPerArea, 1.0 / (1000.0), "mmole/m²");
            public static readonly Unit MolesPerSquareFeet = new Unit("molesPerSquareFeet", Dimensions.MolesPerArea, 1.0 / (0.09290304), "mole/ft²");
            public static readonly Unit MilliMolesPerSquareFeet = new Unit("milliMolesPerSquareFeet", Dimensions.MolesPerArea, 1.0 / (92.90304), "mmole/ft²");
            public static readonly Unit MolesPerSquareCentimeter = new Unit("molesPerSquareCentimeter", Dimensions.MolesPerArea, 1.0 / (0.0001), "mole/cm²");
            public static readonly Unit MilliMolesPerSquareCentimeter = new Unit("milliMolesPerSquareCentimeter", Dimensions.MolesPerArea, 1.0 / (0.1), "mmole/cm²");
            public static readonly Unit[] All = new Unit[] { MolesPerSquareMeter, MilliMolesPerSquareMeter, MolesPerSquareFeet, MilliMolesPerSquareFeet, MolesPerSquareCentimeter, MilliMolesPerSquareCentimeter };
        }

        public static class ValveOpenCloseRateCoefficientPerFlow
        {
            public static readonly Unit PercentPerSecondPerCubicFeetPerSecond = new Unit("PercentPerSecondPerCubicFeetPerSecond", Dimensions.ValveOpenCloseRateCoefficientPerFlow, 1.0 / (1.0 / 35.314667), "%%/s/(ft³/s)");
            public static readonly Unit PercentPerSecondPerCubicFeetPerMinute = new Unit("PercentPerSecondPerCubicFeetPerMinute", Dimensions.ValveOpenCloseRateCoefficientPerFlow, 1.0 / (1.0 / 2118.88002), "%%/s/(ft³/min)");
            public static readonly Unit PercentPerSecondPerCubicMeterPerSecond = new Unit("PercentPerSecondPerCubicMeterPerSecond", Dimensions.ValveOpenCloseRateCoefficientPerFlow, 1.0 / (1.0), "%%/s/(m³/s)");
            public static readonly Unit PercentPerSecondPerCubicMeterPerMinute = new Unit("PercentPerSecondPerCubicMeterPerMinute", Dimensions.ValveOpenCloseRateCoefficientPerFlow, 1.0 / (1.0 / 60.0), "%%/s/(m³/min)");
            public static readonly Unit PercentPerSecondPerLiterPerSecond = new Unit("PercentPerSecondPerLiterPerSecond", Dimensions.ValveOpenCloseRateCoefficientPerFlow, 1.0 / (1.0 / 1000.0), "%%/s/(L/s)");
            public static readonly Unit PercentPerSecondPerLiterPerMinute = new Unit("PercentPerSecondPerLiterPerMinute", Dimensions.ValveOpenCloseRateCoefficientPerFlow, 1.0 / (1.0 / 60000.0), "%%/s/(L/min)");
            public static readonly Unit PercentPerSecondPerGalPerSecond = new Unit("PercentPerSecondPerGalPerSecond", Dimensions.ValveOpenCloseRateCoefficientPerFlow, 1.0 / (1.0 / 264.17205), "%%/s/(gal/s)");
            public static readonly Unit PercentPerSecondPerGalPerMinute = new Unit("PercentPerSecondPerGalPerMinute", Dimensions.ValveOpenCloseRateCoefficientPerFlow, 1.0 / (1.0 / 15850.323), "%%/s/(gal/min)");
            public static readonly Unit[] All = new Unit[] { PercentPerSecondPerCubicFeetPerSecond, PercentPerSecondPerCubicFeetPerMinute, PercentPerSecondPerCubicMeterPerSecond, PercentPerSecondPerCubicMeterPerMinute, PercentPerSecondPerLiterPerSecond, PercentPerSecondPerLiterPerMinute, PercentPerSecondPerGalPerSecond, PercentPerSecondPerGalPerMinute };
        }

        public static class FlowPerUnitLength
        {
            public static readonly Unit CubicFeetPerMilePerSecond = new Unit("cubicFeetPerMilePerSecond", Dimensions.FlowPerUnitLength, 1.0 / (1.0), "ft³*mi/s");
            public static readonly Unit LitersPerKilometerPerSecond = new Unit("litersPerKilometerPerSecond", Dimensions.FlowPerUnitLength, 1.0 / (45.5714370388), "L*km/s");
            public static readonly Unit QuadFeetPerSecond = new Unit("quadFeetPerSecond", Dimensions.FlowPerUnitLength, 1.0 / (5280.0000000000), "ft^4/s");
            public static readonly Unit GallonsPerFootPerMinute = new Unit("gallonsPerFootPerMinute", Dimensions.FlowPerUnitLength, 1.0 / (658.2857597074), "gal*ft/min");
            public static readonly Unit GallonsPerMilePerMinute = new Unit("gallonsPerMilePerMinute", Dimensions.FlowPerUnitLength, 1.0 / (0.1246753333), "gal*mi/min");
            public static readonly Unit QuadMetersPerSecond = new Unit("quadMetersPerSecond", Dimensions.FlowPerUnitLength, 1.0 / (45.5710940918), "m^4/s");
            public static readonly Unit CubicMetersPerKilometerPerSecond = new Unit("cubicMetersPerKilometerPerSecond", Dimensions.FlowPerUnitLength, 1.0 / (0.0455710941), "m³*km/s");
            public static readonly Unit LitersPerMeterPerSecond = new Unit("litersPerMeterPerSecond", Dimensions.FlowPerUnitLength, 1.0 / (28.3168485459), "L*m/s");
            public static readonly Unit[] All = new Unit[] { CubicFeetPerMilePerSecond, LitersPerKilometerPerSecond, QuadFeetPerSecond, GallonsPerFootPerMinute, GallonsPerMilePerMinute, QuadMetersPerSecond, CubicMetersPerKilometerPerSecond, LitersPerMeterPerSecond };
        }

        public static class Acceleration
        {
            public static readonly Unit Meterspersquaresecond = new Unit("meterspersquaresecond", Dimensions.Acceleration, 1.0 / (1.0), "m/s²");
            public static readonly Unit Feetpersquaresecond = new Unit("feetpersquaresecond", Dimensions.Acceleration, 1.0 / (3.280839895), "ft/s²");
            public static readonly Unit[] All = new Unit[] { Meterspersquaresecond, Feetpersquaresecond };
        }



    }
}
