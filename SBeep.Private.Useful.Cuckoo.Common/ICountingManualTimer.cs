namespace SBeep.Private.Useful.Cuckoo.Common
{
    using System;
    using System.Threading;

    public interface ICountingManualTimer : IManualTimer
    {
        ICountingManualTimer SetCounting(TimeSpan period, TimerCallback callback);
    }
}