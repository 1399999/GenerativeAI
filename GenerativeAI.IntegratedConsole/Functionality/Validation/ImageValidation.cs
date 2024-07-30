namespace GenerativeAI.IntegratedConsole.Functionality.Validation;

public static class ImageValidation
{
    public static bool ValidateBlendedImage(string? definedAlpha = null, string? definedBeta = null)
    {
        if (InputModel.InputFiles.Length > 2)
        {
            Program.WriteLineDebug("The correct amount of files (2 or more) has not been specified.");

            return false;
        }

        Console.Write("\nEnter an alpha value (press enter for the defualt value): ");
        string? input = (!SystemModel.Testing) ? Console.ReadLine() : definedAlpha;

        Program.WriteLineDebug($"Alpha Value: {input}");

        if (input != string.Empty)
        {
            bool result = float.TryParse(input, out float alpha);
            InputModel.Alpha = alpha;

            if (!result)
            {
                Program.WriteLineError($"The input \"{input}\" is not a decimal.");

                return false;
            }
        }

        Console.Write("\nEnter an beta value (press enter for the defualt value): ");
        input = (!SystemModel.Testing) ? Console.ReadLine() : definedBeta;

        Program.WriteLineDebug($"Beta Value: {input}");

        if (input != string.Empty)
        {
            bool result = float.TryParse(input, out float beta);
            InputModel.Beta = beta;

            if (!result)
            {
                Program.WriteLineError($"The input \"{input}\" is not a decimal.");

                return false;
            }
        }

        return true;
    }
}
