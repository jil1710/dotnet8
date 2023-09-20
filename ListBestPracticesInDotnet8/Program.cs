using BenchmarkDotNet.Running;

namespace ListBestPracticesInDotnet8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmark>();
        }
    }
}
