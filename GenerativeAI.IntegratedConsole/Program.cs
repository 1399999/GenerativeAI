namespace GenerativeAI.IntegratedConsole;

public static class Program
{
    private const string regexValidationExpression = @"(0[0-9]|1[0-1].){1,}";

    private static void Main(string[] args)
    {
        Console.WriteLine("======================= Main Commit 13 =======================\n");

        InputModel.InitialImageNumber = UtilityFunctions.GetCurrentOutputNumber();

        WriteLineTesting("Test beginning");

        if (SystemModel.Testing)
        {
            OpenCVUtilities.Test();
        }

        else
        {
            if (Validate(SystemModel.StaticInput))
            {
                int[] vectors = SystemModel.StaticInput.Seed.Split('.').StringToIntArray();
                SeedNavigator.Navigate(vectors);
            }
        }

        Console.WriteLine("\n======================= Program Ended =======================");
    }

    public static bool Validate(JsonInput input)
    {
        Regex regex = new Regex(regexValidationExpression);

        if (!regex.IsMatch(input.Seed))
        {
            return false;
        }

        return true;
    }

    public static void WriteError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"[Fatal Error] {message}");

        Console.ForegroundColor = ConsoleColor.White;

        SystemModel.Work = false;
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

    public static bool RequestPermission()
    {
        WriteWarning("Do you wish to proceed? (y for yes, any other key for no): ");

        var key = Console.ReadKey();

        if (key.Key == ConsoleKey.Y)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
