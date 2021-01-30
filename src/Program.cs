using System.Threading;
using System.Diagnostics;
using System;

namespace parallel
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            for (int i = 0; i < 10; i++)
            {
                Process(i);
            }

            Console.WriteLine($"Completed: {timer.Elapsed}");
        }

        private static void Process(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Thread.Sleep(200);
            Console.WriteLine($"Process {id}: {timer.Elapsed}");
        }
    }
}
