using LeetCode.DataStructures;

namespace LeetCode.Helpers
{
    internal class FileReadHelper : BaseReadHelper, IDisposable, IReadHelper
    {
        private readonly StreamReader _streamReader;
        private bool disposedValue;

        public FileReadHelper(string fileName)
        {
            _streamReader = new StreamReader(fileName);
        }

        protected override string GetStringForParsing()
            => _streamReader.ReadLine() ?? throw new ArgumentNullException(nameof(_streamReader), "End of stream.");

        protected override void PringMessage(string message)
        {
            //not required
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

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}