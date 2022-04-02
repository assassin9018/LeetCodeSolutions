using LeetCode.DataStructures;

namespace LeetCode;

public class ConsoleReadHelper : IReadHelper
{
    public int ReadInt(string? message = null)
    {
        if(message is null)
            message = "Введите целое число";

        Console.WriteLine(message);

        return int.Parse(Console.ReadLine()!);
    }

    public double ReadDouble(string? message = null)
    {
        if(message is null)
            message = "Введите число с плавающей запятой";
        Console.WriteLine(message);

        return double.Parse(Console.ReadLine()!);
    }

    public int[][] Read2Array(string? message = null)
    {
        if(message is null)
            message = "Введите двумерный массив (пр: [1,2,3],[4,5,6],[7,8,9])";

        Console.WriteLine(message);

        var source = Console.ReadLine()!.Split(new[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
        int[][] array = new int[source.Length][];
        for(int i = 0; i < source.Length; i++)
            array[i] = source[i].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        return array;
    }

    public int[] ReadArray(string? message = null)
    {
        if(message is null)
            message = "Введите массив (пр: 1,2,3)";

        Console.WriteLine(message);

        return Console.ReadLine()?.Split(',').Select(x => int.Parse(x)).ToArray() ?? throw new ArgumentNullException();
    }

    public ListNode ReadLinkedList(string? message = null)
    {
        if(message is null)
            message = "Введите список (пр: 1,2,3)";

        var list = ReadArray(message) ?? throw new InvalidOperationException();
        var head = new ListNode(list[0], null);
        var t = head;
        foreach(int item in list.Skip(1))
        {
            t.next = new ListNode(item, null);
            t = t.next;
        }

        return head;
    }
}
