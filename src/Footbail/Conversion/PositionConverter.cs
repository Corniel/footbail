using Qowaiv.Conversion;
using System.Globalization;

namespace Footbail.Conversion
{
    /// <summary><see cref="System.ComponentModel.TypeConverter"/> for <see cref="Position"/>.</summary>
    public sealed class PositionConverter : SvoTypeConverter<Position>
    {
        /// <inheritdoc/>
        protected override Position FromString(string str, CultureInfo culture) => Position.Parse(str);
    }
}
