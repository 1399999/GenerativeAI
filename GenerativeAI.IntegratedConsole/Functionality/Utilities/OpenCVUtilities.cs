namespace GenerativeAI.IntegratedConsole.Functionality.Utilities;

public static class OpenCVUtilities
{
    const string DllPath = "C:\\Users\\mzheb\\source\\repos\\GenerativeAI\\x64\\Debug\\GenerativeAI.OpenCVUtils.dll";

    // Standard functions.

    // Function ID: 0.
    // Description: Gets an image from the path specified in color.
    // Paramater (path): The path, which the image is going to be read.
    [DllImport(DllPath)]
    private static extern void RawGetImgColor([MarshalAs(UnmanagedType.LPStr)] string path);

    // Function ID: 1.
    // Description: Gets an image from the path specified in grayscale.
    // Paramater (path): The path, which the image is going to be read.
    [DllImport(DllPath)]
    private static extern void RawGetImgGrayscale([MarshalAs(UnmanagedType.LPStr)] string path);

    // Function ID: 2.
    // Description: Creates a rectangle from the specified parameters.
    // Paramater (width, height): The dimensions for the rectangle.
    // Paramaters (r, g, b): The color of the rectangle.
    // Format (CV_8UC3): CV_[The number of bits per item][Signed or Unsigned][Type Prefix]C[The channel number].
    // Example: CreateRect(100, 100, 0, 0, 0);
    [DllImport(DllPath)]
    private static extern void RawCreateRect(int width, int height, int r, int g, int b);

    // Function ID: 3.
    // Description: Writes the image stored inside "standardImg" to the specified path.
    // Paramater (path): The path, which the image is going to be written.
    [DllImport(DllPath)]
    private static extern void RawWriteToFile([MarshalAs(UnmanagedType.LPStr)] string path);

    // Function ID: 4.
    // Description: Creates an array of ones from the specified paramaters, that can be divided by "divideBy" to produce a needed value of each cell of the array.
    // Paramater (width): The width for the image.
    // Paramater (height): The height for the image.
    // Paramater (divideBy): The value for dividing the image.
    [DllImport(DllPath)]
    private static extern void RawCreateArrayOnes(int width, int height, double divideBy);

    // Function ID: 5.
    // Description: Creates an array of ones from the specified paramaters.
    // Paramater (width): The width for the image.
    // Paramater (height): The height for the image.
    [DllImport(DllPath)]
    private static extern void RawCreateArrayZeros(int width, int height);

    // Function ID: 6.
    // Description: Creates an array of ones from the specified paramaters.
    // Paramater (input): All pixels of the image.
    // Warning: Has to be used in conjunction with other methods.
    //[DllImport(DllPath)]
    //private static extern void CreateManualArray(Mat_<double> input);

    // Function ID: 7.
    // Description: Gets a row from an image.
    // Paramater (img): The input image.
    // Paramater (row): The row of the image that will be extracted.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawGetRow(int row);

    // Function ID: 8.
    // Description: Creates an array with random values using the specified dimensions.
    // Paramater (width): The width of the image.
    // Paramater (height): The height of the image.
    // Paramater (min): Minimum rgb grayscale value.
    // Paramater (max): Maximum rgb grayscale value.
    [DllImport(DllPath)]
    private static extern void RawCreateRandomArray(int width, int height, int min, int max);

    // Function ID: 9.
    // Description: Selects a portion of an image.
    // Paramater (x1): The x coordinate for the first set of coordinates.
    // Paramater (y1): The y coordinate for the first set of coordinates.
    // Paramater (x2): The x coordinate for the second set of coordinates.
    // Paramater (y2): The y coordinate for the second set of coordinates.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawGetRegionOfInterest(int x1, int y1, int x2, int y2);

    // Function ID: 10.
    // Description: Displays a window which shows the standard image.
    // Paramater (winddowName): The name of the displayed window.
    [DllImport(DllPath)]
    private static extern void RawDisplayWindow([MarshalAs(UnmanagedType.LPStr)] string winddowName);

    [DllImport(DllPath)]
    private static extern void RawGetColumn(int row);

    // Debug functions, since they take no paramters, they do not need validation.

    [DllImport(DllPath)]
    public static extern void DebugCheckImageEmpty();

    public static void Test()
    {
        string path = "C:\\Users\\mzheb\\Downloads\\GIlcQIOXMAAWm3D - Copy (2).jpg";
        Random random = new Random();

        RawGetImgColor(path);
        RawWriteToFile(UtilityFunctions.GetNextOutputPath());

        DebugCheckImageEmpty();

        RawGetImgGrayscale(path);
        RawWriteToFile(UtilityFunctions.GetNextOutputPath());

        RawCreateRect(random.Next(1, 250), random.Next(1, 250), random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        RawWriteToFile(UtilityFunctions.GetNextOutputPath());

        RawCreateArrayOnes(random.Next(1, 250), random.Next(1, 250), random.NextDouble());
        RawWriteToFile(UtilityFunctions.GetNextOutputPath());

        RawCreateArrayZeros(random.Next(1, 250), random.Next(1, 250));
        RawWriteToFile(UtilityFunctions.GetNextOutputPath());

        RawGetRow(0);
        RawWriteToFile(UtilityFunctions.GetNextOutputPath());

        RawCreateRandomArray(random.Next(1, 250), random.Next(1, 250), random.Next(1, 127), random.Next(128, 255));
        RawWriteToFile(UtilityFunctions.GetNextOutputPath());

        RawGetImgColor(path);
        RawGetRegionOfInterest(random.Next(1, 250), random.Next(1, 250), random.Next(1, 250), random.Next(1, 250));
        RawWriteToFile(UtilityFunctions.GetNextOutputPath());

        RawDisplayWindow("OpenCV Window");

        RawGetColumn(0);
        RawWriteToFile(UtilityFunctions.GetNextOutputPath());
    }

    public static void GetImgColor(string path)
    {
        if (SystemModel.Work)
        {
            if (ValidatePath(path))
            {
                RawGetImgColor(path);
            }

            else
            {
                Program.WriteLineError($"Could not access RawGetImgColor() due to an invalid path: {path}");
            }
        }
    }

    public static void GetImgGrayscale(string path)
    {
        if (SystemModel.Work)
        {
            if (ValidatePath(path))
            {
                RawGetImgGrayscale(path);
            }

            else
            {
                Program.WriteLineError($"Could not access RawGetImgGrayscale() due to an invalid path: {path}");
            }
        }
    }

    public static void CreateRect(ushort width, ushort height, byte r, byte g, byte b) // Paramters "r, g, b" will go unvalidated.
    {
        if (SystemModel.Work)
        {
            if (ValidateDimension(width) && ValidateDimension(height))
            {
                RawCreateRect((int)width, (int)height, r, g, b);
            }
        }
    }

    public static void WriteToFile(string path)
    {
        if (SystemModel.Work)
        {
            if (ValidateOutputPath(path))
            {
                RawWriteToFile(SystemModel.StaticInput.OutputPath);
            }
        }
    }

    public static void CreateArrayOnes(ushort width, ushort height, double divideBy) // Paramter "divideBy" will go unvalidated.
    {
        if (SystemModel.Work)
        {
            if (ValidateDimension(width) && ValidateDimension(height))
            {
                RawCreateArrayOnes((int)width, (int)height, divideBy);
            }
        }
    }

    public static void CreateArrayZeros(ushort width, ushort height)
    {
        if (SystemModel.Work)
        {
            if (ValidateDimension(width) && ValidateDimension(height))
            {
                RawCreateArrayZeros((int)width, (int)height);
            }
        }
    }

    public static void GetRow(ushort row) // Not fully finished.
    {
        if (SystemModel.Work)
        {
            if (ValidateSubsection(row))
            {
                RawGetRow(row);
            }
        }
    }

    public static void CreateRandomArray(ushort width, ushort height, byte min, byte max) // Paramters "min, max" will go unvalidated.
    {
        if (SystemModel.Work)
        {
            if (ValidateDimension(width) && ValidateDimension(height))
            {
                RawCreateRandomArray(width, height, min, max);
            }
        }
    }

    public static void GetRegionOfInterest(ushort x1, ushort y1, ushort x2, ushort y2) // Not fully finished.
    {
        if (SystemModel.Work)
        {
            if (ValidateSubsection(x1) && ValidateSubsection(y1) && ValidateSubsection(x2) && ValidateSubsection(y2))
            {
                RawGetRegionOfInterest((int)x1, (int)y1, (int)x2, (int)y2);
            }
        }
    }

    public static void DisplayWindow(string windowName) // No validation here.
    {
        if (SystemModel.Work)
        {
            RawDisplayWindow(windowName);
        }
    }

    public static void GetColumn(ushort col)
    {
        if (SystemModel.Work)
        {
            if (ValidateSubsection(col))
            {
                RawGetColumn(col);
            }
        }
    }

    public static bool ValidatePath(string path) => File.Exists(path);

    public static bool ValidateDimension(ushort dimension)
    {
        if (dimension == 0)
        {
            Program.WriteLineError("The specified dimension is zero.");

            return false;
        }

        if (dimension > 3480) 
        {
            Program.WriteLineWarning("The specified dimension is greater than 3480. (A 4k image is 3480x2160 pixels).");
            return Program.RequestPermission();
        }

        return true;
    }

    public static bool ValidateOutputPath(string path)
    {
        if (path == string.Empty)
        {
            SystemModel.StaticInput.OutputPath = UtilityFunctions.GetNextOutputPath();
        }

        if (File.Exists(path)) 
        {
            Program.WriteLineWarning($"The file '{path}' aldreay exists, if you press 'y' the program will override the file.");
            return Program.RequestPermission();
        }

        return true;
    }

    public static bool ValidateSubsection(ushort row)
    {
        return true;
    }
}
