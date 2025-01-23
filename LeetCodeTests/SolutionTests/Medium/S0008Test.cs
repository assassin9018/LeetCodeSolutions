namespace LeetCodeTests.SolutionTests.Medium;

public class S0008Test
{
    [Theory]
    [InlineData("42", 42)]
    [InlineData(" -042", -42)]
    [InlineData("1337c0d3", 1337)]
    [InlineData("0-1", 0)]
    [InlineData("words and 987", 0)]
    [InlineData("2147483648", int.MaxValue)]
    [InlineData("21474836470", int.MaxValue)]
    [InlineData("-2147483649", int.MinValue)]
    [InlineData("-21474836480", int.MinValue)]
    public void Test(string input, int expected)
    {
        TestReadHelper reader = new([input]);
        TestWriteHelper<int> writer = new();
        S0008 solver = new(reader, writer);
        solver.Run();
        writer.LastValue.Should().Be(expected);
    }
}