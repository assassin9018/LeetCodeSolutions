namespace LeetCodeTests.SolutionTests.Easy;

public class S3110Tests
{
    [Theory]
    [InlineData("hello", 13)]
    [InlineData("zaz", 50)]
    public void Test(string s, int expected)
    {
        TestReadHelper reader = new([s]);
        TestWriteHelper<int> writer = new();
        S3110 solver = new(reader, writer);
        solver.Run();
        writer.LastValue.Should().Be(expected);
    }
}