namespace GenerativeAI.IntegratedConsole;

public static class Program
{
    private static string regexExpression = @"\d.\d.\d";
    private static string regexExpressionTwoDigits = @"\d\d.\d\d.\d\d";

    private static void Main(string[] args)
    {
        Console.WriteLine("======================= Main Commit 11 =======================\n");

        InputModel.InitialImageNumber = UtilityFunctions.GetCurrentOutputNumber();

        WriteLineTesting("Test beginning");

        if (SystemModel.Testing)
        {
            OpenCVUtilities.Test();
        }

        //else
        //{
        //    if (Validate(SystemModel.StaticInput))
        //    {
        //        int[] vectors = SystemModel.Seed.Split('.').StringToIntArray();
        //        SeedNavigator.Navigate(vectors);
        //    }
        //}

        Console.WriteLine("\n======================= Program Ended =======================");
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
