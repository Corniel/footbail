namespace Footbail;

public sealed record Match(Team Left, Team Right, Duration TimeLeft, Pitch Pitch, Score Score);
