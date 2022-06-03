namespace LeetCode.Solutions.Medium;

public class S0050 : SingleResultSolution<double>
{
    public override int Number => 50;

    public override string Name => "Pow(x, n)";

    private protected override Func<double> CreateExecutionMethod()
    {
        double x = _reader.ReadDouble();
        int n = _reader.ReadInt();
        return () => MyPow(x, n);
    }
    private static double MyPow(double x, int n)
    {
        double value = Math.Abs(x);
        double sign = (n & 1) == 0 ? 1 : Math.Sign(x);
        double result = Math.Exp(n * Math.Log(value));

        return result * sign;
    }

    public override string Decription =>
@"Implement pow(x, n), which calculates x raised to the power n (i.e., xn).

Example 1:

Input: x = 2.00000, n = 10
Output: 1024.00000
Example 2:

Input: x = 2.10000, n = 3
Output: 9.26100
Example 3:

Input: x = 2.00000, n = -2
Output: 0.25000
Explanation: 2-2 = 1/22 = 1/4 = 0.25
 

Constraints:

-100.0 < x < 100.0
-2^31 <= n <= 2^31-1
-10^4 <= xn <= 10^4";
}
