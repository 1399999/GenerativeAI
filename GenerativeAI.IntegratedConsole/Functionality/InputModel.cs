namespace GenerativeAI.IntegratedConsole.Functionality;

public static class InputModel
{
    public static string? InputFile { get; set; }
    public static string[] InputFiles { get; set; } = new string[] { };
    public static string? OutputFile { get; set; }
    public static bool Debug { get; set; } = true;
    public static int EscapeCharInt { get; set; } = 27; // Escape key.
}
