namespace LeetCodeTests.SolutionTests.Easy;

public class S2798Tests
{
    [Theory]
    [InlineData("0,1,2,3,4", "2", 3)]
    [InlineData("5,1,4,2,2", "6", 0)]
    public void Test(string hours, string target, int expected)
    {
        TestReadHelper reader = new([hours, target]);
        TestWriteHelper<int> writer = new();
        S2798 solver = new(reader, writer);
        solver.Run();
        writer.LastValue.Should().Be(expected);
    }
}