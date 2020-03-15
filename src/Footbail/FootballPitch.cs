using System.Diagnostics;
using System.Globalization;

namespace Footbail
{
    /// <summary>Represents the football pitch.</summary>
    public class FootballPitch
    {
        public FootballPitch(double touchLine, double goalLine)
        {
            TouchLine = Guard.IsNumber(touchLine, nameof(touchLine));
            GoalLine = Guard.IsNumber(goalLine, nameof(goalLine));
        }

        /// <summary>Gets the touch line size (width) of the football pitch.</summary>
        public double TouchLine { get; }

        /// <summary>Gets the goal line size (height) of the football pitch.</summary>
        public double GoalLine { get; }

        /// <summary>Returns true if the position is out-of-play.</summary>
        public bool OutOfPlay(Position position)
        {
            var x = position.X;
            var y = position.Y;

            return x < MinX || x > MaxX
                || y < MinY || y > MaxY;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "Touch line: {0}, Goal line: {1}", TouchLine, GoalLine);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private double MinX => -TouchLine / 2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private double MaxX => TouchLine / 2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private double MinY => -GoalLine / 2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private double MaxY => GoalLine / 2;
    }
}
