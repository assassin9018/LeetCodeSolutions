using LeetCode.Helpers;

namespace LeetCode.Solutions.Easy;

public class S0191(IReadHelper reader, IWriteHelper<int> writer) : SingleResultSolution<int>(reader, writer)
{
    public override int Number => 191;
    public override string Name => "Number of 1 Bits";

    private protected override Func<int> CreateExecutionMethod()
    {
        var n = _reader.ReadInt();

        return () => HammingWeight(n);
    }

    private static int HammingWeight(int n)
    {
        var count = 0;

        while (n > 0)
        {
            count++;
            var p = (int)Math.Log2(n);
            n -= (int)Math.Pow(2, p);
        }

        return count;
    }

    // private static int WithCheating(int n)
    // {
    //     return BitOperations.PopCount((uint)n);
    // }

    public override string Description =>
        """
        Given a positive integer n, write a function that returns the number of set bits in its binary representation (also known as the Hamming weight).

        Example 1:
        Input: n = 11
        Output: 3
        Explanation:
        The input binary string 1011 has a total of three set bits.

        Example 2:
        Input: n = 128
        Output: 1
        Explanation:
        The input binary string 10000000 has a total of one set bit.

        Example 3:
        Input: n = 2147483645
        Output: 30
        Explanation:
        The input binary string 1111111111111111111111111111101 has a total of thirty set bits.

        Constraints:
        1 <= n <= 231 - 1

        Follow up: If this function is called many times, how would you optimize it?
        """;
}