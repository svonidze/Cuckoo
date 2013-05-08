// Sergey Kirichenkov [kirichenkov.sa@gmail.com]
// 2013.05.08 23:46

using System;

namespace SBeep.Private.Useful.Cuckoo.Common.Pub.Interfaces.Timers
{
    public interface IManualTimer
    {
        TimeSpan NextCallBackTime { get; }
        DateTime? StartTime { get; }

        void SetPeriod( TimeSpan period );
        void Start( TimeSpan? dueTime = null );
        void Pause();
    }
}