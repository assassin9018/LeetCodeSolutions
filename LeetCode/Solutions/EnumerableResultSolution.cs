using LeetCode.Helpers;

namespace LeetCode.Solutions;

public abstract class EnumerableResultSolution<T> : SolutionBase<IEnumerable<T>>
{
    private protected readonly IWriteHelper<T> _writer;

    protected EnumerableResultSolution()
    {
        _writer = new ConsoleWriteHelper<T>();
    }

    protected EnumerableResultSolution(IReadHelper reader, IWriteHelper<T> writer) : base(reader)
    {
        _writer = writer;
    }

    private protected override void PrintResult(IEnumerable<T> result)
        => _writer.Write(result);
}
