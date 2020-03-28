using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncSamples.Samples;
using static AsyncSamples.Utils.TimeMeasurer;

namespace AsyncSamples
{
    public static class Program
    {
        private static int _counter;
        private static readonly IList<string> TaskEnumList = new List<string>{"TE1", "TE2", "TE3"};
        private static readonly IList<string> AsyncEnumList = new List<string>{"AE1", "AE2", "AE3"};

        public static void Main()
        {
            var iterator = new AsyncIterator();

            var asyncEnumAsync = iterator.GetAsyncEnumerable(AsyncEnumList, ConcatCounterAsync);
            var taskEnumAsync = iterator.GetTaskEnumerable(TaskEnumList, ConcatCounterAsync);

            Console.WriteLine($"{_counter++}\t####### AsyncEnum ##########");
            PrintElapsedMilliseconds(async () =>
            {
                await iterator.PrintEachElement(asyncEnumAsync);
            }, $"{_counter++}\tEnd AsyncEnum");

            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine($"{_counter++}\t####### TaskEnum ##########");
            PrintElapsedMilliseconds(async () =>
            {
                await iterator.PrintAllElements(taskEnumAsync);
            }, $"{_counter++}\tEnd TaskEnum");

            Console.ReadKey();
        }

        private static async Task<string> ConcatCounterAsync(string s)
        {
            PrintElapsedMilliseconds(async () => await Task.Delay(1000), $"{_counter++}\t{s}\t");
            return await Task<string>.Factory.StartNew(() => $"{_counter++}\t{s}\t");
        }
    }
}