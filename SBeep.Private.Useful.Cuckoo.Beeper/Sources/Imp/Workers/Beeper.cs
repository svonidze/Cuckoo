namespace SBeep.Private.Useful.Cuckoo.Beeper.Imp.Workers
{
    using System;
    using System.Threading.Tasks;

    using SBeep.Private.Useful.Cuckoo.Beeper.Common.Sources.Pub.Requirements;
    using SBeep.Private.Useful.Cuckoo.Common;

    internal class Beeper
    {
        private readonly IBeeperRequirements requirements;

        private readonly IBeepRequirements beepRequirements;

        private readonly ICountingManualTimer workTimer;

        private readonly ICountingManualTimer restTimer;

        public Beeper(
            IBeeperRequirements requirements,
            IBeepRequirements beepRequirements,
            ICountingManualTimer workTimer,
            ICountingManualTimer restTimer)
        {
            this.requirements = requirements;
            this.beepRequirements = beepRequirements;
            this.workTimer = workTimer;
            this.restTimer = restTimer;

            this.workTimer.SetCallback(this.CallBackWork);
            this.restTimer.SetCallback(this.CallBackRest);
        }

        public void Go()
        {
            Console.Clear();

            SetCounting(this.restTimer, "Rest");
            SetCounting(this.workTimer, "Work");

            this.workTimer.Start(this.requirements.WorkTime);

            Console.ReadLine();

            this.workTimer.Pause();
            this.restTimer.Pause();

            this.Go();
        }

        private static void Counting(string actionName, DateTime? startTime, TimeSpan operationTime)
        {
            Console.Clear();
            if (startTime.HasValue == false)
            {
                Console.WriteLine("startTime is null");
                return;
            }

            TimeSpan? remainingTime = operationTime - (DateTime.Now - startTime);
            Console.WriteLine(
                "Time left {1} until the end of '{0}'", 
                actionName, 
                remainingTime.Value.ToString(@"dd\.hh\:mm\:ss"));
        }

        private static void SetCounting(ICountingManualTimer timer, string actionName)
        {
            timer.SetCounting(
                TimeSpan.FromSeconds(1), 
                x => Counting(actionName, timer.StartTime, timer.NextCallBackTime));
        }

        private void Beep()
        {
            for (int i = 1; i < this.beepRequirements.Number; i++)
            {
                Console.Beep(i * this.beepRequirements.Frequency, (int)this.beepRequirements.Duration.TotalMilliseconds);
            }
        }

        private void CallBackRest(object state)
        {
            Console.WriteLine("CallBackRest");
            this.restTimer.Pause();
            this.workTimer.Start(this.requirements.WorkTime);

            Parallel.Invoke(Beep);
        }

        private void CallBackWork(object state)
        {
            Console.WriteLine("CallBackWork");
            this.workTimer.Pause();
            this.restTimer.Start(this.requirements.RestTime);

            Parallel.Invoke(Beep);
        }
    }
}