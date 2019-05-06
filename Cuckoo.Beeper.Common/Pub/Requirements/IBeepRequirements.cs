namespace SBeep.Private.Useful.Cuckoo.Beeper.Common.Sources.Pub.Requirements
{
    using System;

    public interface IBeepRequirements
    {
        /// <summary>
        /// Gets the total number of beeps
        /// </summary>
        int Number { get; }

        /// <summary>
        /// Gets the frequency of the beep, ranging from 37 to 32767 hertz.
        /// </summary>
        int Frequency { get; }

        /// <summary>
        /// Gets the duration of the beep.
        /// </summary>
        TimeSpan Duration { get; }
    }
}