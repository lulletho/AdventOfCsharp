using AoC.Utils;

namespace AoC.Solutions._2024;

public class Day01 : IDay
{
    public string SolvePart1(string input)
    {
        var lines = InputParser.ParseLines(input);
        
        List<int> leftSide = [];
        List<int> rightSide = [];

        foreach (var line in lines)
        {
            var parts = line.Split("   ", StringSplitOptions.RemoveEmptyEntries);
            if (!parts.Length.Equals(2))
            {
                throw new ArgumentException("Each line must contain exactly two parts, Code Broken.");
            }

            leftSide.Add(int.Parse(parts[0]));
            rightSide.Add(int.Parse(parts[1]));
        }

        leftSide.Sort();
        rightSide.Sort();

        int distance = 0;

        for (int i = 0; i < leftSide.Count; i++)
        {
            distance += Math.Abs(leftSide[i] - rightSide[i]);
        }

        return distance.ToString();
    }

    public string SolvePart2(string input)
    {
        var lines = InputParser.ParseLines(input);

        List<int> leftSide = [];
        List<int> rightSide = [];

        foreach (var line in lines)
        {
            var parts = line.Split("   ", StringSplitOptions.RemoveEmptyEntries);
            if (!parts.Length.Equals(2))
            {
                throw new ArgumentException("Each line must contain exactly two parts, Code Broken.");
            }

            leftSide.Add(int.Parse(parts[0]));
            rightSide.Add(int.Parse(parts[1]));
        }

        int similarityScore = 0;
        var previouslyCountedNumbers = new Dictionary<int, int>(); // (key, similarityScore)

        foreach (var number in leftSide)
        {
            if (previouslyCountedNumbers.TryGetValue(number, out int score))
            {
                similarityScore += score;
            }
            else
            {
                int count = rightSide.Count(n => n == number);
                score = number * count;
                previouslyCountedNumbers[number] = score;
                similarityScore += score;
            }
        }
        
        return similarityScore.ToString();
    }
}