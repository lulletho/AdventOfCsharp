using System.Text.RegularExpressions;


namespace AoC.Solutions._2024;

public class Day03 : IDay
{
    public string SolvePart1(string input)
    {
        string pattern = @"mul[´(´]\d{1,3},\d{1,3}[´)´]";

        MatchCollection matches = Regex.Matches(input, pattern);

        int sum = 0;

        foreach (Match match in matches)
        {
            var val = MultiplyMatch(match);
            sum += val;
        }
        return sum.ToString();
    }

    public string SolvePart2(string input)
    {
        var pattern = @"do[`(`][`)`]|don[`'`]t[`(`][`)`]|mul[´(´]\d{1,3},\d{1,3}[´)´]";
        var matches = Regex.Matches(input, pattern);

        bool enabled = true;
        var sum = 0;
        foreach (Match match in matches)
        {
            if (match.Value.StartsWith("do("))
            {
                enabled = true;
            }
            else if (match.Value.StartsWith("don"))
            {
                enabled = false;
            }
            else if (enabled && match.Value.StartsWith("mul"))
            {
                sum += MultiplyMatch(match);
            }
        }

        return sum.ToString();
    }

    public static int MultiplyMatch(Match match)
    {
        int sum = 0;
        var numbers = match.Value
                .Replace("mul(", "")
                .Replace(")", "")
                .Split(',')
                .Select(n => int.Parse(n)).ToArray();

        if (numbers.Count() == 2)
        {
            sum += numbers[0] * numbers[1];
        }
        else
        {
            Console.WriteLine($"Unexpected match format: {match.Value}");
        }
        return sum;
    }
}