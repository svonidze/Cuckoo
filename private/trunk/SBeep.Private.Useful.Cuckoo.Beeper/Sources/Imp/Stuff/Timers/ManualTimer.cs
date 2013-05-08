﻿// Sergey Kirichenkov [kirichenkov.sa@gmail.com]
// 2013.05.08 17:10

using System;
using System.Threading;

namespace SBeep.Private.Useful.Cuckoo.Beeper.Imp.Stuff.Timers
{
    internal class ManualTimer
    {
        public ManualTimer( Action<object> callBack )
        {
            _timer = new Timer(
                x => {
                    NextCallBackTime = _period;
                    callBack( x );
                } );
        }




        #region Data
        //===============================================================================================[]
        private readonly Timer _timer;
        private TimeSpan _period = TimeSpan.Zero;

        //===============================================================================================[]
        #endregion




        #region Pub data
        //===============================================================================================[]
        public TimeSpan NextCallBackTime { get; private set; }
        public DateTime? StartTime { get; private set; }

        //===============================================================================================[]
        #endregion




        #region Pub
        //===============================================================================================[]
        public void SetPeriod( TimeSpan period )
        {
            _period = period;
        }

        public virtual void Start( TimeSpan? dueTime = null )
        {
            StartTime = DateTime.Now;
            NextCallBackTime = dueTime ?? TimeSpan.Zero;
            _timer.Change( NextCallBackTime, _period );
        }

        public virtual void Pause()
        {
            StartTime = null;
            _timer.Change( TimeSpan.FromHours( 1 ), TimeSpan.FromHours( 1 ) );
        }

        //===============================================================================================[]
        #endregion
    }
}