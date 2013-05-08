// Sergey Kirichenkov [kirichenkov.sa@gmail.com]
// 2013.05.09 0:06

using System;

using SBeep.Private.Useful.Cuckoo.Beeper.Common.Pub.Requirements;
using SBeep.Private.Useful.Cuckoo.Beeper.Imp.Stuff.Help;
using SBeep.Private.Useful.Cuckoo.Beeper.Imp.Stuff.Timers;
using SBeep.Private.Useful.Cuckoo.Beeper.Imp.Types;
using SBeep.Private.Useful.Cuckoo.Beeper.Pub.Types;

namespace SBeep.Private.Useful.Cuckoo.Beeper.App
{
    internal class Program
    {
        private const string Path = "configuration.config";

        private static Configuration ReadConfig()
        {
            return FileWizard.OpenXml<Configuration>( Path );
        }

        private static void Main( string[] args )
        {
            var config = ReadConfig();
            IBeeperRequirements requirements = new BeeperRequirements {
                RestTime = config.RestTime,
                WorkTime = config.WorkTime
            };
            try {
                var beeper = new Imp.Workers.Beeper(
                    requirements, new CountingManualTimer(), new CountingManualTimer() );
                beeper.Go();
            }
            catch( Exception e ) {
                Console.WriteLine( e );
                Console.Read();
            }
        }
    }
}