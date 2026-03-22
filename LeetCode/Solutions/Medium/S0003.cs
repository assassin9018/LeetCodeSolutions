using LeetCode.Helpers;

namespace LeetCode.Solutions.Medium;

internal sealed class S0003(IReadHelper reader, IWriteHelper<int> writer) : SingleResultSolution<int>(reader, writer)
{
    public override int Number => 3;
    public override string Name => "Longest Substring Without Repeating Characters";

    private protected override Func<int> CreateExecutionMethod()
    {
        var str = _reader.ReadStr();
        return () => LengthOfLongestSubstring(str);
    }

    private static int LengthOfLongestSubstring(string s)
    {
        var hashSet = new HashSet<char>(s.Length);
        int offset = 0, maxUniqueLength = 0, currentLength = 0;

        for (var i = 0; i < s.Length; i++)
        {
            if (hashSet.Add(s[i]))
            {
                currentLength++;
                maxUniqueLength = Math.Max(maxUniqueLength, currentLength);
            }
            else
            {
                currentLength = 0;
                hashSet.Clear();
                i = s.IndexOf(s[i], offset);
                offset = i + 1;
            }
        }

        return maxUniqueLength;
    }

    public override string Description =>
        """
        Given a string s, find the length of the longest substring without duplicate characters.

        Example 1:
        Input: s = "abcabcbb"
        Output: 3
        Explanation: The answer is "abc", with the length of 3. Note that "bca" and "cab" are also correct answers.

        Example 2:
        Input: s = "bbbbb"
        Output: 1
        Explanation: The answer is "b", with the length of 1.

        Example 3:
        Input: s = "pwwkew"
        Output: 3
        Explanation: The answer is "wke", with the length of 3.
        Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
         

        Constraints:
        0 <= s.length <= 5 * 104
        s consists of English letters, digits, symbols and spaces.
        """;
}