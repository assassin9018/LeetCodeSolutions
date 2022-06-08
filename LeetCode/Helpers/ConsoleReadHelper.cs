namespace LeetCode.Helpers;

internal class ConsoleReadHelper : BaseReadHelper
{
    public ConsoleReadHelper()
    {
        ApplyFilters = true;
    }

    protected override string GetStringForParsing()
        => Console.ReadLine()!;

    protected override void PringMessage(string message)
        => Console.WriteLine(message);
}