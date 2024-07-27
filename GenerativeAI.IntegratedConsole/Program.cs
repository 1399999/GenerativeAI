namespace GenerativeAI.IntegratedConsole;

public static class Program
{
    private static string regexExpression = @"\d.\d";
    private static string regexExpression2 = @"\d\d.\d\d";

    private static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("======================= Main Commit 4 =======================\n");
        Console.ForegroundColor = ConsoleColor.White;

        var validationOutput = Validate();

        if (validationOutput)
        {
            int[] vectors = CentralModel.Seed.Split('.').StringToIntArray();
            SeedNavigator.Navigate(vectors);
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n======================= Program Ended =======================");
        Console.ForegroundColor = ConsoleColor.White;
    }

    // (bool IsValid, string? Input) is a tuple.
    public static bool Validate()
    {

        InputEnum inputEnum = (InputEnum)int.Parse(CentralModel.Seed.Split('.')[0]);
        OutputEnum outputEnum = (OutputEnum)int.Parse(CentralModel.Seed.Split('.')[1]);

        if (!ValidateSeed())
        {
            return false;
        }

        if (inputEnum == InputEnum.CVFile)
        {
            Console.Write("\nEnter an input path for the program: ");
            string? inputFile = Console.ReadLine();

            WriteLineDebug($"Input File: {inputFile}");
            CentralModel.InputFile = inputFile;

            if (inputFile == null)
            {
                WriteLineError("The input file path is null.");

                return false;
            }

            if (!File.Exists(inputFile))
            {
                WriteLineError("The input file does not exist.");

                return false;
            }
        }

        if (outputEnum == OutputEnum.CVFile)
        {
            Console.Write("\nEnter an output path for the program: ");
            string? input = Console.ReadLine();

            WriteLineDebug($"Output File: {input}");
            CentralModel.OutputFile = input;

            if (input == null)
            {
                WriteLineError("The output file path is null.");

                return false;
            }

            if (File.Exists(input))
            {
                WriteLineError("The output file already exists.");

                return false;
            }
        }

        return true;
    }

    private static bool ValidateSeed()
    {
        Console.Write("Enter a seed for the program: ");
        string seed = Console.ReadLine();
        CentralModel.Seed = seed;

        InputEnum inputEnum = (InputEnum)int.Parse(seed.Split('.')[0]);
        OutputEnum outputEnum = (OutputEnum)int.Parse(seed.Split('.')[1]);

        WriteLineDebug($"Seed: {seed}");

        if (seed == null)
        {
            WriteLineError("The seed is null.");

            return false;
        }

        if (!new Regex(regexExpression).IsMatch(seed) && !new Regex(regexExpression2).IsMatch(seed))
        {
            WriteLineError("The seed is in an incorrect format.");

            return false;
        }

        return true;
    }

    public static void WriteError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"Error: {message}");

        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void WriteLineError(string message) => WriteError($"{message}\n");

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
        if (CentralModel.Debug)
        {
            WriteDebug($"{message}\n");
        }
    }
}
