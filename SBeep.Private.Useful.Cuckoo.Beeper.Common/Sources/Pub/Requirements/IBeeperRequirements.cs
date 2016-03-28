namespace SBeep.Private.Useful.Cuckoo.Beeper.Common.Pub.Requirements
{
    using System;

    public interface IBeeperRequirements
    {
        TimeSpan WorkTime { get; }

        TimeSpan RestTime { get; }
    }
}