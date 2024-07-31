namespace GenerativeAI.IntegratedConsole.Functionality.Validation;

public static class OutputValidation
{
    public static bool ValidateOutputFile(string? outputFilePath = null)
    {
        string input = outputFilePath;

        Program.WriteLineDebug($"Output File: {input}");
        InputModel.Input.OutputFile = input;

        if (File.Exists(input))
        {
            Program.WriteLineError("The output file already exists.");

            return false;
        }

        return true;
    }
}
