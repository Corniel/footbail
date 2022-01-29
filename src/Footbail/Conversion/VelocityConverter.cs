using Qowaiv.Conversion;

namespace Footbail.Conversion
{
    /// <summary><see cref="System.ComponentModel.TypeConverter"/> for <see cref="Velocity"/>.</summary>
    public sealed class VelocityConverter : SvoTypeConverter<Velocity>
    {
        /// <inheritdoc/>
        protected override Velocity FromString(string? str, CultureInfo? culture) => Velocity.Parse(str);
    }
}
