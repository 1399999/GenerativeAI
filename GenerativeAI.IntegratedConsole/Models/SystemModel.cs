namespace GenerativeAI.IntegratedConsole.Models;

public static class SystemModel
{
    public static List<Variable> Variables { get; set; } = new();
    public static string Seed { get; set; } = string.Empty;
    public static bool Testing { get; } = false; // Has to be turned on manually.
    public static bool Debug { get; set; } = true; // Has to be turned on manually.
}
