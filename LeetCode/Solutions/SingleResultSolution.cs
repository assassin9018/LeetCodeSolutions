using LeetCode.Helpers;

namespace LeetCode.Solutions
{
    public abstract class SingleResultSolution<T> : SolutionBase<T>
    {
        private protected readonly IWriteHelper<T> _writer;

        protected SingleResultSolution()
        {
            _writer = new ConsoleWriteHelper<T>();
        }

        protected SingleResultSolution(IReadHelper reader, IWriteHelper<T> writer) : base(reader)
        {
            _writer = writer;
        }

        private protected override void PrintResult(T result)
            => _writer.Write(result);
    }
}
