namespace LeetCodeTests.SolutionTests.Easy;

public class S3151Test
{
    [Theory]
    [InlineData("1", true)]
    [InlineData("2,1,4", true)]
    [InlineData("4,3,1,6", false)]
    public void Test(string nums, bool expected)
    {
        TestReadHelper reader = new([nums]);
        TestWriteHelper<bool> writer = new();
        S3151 solver = new(reader, writer);
        solver.Run();
        writer.LastValue.Should().Be(expected);
    }
}
