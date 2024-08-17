namespace GenerativeAI.IntegratedConsole.Models;

public static class InputModel
{
    public static int InputIndex { get; set; } = 0;
    public static int ImageIndex { get; set; } = 1;
    public static int OutputIndex { get; set; } = 2;
    public static int FirstVariableIndex { get; set; } = 0;
    public static int SecondVariableIndex { get; set; } = 1;
    public static string OutputDirectoryPath { get; set; } = "C:\\GenerativeAITests";
    public static int InitialImageNumber { get; set; }
    public static JsonInput Input { get; set; } = new();
}
