using LeetCode.Helpers;

namespace LeetCode.Solutions.Easy;

public class S3151(IReadHelper reader, IWriteHelper<bool> writer) : SingleResultSolution<bool>(reader, writer)
{
    public override int Number => 3151;
    public override string Name => "Special Array I";

    private protected override Func<bool> CreateExecutionMethod()
    {
        var nums = _reader.ReadArray();

        return () => IsArraySpecial(nums);
    }

    private static bool IsArraySpecial(int[] nums)
    {
        var isSpecial = true;
        for (var i = 1; i < nums.Length && isSpecial; i++)
            isSpecial &= (nums[i - 1] % 2 + nums[i] % 2) == 1;

        return isSpecial;
    }

    public override string Description
        =>
            """
            An array is considered special if every pair of its adjacent elements contains two numbers with different parity.
            You are given an array of integers nums. Return true if nums is a special array, otherwise, return false.

            Example 1:
            Input: nums = [1]
            Output: true
            Explanation:
            There is only one element. So the answer is true.

            Example 2:
            Input: nums = [2,1,4]
            Output: true
            Explanation:
            There is only two pairs: (2,1) and (1,4), and both of them contain numbers with different parity. So the answer is true.

            Example 3:
            Input: nums = [4,3,1,6]
            Output: false
            Explanation:
            nums[1] and nums[2] are both odd. So the answer is false.

            Constraints:
            1 <= nums.length <= 100
            1 <= nums[i] <= 100
            """;
}