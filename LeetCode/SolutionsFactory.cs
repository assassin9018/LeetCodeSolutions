using System.Reflection;

namespace LeetCode;

public class SolutionsFactory
{
    public SolutionsFactory()
    {
    }

    public IEnumerable<IIssueSolution> CreateSolutions()
    {
        return Assembly
            .GetAssembly(typeof(SolutionsFactory))
            !.GetTypes()
            .Where(x => x.IsClass && x.GetInterface(nameof(IIssueSolution)) != null)
            .Select(x => x.GetConstructor(Type.EmptyTypes)?.Invoke(Array.Empty<object>()))
            .Where(x => x != null)
            .Cast<IIssueSolution>()
            .OrderBy(x => x.Number);
    }
}