namespace Footbail;

public sealed partial record Physics
{
    public sealed record PitchPhysics(double TouchLine, double GoalLine, double Goal)
    {
        /// <summary>Gets the pitch specifications for FIFA.</summary>
        public static readonly PitchPhysics FIFA = new(TouchLine: 105, GoalLine: 68, Goal: 7.32);
        
        /// <summary>Gets the pitch specification for Futsal (with bouncing lines).</summary>
        public static readonly PitchPhysics Futsal = new(TouchLine: 40, GoalLine: 22.5, Goal: 3);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private double MaxX => TouchLine / 2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private double MaxZ => GoalLine / 2;

        /// <summary>Returns true if the position is out-of-play.</summary>
        public BallPlay OutOfPlay(Position position, TeamId possession)
        {
            var x = position.X.Abs();
            var z = position.Z.Abs();
            
            if (x <= MaxX && z <= MaxZ)
            {
                return BallPlay.InPlay;
            }
            else if(z > MaxZ)
            {
                return BallPlay.ThrowIn;
            }
            if(position.X > MaxX)
            {
                if (z < Goal / 2)
                {
                    return BallPlay.KickOff;
                }
                else return possession == TeamId.Left ? BallPlay.GoalKick : BallPlay.CornerKick;
            }
            else
            {
                if (z < Goal / 2)
                {
                    return BallPlay.KickOff;
                }
                else return possession == TeamId.Right ? BallPlay.GoalKick : BallPlay.CornerKick;
            }
        }

        /// <inheritdoc/>
        public override string ToString() 
            => string.Format(
            CultureInfo.InvariantCulture,
            "Touch line: {0}, Goal line: {1}, Goal: {2}",
            TouchLine,
            GoalLine,
            Goal);
    }
}
