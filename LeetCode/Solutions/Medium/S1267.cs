using LeetCode.Helpers;

namespace LeetCode.Solutions.Medium;

public class S1267(IReadHelper reader, IWriteHelper<int> writer) : SingleResultSolution<int>(reader, writer)
{
    public override int Number => 1267;
    public override string Name => "Count Servers that Communicate";

    private protected override Func<int> CreateExecutionMethod()
    {
        var communicationMatrix = _reader.Read2Array("Введите матрицу расположения серверов");

        return () => CountServers(communicationMatrix);
    }

    private static int CountServers(int[][] grid)
    {
        var r = new int[grid.Length];
        var c = new int[grid[0].Length];

        for (int rowIndex = 0; rowIndex < grid.Length; rowIndex++)
        {
            var row = grid[rowIndex];
            for (int colIndex = 0; colIndex < row.Length; colIndex++)
            {
                var cell = row[colIndex];
                r[rowIndex] += cell;
                c[colIndex] += cell;
            }
        }

        var count = 0;

        for (int rowIndex = 0; rowIndex < grid.Length; rowIndex++)
        {
            var row = grid[rowIndex];
            for (int colIndex = 0; colIndex < row.Length; colIndex++)
            {
                var cell = row[colIndex];
                if (cell > 0 && (r[rowIndex] > 1 || c[colIndex] > 1))
                {
                    count++;
                }
            }
        }

        return count;
    }

    public override string Decription
        => """
        You are given a map of a server center, represented as a m * n integer matrix grid, where 1 means that on that cell there is a server and 0 means that it is no server. 
        Two servers are said to communicate if they are on the same row or on the same column.
        Return the number of servers that communicate with any other server.

        Example 1:
        Input: grid = [[1,0],[0,1]]
        Output: 0
        Explanation: No servers can communicate with others.
        
        Example 2:
        Input: grid = [[1,0],[1,1]]
        Output: 3
        Explanation: All three servers can communicate with at least one other server.

        Example 3:
        Input: grid = [[1,1,0,0],[0,0,1,0],[0,0,1,0],[0,0,0,1]]
        Output: 4
        Explanation: The two servers in the first row can communicate with each other. The two servers in the third column can communicate with each other. 
        The server at right bottom corner can't communicate with any other server.

        Constraints:
        m == grid.length
        n == grid[i].length
        1 <= m <= 250
        1 <= n <= 250
        grid[i][j] == 0 or 1
        """;
}
