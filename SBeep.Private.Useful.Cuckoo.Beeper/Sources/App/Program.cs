// Sergey Kirichenkov [kirichenkov.sa@gmail.com]
// 2012.11.06 11:04

namespace SBeep.Private.Useful.Cuckoo.Beeper.App
{
    internal class Program
    {
        private static void Main( string[] args )
        {
            var b = new Imp.Workers.Beeper();
            b.Do();
        }
    }
}