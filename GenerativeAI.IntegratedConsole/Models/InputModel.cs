namespace GenerativeAI.IntegratedConsole.Models;

public static class InputModel
{
    public static string? InputFile { get; set; }
    public static string[] InputFiles { get; set; } = new string[] { };
    public static string? OutputFile { get; set; }
    public static bool Debug { get; set; } = true;
    public static int EscapeCharInt { get; set; } = 27; // Escape key.
    public static float Alpha { get; set; } = 0.5F;
    public static float Beta { get; set; } = 0.5F;
    public static int InputIndex { get; set; } = 0;
    public static int ImageIndex { get; set; } = 1;
    public static int OutputIndex { get; set; } = 2;
    public static int FirstVariableIndex { get; set; } = 0;
    public static int SecondVariableIndex { get; set; } = 1;
}
