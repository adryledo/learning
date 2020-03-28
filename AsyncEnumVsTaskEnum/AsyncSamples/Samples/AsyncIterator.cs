using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncSamples.Samples
{
    public class AsyncIterator
    {
        public async Task PrintAllElements(Task<IEnumerable<string>> list)
        {
            foreach (var s1 in await list)
            {
                Console.WriteLine(s1);
            }
        }
        
        public async Task PrintEachElement(IAsyncEnumerable<string> list)
        {
            await foreach (var s2 in list)
            {
                Console.WriteLine(s2);
            }
        }

        public async Task<IEnumerable<string>> GetTaskEnumerable(IEnumerable<string> list, Func<string, Task<string>> func)
        {
            var responses = new List<string>();
            foreach (var l in list)
            {
                var elem = await func(l);
                responses.Add(elem + "with TaskEnumerable");
            }
            return responses;
        }
    
        public async IAsyncEnumerable<string> GetAsyncEnumerable(IEnumerable<string> list, Func<string, Task<string>> func)
        {
            foreach (var l in list)
            {
                var elem = await func(l);
                yield return elem + "with AsyncEnumerable";
            }
        }
    }
}