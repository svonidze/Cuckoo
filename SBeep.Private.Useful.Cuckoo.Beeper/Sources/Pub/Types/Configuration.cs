// Sergey Kirichenkov [kirichenkov.sa@gmail.com]
// 2012.08.09 11:43

using System;
using System.Xml.Serialization;

namespace SBeep.Private.Useful.Cuckoo.Beeper.Pub.Types
{
    [Serializable]
    public class Configuration
    {
        [ XmlAttribute( "workSeconds" ) ] public double WorkSeconds { get; set; }
        [ XmlAttribute( "restSeconds" ) ] public double RestSeconds { get; set; }
    }
}