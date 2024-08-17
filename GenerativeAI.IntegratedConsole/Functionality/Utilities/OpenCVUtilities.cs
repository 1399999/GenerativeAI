namespace GenerativeAI.IntegratedConsole.Functionality.Utilities;

public static class OpenCVUtilities
{
    //// Import the DLL (containing the function we need) and define the method corresponding to the native function.
    //[DllImport("C:\\Users\\mzheb\\source\\repos\\GenerativeAI\\x64\\Debug\\CppTest.dll")]
    //public static extern void GetImgColor([MarshalAs(UnmanagedType.LPStr)] string path);

    //[DllImport("C:\\Users\\mzheb\\source\\repos\\GenerativeAI\\x64\\Debug\\CppTest.dll")]
    //public static extern void WriteToFile([MarshalAs(UnmanagedType.LPStr)] string path);

    const string DllPath = "C:\\Users\\mzheb\\source\\repos\\GenerativeAI\\x64\\Debug\\GenerativeAI.OpenCVUtils.dll";

    // Standard functions.

    // Function ID: 0.
    // Description: Gets an image from the path specified in color.
    // Paramater (path): The path, which the image is going to be read.
    [DllImport(DllPath)]
    public static extern void GetImgColor([MarshalAs(UnmanagedType.LPStr)] string path);

    // Function ID: 1.
    // Description: Gets an image from the path specified in grayscale.
    // Paramater (path): The path, which the image is going to be read.
    [DllImport(DllPath)]
    public static extern void GetImgGrayscale([MarshalAs(UnmanagedType.LPStr)] string path);

    // Function ID: 2.
    // Description: Creates a rectangle from the specified parameters.
    // Paramater (width, height): The dimensions for the rectangle.
    // Paramaters (r, g, b): The color of the rectangle.
    // Format (CV_8UC3): CV_[The number of bits per item][Signed or Unsigned][Type Prefix]C[The channel number].
    // Example: CreateRect(100, 100, 0, 0, 0);
    [DllImport(DllPath)]
    public static extern void CreateRect(int width, int height, int r, int g, int b);

    // Function ID: 3.
    // Description: Writes the image stored inside "inputImg" to the specified path.
    // Paramater (path): The path, which the image is going to be written.
    [DllImport(DllPath)]
    public static extern void WriteToFile([MarshalAs(UnmanagedType.LPStr)] string path);

    // Function ID: 4.
    // Description: Creates an array of ones from the specified paramaters, that can be divided by "divideBy" to produce a needed value of each cell of the array.
    // Paramater (width): The width for the image.
    // Paramater (height): The height for the image.
    // Paramater (divideBy): The value for dividing the image.
    [DllImport(DllPath)]
    public static extern void CreateArrayOnes(int width, int height, double divideBy);

    // Function ID: 5.
    // Description: Creates an array of ones from the specified paramaters.
    // Paramater (width): The width for the image.
    // Paramater (height): The height for the image.
    [DllImport(DllPath)]
    public static extern void CreateArrayZeros(int width, int height);

    // Function ID: 6.
    // Description: Creates an array of ones from the specified paramaters.
    // Paramater (input): All pixels of the image.
    //[DllImport(DllPath)]
    //public static extern void CreateManualArray(Mat_<double> input);

    // Function ID: 7.
    // Description: Gets a row from an image.
    // Paramater (img): The input image.
    // Paramater (row): The row of the image that will be extracted.
    // Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    public static extern void GetRow(int row);

    // Function ID: 8.
    // Description: Creates an array with random values using the specified dimensions.
    // Paramater (width): The width of the image.
    // Paramater (height): The height of the image.
    // Paramater (min): Minimum rgb grayscale value.
    // Paramater (max): Maximum rgb grayscale value.
    [DllImport(DllPath)]
    public static extern void CreateRandomArray(int width, int height, int min, int max);

    // Function ID: 9.
    // Description: Selects a portion of an image.
    // Paramater (x1): The x coordinate for the first set of coordinates.
    // Paramater (y1): The y coordinate for the first set of coordinates.
    // Paramater (x2): The x coordinate for the second set of coordinates.
    // Paramater (y2): The y coordinate for the second set of coordinates.
    [DllImport(DllPath)]
    public static extern void GetRegionOfInterest(int x1, int y1, int x2, int y2);

    // Function ID: 10.
    // Description: Displays a window which shows the standard image.
    // Paramater (winddowName): The name of the displayed window.
    [DllImport(DllPath)]
    public static extern void DisplayWindow([MarshalAs(UnmanagedType.LPStr)] string winddowName);

    // Debug functions.

    [DllImport(DllPath)]
    public static extern void DebugCheckImageEmpty();

    public static void Test()
    {
        string path = "C:\\Users\\mzheb\\Downloads\\GIlcQIOXMAAWm3D - Copy (2).jpg";
        Random random = new Random();

        GetImgColor(path);
        WriteToFile(UtilityFunctions.GetNextOutputPath());

        DebugCheckImageEmpty();

        GetImgGrayscale(path);
        WriteToFile(UtilityFunctions.GetNextOutputPath());

        CreateRect(random.Next(1, 250), random.Next(1, 250), random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        WriteToFile(UtilityFunctions.GetNextOutputPath());

        CreateArrayOnes(random.Next(1, 250), random.Next(1, 250), random.NextDouble());
        WriteToFile(UtilityFunctions.GetNextOutputPath());

        CreateArrayZeros(random.Next(1, 250), random.Next(1, 250));
        WriteToFile(UtilityFunctions.GetNextOutputPath());

        GetRow(0);
        WriteToFile(UtilityFunctions.GetNextOutputPath());

        CreateRandomArray(random.Next(1, 250), random.Next(1, 250), random.Next(1, 127), random.Next(128, 255));
        WriteToFile(UtilityFunctions.GetNextOutputPath());

        GetImgColor(path);
        GetRegionOfInterest(random.Next(1, 250), random.Next(1, 250), random.Next(1, 250), random.Next(1, 250));
        WriteToFile(UtilityFunctions.GetNextOutputPath());

        DisplayWindow("OpenCV Window");
    }
}
