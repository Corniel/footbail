namespace Footbail
{
    public class Rules
    {
        public static Rules Default
        {
            get
            {
                return new Rules
                {
                    Pitch = Pitch.UEFA,
                    Duration = Duration.FromMinutes(90),
                    PlayerCount = 11,
                    WithOffside = true,
                    WithKeeper = true,
                };
            }
        }

        public Pitch Pitch { get; set; }
        public Duration Duration { get; set; }

        public int PlayerCount { get; set; }

        public bool WithOffside { get; set; }

        public bool WithKeeper { get; set; }

        public double BallAccelaration { get; set; } = 0.99;

        public double OldMoveNewMoveRatio { get; set; } = 0.75;
        public double NewMoveOldMoveRation => 1 - OldMoveNewMoveRatio;

        public double ShootSlowdownFactor { get; set; } = 0.5;
    }
}
