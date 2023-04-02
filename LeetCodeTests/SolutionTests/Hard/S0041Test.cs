namespace LeetCodeTests.SolutionTests.Hard;

public class S0041Test
{
    [Theory]
    [InlineData("0,1,2,3,4,5,6,8", 7)]
    [InlineData("1,2,3,4,5,6,8", 7)]
    [InlineData("-1,-2,-3,-10,1,2,3,4,5,6,8", 7)]
    [InlineData("0,2,3,4,5,6,7,8", 1)]
    [InlineData("6,7,8,9", 1)]
    [InlineData("1,1", 2)]
    [InlineData("1", 2)]
    [InlineData("-1,4,2,1,9,10", 3)]
    public void Test(string input, int expected)
    {
        TestReadHelper reader = new(new[] { input });
        TestWriteHelper<int> writer = new();
        S0041 solver = new(reader, writer);
        solver.Run();
        writer.LastValue.Should().Be(expected);
    }
}