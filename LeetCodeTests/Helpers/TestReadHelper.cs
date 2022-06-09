using LeetCode.Helpers;

namespace LeetCodeTests.Helpers;

internal class TestReadHelper : BaseReadHelper
{
    private readonly string[] _valuesForTest;
    private int _iterator;

    public TestReadHelper(string[] valuesForTest)
    {
        _valuesForTest = valuesForTest;
    }

    protected override string GetStringForParsing()
        => _valuesForTest[_iterator++];

    protected override void PringMessage(string message)
    {
    }
}
