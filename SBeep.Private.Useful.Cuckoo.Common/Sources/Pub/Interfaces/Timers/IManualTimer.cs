using System;

namespace SBeep.Private.Useful.Cuckoo.Common.Pub.Interfaces.Timers
{
    public interface IManualTimer {
        TimeSpan NextCallBackTime { get; }
        DateTime? StartTime { get; }
        void SetPeriod( TimeSpan period );
        void Start( TimeSpan? dueTime = null );
        void Pause();
    }
}