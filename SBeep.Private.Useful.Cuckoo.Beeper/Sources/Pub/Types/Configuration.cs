namespace SBeep.Private.Useful.Cuckoo.Beeper.Pub.Types
{
    using System;
    using System.Xml.Serialization;

    [Serializable]
    public class Configuration
    {
        private TimeSpan? _workTime;

        private TimeSpan? _restTime;

        [XmlAttribute("workPeriod")]
        public string WorkSeconds { get; set; }

        [XmlAttribute("restPeriod")]
        public string RestSeconds { get; set; }

        public TimeSpan WorkTime
        {
            get
            {
                return (this._workTime ?? (this._workTime = TimeSpan.Parse(this.WorkSeconds))).Value;
            }
        }

        public TimeSpan RestTime
        {
            get
            {
                return (this._restTime ?? (this._restTime = TimeSpan.Parse(this.RestSeconds))).Value;
            }
        }
    }
}