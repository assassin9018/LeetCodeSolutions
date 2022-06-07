namespace LeetCode.Solutions;

public abstract class EnumerableResultSolution<T> : SolutionBase<IEnumerable<T>>
{
    private protected readonly IWriteHelper _writer;

    protected EnumerableResultSolution()
    {
        _writer = new ConsoleWriteHelper();
    }

    protected EnumerableResultSolution(IReadHelper reader) : base(reader)
    {
        _writer = new ConsoleWriteHelper();
    }

    private protected override void PrintResult(IEnumerable<T> result)
        => _writer.Write(result);
}
