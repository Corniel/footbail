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
                    Pitch = Pitch.FIFA,
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

        public Physics Physics { get; set; } = new Physics();
    }
}
