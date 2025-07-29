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

    public static string[] ParseLines(string input)
    {
        return input.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
    }
}