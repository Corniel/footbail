namespace Footbail;

public sealed partial record Physics
{
    public sealed record BallPhysics
    {
        /// <summary>Area (in m²).</summary>
        public double A => R.Pow2() * Math.PI;

        /// <summary>Drag (default: 0.23).</summary>
        public double Cd { get; init; } = 0.23;

        /// <summary>Mass (default: 0.43kg).</summary>
        public double m { get; init; } = 0.43;

        /// <summary>Radius (default: 0.11m).</summary>
        public double R { get; init; } = 0.11;
    }
}
