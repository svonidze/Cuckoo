namespace SBeep.Private.Useful.Cuckoo.Beeper.Imp.Stuff.Timers
{
    using System;
    using System.Threading;

    using SBeep.Private.Useful.Cuckoo.Common;

    internal class ManualTimer : IManualTimer
    {
        #region Data

        private Timer _timer;

        private TimeSpan _period = TimeSpan.Zero;

        #endregion

        #region Implementation of IManualTimer

        public TimeSpan NextCallBackTime { get; private set; }

        public DateTime? StartTime { get; private set; }

        public IManualTimer SetCallback(TimerCallback callback)
        {
            this._timer = new Timer(
                x =>
                    {
                        this.NextCallBackTime = this._period;
                        callback(x);
                    });
            return this;
        }

        public IManualTimer SetPeriod(TimeSpan period)
        {
            this._period = period;
            return this;
        }

        public virtual void Start(TimeSpan? dueTime = null)
        {
            this.StartTime = DateTime.Now;
            this.NextCallBackTime = dueTime ?? TimeSpan.Zero;
            this._timer.Change(this.NextCallBackTime, this._period);
        }

        public virtual void Pause()
        {
            this.StartTime = null;
            this._timer.Change(TimeSpan.FromDays(1), TimeSpan.FromDays(1));
        }

        #endregion
    }
}