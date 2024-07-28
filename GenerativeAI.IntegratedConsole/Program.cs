namespace GenerativeAI.IntegratedConsole;

public static class Program
{
    private static string regexExpression = @"\d.\d.\d";
    private static string regexExpressionTwoDigits = @"\d\d.\d\d.\d\d";

    private static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("======================= Main Commit 7 =======================\n");
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

        InputEnum inputEnum = (InputEnum)int.Parse(SystemModel.Seed.Split('.')[InputModel.InputIndex]);
        ImageTransformationEnum imageEnum = (ImageTransformationEnum)int.Parse(SystemModel.Seed.Split('.')[InputModel.ImageIndex]);
        OutputEnum outputEnum = (OutputEnum)int.Parse(SystemModel.Seed.Split('.')[InputModel.OutputIndex]);

        if (inputEnum == InputEnum.CVFile && !ValidateInputFile())
        {
            return false;
        }

        if (inputEnum == InputEnum.CVMultipleFiles && !ValidateInputFiles())
        {
            return false;
        }

        if (imageEnum == ImageTransformationEnum.BlendImages && !ValidateImageFile())
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

        if (!new Regex(regexExpression).IsMatch(seed) && !new Regex(regexExpressionTwoDigits).IsMatch(seed))
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

    private static bool ValidateImageFile()
    {
        Console.Write("\nEnter an alpha value (press enter for the defualt value): ");
        string? input = Console.ReadLine();

        if (input != string.Empty)
        {
            bool result = float.TryParse(input, out float alpha);
            InputModel.Alpha = alpha;

            if (!result)
            {
                WriteLineError($"The input \"{input}\" is not a decimal.");

                return false;
            }
        }

        Console.Write("\nEnter an beta value (press enter for the defualt value): ");
        input = Console.ReadLine();

        if (input != string.Empty)
        {
            bool result = float.TryParse(input, out float beta);
            InputModel.Beta = beta;

            if (!result)
            {
                WriteLineError($"The input \"{input}\" is not a decimal.");

                return false;
            }
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

        WriteLineDebug($"Input Files: {input.ToList().ListToString(", and \n")}");
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
