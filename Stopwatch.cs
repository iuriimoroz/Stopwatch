using System;

namespace StopwatchApp
{
    public class Stopwatch
    {
        private DateTime startTime;
        private bool isTimerRunning = false;

        public TimeSpan Duration { get; private set; } = new TimeSpan();

        public void Start()
        {
            if (!isTimerRunning)
            {
                startTime = DateTime.Now;
                isTimerRunning = true;
            }
            else
            {
                throw new InvalidOperationException("Timer is already running. Please stop it first.");
            }
        }
        public void Stop()
        {
            if (isTimerRunning)
            {
                this.Duration += (DateTime.Now - startTime);
                isTimerRunning = false;
            }
        }
    }
}
