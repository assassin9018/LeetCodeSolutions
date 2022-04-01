namespace LeetCode.Solutions.Easy;

internal class S0383 : IIssueSolution
{
    public int Number => 383;

    public string Name => "Ransom Note";

    public void Run()
    {
        string ransomNote = Console.ReadLine() ?? throw new ArgumentNullException();
        string magazine = Console.ReadLine() ?? throw new ArgumentNullException();
        Console.WriteLine(CanConstruct(ransomNote, magazine));
    }

    public bool CanConstruct(string ransomNote, string magazine)
    {
        var dick = GroupBy(magazine).ToDictionary(k => k.symbol, v => v.count);
        return GroupBy(ransomNote).All(x => dick.TryGetValue(x.symbol, out int mCount) && mCount >= x.count);
    }

    private static IEnumerable<(char symbol, int count)> GroupBy(string s)
        => s.GroupBy(k => k).Select(x => (x.Key, x.Count()));

    public string Decription =>
@"Given two strings ransomNote and magazine, return true if ransomNote can be constructed from magazine and false otherwise.

Each letter in magazine can only be used once in ransomNote.

Example 1:

Input: ransomNote = 'a', magazine = 'b'
Output: false
Example 2:

Input: ransomNote = 'aa', magazine = 'ab'
Output: false
Example 3:

Input: ransomNote = 'aa', magazine = 'aab'
Output: true
 

Constraints:

1 <= ransomNote.length, magazine.length <= 105
ransomNote and magazine consist of lowercase English letters.";
}
