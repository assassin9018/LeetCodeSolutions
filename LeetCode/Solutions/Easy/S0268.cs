namespace LeetCode.Solutions.Easy;
internal class S0268 : SingleResultSolution<int>
{
    public override int Number => 268;

    public override string Name => "Missing Number";

    private protected override Func<int> CreateExecutionMethod()
    {
        int[] arr = _reader.ReadArray("Array from zero to any value with one missed number.", x => x.Min() == 0 && x.Max() == x.Length);

        return () => MissingNumber(arr);
    }

    public static int MissingNumber(int[] nums) 
        => -Enumerable.Range(0, nums.Length).Select(x => nums[x] - x).Sum() + nums.Length;

    public override string Description => @"Given an array nums containing n distinct numbers in the range [0, n], return the only number in the range that is missing from the array.

Example 1:
Input: nums = [3,0,1]
Output: 2
Explanation: n = 3 since there are 3 numbers, so all numbers are in the range [0,3]. 2 is the missing number in the range since it does not appear in nums.

Example 2:
Input: nums = [0,1]
Output: 2
Explanation: n = 2 since there are 2 numbers, so all numbers are in the range [0,2]. 2 is the missing number in the range since it does not appear in nums.

Example 3:
Input: nums = [9,6,4,2,3,5,7,0,1]
Output: 8
Explanation: n = 9 since there are 9 numbers, so all numbers are in the range [0,9]. 8 is the missing number in the range since it does not appear in nums.

Constraints:
n == nums.length
1 <= n <= 104
0 <= nums[i] <= n
All the numbers of nums are unique.";
}
