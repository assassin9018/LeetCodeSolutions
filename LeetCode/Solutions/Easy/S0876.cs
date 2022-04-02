using LeetCode.DataStructures;

namespace LeetCode.Solutions.Easy;
public class S0876 : SolutionBase
{
    public override int Number => 876;

    public override string Name => "Middle of the Linked List";

    public override void Run()
    {
        ListNode? head = _reader.ReadLinkedList();
        head = MiddleNode(head);
        head.ToConsole();
    }

    public ListNode MiddleNode(ListNode head)
    {
        return GoTo(head, Count(head) / 2);
    }

    public static int Count(ListNode head)
    {
        int i = 0;
        var h = head;
        while(h != null)
        {
            i++;
            h = h.next;
        }
        return i;
    }

    public static ListNode GoTo(ListNode head, int index)
    {
        for(int i = 0; i < index; i++)
            head = head.next!;
        return head;
    }

    public override string Decription =>
@"Given the head of a singly linked list, return the middle node of the linked list.

If there are two middle nodes, return the second middle node.

Example 1:

Input: head = [1,2,3,4,5]
Output: [3,4,5]
Explanation: The middle node of the list is node 3.
Example 2:


Input: head = [1,2,3,4,5,6]
Output: [4,5,6]
Explanation: Since the list has two middle nodes with values 3 and 4, we return the second one.
 
Constraints:

The number of nodes in the list is in the range [1, 100].
1 <= Node.val <= 100";
}
