namespace SBeep.Private.Useful.Cuckoo.Common
{
    using System;
    using System.Threading;

    public interface IManualTimer
    {
        TimeSpan NextCallBackTime { get; }

        DateTime? StartTime { get; }

        IManualTimer SetCallback(TimerCallback callback);

        IManualTimer SetPeriod(TimeSpan period);

        void Start(TimeSpan? dueTime = null);

        void Pause();
    }
}