namespace Footbail;

public sealed record Match(BallPlay BallPlay, Ball Ball, Team Left, Team Right, Duration TimeLeft, Score Score);
