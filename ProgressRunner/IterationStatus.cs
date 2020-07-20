using System;

namespace ProgressRunner
{
    public readonly struct IterationStatus
    {
        private const double MinimumPercentChangeToReport = 0.25;
        private const int MinimumMillisecondsToReport = 10 * 1000;

        public int CurrentValue { get; }
        public int MaximumValue { get; }

        private int TickCount { get; }
        private double PercentComplete => CurrentValue / (double)(MaximumValue == 0 ? 1 : MaximumValue) * 100;

        public IterationStatus(int currentValue, int maximumValue)
        {
            CurrentValue = currentValue;
            MaximumValue = maximumValue;

            // DateTime.Now is really expensive in a loop and we don't need that kind of resolution here,
            // just a simple gauge as to whether a decent amount of time has gone by since the last progress report.
            TickCount = Environment.TickCount;
        }

        public bool ShouldReport(IterationStatus previousStatus)
        {
            if (CurrentValue < 2)
            {
                return true;
            }

            if (Math.Abs(PercentComplete - previousStatus.PercentComplete) >= MinimumPercentChangeToReport)
            {
                return true;
            }

            if (TickCount - previousStatus.TickCount >= MinimumMillisecondsToReport)
            {
                return true;
            }

            return false;
        }
    }
}
