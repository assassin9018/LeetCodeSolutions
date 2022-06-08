﻿using LeetCode.DataStructures;

namespace LeetCode.Helpers;

internal class ConsoleReadHelper : StringParser, IReadHelper
{
    public string ReadStr(string? message = null)
    {
        if (message is null)
            message = "Введите строку";

        Console.WriteLine(message);

        return Console.ReadLine()!;
    }

    public int ReadInt(string? message = null)
    {
        if (message is null)
            message = "Введите целое число";

        Console.WriteLine(message);

        return int.Parse(Console.ReadLine()!);
    }

    public double ReadDouble(string? message = null)
    {
        if (message is null)
            message = "Введите число с плавающей запятой";
        Console.WriteLine(message);

        return double.Parse(Console.ReadLine()!);
    }

    public int[][] Read2Array(string? message = null)
    {
        if (message is null)
            message = "Введите двумерный массив (пр: [1,2,3],[4,5,6],[7,8,9])";

        Console.WriteLine(message);
        string source = Console.ReadLine()!;

        return Parce2IntArrayStr(source);
    }

    public int[] ReadArray(string? message = null, Func<int[], bool>? filter = null)
    {
        if (message is null)
            message = "Введите массив (пр: 1,2,3)";

        Console.WriteLine(message);
        int[]? result = null;

        do
        {
            try
            {
                string source = Console.ReadLine()!;
                result = ParceIntArrayStr(source);
                if (!(filter?.Invoke(result) ?? true))
                {
                    result = null;
                    Console.WriteLine($"Не корректный ввод данных.\n{message}");
                }
            }
            catch
            {
                Console.WriteLine($"Не корректный ввод данных.\n{message}");
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
