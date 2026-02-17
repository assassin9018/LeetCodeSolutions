using LeetCode.Helpers;

namespace LeetCode.Solutions.Medium;

internal class S0007: SingleResultSolution<int>
{
    public override int Number => 7;
    public override string Name => "Reverse Integer";

    private protected override Func<int> CreateExecutionMethod()
    {
        var value = _reader.ReadInt();

        return () => Reverse(value);
    }

    public int Reverse(int x)
    {
        var result = 0L;

        while (x != 0)
        {
            result = result * 10 + x % 10;
            x /= 10;

            if (result > int.MaxValue || result < int.MinValue)
                return 0;
        }

        return (int)result;
    }

    public override string Description
        =>
        """
        Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.
        Assume the environment does not allow you to store 64-bit integers (signed or unsigned).

        Example 1:
        Input: x = 123
        Output: 321

        Example 2:
        Input: x = -123
        Output: -321

        Example 3:
        Input: x = 120
        Output: 21

        Constraints:
        -231 <= x <= 231 - 1
        """;
}
