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

            List<Task<int>> tasks = new List<Task<int>>();
            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Process(i));
            }
            Task.WaitAll(tasks.ToArray());

            List<int> results = new List<int>();
            foreach (var task in tasks)
            {
                results.Add(task.Result);
            }

            Console.WriteLine();
            Console.WriteLine($"Result: {string.Join(",", results)}");
            Console.WriteLine($"Completed: {timer.Elapsed}");
        }

        private static async Task<int> Process(int id)
        {
            var number = await Task<int>.Run(() =>
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                Random random = new Random();
                Thread.Sleep(200);

                int number = random.Next(1,100);

                Console.WriteLine($"Process {id}: {timer.Elapsed}");
                return number;
            });
            return number;
        }
    }
}
