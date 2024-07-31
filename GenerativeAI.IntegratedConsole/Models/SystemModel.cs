namespace GenerativeAI.IntegratedConsole.Models;

public static class SystemModel
{
    public static List<Variable> Variables { get; set; } = new();
    public static string Seed { get; set; } = string.Empty;
    public static bool Testing { get; } = false; // Has to be turned on manually.
    public static bool Debug { get; set; } = true; // Has to be turned on manually.
    public static int LastVarNum { get; set; } = 0;
    public static JsonInput StaticInput { get; set; } = new() 
    {
        Seed = "0.0.0",

        InputFiles = new string[]
        {
            @"C:\ComputerVisionCourse\ImgSaves\Img1.jpg"
        },

        Alpha = 0.5,
        Beta = 0.5,
        OutputFile = @"C:\GenerativeAITests\Img382.png",
    };
}
