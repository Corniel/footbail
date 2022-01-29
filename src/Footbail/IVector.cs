namespace Footbail
{
    /// <summary>Represents a two-dimensional vector.</summary>
    public interface IVector : IFormattable
    {
        /// <summary>The X-component of the vector.</summary>
        double X { get; }

        /// <summary>The Y-component of the vector.</summary>
        double Y { get; }

        /// <summary>The Z-component of the vector.</summary>
        double Z { get; }
    }
}
