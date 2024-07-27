namespace GenerativeAI.IntegratedConsole.Functionality;

public static class CentralModel
{
    public static string? InputFile { get; set; }
    public static string? OutputFile { get; set; }
    public static bool Debug { get; set; } = true;
    public static int EscapeCharInt { get; set; } = 27; // Escape key.
    public static string Seed { get; set; } = string.Empty; // Escape key.
}
