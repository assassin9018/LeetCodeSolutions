namespace LeetCode
{
    internal static class WriteHelper
    {
        public static void Write<T>(T[] arr) where T : struct
            => Console.WriteLine(String.Join(' ', arr.Select(x => x.ToString())));
    }
}
