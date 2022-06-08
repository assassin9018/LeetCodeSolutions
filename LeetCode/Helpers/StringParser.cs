namespace LeetCode.Helpers;

public class StringParser
{
    private protected static int[][] Parce2IntArrayStr(string str)
    {
        var source = str.Split(new[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
        List<int[]> result = new();
        for (int i = 0; i < source.Length; i += 2)
            result.Add(source[i].Trim().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x.Trim())).ToArray());

        return result.ToArray();
    }

    private protected static int[] ParceIntArrayStr(string str)
        => str.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x.Trim())).ToArray();
}
