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

            for (int i = 0; i < 10; i++)
            {
                await Process(i);
            }

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
