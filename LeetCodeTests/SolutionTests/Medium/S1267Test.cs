namespace LeetCodeTests.SolutionTests.Medium;

public class S1267Test
{
    [Theory]
    [InlineData("[[1,0],[0,1]]", 0)]
    [InlineData("[[1,0],[1,1]]", 3)]
    [InlineData("[[1,1,0,0],[0,0,1,0],[0,0,1,0],[0,0,0,1]]", 4)]
    public void Test(string matrix, int expected)
    {
        TestReadHelper reader = new([matrix]);
        TestWriteHelper<int> writer = new();
        S1267 solver = new(reader, writer);
        solver.Run();
        writer.LastValue.Should().Be(expected);
    }
}