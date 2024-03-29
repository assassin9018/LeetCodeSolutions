﻿using LeetCode.DataStructures;

namespace LeetCode.Helpers
{
    public interface IReadHelper
    {
        int[][] Read2Array(string? message = null);
        int[] ReadArray(string? message = null, Func<int[], bool>? filter = null);
        double ReadDouble(string? message = null);
        int ReadInt(string? message = null);
        long ReadLong(string? message = null);
        ListNode ReadLinkedList(string? message = null);
        string ReadStr(string? message = null);
    }
}