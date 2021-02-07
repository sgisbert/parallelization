using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System;

namespace parallel
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ConcurrentBag<int> cb = new ConcurrentBag<int>();
            Stopwatch timer = new Stopwatch();
            timer.Start();

            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Process(i, cb));
            }
            Task.WaitAll(tasks.ToArray());

            Console.WriteLine();
            Console.WriteLine($"Result: {string.Join(",", cb)}");
            Console.WriteLine($"Completed: {timer.Elapsed}");
        }

        private static async Task Process(int id, ConcurrentBag<int> cb)
        {
            await Task.Run(() =>
            {
                CoreProcess(id, cb);
            });
        }

        private static void CoreProcess(int id, ConcurrentBag<int> cb)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Random random = new Random();
            Thread.Sleep(200);

            int number = random.Next(1, 100);
            cb.Add(number);

            Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Process {id}: {timer.Elapsed}");
        }
    }
}
