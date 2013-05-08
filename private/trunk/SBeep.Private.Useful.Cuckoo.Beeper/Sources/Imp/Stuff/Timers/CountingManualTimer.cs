// Sergey Kirichenkov [kirichenkov.sa@gmail.com]
// 2013.05.08 17:10

using System;

namespace SBeep.Private.Useful.Cuckoo.Beeper.Imp.Stuff.Timers
{
    internal class CountingManualTimer : ManualTimer
    {
        private ManualTimer _timerForCounting;

        public CountingManualTimer( Action<object> callBack )
            : base( callBack ) {}

        public CountingManualTimer SetCounting(
            TimeSpan period,
            Action action )
        {
            _timerForCounting = new ManualTimer( x => action() );
            _timerForCounting.SetPeriod( period );
            return this;
        }




        #region Overrides of MyTimer
        public override void Start( TimeSpan? dueTime = null )
        {
            base.Start( dueTime );
            if( _timerForCounting != null )
                _timerForCounting.Start();
        }

        public override void Pause()
        {
            base.Pause();
            if( _timerForCounting != null )
                _timerForCounting.Pause();
        }
        #endregion
    }
}