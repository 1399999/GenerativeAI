namespace GenerativeAI.IntegratedConsole;

public static class Program
{
    private static string regexExpression = @"\d.\d";

    private static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("======================= Main Commit 3 =======================\n");
        Console.ForegroundColor = ConsoleColor.White;

        var validationOutput = Validate();

        if (validationOutput.IsValid)
        {
            int[] vectors = validationOutput.Input.Split('.').StringToIntArray();
            SeedNavigator.Navigate(vectors);
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n======================= Program Ended =======================");
        Console.ForegroundColor = ConsoleColor.White;
    }

    // (bool IsValid, string? Input) is a tuple.
    public static (bool IsValid, string Input) Validate()
    {
        Console.Write("Enter a seed for the program: ");
        string? seed = Console.ReadLine();

        WriteLineDebug($"Seed: {seed}");

        if (seed == null)
        {
            WriteLineError("The input is null.");

            return (false, seed);
        }

        if (!new Regex(regexExpression).IsMatch(seed))
        {
            WriteLineError("The input is in an incorrect format.");

            return (false, seed);
        }

        Console.Write("\nEnter an input path for the program: ");
        string? input = Console.ReadLine();

        WriteLineDebug($"Input File: {input}");
        CentralModel.InputFile = input;

        if (input == null)
        {
            WriteLineError("The input file path is null.");

            return (false, input);
        }

        if (!File.Exists(input))
        {
            WriteLineError("The input file does not exist.");

            return (false, input);
        }

        Console.Write("\nEnter an output path for the program: ");
        input = Console.ReadLine();

        WriteLineDebug($"Output File: {input}");
        CentralModel.OutputFile = input;

        if (input == null)
        {
            WriteLineError("The output file path is null.");

            return (false, input);
        }

        if (File.Exists(input))
        {
            WriteLineError("The output file already exists.");

            return (false, input);
        }

        return (true, seed);
    }

    public static void WriteError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"Error: {message}");

        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void WriteLineError(string message)
    {
        WriteError($"{message}\n");
    }

    public static void WriteDebug(string message)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write('[');

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Debug");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("] ");

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(message);
    }

    public static void WriteLineDebug(string message)
    {
        WriteDebug($"{message}\n");
    }
}
