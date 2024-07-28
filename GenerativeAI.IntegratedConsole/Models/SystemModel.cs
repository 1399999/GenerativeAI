namespace GenerativeAI.IntegratedConsole.Models;

public static class SystemModel
{
    public static List<Variable> Variables { get; set; } = new();
    public static string Seed { get; set; } = string.Empty;
}
