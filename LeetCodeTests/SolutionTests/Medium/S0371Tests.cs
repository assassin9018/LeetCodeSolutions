namespace LeetCodeTests.SolutionTests.Medium;

public class S0371Tests
{
    [Theory]
    [InlineData("-1", "1", 0)]
    [InlineData("1", "2", 3)]
    [InlineData("2", "3", 5)]
    [InlineData("999", "999", 1998)]
    public void Test(string a, string b, int expected)
    {
        TestReadHelper reader = new([a, b]);
        TestWriteHelper<int> writer = new();
        S0371 solver = new(reader, writer);
        solver.Run();
        writer.LastValue.Should().Be(expected);
    }
}