// Sergey Kirichenkov [kirichenkov.sa@gmail.com]
// 2013.03.11 10:26

using System;
using System.Xml.Serialization;

namespace SBeep.Private.Useful.Cuckoo.Beeper.Pub.Types
{
    [ Serializable ]
    public class Configuration
    {
        [ XmlAttribute( "workPeriod" ) ] public string WorkSeconds1 { get; set; }
        [ XmlAttribute( "restPeriod" ) ] public string RestSeconds1 { get; set; }

        public TimeSpan WorkSeconds { get; set; }
        public TimeSpan RestSeconds { get; set; }
    }
}