using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmark.ByteExtensions
{
    [SimpleJob(RuntimeMoniker.Net48)]
// [SimpleJob(RuntimeMoniker.Net60)]
// [RPlotExporter]
    [MemoryDiagnoser]
    public class Number2ChineseBenchmark
    {
        public readonly ulong Source;
        public readonly ulong SourceLess10;

        public Number2ChineseBenchmark()
        {
            // Source = (ulong)Random.Shared.NextInt64();
            Source = ulong.MaxValue;
            SourceLess10 = Source % 10;
        }

        [Benchmark]
        public string ToLowercaseReadingStringInChinese()
        {
            return Number2Chinese.Number2Chinese.ToLowercaseReadingString(Source);
        }

        // [Benchmark]
        // public string ToLowercaseReadingStringInChineseLess10()
        // {
        //     return Number2Chinese.Number2Chinese.ToLowercaseReadingString(SourceLess10);
        // }
    }
}