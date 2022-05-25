namespace LeetCode.Solutions.Easy;

internal class S1470 : SolutionBase
{
    public override int Number => 1470;

    public override string Name => "Shuffle the Array";

    public override void Run()
    {
        int[] arr = _reader.ReadArray("Введите массив с чётным количество эллементов", (arr)=> arr.Length % 2 == 0);
        arr = Shuffle(arr, arr.Length / 2);
        Console.WriteLine(string.Join(',', arr.Select(x => x.ToString())));
    }

    public static int[] Shuffle(int[] nums, int n)
    {
        int[] result = new int[n * 2];
        for (int i = 0, j = n; i < n; i++)
        {
            result[i * 2] = nums[i];
            result[i * 2 + 1] = nums[j++];
        }
        return result;
    }

    public override string Decription => @"Given the array nums consisting of 2n elements in the form [x1,x2,...,xn,y1,y2,...,yn].

Return the array in the form [x1,y1,x2,y2,...,xn,yn].

Example 1:

Input: nums = [2,5,1,3,4,7], n = 3
Output: [2,3,5,4,1,7] 
Explanation: Since x1=2, x2=5, x3=1, y1=3, y2=4, y3=7 then the answer is [2,3,5,4,1,7].
Example 2:

Input: nums = [1,2,3,4,4,3,2,1], n = 4
Output: [1,4,2,3,3,2,4,1]
Example 3:

Input: nums = [1,1,2,2], n = 2
Output: [1,2,1,2]

Constraints:

1 <= n <= 500
nums.length == 2n
1 <= nums[i] <= 10^3";
}
