namespace GenerativeAI.IntegratedConsole;

public static class Program
{
    private static string regexExpression = @"\d.\d.\d";
    private static string regexExpressionTwoDigits = @"\d\d.\d\d.\d\d";

    private static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("======================= Main Commit 8 =======================\n");
        Console.ForegroundColor = ConsoleColor.White;

        WriteLineTesting("Test beginning.");

        if (SystemModel.Testing)
        {
            TestFile.TestAllCases();
        }

        else
        {
            if (Validate(SystemModel.StaticInput))
            {
                int[] vectors = SystemModel.Seed.Split('.').StringToIntArray();
                SeedNavigator.Navigate(vectors);
            }
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n======================= Program Ended =======================");
        Console.ForegroundColor = ConsoleColor.White;
    }

    // (bool IsValid, string? Input) is a tuple.
    private static bool Validate(JsonInput input)
    {
        if (!ValidateSeed(input.Seed))
        {
            return false;
        }

        InputEnum inputEnum = (InputEnum)int.Parse(SystemModel.Seed.Split('.')[InputModel.InputIndex]);
        ImageTransformationEnum imageEnum = (ImageTransformationEnum)int.Parse(SystemModel.Seed.Split('.')[InputModel.ImageIndex]);
        OutputEnum outputEnum = (OutputEnum)int.Parse(SystemModel.Seed.Split('.')[InputModel.OutputIndex]);

        if (inputEnum == InputEnum.CVFile && !InputValidation.ValidateInputFiles(input.InputFiles))
        {
            return false;
        }

        else if (inputEnum == InputEnum.CVGrayScale)
        {
            InputModel.Input.Grayscale = true;

            if (!InputValidation.ValidateInputFiles(input.InputFiles))
            {
                return false;
            }
        }

        if (imageEnum == ImageTransformationEnum.BlendImagesFull && !ImageValidation.ValidateBlendedImage(input.Alpha.ToString(), input.Beta.ToString()))
        {
            return false;
        }

        if (outputEnum == OutputEnum.CVFile && !OutputValidation.ValidateOutputFile(input.OutputFile))
        {
            return false;
        }

        return true;
    }

    public static bool ValidateSeed(string definedSeed)
    {
        string seed = definedSeed;
        SystemModel.Seed = seed;

        WriteLineDebug($"Seed: {seed}");

        if (TestFile.InvalidSeedArray.Contains(seed))
        {
            WriteLineError("That seed is contained in a blacklist array.");

            return false;
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
        if (SystemModel.Debug || SystemModel.Testing)
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

    public static void WriteTesting(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"[Testing] ");

        Console.ForegroundColor = ConsoleColor.White;

        Console.Write(message);
    }

    public static void WriteLineTesting(string message)
    {
        if (SystemModel.Testing)
        {
            WriteTesting($"{message}\n");
        }
    }
}
