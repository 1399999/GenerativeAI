using GenerativeAI.IntegratedConsole.Functionality.Navigator;

namespace GenerativeAI.IntegratedConsole;

public static class Program
{
    private const string regexValidationExpression = @"(0[0-9]|6[0-9].){1,}";

    private static void Main(string[] args)
    {
        Console.WriteLine("======================= Main Commit 20 =======================\n");

        InputModel.InitialImageNumber = UtilityFunctions.GetCurrentOutputNumber();

        WriteLineTesting("Test beginning");

        if (SystemModel.Testing)
        {
            OpenCVUtilities.Test();
        }

        else
        {
            InputModel.StandardInput.Add(new JsonInput()
            {
                Order = 0,
                FunctionType = OptionEnum.GetColorImg,
                InputPath = "C:\\Users\\mzheb\\Downloads\\GIlcQIOXMAAWm3D - Copy (2).jpg",
            });

            InputModel.StandardInput.Add(new JsonInput()
            {
                Order = 1,
                FunctionType = OptionEnum.WriteToFile,
            });

            SeedNavigator.Navigate();

            string json = JsonConvert.SerializeObject(InputModel.StandardInput);

            Console.WriteLine(json);

            Console.WriteLine("\n======================= Program Ended =======================");
        }
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
