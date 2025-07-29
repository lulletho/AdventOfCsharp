using AoC.Utils;
using System.Text.RegularExpressions;
namespace AoC.Solutions._2024;

public class Day05: IDay
{
    public string SolvePart1(string input)
    {
        string[] sections = Regex.Split(input, @"\r?\n\s*\r?\n");

        if (sections.Length != 2)
        {
            throw new ArgumentException("Input must contain exactly two sections separated by a blank line.");
        }

        string[] rules = InputParser.ParseLines(sections[0]);
        List<List<int>> messages = InputParser.Parse2DListIntCommaSeparated(sections[1]);

        Dictionary<int, HashSet<int>> rulebook = MakeRulebook(rules);

        int sum = 0;

        foreach (var message in messages)
        {
            if (IsMessageFollowingRule(message, rulebook))
            {
                sum += message[message.Count / 2];
            }
        }

        return sum.ToString();
    }

    static Dictionary<int, HashSet<int>> MakeRulebook(string[] rules)
    {
        Dictionary<int, HashSet<int>> rulebook = [];

        foreach (var rule in rules)
        {
            var parts = rule.Split("|", StringSplitOptions.RemoveEmptyEntries).Select(p => int.Parse(p)).ToArray();
            int key = parts[0];
            int value = parts[1];

            if (!rulebook.TryGetValue(key, out var values))
            {
                values = new HashSet<int>();
                rulebook[key] = values;
            }
            values.Add(value);
        }

        return rulebook;
    }

    static bool IsMessageFollowingRule(List<int> message, Dictionary<int, HashSet<int>> rulebook)
    {
        foreach (var pageNum in message)
        {
            if (!rulebook.TryGetValue(pageNum, out var rules))
            {
                continue; // No Rule for this number, so it is valid
            }

            int pageNumIndex = message.IndexOf(pageNum);

            for (int i = 0; i < message.Count; i++)
            {
                int pageToValidate = message[i];
                if (pageToValidate == pageNum)
                {
                    continue;
                }

                if (rules.Contains(pageToValidate) && i < pageNumIndex)
                {
                    return false; // Rulenumber most be before all corresponding numbers in the rule set
                }
            }
        }

        return true;
    }

    public static List<int> FixBrokenMessage(List<int> message, Dictionary<int, HashSet<int>> rulebook, int reccursionDepth = 0)
    {
        if (reccursionDepth > 10000)
        {
            throw new InvalidOperationException("Recursion depth exceeded while trying to fix message.");
        }

        foreach (var pageNum in message)
        {
            if (!rulebook.TryGetValue(pageNum, out var rules))
            {
                continue; // No Rule for this number, so it is valid
            }

            int pageNumIndex = message.IndexOf(pageNum);

            for (int i = 0; i < message.Count; i++)
            {
                int pageToValidate = message[i];
                if (pageToValidate == pageNum)
                {
                    continue;
                }

                if (rules.Contains(pageToValidate) && i < pageNumIndex)
                {
                    (message[i], message[pageNumIndex]) = (message[pageNumIndex], message[i]);
                    FixBrokenMessage(message, rulebook, reccursionDepth + 1);
                    return message;

                }
            }
        }

        return message;
    }

    public string SolvePart2(string input)
    {
        string[] sections = Regex.Split(input, @"\r?\n\s*\r?\n");

        if (sections.Length != 2)
        {
            throw new ArgumentException("Input must contain exactly two sections separated by a blank line.");
        }

        string[] rules = InputParser.ParseLines(sections[0]);
        List<List<int>> messages = InputParser.Parse2DListIntCommaSeparated(sections[1]);

        Dictionary<int, HashSet<int>> rulebook = MakeRulebook(rules);

        int sum = 0;

        foreach (var message in messages)
        {
            if (IsMessageFollowingRule(message, rulebook))
            {
                continue;
            }
            else
            {
                var fixedMessage = FixBrokenMessage(message, rulebook);
                sum += fixedMessage[fixedMessage.Count / 2];
            }
        }

        return sum.ToString();
    }
}