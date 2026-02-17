using System.Diagnostics.CodeAnalysis;
using System.Text;
using LeetCode.Helpers;

namespace LeetCode.Solutions.Hard;

public class S0273(IReadHelper reader, IWriteHelper<string> writer) : SingleResultSolution<string>(reader, writer)
{
    public override int Number => 273;
    public override string Name => "Integer to English Words";


    private protected override Func<string> CreateExecutionMethod()
    {
        var value = _reader.ReadInt();

        return () => NumberToWords(value);
    }

    private static string NumberToWords(int num)
    {
        if (num.TryGetWord(out var digit))
            return digit;

        var sb = new StringBuilder(128);

        if (num > 999_999_999)
        {
            var xyz = num / 1_000_000_000;
            sb.AppendWords(xyz).AppendSuffix(1_000_000_000).Append(' ');
            num %= 1_000_000_000;
        }

        if (num > 999_999)
        {
            var xyz = num / 1_000_000;
            sb.AppendWords(xyz).AppendSuffix(1_000_000).Append(' ');
            num %= 1_000_000;
        }

        if (num > 999)
        {
            var xyz = num / 1_000;
            sb.AppendWords(xyz).AppendSuffix(1_000).Append(' ');
            num %= 1_000;
        }

        if (num > 0)
            sb.AppendWords(num);

        if (sb[^1] == ' ')
            sb.Remove(sb.Length - 1, 1);
        return sb.ToString();
    }

    public override string Description =>
        @"Convert a non-negative integer num to its English words representation.
Example 1:
Input: num = 123
Output: 'One Hundred Twenty Three'
Example 2:
Input: num = 12345
Output: 'Twelve Thousand Three Hundred Forty Five''
Example 3:
Input: num = 1234567
Output: 'One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven'
Constraints:
0 <= num <= 231 - 1";
}

public static class DigitExtensions
{
    public static StringBuilder AppendWords(this StringBuilder sb, int num)
    {
        //147 => XYZ => X = 1, Y = 4, Z = 7, YZ = 47
        int x = num / 100, yz = num % 100, y = yz / 10, z = yz % 10;
        if (x > 0)
            sb.Append(x.ToWord()).Append(' ').AppendSuffix(100).Append(' ');

        if (yz > 0 && _wordByDigit.TryGetValue(yz, out var str))
            sb.Append(str).Append(' ');
        else
        {
            if (y > 0)
                sb.Append((y * 10).ToWord()).Append(' ');
            if (z > 0)
                sb.Append(z.ToWord()).Append(' ');
        }

        return sb;
    }

    public static StringBuilder AppendSuffix(this StringBuilder sb, int num)
        => num switch
        {
            100 => sb.Append("Hundred"),
            1_000 => sb.Append("Thousand"),
            1_000_000 => sb.Append("Million"),
            1_000_000_000 => sb.Append("Billion"),
            _ => throw new NotSupportedException()
        };

    public static bool TryGetWord(this int val, [MaybeNullWhen(false)] out string word)
        => _wordByDigit.TryGetValue(val, out word);

    public static string ToWord(this int v) => _wordByDigit[v];

    private static Dictionary<int, string> _wordByDigit = new()
    {
        { 0, "Zero" },
        { 1, "One" },
        { 2, "Two" },
        { 3, "Three" },
        { 4, "Four" },
        { 5, "Five" },
        { 6, "Six" },
        { 7, "Seven" },
        { 8, "Eight" },
        { 9, "Nine" },
        { 10, "Ten" },
        { 11, "Eleven" },
        { 12, "Twelve" },
        { 13, "Thirteen" },
        { 14, "Fourteen" },
        { 15, "Fifteen" },
        { 16, "Sixteen" },
        { 17, "Seventeen" },
        { 18, "Eighteen" },
        { 19, "Nineteen" },
        { 20, "Twenty" },
        { 30, "Thirty" },
        { 40, "Forty" },
        { 50, "Fifty" },
        { 60, "Sixty" },
        { 70, "Seventy" },
        { 80, "Eighty" },
        { 90, "Ninety" }
    };
}