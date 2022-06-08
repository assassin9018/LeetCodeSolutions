using LeetCode.Helpers;

namespace LeetCode.Solutions
{
    public abstract class SingleResultSolution<T> : SolutionBase<T>
    {
        private protected readonly IWriteHelper _writer;

        protected SingleResultSolution()
        {
            _writer = new ConsoleWriteHelper();
        }

        protected SingleResultSolution(IReadHelper reader) : base(reader)
        {
            _writer = new ConsoleWriteHelper();
        }

        private protected override void PrintResult(T result)
            => _writer.Write(result);
    }
}
