// Sergey Kirichenkov [kirichenkov.sa@gmail.com]
// 2013.05.09 0:09

using System;
using System.Threading;

using SBeep.Private.Useful.Cuckoo.Common.Pub.Interfaces.Timers;

namespace SBeep.Private.Useful.Cuckoo.Beeper.Imp.Stuff.Timers
{
    internal class ManualTimer : IManualTimer
    {
        #region Data
        //===============================================================================================[]
        private Timer _timer;
        private TimeSpan _period = TimeSpan.Zero;

        //===============================================================================================[]
        #endregion




        #region Implementation of IManualTimer
        //===============================================================================================[]
        public TimeSpan NextCallBackTime { get; private set; }
        public DateTime? StartTime { get; private set; }

        public IManualTimer SetCallback( TimerCallback callback )
        {
            _timer = new Timer(
                x => {
                    NextCallBackTime = _period;
                    callback( x );
                } );
            return this;
        }

        public IManualTimer SetPeriod( TimeSpan period )
        {
            _period = period;
            return this;
        }

        //-------------------------------------------------------------------------------------[]
        public virtual void Start( TimeSpan? dueTime = null )
        {
            StartTime = DateTime.Now;
            NextCallBackTime = dueTime ?? TimeSpan.Zero;
            _timer.Change( NextCallBackTime, _period );
        }

        //-------------------------------------------------------------------------------------[]
        public virtual void Pause()
        {
            StartTime = null;
            _timer.Change( TimeSpan.FromDays( 1 ), TimeSpan.FromDays( 1 ) );
        }

        //===============================================================================================[]
        #endregion
    }
}