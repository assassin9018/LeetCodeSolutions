namespace LeetCodeTests.SolutionTests.Hard;

public class S0273Test
{
    [Theory]
    [InlineData("123", "One Hundred Twenty Three")]
    [InlineData("100", "One Hundred")]
    [InlineData("12345", "Twelve Thousand Three Hundred Forty Five")]
    [InlineData("1234567", "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven")]
    [InlineData("2147483647", "Two Billion One Hundred Forty Seven Million Four Hundred Eighty Three Thousand Six Hundred Forty Seven")]
    public void Test(string input, string expected)
    {
        TestReadHelper reader = new(new[] { input });
        TestWriteHelper<string> writer = new();
        S0273 solver = new(reader, writer);
        solver.Run();
        writer.LastValue.Should().Be(expected);
    }
}