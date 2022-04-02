namespace LeetCode.Solutions.Easy;
public class S1337 : SolutionBase
{
    public override int Number => 1337;

    public override string Name => "The K Weakest Rows in a Matrix";

    public override void Run()
    {
        var mat = _reader.Read2Array();
        int k = _reader.ReadInt();
        Console.WriteLine(KWeakestRows(mat, k));
    }

    private static int[] KWeakestRows(int[][] mat, int k)
    {
        return Enumerable
           .Range(0, mat.Length)
           .Select(i => (i, mat[i].Sum()))
           .OrderBy(x => x.Item2)
           .ThenBy(x => x.i)
           .Take(k)
           .Select(x => x.i)
           .ToArray();
    }

    public override string Decription =>
@"You are given an m x n binary matrix mat of 1's (representing soldiers) and 0's (representing civilians). The soldiers are positioned in front of the civilians. That is, all the 1's will appear to the left of all the 0's in each row.

A row i is weaker than a row j if one of the following is true:

The number of soldiers in row i is less than the number of soldiers in row j.
Both rows have the same number of soldiers and i < j.
Return the indices of the k weakest rows in the matrix ordered from weakest to strongest.

Example 1:

Input: mat = 
[[1,1,0,0,0],
 [1,1,1,1,0],
 [1,0,0,0,0],
 [1,1,0,0,0],
 [1,1,1,1,1]], 
k = 3
Output: [2,0,3]
Explanation: 
The number of soldiers in each row is: 
- Row 0: 2 
- Row 1: 4 
- Row 2: 1 
- Row 3: 2 
- Row 4: 5 
The rows ordered from weakest to strongest are [2,0,3,1,4].
Example 2:

Input: mat = 
[[1,0,0,0],
 [1,1,1,1],
 [1,0,0,0],
 [1,0,0,0]], 
k = 2
Output: [0,2]
Explanation: 
The number of soldiers in each row is: 
- Row 0: 1 
- Row 1: 4 
- Row 2: 1 
- Row 3: 1 
The rows ordered from weakest to strongest are [0,2,3,1].";
}
