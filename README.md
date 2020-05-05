# TimerBenchmark

This is a CMake skeleton for C# projects. It is also a kind of benchmark for Windows timer utilities, based on [TimeSpan Calculation based on DateTime is a Performance Bottleneck](https://www.codeproject.com/Articles/800756/TimeSpan-Calculation-based-on-DateTime-is-a-Perfor).

## Clonning, Compiling and Running

Make sure you have CMake, Git and a C# toolchain properly installed and issue the following commands:

```batch
git clone https://github.com/tarc/TimerBenchmark.git
cd TimerBenchmark
run.bat
```

The expected output from the above commands is something like:

```text
-- Building for: Visual Studio 16 2019
-- Selecting Windows SDK version 10.0.18362.0 to target Windows 10.0.17763.
-- The CSharp compiler identification is Microsoft unknown 9999
-- The CSharp compiler version is 9999
-- Check for working C# compiler: C:/Program Files (x86)/Microsoft Visual Studio/2019/Professional/MSBuild/Current/Bin/Roslyn/csc.exe
-- Check for working C# compiler: C:/Program Files (x86)/Microsoft Visual Studio/2019/Professional/MSBuild/Current/Bin/Roslyn/csc.exe - works
-- Generating timerbenchmark
-- Configuring done
-- Generating done
-- Build files have been written to: E:/projects/TimerBenchmark/build
Microsoft(R) Build Engine versão 16.5.0+d4cbfca49 para .NET Framework
Copyright (C) Microsoft Corporation. Todos os direitos reservados.

  Checking Build System
  timerbenchmark -> E:\projects\TimerBenchmark\build\Debug\timerbenchmark.exe
  Performance Tests
    Stopwatch Resolution (nS): 100

  Reference Loop (NOP) Iterations: 1000000
    Reference Loop (NOP) Elapsed Time (ms): 1,9908

  Query Environment.TickCount
    Query Environment.TickCount Elapsed Time (ms): 4,8561

  Query DateTime.Now.Ticks
    Query DateTime.Now.Ticks Elapsed Time (ms): 178,5078

  Query Stopwatch.ElapsedTicks
    Query Stopwatch.ElapsedTicks Elapsed Time (ms): 33,7396
  Building Custom Rule E:/projects/TimerBenchmark/CMakeLists.txt
```
