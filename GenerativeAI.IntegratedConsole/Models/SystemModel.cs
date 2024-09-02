namespace GenerativeAI.IntegratedConsole.Models;

public static class SystemModel
{
    public static bool Testing { get; } = true; // Has to be turned on manually.
    public static bool Debug { get; set; } = true; // Has to be turned on manually.
    public static bool Work { get; set; } = true; // If off, the entire algorithm shuts down.
}
