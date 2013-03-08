using System;
using System.Threading;

using SBeep.Private.Useful.Cuckoo.Beeper.Imp.Stuff.Help;
using SBeep.Private.Useful.Cuckoo.Beeper.Pub.Types;

namespace SBeep.Private.Useful.Cuckoo.Beeper.Imp.Workers
{
    internal class Beeper
    {
        #region Data
        //===============================================================================================[]
        private static Timer _timer;
        private static Timer _timerRest;

        private static DateTime _start;
        private static TimeSpan _intervalWork;
        private static TimeSpan _intervalRest;

        private static Configuration _configuration;

        //===============================================================================================[]
        #endregion


        public void Do()
        {
            _start = DateTime.Now;
            _configuration = FileWizard.OpenXml<Configuration>("configuration.config");
            _intervalWork = TimeSpan.FromSeconds(_configuration.WorkSeconds);
            _intervalRest = TimeSpan.FromSeconds(_configuration.RestSeconds);

            _timer = new Timer(GoToRest, "", TimeSpan.FromTicks(0), TimeSpan.FromMinutes(1));
            Console.WriteLine("Start");
            Console.ReadLine();
        }

        private static void Beep(object obj)
        {
            _start = DateTime.Now;

            if (obj != null)
                Console.WriteLine(obj);

            for (var i = 1; i < 5; i++)
                Console.Beep(i * 300, 1000);
        }

        private static void GoToRest(object obj)
        {
            var remainder = (DateTime.Now - _start - _intervalWork).TotalMinutes;
            if( remainder < 0) {
                var b = ( Int32 ) Math.Abs( remainder );
                Console.WriteLine( b );
                return;
            }

            Console.Clear();

            Beep("Отдохни");
            Console.WriteLine("Перерыв до {0}", _start + _intervalRest);

            _timerRest = new Timer(Beep, "Работай", _intervalRest, TimeSpan.FromTicks(0));
        } 
    }
}