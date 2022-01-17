namespace Footbail;

public sealed record Match(Ball Ball, Team Left, Team Right, Duration TimeLeft, Pitch Pitch, Score Score);
