namespace GenerativeAI.IntegratedConsole.Models;

public static class InputModel
{
    public static string OutputDirectoryPath { get; set; } = "C:\\GenerativeAITests";
    public static int InitialImageNumber { get; set; }
    public static bool IsImgColor { get; set; }
    public static List<JsonInput> StandardInput { get; set; } = new List<JsonInput>();
}
