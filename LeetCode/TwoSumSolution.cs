namespace LeetCode;

public class TwoSumSolution {
    public int[] TwoSum(int[] nums, int target)
    {
        var j = 0;
        foreach (var num in nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (num + nums[i] == target)
                {
                    return [i, j];
                }
            }
            j++;
        }
        return [];
    }
}