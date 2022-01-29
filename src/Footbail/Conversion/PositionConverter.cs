using Qowaiv.Conversion;

namespace Footbail.Conversion
{
    /// <summary><see cref="TypeConverter"/> for <see cref="Position"/>.</summary>
    public sealed class PositionConverter : SvoTypeConverter<Position>
    {
        /// <inheritdoc/>
        protected override Position FromString(string? str, CultureInfo? culture) => Position.Parse(str);
    }
}
