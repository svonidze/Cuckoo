namespace SBeep.Private.Useful.Cuckoo.Beeper.Pub.Types
{
    using System;
    using System.Xml.Serialization;

    using SBeep.Private.Useful.Cuckoo.Beeper.Common.Sources.Pub.Requirements;
    using SBeep.Private.Useful.Cuckoo.Common.Types;

    [Serializable]
    public class Configuration : IBeeperRequirements
    {
        [XmlIgnore]
        public TimeSpan WorkTime
        {
            get
            {
                return this.WorkTimeSeriazable;
            }

            set
            {
                this.WorkTimeSeriazable = value;
            }
        }

        [XmlIgnore]
        public TimeSpan RestTime
        {
            get
            {
                return this.RestTimeSeriazable;
            }

            set
            {
                this.RestTimeSeriazable = value;
            }
        }

        [XmlElement("Beep")]
        public BeepConfiguration BeepConfiguration { get; set; }

        [XmlElement("WorkTime")]
        public TimeSpanSeriazable WorkTimeSeriazable { get; set; }

        [XmlElement("RestTime")]
        public TimeSpanSeriazable RestTimeSeriazable { get; set; }
    }
}