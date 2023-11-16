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
        private Stopwatch _stopwatch = new Stopwatch();
        private int _maxValue;
        private int _counter;
        private object _lock = new object();
        ////{
        //    _stopwatch = new Stopwatch();
        //}
        public void Go(int param, bool parallelMode)
        {
            _maxValue = param;
            if (parallelMode)
            {
                StartFactorialParallel(param);
            }
            else
            {
                StartFactorialSequential(param);
            }
        }
        void StartFactorialSequential(int param)
        {
            _stopwatch.Start();
            for(int i = 0; i < param; i++)
            {
                PrintFactorial(i);
            }
        }

        void StartFactorialParallel(int param)
        {
            _stopwatch.Start();
            for (int i = 0; i < param; i++)
            {
                Thread thread = new Thread(PrintFactorial);
                thread.Start(i);
            }
        }

        private void PrintFactorial(object? n)
        {
            int param = (int)n;
            int result = Factorial(param);
            Console.WriteLine($"fact of {param} is {result}");
            if(++_counter == _maxValue)
             {
                 _stopwatch.Stop();
                 Console.WriteLine($"ms {_stopwatch.ElapsedMilliseconds} ticks {_stopwatch.ElapsedTicks}");
             }
        }
        private static int Factorial(int n)
        {
            if (n == 1 || n == 0) return 1;
            return n * Factorial(n - 1);
        }

    }
}