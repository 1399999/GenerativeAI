using System;

namespace GenerativeAI.IntegratedConsole.Functionality.Utilities;

public static class OpenCVUtilities
{
    const string DllPath = "C:\\Users\\mzheb\\source\\repos\\GenerativeAI\\x64\\Debug\\GenerativeAI.OpenCVAPI.dll";

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
    // Recemondation: To be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawDisplayWindow([MarshalAs(UnmanagedType.LPStr)] string winddowName);

    // Function ID: 11.
    // Description: Gets a column from an image.
    // Paramater (col): The row of the image that will be extracted.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawGetColumn(int row);

    // Function ID: 12.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawApplyMaskOnePixel(char[] list);

    // Function ID: 13.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawApplyMaskTwoPixels(char[] list);

    // Function ID: 15.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawApplyMaskThreePixels(char[] list);

    // Function ID: 16.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawApplyMaskFourPixels(char[] list);

    // Function ID: 17.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawApplyMaskFivePixels(char[] list);

    // Function ID: 18.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawApplyMaskSixPixels(char[] list);

    // Function ID: 19.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawApplyMaskSevenPixels(char[] list);

    // Function ID: 20.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawApplyMaskEightPixels(char[] list);

    // Function ID: 21.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawApplyMaskNinePixels(char[] list);

    // Function ID: 22.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawApplyMaskTenPixels(char[] list);

    //   // Function ID: 23.
    // [DllImport(DllPath)]
    //private static extern void GetIntensityGrayScale(int x, int y)
    //{
    //	Scalar intensity = standardImg.at<uchar>(Point(x, y));
    //	return intensity;
    //}

    //   // Function ID: 24.
    // [DllImport(DllPath)]
    //private static extern GetIntensityColor(int x, int y)
    //{
    //	Vec3b intensity = standardImg.at<Vec3b>(y, x);
    //	uchar blue = intensity.val[0];
    //	uchar green = intensity.val[1];
    //	uchar red = intensity.val[2];
    //}

    //   // Function ID: 25.
    // [DllImport(DllPath)]
    //private static extern void GetIntensityFloatColor(int x, int y)
    //{
    //	Vec3f intensity = standardImg.at<Vec3f>(y, x);
    //	float blue = intensity.val[0];
    //	float green = intensity.val[1];
    //	float red = intensity.val[2];
    //}

    // Function ID: 26.
    // Description: Converts a color image into a gray scale image.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void ConvertColorToGray();

    // Function ID: 27.
    // Description: Converts a color image into a color image with alpha.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void ConvertColorToColorAlpha();

    // Function ID: 28.
    // Description: Converts a color image into an HLS color image.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void ConvertColorToHLS();

    // Function ID: 29.
    // Description: Converts a color image into an HSV color image.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void ConvertColorToHSV();

    // Function ID: 30.
    // Description: Switches the r and g color channels.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void ConvertBRGToRGB();

    // Function ID: 31.
    // Description: Switches the r and g color channels and adds an alpha channel.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void ConvertBRGToRGBA();

    // Function ID: 32.
    // Description: Switches the r and g color channels and adds an alpha channel.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void ConvertGrayToRGB();

    // Function ID: 33.
    // Description: Converts a grayscale image into a color image.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void ConvertGrayToColor();

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
