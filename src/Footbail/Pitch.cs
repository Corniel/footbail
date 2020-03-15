using System.Diagnostics;
using System.Globalization;

namespace Footbail
{
    /// <summary>Represents a football pitch.</summary>
    public class Pitch
    {
        /// <summary>Gets the pitch specifications for UEFA.</summary>
        public static readonly Pitch UEFA = new Pitch
        (
            touchLine: 105,
            goalLine: 68,
            goal: 7.32
        );

        /// <summary>Gets the pitch specification for Futsal (with bouncing lines).</summary>
        public static readonly Pitch Futsal = new Pitch
        (
            touchLine: 40,
            goalLine: 22.5,
            goal: 3,
            bouncingLines: true
        );

        public Pitch(
            double touchLine, 
            double goalLine,
            double goal,
            bool bouncingLines = false)
        {
            TouchLine = Guard.IsNumber(touchLine, nameof(touchLine));
            GoalLine = Guard.IsNumber(goalLine, nameof(goalLine));
            Goal = Guard.IsNumber(goal, nameof(goal));
            BouncingLines = bouncingLines;
        }

        /// <summary>Gets the touch line size (width) of the pitch.</summary>
        public double TouchLine { get; }

        /// <summary>Gets the goal line size (height) of the pitch.</summary>
        public double GoalLine { get; }

        /// <summary>Gets the inner edges of the goalposts.</summary>
        public double Goal { get; }

        /// <summary>Indicates if the lines bounce (or not).</summary>
        public bool BouncingLines { get; }

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
            return string.Format(
                CultureInfo.InvariantCulture, 
                "Touch line: {0}, Goal line: {1}, Goal: {2}{3}",
                TouchLine,
                GoalLine,
                Goal,
                BouncingLines ? ", Bouncing lines" : ""
            );
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
