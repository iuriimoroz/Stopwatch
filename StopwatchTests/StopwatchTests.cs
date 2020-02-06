using NUnit.Framework;
using StopwatchApp;
using System;
using System.Threading;

namespace StopwatchTests
{
    public class StopwatchTests
    {
        [Test]
        public void OneSecondTest()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Thread.Sleep(1000);
            stopwatch.Stop();

            Assert.That((int)stopwatch.Duration.TotalSeconds == (int)TimeSpan.FromSeconds(1).TotalSeconds, $"Stopwatch duration does not match expected value");
        }
        [Test]
        public void FewStartsStopsTest()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Thread.Sleep(1000);
            stopwatch.Stop();

            stopwatch.Start();
            Thread.Sleep(2000);
            stopwatch.Stop();

            Assert.That((int)stopwatch.Duration.TotalSeconds == (int)TimeSpan.FromSeconds(3).TotalSeconds, $"Stopwatch duration does not match expected value");
        }
        [Test]
        public void TimeShouldNotBeCountedWhenStoppedTest()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Thread.Sleep(1000);
            stopwatch.Stop();

            Thread.Sleep(5000);

            stopwatch.Start();
            Thread.Sleep(1000);
            stopwatch.Stop();

            Assert.That((int)stopwatch.Duration.TotalSeconds == (int)TimeSpan.FromSeconds(2).TotalSeconds, $"Stopwatch duration does not match expected value");
        }
        [Test]
        public void StoppingTimerDoesNotHaveAnyAffectWhenAlreadyStopped()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Thread.Sleep(1000);
            stopwatch.Stop();
            stopwatch.Stop();

            Thread.Sleep(3000);

            stopwatch.Start();
            Thread.Sleep(1000);
            stopwatch.Stop();

            Assert.That((int)stopwatch.Duration.TotalSeconds == (int)TimeSpan.FromSeconds(2).TotalSeconds, $"Stopwatch duration does not match expected value");
        }
        [Test]
        public void CanNotStartTimerTwice()
        {
            try
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                Thread.Sleep(1000);
                stopwatch.Start();
            }
            catch (InvalidOperationException e)
            {
                Assert.That(e.Message == "Timer is already running. Please stop it first.");
            }
        }
    }
}