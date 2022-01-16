namespace Footbail;

public sealed record Game(Team Left, Team Right, Duration TimeLeft, Pitch Pitch, Score Score);
