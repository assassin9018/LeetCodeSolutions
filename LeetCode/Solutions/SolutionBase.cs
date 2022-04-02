namespace LeetCode.Solutions
{
    public abstract class SolutionBase : IIssueSolution
    {
        protected internal readonly IReadHelper _reader;

        public abstract int Number { get; }
        public abstract string Name { get; }
        public abstract string Decription { get; }

        protected SolutionBase()
        {
            _reader = new ConsoleReadHelper();
        }

        protected SolutionBase(IReadHelper reader)
        {
            _reader = reader;
        }

        public abstract void Run();
    }
}
