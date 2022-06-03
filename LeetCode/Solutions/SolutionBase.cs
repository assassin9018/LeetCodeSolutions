using System.Diagnostics;

namespace LeetCode.Solutions
{
    public abstract class SolutionBase<T> : IIssueSolution
    {
        private protected readonly IReadHelper _reader;

        public abstract int Number { get; }
        public abstract string Name { get; }
        public abstract string Decription { get; }

        protected SolutionBase()
        {
            _reader = new ConsoleReadHelper();
        }

        protected SolutionBase(IReadHelper reader)
        {
            _reader = reader;
        }

        public void Run()
        {
            Func<T> solutionMethod = CreateExecutionMethod();
            Stopwatch stopwatch = Stopwatch.StartNew();
            T result = solutionMethod.Invoke();
            stopwatch.Stop();
            Console.WriteLine($"Execution time {stopwatch.Elapsed.TotalSeconds} sec.");
            PrintResult(result);
        }

        private protected abstract void PrintResult(T result);

        private protected abstract Func<T> CreateExecutionMethod();
    }
}
