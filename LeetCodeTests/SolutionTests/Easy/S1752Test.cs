namespace LeetCodeTests.SolutionTests.Easy;

public class S1752Test
{
    [Theory]
    [InlineData("3,4,5,1,2", true)]
    [InlineData("2,1,3,4", false)]
    [InlineData("1,2,3", true)]
    [InlineData("6,10,6", true)]
    [InlineData("10,1,4,5,10", true)]
    public void Test(string nums, bool expected)
    {
        TestReadHelper reader = new([nums]);
        TestWriteHelper<bool> writer = new();
        S1752 solver = new(reader, writer);
        solver.Run();
        writer.LastValue.Should().Be(expected);
    }
}