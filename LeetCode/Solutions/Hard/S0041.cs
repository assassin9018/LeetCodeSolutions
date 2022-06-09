using LeetCode.Helpers;

namespace LeetCode.Solutions.Hard;
public class S0041 : SingleResultSolution<int>
{
    public S0041()
    {
    }

    public S0041(IReadHelper reader, IWriteHelper<int> writer) : base(reader, writer)
    {
    }

    public override int Number => 41;

    public override string Name => "First Missing Positive";

    private protected override Func<int> CreateExecutionMethod()
    {
        int[] arr = _reader.ReadArray("Array from any to any value with one missed positive number.");

        return () => FirstMissingPositive(arr);
    }

    private static int FirstMissingPositive(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            int n = nums[i];
            if (n > 0 && n != i + 1 && n < nums.Length)
            {
                int ti = nums[i] = nums[n - 1];
                nums[n - 1] = n;
                if (ti!=n && ti - 1 < i)
                    i--;
            }
        }
        for (int i = 0; i < nums.Length; i++)
            if (nums[i] != i + 1)
                return i + 1;

        return nums.Length + 1;
    }

    private static int FirstMissingPositiveJavaStolen(int[] nums)
    {
        bool one = false;

        //step 1 
        for (int i = 0; i < nums.Length; i++) //put in range means 1<=nums<=n
        {
            if (nums[i] == 1)
                one = true;
            if (!(nums[i] >= 1 && nums[i] <= nums.Length))
                nums[i] = 1;
        }
        // System.out.println(one);
        if (one == false)
            return 1;   // because 1 is not present 
                        // System.out.println(Arrays.toString(nums));
                        // step 2 --> put it coresponding indexes to minus

        for (int i = 0; i < nums.Length; i++)
            nums[Math.Abs(nums[i]) - 1] = -Math.Abs(nums[Math.Abs(nums[i]) - 1]);


        //step 3 iterate over array again and see which index is not positive


        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0)
                return i + 1;
        }


        return nums.Length + 1;
    }

    public override string Decription => @"Given an unsorted integer array nums, return the smallest missing positive integer.
You must implement an algorithm that runs in O(n) time and uses constant extra space.

Example 1:
Input: nums = [1,2,0]
Output: 3

Example 2:
Input: nums = [3,4,-1,1]
Output: 2

Example 3:
Input: nums = [7,8,9,11,12]
Output: 1

Constraints:
1 <= nums.length <= 5 * 105
-231 <= nums[i] <= 231 - 1";
}
