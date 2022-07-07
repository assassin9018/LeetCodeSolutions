using LeetCode.Solutions.Easy;
using LeetCodeTests.Helpers;

namespace LeetCodeTests.SolutionTests.Easy;

[TestClass]
public class S1710Test
{
    [TestMethod]
    [DataRow("[[5,10],[2,5],[4,7],[3,9]]", "10", 91)]
    [DataRow("[[1,3],[2,2],[3,1]]", "4", 8)]
    public void TestMethod1(string boxTypes, string truckSize, int expected)
    {
        TestReadHelper reader = new(new[] { boxTypes, truckSize });
        TestWriteHelper<int> writer = new();
        S1710 solver = new(reader, writer);
        solver.Run();
        Assert.AreEqual(expected, writer.LastValue);
    }
}