// Sergey Kirichenkov [kirichenkov.sa@gmail.com]
// 2012.11.06 11:04

using System;

namespace SBeep.Private.Useful.Cuckoo.Beeper.App
{
    internal class Program
    {
        private static void Main( string[] args )
        {
            try {
                var beeper = new Imp.Workers.Beeper();
                beeper.Go();
            }
            catch( Exception e ) {
                Console.WriteLine( e );
                Console.Read();
            }
        }
    }
}