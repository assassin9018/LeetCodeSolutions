using LeetCode.DataStructures;

namespace LeetCode
{
    internal class FileReadHelper : IDisposable, IReadHelper
    {
        private readonly StreamReader _streamReader;
        private bool disposedValue;

        public FileReadHelper(string fileName)
        {
            _streamReader = new StreamReader(fileName);
        }

        public int ReadInt(string? message = null)
        {
            return int.Parse(_streamReader.ReadLine()!);
        }

        public double ReadDouble(string? message = null)
        {
            return double.Parse(_streamReader.ReadLine()!);
        }

        public int[][] Read2Array(string? message = null)
        {
            var source = _streamReader.ReadLine()!.Split(new[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
            int[][] array = new int[source.Length][];
            for(int i = 0; i < source.Length; i++)
                array[i] = source[i].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            return array;
        }

        public int[] ReadArray(string? message = null, Func<int[], bool>? _ = null)
        {
            return _streamReader.ReadLine()?.Split(',').Select(x => int.Parse(x)).ToArray() ?? throw new ArgumentNullException(nameof(_streamReader), "End of stream.");
        }

        public ListNode ReadLinkedList(string? message = null)
        {
            var list = ReadArray(message) ?? throw new InvalidOperationException();
            var head = new ListNode(list[0], null);
            var t = head;
            foreach(int item in list.Skip(1))
            {
                t.next = new ListNode(item, null);
                t = t.next;
            }

            return head;
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!disposedValue)
            {
                if(disposing)
                {
                    _streamReader.Dispose();
                }

                disposedValue = true;
            }
        }

        public string ReadStr(string? message = null)
        {
            return _streamReader.ReadLine() ?? string.Empty;
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}