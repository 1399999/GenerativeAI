namespace GenerativeAI.IntegratedConsole.Functionality.Validation;

public static class ImageValidation
{
    public static bool ValidateBlendedImage(string? definedAlpha = null, string? definedBeta = null)
    {
        if (InputModel.Input.InputFiles.Length > 2)
        {
            Program.WriteLineDebug("The correct amount of files (2 or more) has not been specified.");

            return false;
        }

        string? input = definedAlpha;

        Program.WriteLineDebug($"Alpha Value: {input}");
        InputModel.Input.Alpha = double.Parse(definedAlpha);

        input = definedBeta;

        Program.WriteLineDebug($"Beta Value: {input}");
        InputModel.Input.Beta = double.Parse(definedBeta);

        return true;
    }
}
