namespace SBeep.Private.Useful.Cuckoo.Common.Types
{
    using System;
    using System.Xml.Serialization;

    [Serializable]
    public class TimeSpanSeriazable
    {
        private TimeSpan? value;

        public TimeSpanSeriazable()
        {
        }

        public TimeSpanSeriazable(TimeSpan value)
        {
            this.value = value;
        }

        [XmlIgnore]
        public TimeSpan Value
        {
            get
            {
                return (this.value ?? (this.value = TimeSpan.Parse(this.RawValue))).Value;
            }

            set
            {
                this.value = value;
            }
        }

        [XmlText]
        public string RawValue
        {
            get
            {
                return this.value.GetValueOrDefault().ToString();
            }

            set
            {
                this.value = TimeSpan.Parse(value);
            }
        }

        public static implicit operator TimeSpanSeriazable(TimeSpan span)
        {
            return new TimeSpanSeriazable(span);
        }

        public static implicit operator TimeSpan(TimeSpanSeriazable span)
        {
            return span.Value;
        }

        public override string ToString()
        {
            return this.RawValue;
        }
    }
}