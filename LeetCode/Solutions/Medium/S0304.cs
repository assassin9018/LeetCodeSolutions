using LeetCode.Helpers;

namespace LeetCode.Solutions.Medium;
internal class S0304(IReadHelper reader, IWriteHelper<int> writer) : SingleResultSolution<int>(reader, writer)
{
    public override int Number => 304;

    public override string Name => "Range Sum Query 2D - Immutable";

    private protected override Func<int> CreateExecutionMethod()
    {
        int[][] matrix = _reader.Read2Array();
        int row1 = _reader.ReadInt("row1");
        int col1 = _reader.ReadInt("col1");
        int row2 = _reader.ReadInt("row2");
        int col2 = _reader.ReadInt("col2");

        return () => new NumMatrix(matrix).SumRegion(row1, col1, row2, col2);
    }

    //optimized for one initialize and mulitiple invoke sum method
    private class NumMatrix
    {
        private readonly int[][] sumCache;

        public NumMatrix(int[][] matrix)
        {
            sumCache = new int[matrix.Length + 1][];
            int rowLen = matrix[0].Length + 1;
            for (int i = 0; i < sumCache.Length; i++)
                sumCache[i] = new int[rowLen];

            for (int i = 1; i < sumCache.Length; i++)
                for (int j = 1; j < sumCache[i].Length; j++)
                    sumCache[i][j] = sumCache[i - 1][j] + sumCache[i][j - 1] - sumCache[i - 1][j - 1] + matrix[i - 1][j - 1];
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            int x2 = row2 + 1;
            int y2 = col2 + 1;
            return sumCache[x2][y2] + sumCache[row1][col1] - sumCache[row1][y2] - sumCache[x2][col1];
        }
        /**
        * Your NumMatrix object will be instantiated and called as such:
        * NumMatrix obj = new NumMatrix(matrix);
        * int param_1 = obj.SumRegion(row1,col1,row2,col2);
        */
        /* We will cache result of sum from top left corner to current cell
         * 1 2 3            1  3  6
         * 4 5 6    =>      5  12 21
         * 7 8 9            12 27 45
         * Then we can take value at cell row2\col2(sum of all cell at source squere beetween 0,0 and row2\col2) minus upper row and left column,
         * plus top left squere(0,0,row1,col1)
         */
    }

    public override string Description => @"Given a 2D matrix matrix, handle multiple queries of the following type:

Calculate the sum of the elements of matrix inside the rectangle defined by its upper left corner (row1, col1) and lower right corner (row2, col2).
Implement the NumMatrix class:
NumMatrix(int[][] matrix) Initializes the object with the integer matrix matrix.
int sumRegion(int row1, int col1, int row2, int col2) Returns the sum of the elements of matrix inside the rectangle defined by its upper left corner (row1, col1) and lower right corner (row2, col2).

Example 1:
Input
['NumMatrix', 'sumRegion', 'sumRegion', 'sumRegion']
[[[[3, 0, 1, 4, 2], [5, 6, 3, 2, 1], [1, 2, 0, 1, 5], [4, 1, 0, 1, 7], [1, 0, 3, 0, 5]]], [2, 1, 4, 3], [1, 1, 2, 2], [1, 2, 2, 4]]
Output
[null, 8, 11, 12]

Explanation
NumMatrix numMatrix = new NumMatrix([[3, 0, 1, 4, 2], [5, 6, 3, 2, 1], [1, 2, 0, 1, 5], [4, 1, 0, 1, 7], [1, 0, 3, 0, 5]]);
    numMatrix.sumRegion(2, 1, 4, 3); // return 8 (i.e sum of the red rectangle)
numMatrix.sumRegion(1, 1, 2, 2); // return 11 (i.e sum of the green rectangle)
numMatrix.sumRegion(1, 2, 2, 4); // return 12 (i.e sum of the blue rectangle)
 
Constraints:
m == matrix.length
n == matrix[i].length
1 <= m, n <= 200
-105 <= matrix[i][j] <= 105
-109 <= sum(matrix[i][j]) <= 109
0 <= row1 <= row2<m
0 <= col1 <= col2<n
At most 104 calls will be made to sumRegion.";
}
