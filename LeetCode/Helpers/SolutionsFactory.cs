using System.Reflection;

namespace LeetCode.Helpers;

public class SolutionsFactory
{
    public SolutionsFactory()
    {
    }

    public IEnumerable<IIssueSolution> CreateSolutions()
    {
        return typeof(IIssueSolution).Assembly
            .GetTypes()
            .Where(x => x.IsClass && !x.IsAbstract && x.IsAssignableTo(typeof(IIssueSolution)))
            .Select(Activator.CreateInstance)
            .Cast<IIssueSolution>()
            .OrderBy(x => x.Number);
    }
}