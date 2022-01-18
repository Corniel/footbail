﻿namespace Footbail;

internal static partial class Guard
{
    /// <summary>Guards the parameter if non-infinitive number, otherwise throws an argument exception.</summary>
    /// <param name="parameter">The parameter to guard.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>
    /// The guarded parameter.
    /// </returns>
    [DebuggerStepThrough]
    public static double IsNumber(double parameter, string paramName)
        => double.IsNaN(parameter) || double.IsInfinity(parameter)
        ? throw new ArgumentException(Custom.ArgumentException_NaN, paramName)
        : parameter;

    /// <summary>Guards the parameter is within the margin, otherwise throws an argument exception.</summary>
    /// <param name="parameter">The parameter to guard.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <returns>
    /// The guarded parameter.
    /// </returns>
    [DebuggerStepThrough]

    public static double WitinMargin(double parameter, string paramName)
    {
        if (parameter < 20 || parameter > 40)
        {
            throw new ArgumentOutOfRangeException(paramName, Custom.OutOfRange_WitinMargin);
        }
        return parameter;
    }

    private static class Custom
    {
        public const string ArgumentException_NaN = "Argument should be a non-infinitive number.";
        public const string OutOfRange_WitinMargin = "The value should between [20, 40].";
    }
}
