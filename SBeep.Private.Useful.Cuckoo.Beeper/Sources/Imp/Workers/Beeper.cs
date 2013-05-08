// Sergey Kirichenkov [kirichenkov.sa@gmail.com]
// 2013.05.08 17:22

using System;
using System.Threading.Tasks;

using SBeep.Private.Useful.Cuckoo.Beeper.Imp.Stuff.Help;
using SBeep.Private.Useful.Cuckoo.Beeper.Imp.Stuff.Timers;
using SBeep.Private.Useful.Cuckoo.Beeper.Pub.Types;

namespace SBeep.Private.Useful.Cuckoo.Beeper.Imp.Workers
{
    internal class Beeper
    {
        #region Data
        //===============================================================================================[]
        private static CountingManualTimer _workTimer;
        private static CountingManualTimer _restTimer;

        private static Configuration Configuration { get; set; }

        private const string Path = "configuration.config";
        //===============================================================================================[]
        #endregion




        #region Pub
        //===============================================================================================[]
        public void Go()
        {
            Console.Clear();

            ReadConfig();
            _workTimer = new CountingManualTimer( CallBackWork );
            _restTimer = new CountingManualTimer( CallBackRest );

            SetCounting( _restTimer, "Rest" );
            SetCounting( _workTimer, "Work" );

            _workTimer.Start( Configuration.WorkTime );

            Console.ReadLine();
            Go();
        }

        //-------------------------------------------------------------------------------------[]
        private static void ReadConfig()
        {
            if( Configuration != null )
                return;
            Configuration = FileWizard.OpenXml<Configuration>( Path );
        }

        //===============================================================================================[]
        #endregion




        #region Routines
        //===============================================================================================[]
        private static void Counting(
            string message,
            DateTime? startTime,
            TimeSpan operationTime )
        {
            Console.Clear();
            if( startTime.HasValue == false ) {
                Console.WriteLine( "startTime is null" );
                return;
            }
            var remainingTime = operationTime - ( DateTime.Now - startTime );
            Console.WriteLine( "Time left {1} before {0}", message, remainingTime.Value.ToString( @"dd\.hh\:mm\:ss" ) );
        }

        //-------------------------------------------------------------------------------------[]
        private static void SetCounting(
            CountingManualTimer timer,
            string actionName )
        {
            timer.SetCounting(
                TimeSpan.FromSeconds( 1 ), () => Counting( actionName, timer.StartTime, timer.NextCallBackTime ) );
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
            _workTimer.Start( Configuration.WorkTime );

            Parallel.Invoke( Beep );
        }

        //-------------------------------------------------------------------------------------[]
        private void CallBackWork( object state )
        {
            Console.WriteLine( "CallBackWork" );
            _workTimer.Pause();
            _restTimer.Start( Configuration.RestTime );

            Parallel.Invoke( Beep );
        }

        //===============================================================================================[]
        #endregion
    }
}