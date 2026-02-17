namespace LeetCode;

public interface IIssueSolution
{
    int Number { get; }
    string Name { get; }
    string Description { get; }
    void Run();
}