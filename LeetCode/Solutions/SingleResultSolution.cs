using LeetCode.Helpers;

namespace LeetCode.Solutions
{
    public abstract class SingleResultSolution<T>(IReadHelper reader, IWriteHelper<T> writer) : SolutionBase<T>(reader)
    {
        private protected override void PrintResult(T result)
            => writer.Write(result);
    }
}
