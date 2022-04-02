namespace LeetCode.DataStructures;

public class ListNode
{
    public int val { get; set; }
    public ListNode? next { get; set; }

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }

    public void ToConsole()
    {
        ListNode? head = this;
        while(head != null)
        {
            Console.Write(head.val);
            head = head.next;
        }
        Console.WriteLine();
    }

    public override string ToString() => val.ToString();
}
