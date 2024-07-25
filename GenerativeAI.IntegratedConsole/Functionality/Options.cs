namespace GenerativeAI.IntegratedConsole.Functionality;

public class Options
{
    public static string DirectoryPath { get; } = "C:\\Temp";
    public static string FilePath { get; } = "C:\\Temp\\PythonTemp.py";
    public InputEnum Input { get; set; }
    public OutputEnum Output { get; set; }
}
