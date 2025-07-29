using System.Text.RegularExpressions;
using AoC.Utils;

namespace AoC.Solutions._2024;

public class Day04 : IDay
{
    public string SolvePart1(string input)
    {
        string[] lines = InputParser.ParseLines(input);

        int x = lines[0].Length;
        int y = lines.Length;
        
        int numXMAS = 0;

        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                if (lines[i][j] == 'X')
                {

                    // Check forward
                    if (j + 3 < x && lines[i][j + 1] == 'M' && lines[i][j + 2] == 'A' && lines[i][j + 3] == 'S')
                    {
                        numXMAS++;
                    }
                    // Check backward
                    if (j - 3 >= 0 && lines[i][j - 1] == 'M' && lines[i][j - 2] == 'A' && lines[i][j - 3] == 'S')
                    {
                        numXMAS++;
                    }
                    // Check down
                    if (i + 3 < y && lines[i + 1][j] == 'M' && lines[i + 2][j] == 'A' && lines[i + 3][j] == 'S')
                    {
                        numXMAS++;
                    }
                    // Check up
                    if (i - 3 >= 0 && lines[i - 1][j] == 'M' && lines[i - 2][j] == 'A' && lines[i - 3][j] == 'S')
                    {
                        numXMAS++;
                    }
                    // Check diagonal down-right
                    if (i + 3 < y && j + 3 < x && lines[i + 1][j + 1] == 'M' && lines[i + 2][j + 2] == 'A' && lines[i + 3][j + 3] == 'S')
                    {
                        numXMAS++;
                    }
                    // Check diagonal up-left
                    if (i - 3 >= 0 && j - 3 >= 0 && lines[i - 1][j - 1] == 'M' && lines[i - 2][j - 2] == 'A' && lines[i - 3][j - 3] == 'S')
                    {
                        numXMAS++;
                    }
                    // Check diagonal down-left
                    if (i + 3 < y && j - 3 >= 0 && lines[i + 1][j - 1] == 'M' && lines[i + 2][j - 2] == 'A' && lines[i + 3][j - 3] == 'S')
                    {
                        numXMAS++;
                    }
                    // Check diagonal up-right
                    if (i - 3 >= 0 && j + 3 < x && lines[i - 1][j + 1] == 'M' && lines[i - 2][j + 2] == 'A' && lines[i - 3][j + 3] == 'S')
                    {
                        numXMAS++;
                    }
                }
            }
        }

        return numXMAS.ToString();
    }

    public string SolvePart2(string input)
    {
        var pattern = @"(?=S\wS[\S\r\n]{140}A[\S\r\n]{140}M\wM)|(?=M\wM[\S\r\n]{140}A[\S\r\n]{140}S\wS)|(?=M\wS[\S\r\n]{140}A[\S\r\n]{140}M\wS)|(?=S\wM[\S\r\n]{140}A[\S\r\n]{140}S\wM)";

        MatchCollection matches = Regex.Matches(input, pattern);

        return matches.Count.ToString();
    }
}