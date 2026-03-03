namespace LeetCode;

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
public class AddTwoNumbersSolution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
        l2 = new ListNode(5, new ListNode(6, new ListNode(4)));
        
        return SumListNodes(l1, l2, null, 0);
    }

    private ListNode ResultEntryNode { get; set; }

    private ListNode SumListNodes(ListNode l1, ListNode l2, ListNode previousResultNode, int carry)
    {
        if (l1 == null && l2 == null && carry == 0)
        {
            return ResultEntryNode;
        }
        
        var val1 = l1?.val ?? 0;
        var val2 = l2?.val ?? 0;

        var result = val1 + val2 + carry;

        carry = result > 9 ? 1 : 0;

        result = result % 10;

        var resultNode = new ListNode(result);

        if (previousResultNode == null)
        {
            ResultEntryNode = resultNode;
        }
        else
        {
            previousResultNode.next = resultNode;   
        }
        
        return SumListNodes(l1?.next, l2?.next, resultNode, carry);
    }
}