namespace LeetCode.Solutions.Medium;

public class S0969 : EnumerableResultSolution<int>
{
    public override int Number => 969;

    public override string Name => "Pancake Sorting";

    private protected override Func<IEnumerable<int>> CreateExecutionMethod()
    {
        int[] arr = _reader.ReadArray();
        return () => PancakeSort(arr);
    }

    public static IList<int> PancakeSort(int[] arr)
    {
        List<int> kRange = new();
        Span<int> arrPart = arr.AsSpan();

        while (!IsSorted(arrPart))
        {
            int maxIndex = 0;
            for (int i = 1; i < arrPart.Length; i++)
                if (arrPart[i] >= arrPart[maxIndex])
                    maxIndex = i;
            if (maxIndex < arrPart.Length)
            {
                if (maxIndex != 0)
                {
                    kRange.Add(maxIndex + 1);
                    arrPart[..(maxIndex + 1)].Reverse();
                }
                arrPart.Reverse();
                kRange.Add(arrPart.Length);
            }
            arrPart = arrPart[..^1];
        }

        return kRange;
    }

    public static bool IsSorted(Span<int> ints)
    {
        if (ints.Length == 0)
            return true;

        bool sorted = true;
        int prev = ints[0];
        for (int i = 1; i < ints.Length; i++)
        {
            sorted &= ints[i] >= prev;
            prev = ints[i];
        }

        return sorted;
    }

    public override string Description => @"Given an array of integers arr, sort the array by performing a series of pancake flips.

In one pancake flip we do the following steps:
Choose an integer k where 1 <= k <= arr.length.
Reverse the sub-array arr[0...k-1] (0-indexed).
For example, if arr = [3,2,1,4] and we performed a pancake flip choosing k = 3, we reverse the sub-array [3,2,1], so arr = [1,2,3,4] after the pancake flip at k = 3.
Return an array of the k-values corresponding to a sequence of pancake flips that sort arr. Any valid answer that sorts the array within 10 * arr.length flips will be judged as correct.

Example 1:
Input: arr = [3,2,4,1]
Output: [4,2,4,3]
Explanation: 
We perform 4 pancake flips, with k values 4, 2, 4, and 3.
Starting state: arr = [3, 2, 4, 1]
After 1st flip (k = 4): arr = [1, 4, 2, 3]
After 2nd flip (k = 2): arr = [4, 1, 2, 3]
After 3rd flip (k = 4): arr = [3, 2, 1, 4]
After 4th flip (k = 3): arr = [1, 2, 3, 4], which is sorted.

Example 2:
Input: arr = [1,2,3]
Output: []
Explanation: The input is already sorted, so there is no need to flip anything.
Note that other answers, such as [3, 3], would also be accepted.

Constraints:
1 <= arr.length <= 100
1 <= arr[i] <= arr.length
All integers in arr are unique (i.e. arr is a permutation of the integers from 1 to arr.length).";
}