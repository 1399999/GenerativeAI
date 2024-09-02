namespace GenerativeAI.IntegratedConsole.Functionality.InstanceClasses;

public class JsonInput
{
    public OptionEnum FunctionType { get; set; }
    public int Order { get; set; }
    public string? InputPath { get; set; }
    public string? OutputPath { get; set; }
    public ushort? Width { get; set; }
    public ushort? Height { get; set; }
    public byte? RedChannel { get; set; }
    public byte? BlueChannel { get; set; }
    public byte? GreenChannel { get; set; }
    public double? DivideBy { get; set; }
    public byte? MinRGB { get; set; }
    public byte? MaxRGB { get; set; }
    public string? WindowName { get; set; } = string.Empty;
    public ushort Row { get; set; }
    public ushort Column { get; set; }
    public ushort X1 { get; set; }
    public ushort X2 { get; set; }
    public ushort Y1 { get; set; }
    public ushort Y2 { get; set; }
    public double Alpha { get; set; }
    public double Beta { get; set; }
    public double Gamma { get; set; }
    public ushort Top { get; set; }
    public ushort Bottom { get; set; }
    public ushort Left { get; set; }
    public ushort Right { get; set; }
    public ushort CenterX { get; set; }
    public ushort CenterY { get; set; }
    public ushort CirleWidth { get; set; }
    public ushort CirleHeight { get; set; }
    public double Angle { get; set; }
    public double StartAngle { get; set; }
    public double EndAngle { get; set; }
    public ushort Thickness { get; set; }
    public ushort Radius { get; set; }
    public uint Itterations { get; set; }
    public string Text { get; set; } = string.Empty;
    public ushort BlurSize { get; set; }
    public byte Threshold { get; set; }
    public double Scale { get; set; }
    public uint MaxCorners { get; set; }
}
