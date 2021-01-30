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
            Stopwatch timer = new Stopwatch();
            timer.Start();

            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Process(i));
            }
            Task.WaitAll(tasks.ToArray());

            Console.WriteLine($"Completed: {timer.Elapsed}");
        }

        private static async Task Process(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Thread.Sleep(200);
            Console.WriteLine($"Process {id}: {timer.Elapsed}");
        }
    }
}
