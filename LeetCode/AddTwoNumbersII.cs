namespace LeetCode;

public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        l1 = new ListNode(5);
        l2 = new ListNode(5);
        
        var l1temp = l1;
        var l2temp = l2;
        while (l1temp != null || l2temp != null)
        {
            if (l1temp == null)
            {
                var padding = new ListNode(0, l1);
                l1 = padding;
            }
            if (l2temp == null)
            {
                var padding = new ListNode(0, l2);
                l2 = padding;
            }
            
            l1temp = l1temp?.next;
            l2temp = l2temp?.next;
        }
        
        return SumListNodes(l1, l2, null);
    }

    private ListNode ResultEntryNode { get; set; }
    private Dictionary<ListNode,ListNode> PreviousNodes = new Dictionary<ListNode, ListNode>();

    private ListNode SumListNodes(ListNode l1, ListNode l2, ListNode previousResultNode)
    {
        if (l1 == null && l2 == null)
        {
            return ResultEntryNode;
        }
        
        var val1 = l1?.val ?? 0;
        var val2 = l2?.val ?? 0;

        var result = val1 + val2;

        var carry = result > 9 ? 1 : 0;

        result = result % 10;
        
        var resultNode = new ListNode(result);
                
        if(carry == 1 && previousResultNode != null){
            HandleCarry(previousResultNode);
        }
        
        if (previousResultNode == null)
        {
            if (carry == 1)
            {
                previousResultNode = new ListNode(1);
                previousResultNode.next = resultNode;
                ResultEntryNode = previousResultNode;
                PreviousNodes.Add(resultNode, previousResultNode);
            }
            else
            {
                ResultEntryNode = resultNode;   
            }
        }
        else
        {
            previousResultNode.next = resultNode;   
            PreviousNodes.Add(resultNode, previousResultNode);
        }
        
        return SumListNodes(l1?.next, l2?.next, resultNode);
    }

    private void HandleCarry(ListNode? previousNode)
    {
        previousNode.val += 1;

        if (previousNode.val > 9)
        {
            previousNode.val %= 10;
            var previousNodeHasFather = PreviousNodes.TryGetValue(previousNode, out var previousNodesFather);
            if (previousNodeHasFather)
            {
                HandleCarry(previousNodesFather);
            }
            else
            {
                var finalResult = new ListNode(1, previousNode);
                ResultEntryNode = finalResult;
            }
        }
    }
}