using LeetCode.DataStructures;

namespace LeetCode
{
    public interface IReadHelper
    {
        int[][] Read2Array(string? message = null);
        int[] ReadArray(string? message = null);
        double ReadDouble(string? message = null);
        int ReadInt(string? message = null);
        ListNode ReadLinkedList(string? message = null);
    }
}