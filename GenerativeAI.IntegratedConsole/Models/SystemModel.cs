﻿namespace GenerativeAI.IntegratedConsole.Models;

public static class SystemModel
{
    public static string Seed { get; set; } = string.Empty;
    public static bool Testing { get; } = false; // Has to be turned on manually.
    public static bool Debug { get; set; } = true; // Has to be turned on manually.
    public static int LastVarNum { get; set; } = 0;
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
    };
}
