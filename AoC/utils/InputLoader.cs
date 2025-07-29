namespace AoC.Utils;

public class InputLoader
{
    public string Load(int year, int day)
    {
        string path = $"Inputs/{year}/Day{day:00}.txt";
        return File.Exists(path)
            ? File.ReadAllText(path)
            : throw new FileNotFoundException($"Input not found: {path}");
    }
}



public class InputParser
{
    public static string[][] ParseGridString(string input)
    {
        return input.Split(["\r\n", "\n", "\r"], StringSplitOptions.RemoveEmptyEntries)
                    .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                    .ToArray();
    }

    public static int[][] ParseGridInt(string input)
    {
        return input.Split(["\r\n", "\n", "\r"], StringSplitOptions.RemoveEmptyEntries)
                    .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse).ToArray())
                    .ToArray();
    }

    
    /// <summary>
    /// Parses a string input into a two-dimensional list of integers.
    /// Each line in the input represents a row, and integers within a row are separated by spaces.
    /// Empty lines are ignored.
    /// </summary>
    /// <param name="input">The input string containing rows of space-separated integers.</param>
    /// <returns>A list of lists of integers, where each inner list represents a row of integers.</returns>
    public static List<List<int>> Parse2DListInt(string input)
    {
        return input.Split(["\r\n", "\n", "\r"], StringSplitOptions.RemoveEmptyEntries)
                    .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse).ToList())
                    .ToList();
    }

    /// <summary>
    /// Parses a string input into a two-dimensional list of integers, where each row is comma-separated.
    /// Empty lines are ignored.
    public static List<List<int>> Parse2DListIntCommaSeparated(string input)
    {
        return input.Split(["\r\n", "\n", "\r"], StringSplitOptions.RemoveEmptyEntries)
                    .Select(line => line.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse).ToList())
                    .ToList();
    }

    public static string[] ParseLines(string input)
    {
        return input.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
    }
}