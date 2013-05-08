// Sergey Kirichenkov [kirichenkov.sa@gmail.com]
// 2013.05.08 17:27

using System;
using System.Xml.Serialization;

namespace SBeep.Private.Useful.Cuckoo.Beeper.Pub.Types
{
    [ Serializable ]
    public class Configuration
    {
        private TimeSpan? _workTime;
        private TimeSpan? _restTime;
        [ XmlAttribute( "workPeriod" ) ] public string WorkSeconds { get; set; }
        [ XmlAttribute( "restPeriod" ) ] public string RestSeconds { get; set; }

        public TimeSpan WorkTime { get { return ( _workTime ?? ( _workTime = TimeSpan.Parse( WorkSeconds ) ) ).Value; } }
        public TimeSpan RestTime { get { return ( _restTime ?? ( _restTime = TimeSpan.Parse( RestSeconds ) ) ).Value; } }
    }
}