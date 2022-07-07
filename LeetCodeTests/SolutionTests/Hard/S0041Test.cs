using LeetCode.Solutions.Hard;
using LeetCodeTests.Helpers;

namespace LeetCodeTests.SolutionTests.Hard;

[TestClass]
public class S0041Test
{
    [TestMethod]
    [DataRow("0,1,2,3,4,5,6,8", 7)]
    [DataRow("1,2,3,4,5,6,8", 7)]
    [DataRow("-1,-2,-3,-10,1,2,3,4,5,6,8", 7)]
    [DataRow("0,2,3,4,5,6,7,8", 1)]
    [DataRow("6,7,8,9", 1)]
    [DataRow("1,1", 2)]
    [DataRow("1", 2)]
    [DataRow("-1,4,2,1,9,10", 3)]
    public void TestMethod1(string input, int expected)
    {
        TestReadHelper reader = new(new[] { input });
        TestWriteHelper<int> writer = new();
        S0041 solver = new(reader, writer);
        solver.Run();
        Assert.AreEqual(expected, writer.LastValue);
    }
}
