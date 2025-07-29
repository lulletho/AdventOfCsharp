using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AoC.Solutions;
using AoC.Solutions._2024;
using AoC.Utils;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddSingleton<InputLoader>();
        services.AddSingleton<IDayFactory, DayFactory>();

        services.AddTransient<Day01>();
        services.AddTransient<Day02>();
        services.AddTransient<Day03>();
        services.AddTransient<Day04>();
    })
    .Build();

var factory = host.Services.GetRequiredService<IDayFactory>();

Console.WriteLine("Which year and day would you like to run? (separate with a space, e.g., '2024 1')");
string? userInput = Console.ReadLine();
if (string.IsNullOrWhiteSpace(userInput))
{
    Console.WriteLine("Input cannot be empty.");
    return;
}

var parts = userInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
if (parts.Length != 2 || !int.TryParse(parts[0], out int year) || !int.TryParse(parts[1], out int dayNumber))
{
    Console.WriteLine("Invalid input format. Please enter a year and a day number.");
    return;
}

var day = factory.Create(dayNumber);
if (day == null)
{
    Console.WriteLine($"Day {dayNumber} is not implemented.");
    return;
}

string problemInput = host.Services.GetRequiredService<InputLoader>().Load(year, dayNumber);
Console.WriteLine($"--- Day {dayNumber:00} ---");
Console.WriteLine($"Part 1: {day.SolvePart1(problemInput)}");
Console.WriteLine($"Part 2: {day.SolvePart2(problemInput)}");
