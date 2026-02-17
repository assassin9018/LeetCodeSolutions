using LeetCode.Helpers;

namespace LeetCode.Solutions.Easy;

public class S0412(IReadHelper reader, IWriteHelper<string> writer) : EnumerableResultSolution<string>(reader, writer)
{
    public override int Number => 412;

    public override string Name => "Fizz Buzz";

    private protected override Func<IEnumerable<string>> CreateExecutionMethod()
    {
        int n = _reader.ReadInt();
        return () => FizzBuzz(n);
    }

    public static IList<string> FizzBuzz(int n)
    {
        List<string> list = new(n++);
        for(int i = 1; i < n; i++)
        {
            bool byTree = i % 3 == 0, byFive = i % 5 == 0;
            if(byTree && byFive)
                list.Add("FizzBuzz");
            else if(byTree)
                list.Add("Fizz");
            else if(byFive)
                list.Add("Buzz");
            else
                list.Add(i.ToString());
        }
        return list;
    }

    public override string Description => @"Given an integer n, return a string array answer (1-indexed) where:

answer[i] == 'FizzBuzz' if i is divisible by 3 and 5.
answer[i] == 'Fizz' if i is divisible by 3.
answer[i] == 'Buzz' if i is divisible by 5.
answer[i] == i(as a string) if none of the above conditions are true.

Example 1:

Input: n = 3
Output: ['1','2','Fizz']
    Example 2:

Input: n = 5
Output: ['1','2','Fizz','4','Buzz']
    Example 3:

Input: n = 15
Output: ['1','2','Fizz','4','Buzz','Fizz','7','8','Fizz','Buzz','11','Fizz','13','14','FizzBuzz']

Constraints:

1 <= n <= 104";
}
