// Sergey Kirichenkov [kirichenkov.sa@gmail.com]
// 2013.05.09 0:01

using System;

namespace SBeep.Private.Useful.Cuckoo.Beeper.Common.Pub.Requirements
{
    public interface IBeeperRequirements
    {
        TimeSpan WorkTime { get; }
        TimeSpan RestTime { get; }
    }
}