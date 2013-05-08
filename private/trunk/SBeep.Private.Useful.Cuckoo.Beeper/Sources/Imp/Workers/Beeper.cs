// Sergey Kirichenkov [kirichenkov.sa@gmail.com]
// 2013.05.09 0:07

using System;
using System.Threading.Tasks;

using SBeep.Private.Useful.Cuckoo.Beeper.Common.Pub.Requirements;
using SBeep.Private.Useful.Cuckoo.Common.Pub.Interfaces.Timers;

namespace SBeep.Private.Useful.Cuckoo.Beeper.Imp.Workers
{
    internal class Beeper
    {
        public Beeper(
            IBeeperRequirements requirements,
            ICountingManualTimer workTimer,
            ICountingManualTimer restTimer )
        {
            _requirements = requirements;
            _workTimer = workTimer;
            _restTimer = restTimer;

            _workTimer.SetCallback( CallBackWork );
            _restTimer.SetCallback( CallBackRest );
        }




        #region Data
        //===============================================================================================[]
        private readonly IBeeperRequirements _requirements;

        private readonly ICountingManualTimer _workTimer;
        private readonly ICountingManualTimer _restTimer;

        //===============================================================================================[]
        #endregion




        #region Pub
        //===============================================================================================[]
        public void Go()
        {
            Console.Clear();

            SetCounting( _restTimer, "Rest" );
            SetCounting( _workTimer, "Work" );

            _workTimer.Start( _requirements.WorkTime );

            Console.ReadLine();

            _workTimer.Pause();
            _restTimer.Pause();

            Go();
        }

        //===============================================================================================[]
        #endregion




        #region Routines
        //===============================================================================================[]
        private static void Counting(
            string actionName,
            DateTime? startTime,
            TimeSpan operationTime )
        {
            Console.Clear();
            if( startTime.HasValue == false ) {
                Console.WriteLine( "startTime is null" );
                return;
            }
            var remainingTime = operationTime - ( DateTime.Now - startTime );
            Console.WriteLine(
                "Time left {1} until the end of '{0}'", actionName, remainingTime.Value.ToString( @"dd\.hh\:mm\:ss" ) );
        }

        //-------------------------------------------------------------------------------------[]
        private static void SetCounting(
            ICountingManualTimer timer,
            string actionName )
        {
            timer.SetCounting(
                TimeSpan.FromSeconds( 1 ), x => Counting( actionName, timer.StartTime, timer.NextCallBackTime ) );
        }

        //-------------------------------------------------------------------------------------[]
        private static void Beep()
        {
            for( var i = 1; i < 5; i++ )
                Console.Beep( i*300, 1000 );
        }

        //===============================================================================================[]
        #endregion




        #region Callbacks
        //===============================================================================================[]
        private void CallBackRest( object state )
        {
            Console.WriteLine( "CallBackRest" );
            _restTimer.Pause();
            _workTimer.Start( _requirements.WorkTime );

            Parallel.Invoke( Beep );
        }

        //-------------------------------------------------------------------------------------[]
        private void CallBackWork( object state )
        {
            Console.WriteLine( "CallBackWork" );
            _workTimer.Pause();
            _restTimer.Start( _requirements.RestTime );

            Parallel.Invoke( Beep );
        }

        //===============================================================================================[]
        #endregion
    }
}