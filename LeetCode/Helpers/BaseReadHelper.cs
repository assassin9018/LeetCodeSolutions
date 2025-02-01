using LeetCode.DataStructures;

namespace LeetCode.Helpers;

public abstract class BaseReadHelper : IReadHelper
{
    protected bool ApplyFilters { get; set; }

    protected abstract string GetStringForParsing();
    protected abstract void PringMessage(string message);

    public string ReadStr(string? message = null)
    {
        message ??= "Введите строку";

        PringMessage(message);

        return GetStringForParsing();
    }

    public int ReadInt(string? message = null)
    {
        message ??= "Введите целое число";

        PringMessage(message);

        var stringForParsing = GetStringForParsing();

        return int.Parse(stringForParsing);
    }

    public long ReadLong(string? message = null)
    {
        message ??= "Введите целое число";

        PringMessage(message);

        var stringForParsing = GetStringForParsing();

        return long.Parse(stringForParsing);
    }

    public double ReadDouble(string? message = null)
    {
        message ??= "Введите число с плавающей запятой";

        PringMessage(message);

        return double.Parse(GetStringForParsing());
    }

    public int[][] Read2Array(string? message = null)
    {
        message ??= "Введите двумерный массив (пр: [[1,2,3],[4,5,6],[7,8,9]])";

        PringMessage(message);
        string str = GetStringForParsing().Trim();

        if (str.Length == 0 || str[0] != '[' || str[^1] != ']')
            throw new ArgumentException("Двумерный массив должен начинаться на [ и заканчиваться на ]");

        var source = str[1..^1].Split(["],", "]"], StringSplitOptions.RemoveEmptyEntries);
        if (source.All(x => x[0] != '['))
            throw new ArgumentException("Неверный формат. Каждая строка в двумерном массиве должна начинаться на [ и заканчиваться на ]");

        List<int[]> result = [];
        foreach (var raw in source.Select(x => x[1..]))
        {
            var parsedValue = raw
                .Trim()
                .Split(',')
                .Select(x => x.Trim())
                .Where(x => x.Length > 0)
                .Select(int.Parse)
                .ToArray();

            result.Add(parsedValue);
        }

        return [.. result];
    }

    public int[] ReadArray(string? message = null, Func<int[], bool>? filter = null)
    {
        message ??= "Введите массив (пр: 1,2,3)";

        PringMessage(message);
        int[]? result = null;

        do
        {
            try
            {
                string source = GetStringForParsing();
                result = source.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x.Trim())).ToArray();
                if (ApplyFilters && !(filter?.Invoke(result) ?? true))
                {
                    result = null;
                    PringMessage($"Не корректный ввод данных.\n{message}");
                }
            }
            catch
            {
                PringMessage($"Не корректный ввод данных.\n{message}");
            }

        } while (result is null);

        return result;
    }

    public ListNode ReadLinkedList(string? message = null)
    {
        message ??= "Введите список (пр: 1,2,3)";

        var list = ReadArray(message) ?? throw new InvalidOperationException();
        var head = new ListNode(list[0], null);
        var t = head;
        foreach (int item in list.Skip(1))
        {
            t.next = new ListNode(item, null);
            t = t.next;
        }

        return head;
    }
}
