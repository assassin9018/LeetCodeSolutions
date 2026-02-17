using LeetCode.DataStructures;

namespace LeetCode.Solutions.Hard;
public class S0023 : SingleResultSolution<ListNode>
{
    public override int Number => 23;

    public override string Name => "Merge k Sorted Lists";

    private protected override Func<ListNode> CreateExecutionMethod()
    {
        int listsCount = _reader.ReadInt("Введите кол-во списков");
        ListNode[] nodes = new ListNode[listsCount];
        for(int i = 0; i < listsCount; i++)
            nodes[i] = _reader.ReadLinkedList("Введите отсортированный по возврастанию список");

        return () => MergeKLists(nodes);
    }

    public static ListNode MergeKLists(ListNode[] lists)
    {
        ListNode head = RemoveMin(lists)!;
        ListNode? current = head;
        if(current != null)
            do
            {
                current.next = RemoveMin(lists);
                current = current.next;
            } while(current != null);
        return head;
    }

    private static ListNode? RemoveMin(ListNode?[] lists)
    {
        int index = -1;
        ListNode? min = null;
        for(int i = 0; i < lists.Length; i++)
        {
            ListNode? current = lists[i];
            if(current != null && !(current.val > min?.val))
            {
                min = current;
                index = i;
            }
        }
        if(index >= 0)
        {
            lists[index] = min!.next;
        }

        return min;
    }

    public override string Description =>
@"Input: lists = [[1,4,5],[1,3,4],[2,6]]
Output: [1,1,2,3,4,4,5,6]
Explanation: The linked-lists are:
[
  1->4->5,
  1->3->4,
  2->6
]
merging them into one sorted list:
1->1->2->3->4->4->5->6
Example 2:

Input: lists = []
Output: []
Example 3:

Input: lists = [[]]
Output: []
 

Constraints:

k == lists.length
0 <= k <= 10^4
0 <= lists[i].length <= 500
-10^4 <= lists[i][j] <= 10^4
lists[i] is sorted in ascending order.
The sum of lists[i].length will not exceed 10^4.";
}
