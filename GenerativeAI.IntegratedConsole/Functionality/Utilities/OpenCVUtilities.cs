namespace GenerativeAI.IntegratedConsole.Functionality.Utilities;

public static class OpenCVUtilities
{
    #region Dll Imports

    const string DllPath = "C:\\Users\\mzheb\\source\\repos\\GenerativeAI\\x64\\Debug\\GenerativeAI.OpenCVAPI.dll";

    // Standard functions.

    // Function ID: 00.
    // Description: Gets an image from the path specified in color.
    // Paramater (path): The path, which the image is going to be read.
    [DllImport(DllPath)]
    private static extern void RawGetColorImg([MarshalAs(UnmanagedType.LPStr)] string path);

    // Function ID: 01.
    // Description: Gets an image from the path specified in grayscale.
    // Paramater (path): The path, which the image is going to be read.
    [DllImport(DllPath)]
    private static extern void RawGetGrayscaleImg([MarshalAs(UnmanagedType.LPStr)] string path);

    // Function ID: 02.
    // Description: Creates a rectangle from the specified parameters.
    // Paramater (width, height): The dimensions for the rectangle.
    // Paramaters (r, g, b): The color of the rectangle.
    // Format (CV_8UC3): CV_[The number of bits per item][Signed or Unsigned][Type Prefix]C[The channel number].
    // Example: CreateRect(100, 100, 0, 0, 0);
    [DllImport(DllPath)]
    private static extern void RawCreateRect(int width, int height, int r, int g, int b);

    // Function ID: 03.
    // Description: Writes the image stored inside "standardImg" to the specified path.
    // Paramater (path): The path, which the image is going to be written.
    [DllImport(DllPath)]
    private static extern void RawWriteToFile([MarshalAs(UnmanagedType.LPStr)] string path);

    // Function ID: 04.
    // Description: Creates an array of ones from the specified paramaters, that can be divided by "divideBy" to produce a needed value of each cell of the array.
    // Paramater (width): The width for the image.
    // Paramater (height): The height for the image.
    // Paramater (divideBy): The value for dividing the image.
    [DllImport(DllPath)]
    private static extern void RawCreateArrayOnes(int width, int height, double divideBy);

    // Function ID: 05.
    // Description: Creates an array of ones from the specified paramaters.
    // Paramater (width): The width for the image.
    // Paramater (height): The height for the image.
    [DllImport(DllPath)]
    private static extern void RawCreateArrayZeros(int width, int height);

    // Function ID: 06.
    // Description: Gets a row from an image.
    // Paramater (img): The input image.
    // Paramater (row): The row of the image that will be extracted.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawGetRow(int row);

    // Function ID: 07.
    // Description: Creates an array with random values using the specified dimensions.
    // Paramater (width): The width of the image.
    // Paramater (height): The height of the image.
    // Paramater (min): Minimum rgb grayscale value.
    // Paramater (max): Maximum rgb grayscale value.
    [DllImport(DllPath)]
    private static extern void RawCreateRandomArray(int width, int height, int min, int max);

    // Function ID: 08.
    // Description: Selects a portion of an image.
    // Paramater (x1): The x coordinate for the first set of coordinates.
    // Paramater (y1): The y coordinate for the first set of coordinates.
    // Paramater (x2): The x coordinate for the second set of coordinates.
    // Paramater (y2): The y coordinate for the second set of coordinates.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawGetRegionOfInterest(int x1, int y1, int x2, int y2);

    // Function ID: 09.
    // Description: Displays a window which shows the standard image.
    // Paramater (winddowName): The name of the displayed window.
    // Recemondation: To be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawDisplayWindow([MarshalAs(UnmanagedType.LPStr)] string winddowName);

    // Function ID: 10.
    // Description: Gets a column from an image.
    // Paramater (col): The row of the image that will be extracted.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawGetColumn(int row);

    // Function ID: 11.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawApplyMaskOnePixel(char[] list);

    // Function ID: 12.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawApplyMaskTwoPixels(char[] list);

    // Function ID: 13.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawApplyMaskThreePixels(char[] list);

    // Function ID: 15.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawApplyMaskFourPixels(char[] list);

    // Function ID: 16.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawApplyMaskFivePixels(char[] list);

    // Function ID: 17.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawApplyMaskSixPixels(char[] list);

    // Function ID: 18.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawApplyMaskSevenPixels(char[] list);

    // Function ID: 19.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawApplyMaskEightPixels(char[] list);

    // Function ID: 20.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawApplyMaskNinePixels(char[] list);

    // Function ID: 21.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawApplyMaskTenPixels(char[] list);

    // Function ID: 22.
    // Description: Converts a color image into a gray scale image.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawConvertColorToGray();

    // Function ID: 23.
    // Description: Converts a color image into a color image with alpha.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawConvertColorToColorAlpha();

    // Function ID: 24.
    // Description: Converts a color image into an HLS color image.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawConvertColorToHLS();

    // Function ID: 25.
    // Description: Converts a color image into an HSV color image.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawConvertColorToHSV();

    // Function ID: 26.
    // Description: Switches the r and g color channels.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawConvertBRGToRGB();

    // Function ID: 27.
    // Description: Switches the r and g color channels and adds an alpha channel.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawConvertBRGToRGBA();

    // Function ID: 28.
    // Description: Switches the r and g color channels and adds an alpha channel.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawConvertGrayToRGB();

    // Function ID: 29.
    // Description: Converts a grayscale image into a color image.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawConvertGrayToColor();

    // Function ID: 30.
    // Description: Increases the brightness of an image.
    // Paramater (alpha): The lower the value, the lower the brightness of the image, the higher the brighter the image, no transformation occurs at value 1.
    // Parameter (beta): Increases/decereases the brightness of the image after the image was tansformed with the alpha value.
    // Example Values: alpha: 0.1, beta: 30.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawIncreaseBrightness(double alpha, double beta);

    // Function ID: 31.
    // Description: Increases the brightness of an image and/or the saturation of that image?
    // Paramater (gamma): The higher the value, the lower the brightness of the image and higher satuartion, the lower the brighter the image and lower satuartion, no transformation occurs at value 1.
    // Example Values: gamma: 0.5.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawIncreaseBrightnessSmart(double gamma);

    // Function ID: 32.
    // Description: Adds a constant (one color) border around an image.
    // Paramaters (top, bottom, left, right): The direction of pixels in the margin.
    // Paramaters (r, b, g): The color of the border.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawAddConstMargin(int top, int bottom, int left, int right, int r, int g, int b);

    // Function ID: 33.
    // Description: Adds a mirror like border around an image.
    // Paramaters (top, bottom, left, right): The direction of pixels in the margin.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawAddMirrorMargin(int top, int bottom, int left, int right);

    // Function ID: 34.
    // Description: Adds a replicated border around an image.
    // Paramaters (top, bottom, left, right): The direction of pixels in the margin.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawAddReplicatedMargin(int top, int bottom, int left, int right);

    // Function ID: 35.
    // Description: Adds a wrapped border around an image.
    // Paramaters (top, bottom, left, right): The direction of pixels in the margin.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawAddWrapMargin(int top, int bottom, int left, int right);

    // Function ID: 36.
    // Description: Draws a hollow ellipse on an image.
    // Paramaters (centerX, centerY): center of the circle.
    // Paramaters (width, height): dimensions of the circle.
    // Paramater (thickness): The thickness of the curve.
    // Paramaters (startAngle, endAngle): The angles of the stand and end of a curve.
    // Paramaters (rgb): The color of the curve.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawDrawCurve(int centerX, int centerY, int width, int height, double angle, int thickness, double startAngle, double endAngle, int r, int g, int b);

    // Function ID: 37.
    // Description: Draws a filled circle on an image.
    // Paramters (centerX, centerY): The center of a circle.
    // Paramter (radius): The radius of a circle.
    // Paramters (r, g, b): The color of a circle.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawDrawFilledCircle(int centerX, int centerY, int radius, int r, int g, int b);

    // Function ID: 38.
    // Description: Draws a line from one set of coordinates to another.
    // Paramaters (startX, startY): The first set of coordinates.
    // Paramaters (endX, endY): The second set of coordinates.
    // Paramater (thickness): The thickness of the line.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawDrawLine(int startX, int startY, int endX, int endY, int thickness);

    // Function ID: 39.
    // Description: Draws a random line on the standard image.
    // Paramater (itterations): The number of times that the line will be drawn.
    // Paramater (x1, y1): The first set of coordinates that the rng will be based around.
    // Paramater (x2, y2): The second set of coordinates that the rng will be based around.
    // Paramters (r, g, b): The color of the line.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawDrawRandomLine(int itterations, int x1, int y1, int x2, int y2, int r, int g, int b, int thickness);

    // Function ID: 40.
    // Description: Draws a random line on the standard image with a random color.
    // Paramater (itterations): The number of times that the line will be drawn.
    // Paramater (x1, y1): The first set of coordinates that the rng will be based around.
    // Paramater (x2, y2): The second set of coordinates that the rng will be based around.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawDrawRandomLineRandomColor(int itterations, int x1, int y1, int x2, int y2, int thickness);

    // Function ID: 41.
    // Description: Draws a rectangle with random dimension.
    // Paramater (itterations): The number of times that the line will be drawn.
    // Paramater (x1, y1): The first set of coordinates of the in-bounds box that the lines will be allowed to spawn in.
    // Paramater (x2, y2): The second set of coordinates of the in-bounds box that the lines will be allowed to spawn in.
    // Paramters (r, g, b): The color of the rectangle.
    // Paramters (thickness): How thick the edges are of the rectangle.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawDrawRandomHollowRectangle(int itterations, int x1, int y1, int x2, int y2, int r, int g, int b, int thickness);

    // Function ID: 42.
    // Description: Draws a rectangle with random dimension.
    // Paramater (itterations): The number of times that the line will be drawn.
    // Paramater (x1, y1): The first set of coordinates of the in-bounds box that the lines will be allowed to spawn in.
    // Paramater (x2, y2): The second set of coordinates of the in-bounds box that the lines will be allowed to spawn in.
    // Paramters (r, g, b): The color of the rectangle.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawDrawRandomHollowRectangleRandomColor(int itterations, int x1, int y1, int x2, int y2, int thickness);

    // Function ID: 43.
    // Description: Displays text in a random position.
    // Paramater (itterations): The number of times that the text will be drawn.
    // Paramater (text): The text that will be displayed on the image.
    // Paramaters (x1, x2): The first set of coordinates that define the bounding box where text can spawn.
    // Paramaters (y1, y2): The second set of coordinates that define the bounding box where text can spawn.
    // Paramters (r, g, b): The color of the text.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawDisplayRandomTextPosition(int itterations, [MarshalAs(UnmanagedType.LPStr)] string text, int x1, int y1, int x2, int y2, int r, int g, int b);

    // Function ID: 44.
    // Description: Displays text in a random position, color and font.
    // Paramater (itterations): The number of times that the text will be drawn.
    // Paramater (text): The text that will be displayed on the image.
    // Paramaters (x1, x2): The first set of coordinates that define the bounding box where text can spawn.
    // Paramaters (y1, y2): The second set of coordinates that define the bounding box where text can spawn.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawDisplayRandomTextPositionRandomColor(int itterations, [MarshalAs(UnmanagedType.LPStr)] string text, int x1, int y1, int x2, int y2);

    // Function ID: 45.
    // Description: Blurs the standard image.
    // Paramater (blurSize): The higher the number, the more the blur.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawBlurImage(int blurSize);

    // Function ID: 46.
    // Description: Erodes the standard image using little rectangle shapes.
    // Paramater (erosionSize): The higher the number, the more the erosion.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawErodeImageRectangle(int erosionSize);

    // Function ID: 47.
    // Description: Erodes the standard image using little cross shapes.
    // Paramater (erosionSize): The higher the number, the more the erosion.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawErodeImageCross(int erosionSize);

    // Function ID: 48.
    // Description: Erodes the standard image using little ellipse shapes.
    // Paramater (erosionSize): The higher the number, the more the erosion.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawErodeImageEllipse(int erosionSize);

    // Function ID: 49.
    // Description: Erodes the standard image.
    // Paramater (erosionSize): The higher the number, the more the erosion.
    // Warning: Has to be used in conjunction with other methods.
    // May be the same thing as erode image cross.
    [DllImport(DllPath)]
    private static extern void RawErodeImage(int erosionSize);

    // Function ID: 50.
    // Description: Dialates the standard image using little rectangle shapes.
    // Paramater (dialationSize): The higher the number, the more the dialation.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawDialateImageRectangle(int dialationSize);

    // Function ID: 51.
    // Description: Dialates the standard image using little cross shapes.
    // Paramater (dialationSize): The higher the number, the more the dialation.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawDialateImageCross(int dialationSize);

    // Function ID: 52.
    // Description: Dialates the standard image using little ellipse shapes.
    // Paramater (dialationSize): The higher the number, the more the dialation.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawDialateImageEllipse(int dialationSize);

    // Function ID: 53.
    // Description: Dialates the standard image using little ellipse shapes.
    // Paramater (dialationSize): The higher the number, the more the dialation.
    // Warning: Has to be used in conjunction with other methods
    // May be the same thing as dialate image cross.
    [DllImport(DllPath)]
    private static extern void RawDialateImage(int dialationSize);

    // Function ID: 54.
    // Description: Also known as opening, removes the background noise from the image.
    // Paramater (kernelSize): The higher the number, the more background niose is removed.
    // Warning: Has to be used in conjunction with other methods.
    // Warning: The kernelSize has to be odd.
    [DllImport(DllPath)]
    private static extern void RawRemoveBackgroundNoise(int kernelSize);

    // Function ID: 55.
    // Description: If there are horizontal lines in an image, it extracts them.
    // Warning: Has to be used in conjunction with other methods.
    // Warning: Only works with grayscale images.
    [DllImport(DllPath)]
    private static extern void RawGetHorizontalLines();

    // Function ID: 56.
    // Description: If there are vertical lines in an image, it extracts them.
    // Warning: Has to be used in conjunction with other methods.
    // Warning: Only works with grayscale images.
    [DllImport(DllPath)]
    private static extern void RawGetVerticalLines();

    // Function ID: 57.
    // Description: Converts an image to either black or white without any shades of gray.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawConvertToBinary();

    // Function ID: 58.
    // Description: Converts an image to either black or white without any shades of gray and inverts the result.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawConvertToInverseBinary();

    // Function ID: 59.
    // Description: Smooths the detected edges of the image.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawSmoothEdges();

    // Function ID: 60.
    // Description: Turns any colors above the threshold value to white and the image itself will get brighter.
    // Paramter (thresholdValue): Any grayscale "rgb" values below that value will turn to white.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawLowThresholdImage(double thresholdValue);

    // Function ID: 61.
    // Description: Turns any colors above the threshold value to black and the image itself will get brighter.
    // Paramter (thresholdValue): Any grayscale "rgb" values below that value will turn to white.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawHighThresholdImage(double thresholdValue);

    // Function ID: 62.
    // Description: Detects and draws edges to the standard image, also known as hough line transform.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawDetectEdges();

    // Function ID: 63.
    // Description: Tilts the image using the angle paramter and scales it based on the scale paramater, also known as affline transformations.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawTiltImage(double angle, double scale);

    // Function ID: 64.
    // Description: Draws a filled triangle on the standard image with random sides, but fixed amount of sides.
    // Paramater (itterations): The number of polygons to spawn.
    // Paramaters (x1, x2): The first set of bounds where the polygons can spawn.
    // Paramaters (y1, y2): The second set of bounds where the polygons can spawn.
    // Warning: This function is unfinished.
    [DllImport(DllPath)]
    private static extern void RawDrawRandomFilledTriangles(int itterations, int x1, int y1, int x2, int y2);

    // Function ID: 65.
    // Description: Draws a holllow triangle on the standard image with random sides, but fixed amount of sides.
    // Paramater (itterations): The number of polygons to spawn.
    // Paramaters (x1, x2): The first set of bounds where the polygons can spawn.
    // Paramaters (y1, y2): The second set of bounds where the polygons can spawn.
    // Warning: This function is unfinished.
    [DllImport(DllPath)]
    private static extern void RawDrawRandomHollowTriangles(int itterations, int x1, int y1, int x2, int y2);

    // Function ID: 66.
    // Description: Gets and draws contours around the edges.
    // Paramater (thresh): The higher the number the more contours.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawGetContours(int thresh);

    // Function ID: 67.
    // Description: Draws a contour around the edges it detects.
    // Paramater (thresh): The higher the number the more contours.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawGetConvexHull(double thresh);

    // Function ID: 68.
    // Description: Splits the image apart into multiple layers.
    // Warning: Has to be used in conjunction with other methods.
    [DllImport(DllPath)]
    private static extern void RawWatershedImage();

    // Function ID: 69.
    // Description: Gets and draws the corners detected in the image.
    // Paramater (maxCorners): The maximum amount of corners that the function will detect.
    // Warning: Has to be used in conjunction with other methods.
    // Warning: Only works with grayscale images.
    [DllImport(DllPath)]
    private static extern void RawGetCorners(int maxCorners);

    #endregion
    #region Testing Function

    public static void Test()
    {
        string path = "C:\\Users\\mzheb\\Downloads\\GIlcQIOXMAAWm3D - Copy (2).jpg";
        Random random = new Random();

        RawGetColorImg(path);
        RawWriteToFile(UtilityFunctions.GetNextOutputPath());

        RawGetGrayscaleImg(path);
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

        RawGetColorImg(path);
        RawGetRegionOfInterest(random.Next(1, 250), random.Next(1, 250), random.Next(1, 250), random.Next(1, 250));
        RawWriteToFile(UtilityFunctions.GetNextOutputPath());

        RawDisplayWindow("OpenCV Window");

        RawGetColumn(0);
        RawWriteToFile(UtilityFunctions.GetNextOutputPath());
    }

    #endregion
    #region Export Functions

    public static void GetImgColor(string path)
    {
        if (SystemModel.Work)
        {
            if (ValidatePath(path))
            {
                InputModel.IsImgColor = true;

                RawGetColorImg(path);
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
                InputModel.IsImgColor = false;

                RawGetGrayscaleImg(path);
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
                RawWriteToFile(path);
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

    public static void ConvertColorToGray()
    {
        if (SystemModel.Work)
        {
            if (InputModel.IsImgColor)
            {
                RawConvertColorToGray();
            }

            else
            {
                Program.WriteError("The image is not in a color format to convert it to grayscale.");
            }
        }
    }

    public static void ConvertColorToColorAlpha()
    {
        if (SystemModel.Work)
        {
            if (InputModel.IsImgColor)
            {
                RawConvertColorToColorAlpha();
            }

            else
            {
                Program.WriteError("The image is not in a color format to add an alpha channel to it.");
            }
        }
    }

    public static void ConvertColorToHLS()
    {
        if (SystemModel.Work)
        {
            if (InputModel.IsImgColor)
            {
                RawConvertColorToHLS();
            }

            else
            {
                Program.WriteError("The image is not in a color format to convert it to HLS.");
            }
        }
    }

    public static void ConvertColorToHSV()
    {
        if (SystemModel.Work)
        {
            if (InputModel.IsImgColor)
            {
                RawConvertColorToHSV();
            }

            else
            {
                Program.WriteError("The image is not in a color format to convert it to HSV.");
            }
        }
    }

    public static void SwitchColorChannels()
    {
        if (SystemModel.Work)
        {
            if (InputModel.IsImgColor)
            {
                RawConvertBRGToRGB();
            }

            else
            {
                Program.WriteError("The image does not have enogh color channels to switch them.");
            }
        }
    }

    public static void SwitchColorChannelsAlpha()
    {
        if (SystemModel.Work)
        {
            if (InputModel.IsImgColor)
            {
                RawConvertBRGToRGBA();
            }

            else
            {
                Program.WriteError("The image does not have enogh color channels to switch them.");
            }
        }
    }

    public static void ConvertGrayToColorSwitchChannels()
    {
        if (SystemModel.Work)
        {
            if (!InputModel.IsImgColor)
            {
                RawConvertGrayToRGB();
            }

            else
            {
                Program.WriteError("The image is not in a grayscale format.");
            }
        }
    }

    public static void ConvertGrayToColor()
    {
        if (SystemModel.Work)
        {
            if (!InputModel.IsImgColor)
            {
                RawConvertGrayToColor();
            }

            else
            {
                Program.WriteError("The image is not in a grayscale format.");
            }
        }
    }

    public static void IncreaseBrightness(double alpha, double beta) // Dont know about validation for this.
    {
        if (SystemModel.Work)
        {
            RawIncreaseBrightness(alpha, beta);
        }
    }

    public static void IncreaseBrightnessSmart(double gamma) // Dont know about validation for this.
    {
        if (SystemModel.Work)
        {
            RawIncreaseBrightnessSmart(gamma);
        }
    }

    public static void AddConstMargin(ushort top, ushort bottom, ushort left, ushort right, byte r, byte g, byte b)
    {
        if (SystemModel.Work)
        {
            if (ValidateDimension(top) && ValidateDimension(bottom) && ValidateDimension(left) && ValidateDimension(right))
            {
                RawAddConstMargin(top, bottom, left, right, r, g, b);
            }
        }
    }

    public static void AddMirrorMargin(ushort top, ushort bottom, ushort left, ushort right)
    {
        if (SystemModel.Work)
        {
            if (ValidateDimension(top) && ValidateDimension(bottom) && ValidateDimension(left) && ValidateDimension(right))
            {
                RawAddMirrorMargin(top, bottom, left, right);
            }
        }
    }

    public static void AddReplicatedMargin(ushort top, ushort bottom, ushort left, ushort right)
    {
        if (SystemModel.Work)
        {
            if (ValidateDimension(top) && ValidateDimension(bottom) && ValidateDimension(left) && ValidateDimension(right))
            {
                RawAddReplicatedMargin(top, bottom, left, right);
            }
        }
    }

    public static void AddWrapMargin(ushort top, ushort bottom, ushort left, ushort right)
    {
        if (SystemModel.Work)
        {
            if (ValidateDimension(top) && ValidateDimension(bottom) && ValidateDimension(left) && ValidateDimension(right))
            {
                RawAddWrapMargin(top, bottom, left, right);
            }
        }
    }

    public static void DrawCurve(ushort centerX, ushort centerY, ushort width, ushort height, double angle, ushort thickness, double startAngle, double endAngle, byte r, byte g, byte b)
    {
        if (SystemModel.Work)
        {
            if (ValidateDimension(width) && ValidateDimension(height) && ValidateSubsection(centerX) && ValidateDimension(centerY) && ValidateAngle(angle) && ValidateAngle(startAngle) && ValidateAngle(endAngle) && ValidateDimension(thickness))
            {
                RawDrawCurve(centerX, centerY, width, height, angle, thickness, startAngle, endAngle, r, g, b);
            }
        }
    }

    public static void DrawFilledCircle(ushort centerX, ushort centerY, ushort radius, byte r, byte g, byte b)
    {
        if (SystemModel.Work)
        {
            if (ValidateDimension(centerX) && ValidateDimension(centerY) && ValidateDimension(radius))
            {
                RawDrawFilledCircle(centerX, centerY, radius, r, g, b);
            }
        }
    }

    public static void DrawLine(ushort startX, ushort startY, ushort endX, ushort endY, ushort thickness)
    {
        if (SystemModel.Work)
        {
            if (ValidateDimension(startX) && ValidateDimension(startY) && ValidateDimension(endX) && ValidateDimension(endY) && ValidateDimension(thickness))
            {
                RawDrawLine(startX, startY, endX, endY, thickness);
            }
        }
    }

    public static void DrawRandomLine(uint itterations, ushort x1, ushort y1, ushort x2, ushort y2, byte r, byte g, byte b, ushort thickness)
    {
        if (SystemModel.Work)
        {
            if (ValidateDimension(x1) && ValidateDimension(y1) && ValidateDimension(x2) && ValidateDimension(y2) && ValidateDimension(thickness))
            {
                RawDrawRandomLine((int) itterations, x1, y1, x2, y2, r, g, b, thickness);
            }
        }
    }

    public static void DrawRandomLineRandomColor(uint itterations, ushort x1, ushort y1, ushort x2, ushort y2, ushort thickness)
    {
        if (SystemModel.Work)
        {
            if (ValidateDimension(x1) && ValidateDimension(y1) && ValidateDimension(x2) && ValidateDimension(y2) && ValidateDimension(thickness))
            {
                RawDrawRandomLineRandomColor((int) itterations, x1, y1, x2, y2, thickness);
            }
        }
    }

    public static void DrawRandomHollowRectangle(uint itterations, ushort x1, ushort y1, ushort x2, ushort y2, byte r, byte g, byte b, ushort thickness)
    {
        if (SystemModel.Work)
        {
            if (ValidateDimension(x1) && ValidateDimension(y1) && ValidateDimension(x2) && ValidateDimension(y2) && ValidateDimension(thickness))
            {
                RawDrawRandomLineRandomColor((int) itterations, x1, y1, x2, y2, thickness);
            }
        }
    }

    public static void DrawRandomHollowRectangleRandomColor(uint itterations, ushort x1, ushort y1, ushort x2, ushort y2, ushort thickness)
    {
        if (SystemModel.Work)
        {
            if (ValidateDimension(x1) && ValidateDimension(y1) && ValidateDimension(x2) && ValidateDimension(y2) && ValidateDimension(thickness))
            {
                RawDrawRandomHollowRectangleRandomColor((int)itterations, x1, y1, x2, y2, thickness);
            }
        }
    }

    public static void DisplayRandomTextPosition(uint itterations, [MarshalAs(UnmanagedType.LPTStr)] string text, ushort x1, ushort y1, ushort x2, ushort y2, byte r, byte g, byte b)
    {
        if (SystemModel.Work)
        {
            if (ValidateDimension(x1) && ValidateDimension(y1) && ValidateDimension(x2) && ValidateDimension(y2))
            {
                RawDisplayRandomTextPosition((int)itterations, text, x1, y1, x2, y2, r, g, b);
            }
        }
    }

    public static void DisplayRandomTextPositionRandomColor(uint itterations, [MarshalAs(UnmanagedType.LPTStr)] string text, ushort x1, ushort y1, ushort x2, ushort y2)
    {
        if (SystemModel.Work)
        {
            if (ValidateDimension(x1) && ValidateDimension(y1) && ValidateDimension(x2) && ValidateDimension(y2))
            {
                RawDisplayRandomTextPositionRandomColor((int)itterations, text, x1, y1, x2, y2);
            }
        }
    }

    public static void BlurImage(ushort blurSize)
    {
        if (SystemModel.Work)
        {
            if (ValidateOddNumber(blurSize))
            {
                RawBlurImage(blurSize);
            }
        }
    }

    public static void ErodeImageRectangle(ushort blurSize)
    {
        if (SystemModel.Work)
        {
            if (ValidateOddNumber(blurSize))
            {
                RawErodeImageRectangle(blurSize);
            }
        }
    }

    public static void ErodeImageEllipse(ushort blurSize)
    {
        if (SystemModel.Work)
        {
            if (ValidateOddNumber(blurSize))
            {
                RawErodeImageEllipse(blurSize);
            }
        }
    }

    public static void ErodeImage(ushort blurSize)
    {
        if (SystemModel.Work)
        {
            if (ValidateOddNumber(blurSize))
            {
                RawErodeImage(blurSize);
            }
        }
    }

    public static void DialateImageRectangle(ushort blurSize)
    {
        if (SystemModel.Work)
        {
            if (ValidateOddNumber(blurSize))
            {
                RawDialateImageRectangle(blurSize);
            }
        }
    }

    public static void DialateImageCross(ushort blurSize)
    {
        if (SystemModel.Work)
        {
            if (ValidateOddNumber(blurSize))
            {
                RawDialateImageCross(blurSize);
            }
        }
    }

    public static void DialateImage(ushort blurSize)
    {
        if (SystemModel.Work)
        {
            if (ValidateOddNumber(blurSize))
            {
                RawDialateImage(blurSize);
            }
        }
    }

    public static void RemoveBackgroundNoise(ushort kernelSize)
    {
        if (SystemModel.Work)
        {
            if (ValidateOddNumber(kernelSize))
            {
                RawDialateImage(kernelSize);
            }
        }
    }

    public static void GetHorizontalLines()
    {
        if (SystemModel.Work)
        {
            RawGetHorizontalLines();
        }
    }

    public static void GetVerticalLines()
    {
        if (SystemModel.Work)
        {
            RawGetVerticalLines();
        }
    }

    public static void ConvertToBinary()
    {
        if (SystemModel.Work)
        {
            RawConvertToBinary();
        }
    }

    public static void ConvertToInverseBinary()
    {
        if (SystemModel.Work)
        {
            RawConvertToInverseBinary();
        }
    }

    public static void SmoothEdges()
    {
        if (SystemModel.Work)
        {
            RawSmoothEdges();
        }
    }

    public static void LowThresholdImage(byte thresholdValue)
    {
        if (SystemModel.Work)
        {
            RawLowThresholdImage(thresholdValue);
        }
    }

    public static void HighThresholdImage(byte thresholdValue)
    {
        if (SystemModel.Work)
        {
            RawHighThresholdImage(thresholdValue);
        }
    }

    public static void DetectEdges(byte thresholdValue)
    {
        if (SystemModel.Work)
        {
            RawDetectEdges();
        }
    }

    public static void TiltImage(double angle, double scale) // Scale will go unvalidated.
    {
        if (SystemModel.Work)
        {
            if (ValidateAngle(angle))
            {
                RawTiltImage(angle, scale);
            }
        }
    }

    //public static void DrawRandomFilledTriangles(uint itterations, ushort x1, ushort y1, ushort x2, ushort y2)
    //{
    //    if (SystemModel.Work)
    //    {
    //        if (ValidateDimension(x1) && ValidateDimension(y1) && ValidateDimension(x2) && ValidateDimension(y2))
    //        {
    //            RawDrawRandomFilledTriangles((int) itterations, x1, y1, x2, y2);
    //        }
    //    }
    //}

    //public static void DrawRandomHollowTriangles(uint itterations, ushort x1, ushort y1, ushort x2, ushort y2)
    //{
    //    if (SystemModel.Work)
    //    {
    //        if (ValidateDimension(x1) && ValidateDimension(y1) && ValidateDimension(x2) && ValidateDimension(y2))
    //        {
    //            RawDrawRandomHollowTriangles((int) itterations, x1, y1, x2, y2);
    //        }
    //    }
    //}

    public static void GetContours(byte thresh)
    {
        if (SystemModel.Work)
        {
            RawGetContours(thresh);
        }
    }

    public static void GetConvexHull(byte thresh)
    {
        if (SystemModel.Work)
        {
            RawGetConvexHull(thresh);
        }
    }

    public static void WatershedImage()
    {
        if (SystemModel.Work)
        {
            RawWatershedImage();
        }
    }

    public static void GetCorners(int maxCorners)
    {
        if (SystemModel.Work)
        {
            RawGetCorners(maxCorners);
        }
    }

    #endregion
    #region Validation

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

    public static bool ValidateAngle(double angle)
    {
        if (angle < 0 && angle > 360)
        {
            return true;
        }

        return false;
    }

    public static bool ValidateOddNumber(ushort num)
    {
        if (num % 2 != 0)
        {
            return false;
        }

        return true;
    }

    #endregion
}
