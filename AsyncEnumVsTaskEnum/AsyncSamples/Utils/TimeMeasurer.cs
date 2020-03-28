using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncSamples.Utils
{
    public static class TimeMeasurer
    {
        public static async void PrintElapsedMilliseconds(Func<Task> action, string message = null)
        {
            var stw = new Stopwatch();
            stw.Start();
            await action();
            stw.Stop();
            Console.WriteLine($"{message} watch => {stw.ElapsedMilliseconds}ms");
        }
    }
}