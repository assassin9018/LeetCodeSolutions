namespace LeetCode.Helpers;

public interface IWriteHelper<T>
{
    void Write(IEnumerable<T> arr);
    void Write(T value);
}