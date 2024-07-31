namespace GenerativeAI.IntegratedConsole.Functionality.InstanceClasses;

public class Variable
{
    public string Name { get; set; } = string.Empty;
    public VariableType Type { get; set; }
    public int XShape { get; set; }
    public int YShape { get; set; }
}
