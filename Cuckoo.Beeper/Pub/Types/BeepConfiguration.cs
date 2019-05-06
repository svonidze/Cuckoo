namespace SBeep.Private.Useful.Cuckoo.Beeper.Pub.Types
{
    using System;
    using System.Xml.Serialization;

    using SBeep.Private.Useful.Cuckoo.Beeper.Common.Sources.Pub.Requirements;
    using SBeep.Private.Useful.Cuckoo.Common.Types;

    [Serializable]
    public class BeepConfiguration : IBeepRequirements
    {
        [XmlAttribute("number")]
        public int Number { get; set; }

        [XmlAttribute("frequency")]
        public int Frequency { get; set; }

        [XmlIgnore]
        public TimeSpan Duration
        {
            get
            {
                return this.DurationSeriazable;
            }

            set
            {
                this.DurationSeriazable = value;
            }
        }

        [XmlElement("Duration")]
        public TimeSpanSeriazable DurationSeriazable { get; set; }
    }
}