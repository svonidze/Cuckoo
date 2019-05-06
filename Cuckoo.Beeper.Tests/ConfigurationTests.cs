namespace SBeep.Private.Useful.Cuckoo.Beeper.Tests
{
    using System;

    using NUnit.Framework;

    using SBeep.Private.Useful.Cuckoo.Beeper.Imp.Stuff.Help;
    using SBeep.Private.Useful.Cuckoo.Beeper.Pub.Types;

    public class ConfigurationTests
    {
        [Test]
        public void IsXmlSerializable()
        {
            var configuration = new Configuration
                           {
                               BeepConfiguration = new BeepConfiguration
                                                       {
                                                           Duration = TimeSpan.FromMilliseconds(100), 
                                                           Frequency = 1000, 
                                                           Number = 3
                                                       }, 
                               RestTime = TimeSpan.FromSeconds(15), 
                               WorkTime = TimeSpan.FromSeconds(30), 
                           };
            var s = new ConfigurationSerializer<Configuration>();
            Console.WriteLine(s.Serialize(configuration));
        }
    }
}