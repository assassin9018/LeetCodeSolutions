namespace LeetCodeTests.SolutionTests.Medium;

public class S2300Test
{
    [Theory]
    [InlineData("5,1,3", "1,2,3,4,5", "7", new[] { 4, 0, 3 })]
    [InlineData("3,1,2", "8,5,8", "16", new[] { 2, 0, 2 })]
    [InlineData("1000,1000,1000", "1000,1000,1000", "1000000", new[] { 3, 3, 3 })]
    public void Test(string spells, string potions, string success, int[] expected)
    {
        TestReadHelper reader = new(new[] { spells, potions, success });
        TestWriteHelper<int> writer = new();
        S2300 solver = new(reader, writer);
        solver.Run();
        writer.LastValues.Should().BeEquivalentTo(expected);
    }
}