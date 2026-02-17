namespace LeetCode.Helpers;

internal class ConsoleWriteHelper<T> : IWriteHelper<T>
{
    public void Write(IEnumerable<T> arr)
        => Console.WriteLine(string.Join(' ', arr.Select(x => x?.ToString() ?? "null")));

    public void Write(T value)
        => Console.WriteLine(value?.ToString());
}