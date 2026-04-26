namespace UnitRegistry
{
    /// <summary>
    /// Provides the curated set of well-known built-in dimensions.
    /// Custom dimensions can be introduced by constructing new <see cref="Dimension"/> instances directly.
    /// </summary>
    public static class Dimensions
    {
        /// <summary>
        /// Built-in dimension for lengths and distances.
        /// </summary>
        public static readonly Dimension Length = new Dimension("length");

        /// <summary>
        /// Built-in dimension for durations.
        /// </summary>
        public static readonly Dimension Time = new Dimension("time");
    }
}
