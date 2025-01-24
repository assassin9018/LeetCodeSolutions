namespace LeetCodeTests.SolutionTests.Medium;

public class S0802Test
{
    [Theory]
    [InlineData("[[1,2],[2,3],[5],[0],[5],[],[]]", "2,4,5,6")]
    [InlineData("[[1,2,3,4],[1,2],[3,4],[0,4],[]]", "4")]
    [InlineData("[[],[0,2,3,4],[3],[4],[]]", "0,1,2,3,4")]
    public void Test(string input, string expected)
    {
        TestReadHelper reader = new([input]);
        TestWriteHelper<int> writer = new();
        S0802 solver = new(reader, writer);
        solver.Run();
        var values = writer.LastValues!.ToList();

        values.Should().BeInAscendingOrder();
        values.Should().BeEquivalentTo(expected.Split(',').Select(int.Parse));
    }
}