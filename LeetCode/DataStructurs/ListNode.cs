using System.Text;

namespace LeetCode.DataStructures;

public class ListNode
{
#pragma warning disable IDE1006 // Naming Styles
    /// <summary>
    /// Value.
    /// </summary>
    /// <remarks>This field provided by LeetCode and have not to be renamed</remarks>
    public int val { get; set; }
    /// <summary>
    /// Next node in linked list.
    /// </summary>
    /// <remarks>This field provided by LeetCode and have not to be renamed</remarks>
    public ListNode? next { get; set; }
#pragma warning restore IDE1006 // Naming Styles

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        ListNode? head = this;
        while (head != null)
        {
            sb.Append(head.val).Append(' ');
            head = head.next;
        }
        sb.AppendLine();

        return sb.ToString();
    }
}
