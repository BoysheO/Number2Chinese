using System;
using Benchmark.ByteExtensions;
using BenchmarkDotNet.Running;

public static class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<Number2ChineseBenchmark>();
        Console.WriteLine("Hello, World!");
    }
}