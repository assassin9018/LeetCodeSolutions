﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions.Easy;
internal class S2160 : IIssueSolution
{
    public int Number => 2160;

    public string Name => "Minimum Sum of Four Digit Number After Splitting Digits";

    public void Run()
    {
        int num = ReadInt("1000 <= num >= 9999");
        Console.WriteLine(minimumSum(num));
    }

    private static int minimumSum(int num)
    {
        int[] arr = num.ToString().Select(x => int.Parse(x.ToString())).Where(x => x != 0).OrderBy(x => x).ToArray();
        int a = arr.Length > 2 ? arr[0] * 10 + arr[^1] : arr[0];
        int b = arr.Length > 1 ? arr[1] : 0;
        if (arr.Length == 4)
            b = b * 10 + arr[2];
        return a + b;
    }

    public string Decription =>
@"You are given a positive integer num consisting of exactly four digits. Split num into two new integers new1 and new2 by using the digits found in num. Leading zeros are allowed in new1 and new2, and all the digits found in num must be used.

For example, given num = 2932, you have the following digits: two 2's, one 9 and one 3. Some of the possible pairs [new1, new2] are [22, 93], [23, 92], [223, 9] and [2, 329].
Return the minimum possible sum of new1 and new2.

 

Example 1:

Input: num = 2932
Output: 52
Explanation: Some possible pairs [new1, new2] are [29, 23], [223, 9], etc.
The minimum sum can be obtained by the pair [29, 23]: 29 + 23 = 52.
Example 2:

Input: num = 4009
Output: 13
Explanation: Some possible pairs [new1, new2] are [0, 49], [490, 0], etc. 
The minimum sum can be obtained by the pair [4, 9]: 4 + 9 = 13.
 

Constraints:

1000 <= num <= 9999";
}