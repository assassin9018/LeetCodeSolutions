namespace LeetCodeTests.SolutionTests.Medium;

public class S0012Test
{
    [Theory]
    [InlineData("3", "III")]
    [InlineData("58", "LVIII")]
    [InlineData("1994", "MCMXCIV")]
    public void IntToRomanTest(string input, string expected)
    {
        TestReadHelper reader = new(new[] { input });
        TestWriteHelper<string> writer = new();
        S0012 solver = new(reader, writer);
        solver.Run();
        writer.LastValue.Should().Be(expected);
    }
}
