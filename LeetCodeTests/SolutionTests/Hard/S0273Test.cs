using LeetCode.Solutions.Hard;
using LeetCodeTests.Helpers;

namespace LeetCodeTests.SolutionTests.Hard;

[TestClass]
public class S0273Test
{
    [TestMethod]
    [DataRow("123", "One Hundred Twenty Three")]
    [DataRow("100", "One Hundred")]
    [DataRow("12345", "Twelve Thousand Three Hundred Forty Five")]
    [DataRow("1234567", "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven")]
    [DataRow("2147483647", "Two Billion One Hundred Forty Seven Million Four Hundred Eighty Three Thousand Six Hundred Forty Seven")]
    public void Test(string input, string expected)
    {
        TestReadHelper reader = new(new[] { input });
        TestWriteHelper<string> writer = new();
        S0273 solver = new(reader, writer);
        solver.Run();
        Assert.AreEqual(expected, writer.LastValue);
    }
}