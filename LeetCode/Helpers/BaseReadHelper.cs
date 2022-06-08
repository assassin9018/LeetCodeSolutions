using LeetCode.DataStructures;

namespace LeetCode.Helpers;

public abstract class BaseReadHelper : IReadHelper
{
    protected bool ApplyFilters { get; set; }

    protected abstract string GetStringForParsing();
    protected abstract void PringMessage(string message);

    public string ReadStr(string? message = null)
    {
        if (message is null)
            message = "Введите строку";

        PringMessage(message);

        return GetStringForParsing();
    }

    public int ReadInt(string? message = null)
    {
        if (message is null)
            message = "Введите целое число";

        PringMessage(message);

        return int.Parse(GetStringForParsing());
    }

    public double ReadDouble(string? message = null)
    {
        if (message is null)
            message = "Введите число с плавающей запятой";
        PringMessage(message);

        return double.Parse(GetStringForParsing());
    }

    public int[][] Read2Array(string? message = null)
    {
        if (message is null)
            message = "Введите двумерный массив (пр: [1,2,3],[4,5,6],[7,8,9])";

        PringMessage(message);
        string str = GetStringForParsing();

        var source = str.Split(new[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
        List<int[]> result = new();
        for (int i = 0; i < source.Length; i += 2)
            result.Add(source[i].Trim().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x.Trim())).ToArray());

        return result.ToArray();
    }

    public int[] ReadArray(string? message = null, Func<int[], bool>? filter = null)
    {
        if (message is null)
            message = "Введите массив (пр: 1,2,3)";

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
        if (message is null)
            message = "Введите список (пр: 1,2,3)";

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
