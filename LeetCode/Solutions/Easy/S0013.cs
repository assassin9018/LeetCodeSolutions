using LeetCode.Helpers;

namespace LeetCode.Solutions.Easy;

public class S0013 : SingleResultSolution<int>
{
    public S0013()
    {
    }

    public S0013(IReadHelper reader, IWriteHelper<int> writer) : base(reader, writer)
    {
    }

    public override int Number => 13;

    public override string Name => "Roman to Integer";

    private protected override Func<int> CreateExecutionMethod()
    {
        string s = _reader.ReadStr();
        return () => Parce(s);
    }

    private static int Parce(string s)
    {
        int value = 0;
        Roman last = Roman.None;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            char c = s[i];
            Roman current = CharToRoman(c);
            if (current >= last)
                value += (int)current;
            else
                value -= (int)current;
            last = (Roman)Math.Max((int)last, (int)current);
        }

        return value;
    }

    private static Roman CharToRoman(char symbol)
    {
        return symbol switch
        {
            'I' => Roman.I,
            'V' => Roman.V,
            'X' => Roman.X,
            'L' => Roman.L,
            'C' => Roman.C,
            'D' => Roman.D,
            'M' => Roman.M,
            _ => throw new NotSupportedException(nameof(symbol)),
        };
    }

    public override string Decription =>
@"Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

Symbol       Value
I             1
V             5
X             10
L             50
C             100
D             500
M             1000
For example, 2 is written as II in Roman numeral, just two one's added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.

Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:

I can be placed before V (5) and X (10) to make 4 and 9. 
X can be placed before L (50) and C (100) to make 40 and 90. 
C can be placed before D (500) and M (1000) to make 400 and 900.
Given a roman numeral, convert it to an integer.

 

Example 1:

Input: s = 'III'
Output: 3
Explanation: III = 3.
Example 2:

Input: s = 'LVIII'
Output: 58
Explanation: L = 50, V= 5, III = 3.
Example 3:

Input: s = 'MCMXCIV'
Output: 1994
Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.";
}
