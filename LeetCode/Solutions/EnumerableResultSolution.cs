using System.Collections;
using LeetCode.Helpers;

namespace LeetCode.Solutions;

public abstract class EnumerableResultSolution<T> : SolutionBase<IEnumerable>
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

    private protected override void PrintResult(IEnumerable result)
    {
        if (result is IEnumerable<T> enumerable)
            _writer.Write(enumerable);
        else
            foreach (var item in result.Cast<IEnumerable>())
                PrintResult(item);
    }
}
