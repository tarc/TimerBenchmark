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
            const long loopEnd = 1000000000;
            Stopwatch watch = new Stopwatch();

            Console.WriteLine();
            Console.WriteLine("Reference Loop (NOP) Iterations: " + loopEnd);
            watch.Reset();
            watch.Start();
            for (long i = 0; i < loopEnd; ++i)
            {
                DummyValue += i;
            }
            watch.Stop();
            Console.WriteLine("  Reference Loop (NOP) Elapsed Time (ns): " +
                ( (double) watch.ElapsedTicks * 1000000000 / ( Stopwatch.Frequency * loopEnd ) ).ToString());


            Console.WriteLine();
            Console.WriteLine("Query Environment.TickCount");
            watch.Reset();
            watch.Start();
            for (long i = 0; i < loopEnd; ++i)
            {
                DummyValue += Environment.TickCount;
            }
            watch.Stop();
            Console.WriteLine("  Query Environment.TickCount Elapsed Time (ns): " +
                ( (double) watch.ElapsedTicks * 1000000000 / ( Stopwatch.Frequency * loopEnd ) ).ToString());

            Console.WriteLine();
            Console.WriteLine("Query DateTime.Now.Ticks");
            watch.Reset();
            watch.Start();
            for (long i = 0; i < 1000000; ++i)
            {
                DummyValue += DateTime.Now.Ticks;
            }
            watch.Stop();
            Console.WriteLine("  Query DateTime.Now.Ticks Elapsed Time (ns): " +
                ( (double) watch.ElapsedTicks * 1000000000 / ( Stopwatch.Frequency * 1000000 ) ).ToString());

            Console.WriteLine();
            Console.WriteLine("Query Stopwatch.ElapsedTicks");
            watch.Reset();
            watch.Start();
            for (long i = 0; i < 1000000; ++i)
            {
                DummyValue += watch.ElapsedTicks;
            }
            watch.Stop();
            Console.WriteLine("  Query Stopwatch.ElapsedTicks Elapsed Time (ns): " +
                ( (double) watch.ElapsedTicks * 1000000000 / ( Stopwatch.Frequency * 1000000 ) ).ToString());

            Console.WriteLine($"\n\nDummyValue: {DummyValue}");
        }        
    }
}
