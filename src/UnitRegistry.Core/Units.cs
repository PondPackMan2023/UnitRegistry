namespace UnitRegistry
{
    /// <summary>
    /// Provides the curated set of well-known built-in units, grouped by dimension.
    /// Custom units can be introduced by constructing new <see cref="Unit"/> instances directly.
    /// </summary>
    public static class Units
    {
        /// <summary>
        /// Built-in units for the Length dimension. Canonical base unit is the meter.
        /// </summary>
        public static class Length
        {
            /// <summary>Meter — canonical base unit of length.</summary>
            public static readonly Unit Meter = new Unit("meter", Dimensions.Length, 1.0);

            /// <summary>Millimeter — one thousandth of a meter.</summary>
            public static readonly Unit Millimeter = new Unit("millimeter", Dimensions.Length, 0.001);

            /// <summary>Foot — 0.3048 meters.</summary>
            public static readonly Unit Foot = new Unit("foot", Dimensions.Length, 0.3048);
        }

        /// <summary>
        /// Built-in units for the Time dimension. Canonical base unit is the second.
        /// </summary>
        public static class Time
        {
            /// <summary>Second — canonical base unit of time.</summary>
            public static readonly Unit Second = new Unit("second", Dimensions.Time, 1.0);

            /// <summary>Minute — sixty seconds.</summary>
            public static readonly Unit Minute = new Unit("minute", Dimensions.Time, 60.0);

            /// <summary>Hour — three thousand six hundred seconds.</summary>
            public static readonly Unit Hour = new Unit("hour", Dimensions.Time, 3600.0);
        }
    }
}
