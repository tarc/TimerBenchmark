using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace timerbenchmark
{
    // The code below is copied from:
    // https://www.codeproject.com/Articles/800756/TimeSpan-Calculation-based-on-DateTime-is-a-Perfor
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Performance Tests");
            Console.WriteLine("  Stopwatch Resolution (nS): " + 
                             (1000000000.0 / Stopwatch.Frequency).ToString());

            RunTests();
        }

        public static long DummyValue;

        public static void RunTests()
        {
            const int loopEnd = 1000000;
            Stopwatch watch = new Stopwatch();

            Console.WriteLine();
            Console.WriteLine("Reference Loop (NOP) Iterations: " + loopEnd);
            watch.Reset();
            watch.Start();
            for (int i = 0; i < loopEnd; ++i)
            {
                DummyValue += i;
            }
            watch.Stop();
            Console.WriteLine("  Reference Loop (NOP) Elapsed Time (ms): " + 
                        ((double)watch.ElapsedTicks / Stopwatch.Frequency * 1000).ToString());


            Console.WriteLine();
            Console.WriteLine("Query Environment.TickCount");
            watch.Reset();
            watch.Start();
            for (int i = 0; i < loopEnd; ++i)
            {
                DummyValue += Environment.TickCount;
            }
            watch.Stop();
            Console.WriteLine("  Query Environment.TickCount Elapsed Time (ms): " + 
                           ((double)watch.ElapsedTicks / Stopwatch.Frequency * 1000).ToString());

            Console.WriteLine();
            Console.WriteLine("Query DateTime.Now.Ticks");
            watch.Reset();
            watch.Start();
            for (int i = 0; i < loopEnd; ++i)
            {
                DummyValue += DateTime.Now.Ticks;
            }
            watch.Stop();
            Console.WriteLine("  Query DateTime.Now.Ticks Elapsed Time (ms): " + 
                      ((double)watch.ElapsedTicks / Stopwatch.Frequency * 1000).ToString());

            Console.WriteLine();
            Console.WriteLine("Query Stopwatch.ElapsedTicks");
            watch.Reset();
            watch.Start();
            for (int i = 0; i < loopEnd; ++i)
            {
                DummyValue += watch.ElapsedTicks;
            }
            watch.Stop();
            Console.WriteLine("  Query Stopwatch.ElapsedTicks Elapsed Time (ms): " + 
                  ((double)watch.ElapsedTicks / Stopwatch.Frequency * 1000).ToString());
        }        
    }
}
