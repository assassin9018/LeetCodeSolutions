namespace LeetCode.Helpers;

public class StringParser
{
    private protected int[][] Parce2IntArrayStr(string str)
    {
        var source = str.Split(new[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
        List<int[]> result = new();
        for (int i = 0; i < source.Length; i += 2)
            result.Add(source[i].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray());

        return result.ToArray();
    }

    private protected int[] ParceIntArrayStr(string str)
        => str.Split(',').Select(x => int.Parse(x)).ToArray();
}
