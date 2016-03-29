namespace SBeep.Private.Useful.Cuckoo.Beeper.Common.Sources.Pub.Requirements
{
    using System;

    public interface IBeeperRequirements
    {
        TimeSpan WorkTime { get; }

        TimeSpan RestTime { get; }
    }
}