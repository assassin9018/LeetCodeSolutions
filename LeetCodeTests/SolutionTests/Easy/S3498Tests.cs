namespace LeetCodeTests.SolutionTests.Easy;

public class S3498Tests
{
    [Theory]
    [InlineData("abc", 148)]
    [InlineData("zaza", 160)]
    public void Test(string s, int expected)
    {
        TestReadHelper reader = new([s]);
        TestWriteHelper<int> writer = new();
        S3498 solver = new(reader, writer);
        solver.Run();
        writer.LastValue.Should().Be(expected);
    }
}