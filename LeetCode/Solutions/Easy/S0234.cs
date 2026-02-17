using LeetCode.DataStructures;

namespace LeetCode.Solutions.Easy;

public class S0234 : SingleResultSolution<bool>
{
    public override int Number => 234;

    public override string Name => "Palindrome Linked List";

    private protected override Func<bool> CreateExecutionMethod()
    {
        ListNode head = _reader.ReadLinkedList();
        return () => IsPalindrome(head);
    }

    public static bool IsPalindrome(ListNode head)
    {
        byte[] bytes = GetArray(head);
        bool isTrue = true;
        int middle = bytes.Length / 2;
        for (int i = 0; i < middle && isTrue; i++)
            isTrue = bytes[i] == bytes[bytes.Length - i - 1];

        return isTrue;
    }

    private static byte[] GetArray(ListNode head)
    {
        int length = Count(head);
        byte[] bytes = new byte[length];
        for (int i = 0; i < bytes.Length; i++)
        {
            bytes[i] = (byte)head!.val;
            head = head.next!;
        }
        return bytes;
    }

    public static int Count(ListNode head)
    {
        int i = 0;
        var h = head;
        while (h != null)
        {
            i++;
            h = h.next;
        }
        return i;
    }

    public override string Description =>
@"Given the head of a singly linked list, return true if it is a palindrome.

Example 1:
Input: head = [1,2,2,1]
Output: true
Example 2:
Input: head = [1,2]
Output: false

Constraints:
The number of nodes in the list is in the range [1, 105].
0 <= Node.val <= 9

 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }";
}
