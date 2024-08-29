namespace GenerativeAI.IntegratedConsole.Models;

public static class SystemModel
{
    public static bool Testing { get; } = true; // Has to be turned on manually.
    public static bool Debug { get; set; } = true; // Has to be turned on manually.
    public static bool Work { get; set; } = true; // If off, the entire algorithm shuts down.
    public static JsonInput StaticInput { get; set; } = new() 
    {
        Seed = "00.10.08.03",
        InputPath = @"wetewrterw",
        Width = 100,
        Height = 100,
        DivideBy = 10,
        OutputPath = "",
        RedChannel = 100,
        GreenChannel = 100,
        BlueChannel = 100,
        MinRGB = 100,
        MaxRGB = 200,
        WindowName =  "Window Name",
        Row = 0,
        Column = 0,
        X1 = 0,
        Y1 = 0,
        X2 = 1,
        Y2 = 1,
        Alpha = 0.5,
        Beta = 0.5,
        Gamma = 0.5,
        Top = 10,
        Bottom = 10,
        Left = 10,
        Right = 10,
        CenterX = 100,
        CenterY = 100,
        CirleWidth = 100,
        CirleHeight = 100,
        Angle = 100,
        StartAngle = 100,
        EndAngle = 100,
        Thickness = 100,
        Radius = 100,
        Itterations = 5,
        Text = "",
        BlurSize = 9,
        Threshold = 10,
        Scale = 1.5,
        MaxCorners = 10,
    };
}
