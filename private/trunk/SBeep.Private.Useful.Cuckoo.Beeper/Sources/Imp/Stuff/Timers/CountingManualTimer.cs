// Sergey Kirichenkov [kirichenkov.sa@gmail.com]
// 2013.05.08 23:35

using System;

using SBeep.Private.Useful.Cuckoo.Common.Pub.Interfaces.Timers;

namespace SBeep.Private.Useful.Cuckoo.Beeper.Imp.Stuff.Timers
{
    internal class CountingManualTimer : ManualTimer, ICountingManualTimer
    {
        #region Data
        //===============================================================================================[]
        private IManualTimer _timerForCounting;

        //===============================================================================================[]
        #endregion




        #region Ctors
        //===============================================================================================[]
        public CountingManualTimer( Action<object> callBack )
            : base( callBack ) {}

        //===============================================================================================[]
        #endregion




        #region Implementation of ICountingManualTimer
        //===============================================================================================[]
        public ICountingManualTimer SetCounting(
            TimeSpan period,
            Action action )
        {
            _timerForCounting = new ManualTimer( x => action() );
            _timerForCounting.SetPeriod( period );
            return this;
        }

        //===============================================================================================[]
        #endregion




        #region Overrides of ManualTimer
        //===============================================================================================[]
        public override void Start( TimeSpan? dueTime = null )
        {
            base.Start( dueTime );
            if( _timerForCounting != null )
                _timerForCounting.Start();
        }

        //-------------------------------------------------------------------------------------[]
        public override void Pause()
        {
            base.Pause();
            if( _timerForCounting != null )
                _timerForCounting.Pause();
        }

        //===============================================================================================[]
        #endregion
    }
}