namespace GenerativeAI.IntegratedConsole.Functionality.Validation;

public static class OutputValidation
{
    public static bool ValidateOutputFile(string? outputFilePath = null)
    {
        Console.Write("\nEnter an output path for the program: ");
        string? input = (!SystemModel.Testing) ? Console.ReadLine() : outputFilePath;

        Program.WriteLineDebug($"Output File: {input}");
        InputModel.OutputFile = input;

        if (input == null)
        {
            Program.WriteLineError("The output file path is null.");

            return false;
        }

        if (File.Exists(input))
        {
            Program.WriteLineError("The output file already exists.");

            return false;
        }

        return true;
    }
}
