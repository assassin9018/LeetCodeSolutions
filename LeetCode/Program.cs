using LeetCode.Helpers;

namespace LeetCode;

public class Program
{
    private static readonly Dictionary<int, IIssueSolution> _solutions = new SolutionsFactory().CreateSolutions().ToDictionary(x => x.Number);

    public static void Main(string[] args)
    {
        Console.WriteLine("Select task number or enter -list for show all task numbers.");
        while (true)
        {
            string? command = Console.ReadLine();
            if (command is null)
                continue;
            if (command.Equals("-list", StringComparison.OrdinalIgnoreCase))
                ShowSolutionsList();
            else if (!TryExecuteSolution(command))
                Console.WriteLine("Command not found.");
        }
    }

    private static void ShowSolutionsList()
    {
        foreach (var solution in _solutions.Values)
            Console.WriteLine($"{solution.Number} {solution.Name}");
    }

    private static bool TryExecuteSolution(string command)
    {
        if (int.TryParse(command, out int solutionId))
            if (_solutions.TryGetValue(solutionId, out IIssueSolution? solution))
                try
                {
                    solution.Run();
                    return true;
                }
                catch
                {
                    Console.WriteLine("Something went wrong");
                }
            else
                Console.WriteLine($"There isn't solution for this task({solutionId}).");
        return false;
    }
}