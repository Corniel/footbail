namespace Footbail
{
    public class Physics
    {
        public double BallAccelaration { get; set; } = 0.99;

        public double OldMoveNewMoveRatio { get; set; } = 0.75;
        public double NewMoveOldMoveRation => 1 - OldMoveNewMoveRatio;

        public double ShootSlowdownFactor { get; set; } = 0.5;
    }
}
