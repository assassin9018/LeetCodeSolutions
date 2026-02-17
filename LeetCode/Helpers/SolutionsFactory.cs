using Microsoft.Extensions.DependencyInjection;

namespace LeetCode.Helpers;

public class SolutionsFactory
{
    private readonly IServiceProvider _serviceProvider;

    public SolutionsFactory()
    {
        var services = new ServiceCollection();

        _serviceProvider = Register(services)
            .BuildServiceProvider();
    }

    public IEnumerable<IIssueSolution> CreateSolutions()
        => _serviceProvider.GetRequiredService<IEnumerable<IIssueSolution>>();

    private static IServiceCollection Register(IServiceCollection services)
    {
        // время жизни не имеет значения, т.к. они всё равно лишь являются обёрткой над консолью
        services.AddTransient<IReadHelper, ConsoleReadHelper>();
        services.AddTransient(typeof(IWriteHelper<>), typeof(ConsoleWriteHelper<>));

        var solutionTypes = typeof(IIssueSolution).Assembly
            .GetTypes()
            .Where(x => x is { IsClass: true, IsAbstract: false } && x.IsAssignableTo(typeof(IIssueSolution)));

        // как будто всё можно было сделать singleton, т.к. решения должны быть stateless, но фиг знает что я когда-то написал
        foreach (var type in solutionTypes)
            services.Add(ServiceDescriptor.Describe(typeof(IIssueSolution), type, ServiceLifetime.Transient));

        return services;
    }
}