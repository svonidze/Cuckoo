// Sergey Kirichenkov [kirichenkov.sa@gmail.com]
// 2013.05.08 23:28

using System;

namespace SBeep.Private.Useful.Cuckoo.Common.Pub.Interfaces.Timers
{
    public interface ICountingManualTimer : IManualTimer
    {
        ICountingManualTimer SetCounting(
            TimeSpan period,
            Action action );
    }
}