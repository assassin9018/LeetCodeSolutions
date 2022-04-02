namespace LeetCode;

public class Program
{
    private static readonly Dictionary<int, IIssueSolution> _solutions = new SolutionsFactory().CreateSolutions().ToDictionary(x => x.Number);

    public static void Main(string[] args)
    {
        Console.WriteLine("Select task number or enter -list for show all task numbers.");
        while(true)
        {
            string? command = Console.ReadLine();
            if(command is null)
                continue;
            if(command.Equals("-list", StringComparison.OrdinalIgnoreCase))
                ShowSolutionsList();
            else
                TryExecuteSolution(command);
        }
    }

    private static void ShowSolutionsList()
    {
        foreach(var solution in _solutions.Values)
            Console.WriteLine($"{solution.Number} {solution.Name}");
    }

    private static void TryExecuteSolution(string command)
    {
        if(!int.TryParse(command, out int solutionId) || !_solutions.TryGetValue(solutionId, out IIssueSolution? solution))
            return;
        try
        {
            solution.Run();
        }
        catch
        {
            Console.WriteLine("Something went wrong");
        }
    }
}