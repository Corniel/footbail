namespace Footbail;

/// <summary>Ball (in and out of) play.</summary>
/// <remarks>
///  the two basic states of play during a game are ball in play and ball out
///  of play. From the beginning of each playing period with a kick-off until
///  the end of the playing period, the ball is in play at all times, except
///  when either the ball leaves the field of play, or play is stopped by the
///  referee. When the ball becomes out of play, play is restarted by one of
///  eight restart methods depending on how it went out of play.
/// </remarks>
public enum BallPlay
{
    /// <summary>Ball is in play.</summary>
    InPlay = 0,
    
    /// <summary>Following a goal by the opposing team, or to begin each period of play.</summary>
    KickOff,
    
    /// <summary>When the ball has crossed the touchline; awarded to the opposing team to that which last touched the ball.</summary>
    ThrowIn,

    /// <summary>when the ball has wholly crossed the goal line without a goal having been scored and having last been touched by a player of the attacking team; awarded to defending team.</summary>
    GoalKick,

    /// <summary>When the ball has wholly crossed the goal line without a goal having been scored and having last been touched by a player of the defending team; awarded to attacking team.</summary>
    CornerKick,

    /// <summary>Awarded to the opposing team following "non-penal" fouls, certain technical infringements, or when play is stopped to caution or dismiss an opponent without a specific foul having occurred. A goal may not be scored directly (without the ball first touching another player) from an indirect free kick.</summary>
    IndirectFreeKick,

    /// <summary>Awarded to fouled team following certain listed "penal" fouls. A goal may be scored directly from a direct free kick.</summary>
    DirectFreeKick,

    /// <summary>Awarded to the fouled team following a foul usually punishable by a direct free kick but that has occurred within their opponent's penalty area.</summary>
    PentaltyKick,

    /// <summary>Occurs when the referee has stopped play for any other reason, such as a serious injury to a player, interference by an external party, or a ball becoming defective.</summary>
    DroppedBall,
}
