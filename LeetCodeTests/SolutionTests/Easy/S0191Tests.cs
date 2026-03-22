namespace LeetCodeTests.SolutionTests.Easy;

public class S0191Tests
{
    [Theory]
    [InlineData("11", 3)]
    [InlineData("128", 1)]
    [InlineData("2147483645", 30)]
    public void Test(string s, int expected)
    {
        TestReadHelper reader = new([s]);
        TestWriteHelper<int> writer = new();
        S0191 solver = new(reader, writer);
        solver.Run();
        writer.LastValue.Should().Be(expected);
    }
}