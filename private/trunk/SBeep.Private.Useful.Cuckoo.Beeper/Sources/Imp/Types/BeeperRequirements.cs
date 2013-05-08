// Sergey Kirichenkov [kirichenkov.sa@gmail.com]
// 2013.05.09 0:04

using System;

using SBeep.Private.Useful.Cuckoo.Beeper.Common.Pub.Requirements;

namespace SBeep.Private.Useful.Cuckoo.Beeper.Imp.Types
{
    internal class BeeperRequirements : IBeeperRequirements
    {
        #region Implementation of IBeeperRequirements
        public TimeSpan WorkTime { get; set; }
        public TimeSpan RestTime { get; set; }
        #endregion
    }
}