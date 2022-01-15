namespace Footbail;

public readonly partial struct Ball
{
    public static readonly Physics Default = new();

    public sealed record Physics
    {
        public double ρ { get; init; } = 1.2;
        public double A { get; init; } = Math.Pow(0.69 / 2 / Math.PI, 2) * Math.PI;
        public double m { get; init; } = 0.430;
        public double Cd { get; init; } = 0.5;

        public double Fd(double v) => 0.5 * ρ * Cd * A * v * v;
    }
}
