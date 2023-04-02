using LeetCode.Helpers;

namespace LeetCode.Solutions
{
    public abstract class SingleResultSolution<T> : SolutionBase<T>
    {
        private protected readonly IWriteHelper<T> Writer;

        protected SingleResultSolution()
        {
            Writer = new ConsoleWriteHelper<T>();
        }

        protected SingleResultSolution(IReadHelper reader, IWriteHelper<T> writer) : base(reader)
        {
            Writer = writer;
        }

        private protected override void PrintResult(T result)
            => Writer.Write(result);
    }
}
