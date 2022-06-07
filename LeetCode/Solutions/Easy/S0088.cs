﻿namespace LeetCode.Solutions.Easy;

internal class S0088 : EnumerableResultSolution<int>
{
    public override int Number => 88;

    public override string Name => "Merge Sorted Array";

    private protected override Func<IEnumerable<int>> CreateExecutionMethod()
    {
        var arrT = _reader.ReadArray();
        var arr2 = _reader.ReadArray();
        int[] arr1 = new int[arrT.Length + arr2.Length];

        return () => { Merge(arr1, arrT.Length, arr2, arr2.Length); return arr1; };
    }
        
    private static void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int[] t = nums1.AsSpan(0, m).ToArray();

        int j = 0, k = 0;
        for (int i = 0; i < nums1.Length; i++)
        {
            int next = int.MaxValue;
            if (j < t.Length)
                next = t[j];
            if (k < nums2.Length && nums2[k] <= next)
                next = nums2[k++];
            else
                j++;
            nums1[i] = next;
        }
    }

    public override string Decription => @"You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums2 respectively.
Merge nums1 and nums2 into a single array sorted in non-decreasing order.
The final sorted array should not be returned by the function, but instead be stored inside the array nums1. To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged, and the last n elements are set to 0 and should be ignored. nums2 has a length of n.

Example 1:
Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
Output: [1,2,2,3,5,6]
Explanation: The arrays we are merging are [1,2,3] and [2,5,6].
The result of the merge is [1,2,2,3,5,6] with the underlined elements coming from nums1.

Example 2:
Input: nums1 = [1], m = 1, nums2 = [], n = 0
Output: [1]
Explanation: The arrays we are merging are [1] and [].
The result of the merge is [1].

Example 3:
Input: nums1 = [0], m = 0, nums2 = [1], n = 1
Output: [1]
Explanation: The arrays we are merging are [] and [1].
The result of the merge is [1].
Note that because m = 0, there are no elements in nums1. The 0 is only there to ensure the merge result can fit in nums1.
 
Constraints:
nums1.length == m + n
nums2.length == n
0 <= m, n <= 200
1 <= m + n <= 200
-109 <= nums1[i], nums2[j] <= 109
 
Follow up: Can you come up with an algorithm that runs in O(m + n) time?";
}
