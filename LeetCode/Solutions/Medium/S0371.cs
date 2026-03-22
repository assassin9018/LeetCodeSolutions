using LeetCode.Helpers;

namespace LeetCode.Solutions.Medium;

internal sealed class S0371(IReadHelper reader, IWriteHelper<int> writer) : SingleResultSolution<int>(reader, writer)
{
    public override int Number => 371;
    public override string Name => "Sum of Two Integers";

    private protected override Func<int> CreateExecutionMethod()
    {
        var a = _reader.ReadInt();
        var b = _reader.ReadInt();

        return () => GetSum(a, b);
    }

    private static int GetSum(int a, int b)
    {
        // stolen solution
        while (b != 0) {
            var carry = a & b;   // bits to carry over
            var sum = a ^ b;     // bits without carry
            a = sum;
            b = carry << 1;      // shift carry to add in next place
        }
        return a;
    }

    public override string Description =>
        """
        Given two integers a and b, return the sum of the two integers without using the operators + and -.

        Example 1:
        Input: a = 1, b = 2
        Output: 3

        Example 2:
        Input: a = 2, b = 3
        Output: 5
         

        Constraints:
        -1000 <= a, b <= 1000
        """;
}