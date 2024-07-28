namespace GenerativeAI.IntegratedConsole;

public static class Program
{
    private static string regexExpression = @"\d.\d";
    private static string regexExpression2 = @"\d\d.\d\d";

    private static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("======================= Main Commit 6 =======================\n");
        Console.ForegroundColor = ConsoleColor.White;

        var validationOutput = Validate();

        if (validationOutput)
        {
            int[] vectors = SystemModel.Seed.Split('.').StringToIntArray();
            SeedNavigator.Navigate(vectors);
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n======================= Program Ended =======================");
        Console.ForegroundColor = ConsoleColor.White;
    }

    // (bool IsValid, string? Input) is a tuple.
    public static bool Validate()
    {
        if (!ValidateSeed())
        {
            return false;
        }

        InputEnum inputEnum = (InputEnum)int.Parse(SystemModel.Seed.Split('.')[0]);
        OutputEnum outputEnum = (OutputEnum)int.Parse(SystemModel.Seed.Split('.')[1]);

        if (inputEnum == InputEnum.CVFile && !ValidateInputFile())
        {
            return false;
        }

        if (inputEnum == InputEnum.CVMultipleFiles && !ValidateInputFiles())
        {
            return false;
        }

        if (outputEnum == OutputEnum.CVFile && !ValidateOutputFile())
        {
            return false;
        }

        return true;
    }

    private static bool ValidateSeed()
    {
        Console.Write("Enter a seed for the program: ");
        string seed = Console.ReadLine();
        SystemModel.Seed = seed;

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

    private static bool ValidateInputFile()
    {
        Console.Write("\nEnter an input path for the program: ");
        string? inputFile = Console.ReadLine();

        WriteLineDebug($"Input File: {inputFile}");
        InputModel.InputFile = inputFile;

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

        return true;
    }

    private static bool ValidateOutputFile()
    {
        Console.Write("\nEnter an output path for the program: ");
        string? input = Console.ReadLine();

        WriteLineDebug($"Output File: {input}");
        InputModel.OutputFile = input;

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

        return true;
    }

    private static bool ValidateInputFiles()
    {
        Console.Write("\nEnter the input files: ");
        string[] input = Console.ReadLine().Split(',');

        WriteLineDebug($"Input Files: {input.ToList().ListToString(",\n")}");
        InputModel.InputFiles = input;

        foreach (var item in input)
        {
            if (item == null)
            {
                WriteLineError($"The input file path is null.");

                return false;
            }

            if (!File.Exists(item))
            {
                WriteLineError($"The input file: {item} does not exist.");

                return false;
            }
        }

        return true;
    }

    public static void WriteError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"[Error] {message}");

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
        if (InputModel.Debug)
        {
            WriteDebug($"{message}\n");
        }
    }

    public static void WriteWarning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"[Warning] {message}");

        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void WriteLineWarning(string message)
    {
        WriteWarning($"{message}\n");
    }
}
