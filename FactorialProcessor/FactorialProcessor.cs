using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorialProcessor
{
    class FactorialProcessor
    {
        public void Go(int param, bool parallelMode)
        {
            if (param < 1 || param > 15)
            {
                throw new ArgumentOutOfRangeException("param", "Value must be between 1 and 15.");
            }

            List<Thread> _threads = new List<Thread>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 1; i <= param; i++)
            {
                int n = i;

                if (parallelMode)
                {
                    //creating a thread
                    var thread = new Thread(() =>
                    {
                        int result = Factorial(n);
                        Console.WriteLine($"Factorial of {n} = {result}");
                    });
                    _threads.Add(thread);
                    //starting a thread
                    thread.Start();
                }
                else
                {
                    int result = Factorial(n);
                    Console.WriteLine($"Factorial of {n} = {result}");
                }
            }
            foreach (Thread thread in _threads)
            {
                thread.Join();
            }
            stopwatch.Stop();
            Console.WriteLine($"Execution time: {stopwatch.ElapsedTicks} ticks ({stopwatch.ElapsedMilliseconds} ms)");
        }
        private int Factorial(int n)
        {
            if (n == 1)
                return 1;
            else
                return n * Factorial(n - 1);
        }
    }
}