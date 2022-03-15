namespace Footbail;

public sealed record Match(BallPlay BallPlay, Ball Ball, TeamId Possession, Team Left, Team Right, Duration TimeLeft, Score Score);
