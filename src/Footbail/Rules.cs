namespace Footbail
{
    public class Rules
    {
        public FootballPitch FootballPitch { get; set; }
        public int PlayerCount { get; set; }

        public bool WithOffside { get; set; }
        public bool WithKeeper { get; set; }
        public int Turns { get; set; } = 45 * 2 * 10;


        public double BallAccelaration { get; set; } = 0.99;

        public double OldMoveNewMoveRatio { get; set; } = 0.75;
        public double NewMoveOldMoveRation => 1 - OldMoveNewMoveRatio;

        public double ShootSlowdownFactor { get; set; } = 0.5;
    }
}
