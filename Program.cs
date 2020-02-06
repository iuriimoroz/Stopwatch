using System;
using System.Threading;

namespace StopwatchApp
{
    class Program
    {
        static void Main()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            Thread.Sleep(1000);
            stopwatch.Stop();

            Console.WriteLine(stopwatch.Duration);
        }
    }
}
