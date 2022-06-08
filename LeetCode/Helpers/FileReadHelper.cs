using LeetCode.DataStructures;

namespace LeetCode.Helpers
{
    internal class FileReadHelper : StringParser, IDisposable, IReadHelper
    {
        private readonly StreamReader _streamReader;
        private bool disposedValue;

        public FileReadHelper(string fileName)
        {
            _streamReader = new StreamReader(fileName);
        }

        public int ReadInt(string? message = null) 
            => int.Parse(ReadStr());

        public double ReadDouble(string? message = null) 
            => double.Parse(ReadStr());

        public int[][] Read2Array(string? message = null) 
            => Parce2IntArrayStr(ReadStr(message));

        public int[] ReadArray(string? message = null, Func<int[], bool>? _ = null) 
            => ParceIntArrayStr(ReadStr(message));

        public ListNode ReadLinkedList(string? message = null)
        {
            var list = ReadArray(message) ?? throw new InvalidOperationException();
            var head = new ListNode(list[0], null);
            var t = head;
            foreach (int item in list.Skip(1))
            {
                t.next = new ListNode(item, null);
                t = t.next;
            }

            return head;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _streamReader.Dispose();
                }

                disposedValue = true;
            }
        }

        public string ReadStr(string? message = null) 
            => _streamReader.ReadLine() ?? throw new ArgumentNullException(nameof(_streamReader), "End of stream.");

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}