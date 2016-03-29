namespace SBeep.Private.Useful.Cuckoo.Beeper.App
{
    using System;

    using SBeep.Private.Useful.Cuckoo.Beeper.Imp.Stuff.Help;
    using SBeep.Private.Useful.Cuckoo.Beeper.Imp.Stuff.Timers;
    using SBeep.Private.Useful.Cuckoo.Beeper.Imp.Workers;
    using SBeep.Private.Useful.Cuckoo.Beeper.Pub.Types;

    internal class Program
    {
        private const string Path = "configuration.config";

        private static Configuration ReadConfig()
        {
            return FileWizard.OpenXml<Configuration>(Path);
        }

        private static void Main(string[] args)
        {
            Configuration config = ReadConfig();
            try
            {
                var beeper = new Beeper(
                    requirements: config,
                    beepRequirements: config.BeepConfiguration,
                    workTimer: new CountingManualTimer(),
                    restTimer: new CountingManualTimer());
                beeper.Go();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.Read();
            }
        }
    }
}