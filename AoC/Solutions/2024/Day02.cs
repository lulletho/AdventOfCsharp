using AoC.Utils;

namespace AoC.Solutions._2024;

public class Day02 : IDay
{
    public string SolvePart1(string input)
    {
        var reports = InputParser.ParseLines(input);
        var numSafeReports = 0;

        foreach (var report in reports)
        {
            var parts = report.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();

            bool isSafe = isReportSafe(parts);
            
            if (isSafe)
            {
                numSafeReports++;
            }
        }

        return numSafeReports.ToString();
    }

    public string SolvePart2(string input)
    {
        var reports = InputParser.ParseLines(input);
        var numSafeReports = 0;

        foreach (var report in reports)
        {
            var parts = report.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();

            bool isSafe = isReportSafe(parts);
            if (isSafe)
            {
                numSafeReports++;
            }
            else
            {
                // Check if the report can be made safe by removing one element
                for (int i = 0; i < parts.Length; i++)
                {
                    var modifiedReport = parts.Where((_, index) => index != i).ToArray();
                    if (isReportSafe(modifiedReport))
                    {
                        numSafeReports++;
                        break;
                    }
                }
            }
        }


        return numSafeReports.ToString();
    }
    public bool isReportSafe(int[] report)
    {
        bool isSafe = true;

        int dir = report[0] < report[1] ? 1 : -1;

        for (int i = 0; i < report.Length - 1; i++)
        {
            var currentDir = report[i] < report[i + 1] ? 1 : -1;
            if (currentDir != dir)
            {
                isSafe = false;
                break;
            }

            var distance = Math.Abs(report[i] - report[i + 1]);
            if (distance < 1 || distance > 3)
            {
                isSafe = false;
                break;
            }
        }
        return isSafe;
    }
}