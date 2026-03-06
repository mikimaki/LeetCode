namespace LeetCode;

/// <summary>
/// Given an integer array nums and an integer val, remove all occurrences of val in nums in-place. The order of the elements may be changed. Then return the number of elements in nums which are not equal to val.
///
/// Consider the number of elements in nums which are not equal to val be k, to get accepted, you need to do the following things:
///
/// Change the array nums such that the first k elements of nums contain the elements which are not equal to val. The remaining elements of nums are not important as well as the size of nums.
/// Return k.
///
/// </summary>
public class RemoveElementII
{
    public int RemoveElement(int[] nums, int val)
    {
        var k = 0;
        
        var j = nums.Length - 1;
        var temp = 0;

        if (j == 0 && nums[j] == val)
        {
            return 0;
        }

        bool elementSwapped = false;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i >= j && i > 0 && elementSwapped)
            {
                break;
            }
            if (nums[i] == val)
            {
                while (nums[j] == val && j > i)
                {
                    j = j - 1;
                }

                if (nums[j] != val)
                {
                    elementSwapped = true;
                    nums[i] = nums[j];
                    nums[j] = val;
                    k += 1;   
                }
            }
            else
            {
                k += 1;
            }
        }

        return k;
    }
}