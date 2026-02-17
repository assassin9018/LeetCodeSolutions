using System.Collections;
using LeetCode.Helpers;

namespace LeetCode.Solutions;

public abstract class EnumerableResultSolution<T>(IReadHelper reader, IWriteHelper<T> writer)
    : SolutionBase<IEnumerable>(reader)
{
    private protected override void PrintResult(IEnumerable result)
    {
        if (result is IEnumerable<T> enumerable)
            writer.Write(enumerable);
        else
            foreach (var item in result.Cast<IEnumerable>())
                PrintResult(item);
    }
}
