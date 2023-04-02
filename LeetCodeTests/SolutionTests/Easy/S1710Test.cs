namespace LeetCodeTests.SolutionTests.Easy;

public class S1710Test
{
    [Theory]
    [InlineData("[[5,10],[2,5],[4,7],[3,9]]", "10", 91)]
    [InlineData("[[1,3],[2,2],[3,1]]", "4", 8)]
    public void Test(string boxTypes, string truckSize, int expected)
    {
        TestReadHelper reader = new(new[] { boxTypes, truckSize });
        TestWriteHelper<int> writer = new();
        S1710 solver = new(reader, writer);
        solver.Run();
        writer.LastValue.Should().Be(expected);
    }
}