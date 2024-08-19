namespace GenerativeAI.IntegratedConsole.Functionality.InstanceClasses;

// Does not currently inplement Json. 
public class JsonInput
{
    public string Seed { get; set; } = string.Empty;
    public string InputPath { get; set; } = string.Empty;
    public string OutputPath { get; set; } = string.Empty;
    public ushort Width { get; set; }
    public ushort Height { get; set; }
    public byte RedChannel { get; set; }
    public byte BlueChannel { get; set; }
    public byte GreenChannel { get; set; }
    public double DivideBy { get; set; }
    public byte MinRGB { get; set; }
    public byte MaxRGB { get; set; }
    public string WindowName { get; set; } = string.Empty;
    public ushort Row { get; set; }
    public ushort Column { get; set; }
}
