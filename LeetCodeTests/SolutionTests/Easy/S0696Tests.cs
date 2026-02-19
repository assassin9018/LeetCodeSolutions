namespace LeetCodeTests.SolutionTests.Easy;

public class S0696Tests
{
    [Theory]
    [InlineData("00110011", 6)]
    [InlineData("10101", 4)]
    public void Test(string s, int expected)
    {
        TestReadHelper reader = new([s]);
        TestWriteHelper<int> writer = new();
        S0696 solver = new(reader, writer);
        solver.Run();
        writer.LastValue.Should().Be(expected);
    }
}