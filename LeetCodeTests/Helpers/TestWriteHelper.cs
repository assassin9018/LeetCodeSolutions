using LeetCode.Helpers;

namespace LeetCodeTests.Helpers;

internal class TestWriteHelper<T> : IWriteHelper<T>
{
    public T? LastValue { get; private set; }
    public IEnumerable<T>? LastValues { get; private set; }

    public void Write(IEnumerable<T> values)
        => LastValues = values;

    public void Write(T value)
        => LastValue = value;
}
