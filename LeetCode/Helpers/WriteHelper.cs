﻿namespace LeetCode.Helpers;

internal class ConsoleWriteHelper : IWriteHelper
{
    public void Write<T>(IEnumerable<T> arr)
        => Console.WriteLine(string.Join(' ', arr.Select(x => x?.ToString() ?? "null")));

    public void Write<T>(T value)
        => Console.WriteLine(value?.ToString());
}

public interface IWriteHelper
{
    void Write<T>(IEnumerable<T> arr);
    void Write<T>(T value);
}