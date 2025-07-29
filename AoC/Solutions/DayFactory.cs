using Microsoft.Extensions.DependencyInjection;
using AoC.Solutions._2024;

namespace AoC.Solutions;

public interface IDayFactory
{
    IDay? Create(int day);
}

public class DayFactory : IDayFactory
{
    private readonly IServiceProvider _provider;

    public DayFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public IDay? Create(int day) => day switch
    {
        1 => _provider.GetRequiredService<Day01>(),
        2 => _provider.GetRequiredService<Day02>(),
        3 => _provider.GetRequiredService<Day03>(),
        4 => _provider.GetRequiredService<Day04>(),
        5 => _provider.GetRequiredService<Day05>(),
        _ => null
    };
}