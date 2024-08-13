using System.Runtime.InteropServices;

public partial class Program
{
    // Import the DLL (containing the function we need) and define the method corresponding to the native function.
    [DllImport("C:\\Users\\mzheb\\source\\repos\\GenerativeAI\\x64\\Debug\\CppTest.dll")]
    public static extern void GetImgColor([MarshalAs(UnmanagedType.LPStr)] string path);

    [DllImport("C:\\Users\\mzheb\\source\\repos\\GenerativeAI\\x64\\Debug\\CppTest.dll")]
    public static extern void WriteToFile([MarshalAs(UnmanagedType.LPStr)] string path);

    public static void Main(string[] args)
    {
        string path = "C:\\Users\\mzheb\\Downloads\\GIlcQIOXMAAWm3D - Copy (2).jpg";

        GetImgColor(path);
        WriteToFile("C:\\GenerativeAITests\\Img383.png");
    }
}
