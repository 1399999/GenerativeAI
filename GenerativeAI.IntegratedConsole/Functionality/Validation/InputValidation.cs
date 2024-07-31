namespace GenerativeAI.IntegratedConsole.Functionality.Validation;

public static class InputValidation
{
    public static bool ValidateInputFiles(string[] inputFiles)
    {
        string[]? input = inputFiles;

        Program.WriteLineDebug($"Input Files: {input.ToList().ListToString(", and \n")}");
        InputModel.Input.InputFiles = input;

        foreach (var item in input)
        {
            if (!File.Exists(item))
            {
                Program.WriteLineError($"The input file: {item} does not exist.");

                return false;
            }
        }

        return true;
    }
}
