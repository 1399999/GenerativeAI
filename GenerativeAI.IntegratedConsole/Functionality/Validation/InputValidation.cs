namespace GenerativeAI.IntegratedConsole.Functionality.Validation;

public static class InputValidation
{
    public static bool ValidateInputFiles(string[]? inputFiles = null)
    {
        Console.Write("\nEnter the input files: ");
        string[]? input = (!SystemModel.Testing) ? Console.ReadLine().Split(',') : inputFiles;

        Program.WriteLineDebug($"Input Files: {input.ToList().ListToString(", and \n")}");
        InputModel.InputFiles = input;

        foreach (var item in input)
        {
            if (item == null)
            {
                Program.WriteLineError($"The input file path is null.");

                return false;
            }

            if (!File.Exists(item))
            {
                Program.WriteLineError($"The input file: {item} does not exist.");

                return false;
            }
        }

        return true;
    }
}
