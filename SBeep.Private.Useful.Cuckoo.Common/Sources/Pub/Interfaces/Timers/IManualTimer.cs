// Sergey Kirichenkov [kirichenkov.sa@gmail.com]
// 2013.05.08 23:47

using System;
using System.Threading;

namespace SBeep.Private.Useful.Cuckoo.Common.Pub.Interfaces.Timers
{
    public interface IManualTimer
    {
        TimeSpan NextCallBackTime { get; }
        DateTime? StartTime { get; }

        IManualTimer SetCallback(TimerCallback callback);
        IManualTimer SetPeriod(TimeSpan period);
        void Start( TimeSpan? dueTime = null );
        void Pause();
    }
}