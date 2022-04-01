namespace LeetCode;

internal interface IIssueSolution
{
    int Number { get; }
    string Name { get; }
    string Decription { get; }
    void Run();
}