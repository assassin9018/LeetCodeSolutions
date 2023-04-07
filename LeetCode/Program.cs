using LeetCode.Helpers;

namespace LeetCode;

public class Program
{
    private static readonly Dictionary<int, IIssueSolution> Solutions =
        new SolutionsFactory().CreateSolutions().ToDictionary(x => x.Number);

    public static void Main(string[] args)
    {
        Console.WriteLine("Select task number or enter -list for show all task numbers.");
        while (true)
        {
            var command = Console.ReadLine();
            if (command is null)
                continue;
            if (command.Equals("-list", StringComparison.OrdinalIgnoreCase))
                ShowSolutionsList();
            else
                TryExecuteSolution(command);
        }
    }

    private static void ShowSolutionsList()
    {
        foreach (var solution in Solutions.Values)
            Console.WriteLine($"{solution.Number} {solution.Name}");
    }

    private static void TryExecuteSolution(string command)
    {
        if (!int.TryParse(command, out var solutionId))
        {
            Console.WriteLine("Command not found.");
            return;
        }

        if (!Solutions.TryGetValue(solutionId, out var solution))
        {
            Console.WriteLine($"There isn't solution for this task({solutionId}).");
            return;
        }

        try
        {
            solution.Run();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Something went wrong. Ex: {e}");
        }
    }
}