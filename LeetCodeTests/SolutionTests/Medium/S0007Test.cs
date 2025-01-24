namespace LeetCodeTests.SolutionTests.Medium;

public class S0007Test
{
    [Theory]
    [InlineData("123", 321)]
    [InlineData("-123", -321)]
    [InlineData("120", 21)]
    [InlineData("1534236469", 0)]
    [InlineData("-1534236469", 0)]
    [InlineData("-2147483648", 0)]
    public void Test(string value, int expected)
    {
        TestReadHelper reader = new([value]);
        TestWriteHelper<int> writer = new();
        S0007 solver = new(reader, writer);
        solver.Run();
        writer.LastValue.Should().Be(expected);
    }
}