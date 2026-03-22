namespace LeetCodeTests.SolutionTests.Medium;

public class S0003Tests
{
    [Theory]
    [InlineData("abcabcbb", 3)]
    [InlineData("bbbbb", 1)]
    [InlineData("pwwkew", 3)]
    [InlineData("aab", 2)]
    public void Test(string s, int expected)
    {
        TestReadHelper reader = new([s]);
        TestWriteHelper<int> writer = new();
        S0003 solver = new(reader, writer);
        solver.Run();
        writer.LastValue.Should().Be(expected);
    }
}