using LeetCode.Helpers;

namespace LeetCode.Solutions.Easy;

public class S1752(IReadHelper reader, IWriteHelper<bool> writer) : SingleResultSolution<bool>(reader, writer)
{
    public override int Number => 1752;
    public override string Name => "Check if Array Is Sorted and Rotated";

    private protected override Func<bool> CreateExecutionMethod()
    {
        var nums = _reader.ReadArray();

        return () => Check(nums);
    }

    private static bool Check(int[] nums)
    {
        var startIndex = 0;

        for (var i = 1; i < nums.Length; i++)
            if (nums[i - 1] > nums[i])
                startIndex = i;

        var isSorted = true;
        for (var i = startIndex; i < startIndex + nums.Length - 1 && isSorted; i++)
            isSorted &= nums[i % nums.Length] <= nums[(i + 1) % nums.Length];

        return isSorted;
    }

    public override string Description
        => """
           Given an array nums, return true if the array was originally sorted in non-decreasing order, then rotated some number of positions (including zero). Otherwise, return false.
           There may be duplicates in the original array.
           Note: An array A rotated by x positions results in an array B of the same length such that A[i] == B[(i+x) % A.length], where % is the modulo operation.
           
           Example 1:
           Input: nums = [3,4,5,1,2]
           Output: true
           Explanation: [1,2,3,4,5] is the original sorted array.
           You can rotate the array by x = 3 positions to begin on the the element of value 3: [3,4,5,1,2].
          
           Example 2:
           Input: nums = [2,1,3,4]
           Output: false
           Explanation: There is no sorted array once rotated that can make nums.
           
           Example 3:
           Input: nums = [1,2,3]
           Output: true
           Explanation: [1,2,3] is the original sorted array.
           You can rotate the array by x = 0 positions (i.e. no rotation) to make nums.
            
           Constraints:
           1 <= nums.length <= 100
           1 <= nums[i] <= 100
           """;
}