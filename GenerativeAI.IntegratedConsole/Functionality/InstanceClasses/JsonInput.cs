namespace GenerativeAI.IntegratedConsole.Functionality.InstanceClasses;

// Does not currently inplement Json. 
public class JsonInput
{
    public string Seed { get; set; } = string.Empty;
    public string[] InputFiles { get; set; } = new string[] { };
    public string OutputFile { get; set; } = string.Empty;
    public double Alpha { get; set; }
    public double Beta { get; set; }
    public bool Grayscale { get; set; }
    public int EscapeCharInt { get; set; } = 27; // Escape key.
}
