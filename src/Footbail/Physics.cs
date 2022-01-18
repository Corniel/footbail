namespace Footbail;

public sealed partial record Physics
{
    public BallPhysics Ball { get; init; } = new BallPhysics();
    public PitchPhysics Pitch { get; init; } = PitchPhysics.FIFA;

    /// <summary>Air density (default: 1.225kg/m³).</summary>
    public double ρ { get; init; } = 1.225;

    /// <summary>Gravity (default: 9.80665m/s²).</summary>
    public double g { get; init; } = 9.80665;

    /// <summary>Drag (0.5 * ρ * Cd * A * v²).</summary>
    /// <param name="Cd">
    /// Drag coefficient.
    /// </param>
    /// <param name="A">
    /// Cross sectional area (in m²).
    /// </param>
    /// <param name="v">
    /// The speed of the object (in m/s).
    /// </param>
    public double Fd(double Cd, double A, double v) => 0.5 * ρ * Cd * A * v.Pow2();
}
