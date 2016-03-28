namespace SBeep.Private.Useful.Cuckoo.Beeper.Imp.Stuff.Timers
{
    using System;
    using System.Threading;

    using SBeep.Private.Useful.Cuckoo.Common;

    internal class CountingManualTimer : ManualTimer, ICountingManualTimer
    {
        #region Data

        private IManualTimer _timerForCounting;

        #endregion

        #region Implementation of ICountingManualTimer

        public ICountingManualTimer SetCounting(TimeSpan period, TimerCallback callback)
        {
            this._timerForCounting = new ManualTimer();
            this._timerForCounting.SetCallback(callback);
            this._timerForCounting.SetPeriod(period);
            return this;
        }

        #endregion

        #region Overrides of ManualTimer

        public override void Start(TimeSpan? dueTime = null)
        {
            base.Start(dueTime);
            if (this._timerForCounting != null)
            {
                this._timerForCounting.Start();
            }
        }

        public override void Pause()
        {
            base.Pause();
            if (this._timerForCounting != null)
            {
                this._timerForCounting.Pause();
            }
        }

        #endregion
    }
}