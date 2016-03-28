namespace SBeep.Private.Useful.Cuckoo.Beeper.Imp.Types
{
    using System;

    using SBeep.Private.Useful.Cuckoo.Beeper.Common.Pub.Requirements;

    internal class BeeperRequirements : IBeeperRequirements
    {
        #region Implementation of IBeeperRequirements

        public TimeSpan WorkTime { get; set; }

        public TimeSpan RestTime { get; set; }

        #endregion
    }
}