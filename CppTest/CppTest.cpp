#include "OpenCVHeader.h"

int main(int argc, char** argv)
{
    return 0;
}

namespace OpenCVUtilities 
{
    Mat standardImg;

    // Function ID: 00.
    // Description: Gets an image from the path specified in color.
    // Paramater (path): The path, which the image is going to be read.
    EXTERN_DLL_EXPORT void RawGetImgColor(STRING path)
    {
        Mat img;
        img = imread(path, IMREAD_COLOR); // path
        
        standardImg = img;
    }

    // Function ID: 01.
    // Description: Gets an image from the path specified in grayscale.
    // Paramater (path): The path, which the image is going to be read.
	EXTERN_DLL_EXPORT void RawGetImgGrayscale(STRING path)
	{
		Mat img;
		img = imread(path, IMREAD_GRAYSCALE); // path

        standardImg = img;
	}

    // Function ID: 02.
    // Description: Creates a rectangle from the specified parameters.
    // Paramater (width, height): The dimensions for the rectangle.
    // Paramaters (r, g, b): The color of the rectangle.
    // Format (CV_8UC3): CV_[The number of bits per item][Signed or Unsigned][Type Prefix]C[The channel number].
    // Example: CreateRect(100, 100, 0, 0, 0);
    EXTERN_DLL_EXPORT void RawCreateRect(int width, int height, int r, int g, int b)
	{
		Mat rect(width, height, CV_8UC3, Scalar(b, g, r));
        standardImg = rect;
	}

    // Function ID: 03.
    // Description: Writes the image stored inside "standardImg" to the specified path.
    // Paramater (path): The path, which the image is going to be written.
    EXTERN_DLL_EXPORT void RawWriteToFile(STRING path)
    {
        imwrite(path, standardImg);
    }

    // Function ID: 04.
    // Description: Creates an array of ones from the specified paramaters, that can be divided by "divideBy" to produce a needed value of each cell of the array.
    // Paramater (width): The width for the image.
    // Paramater (height): The height for the image.
    // Paramater (divideBy): The value for dividing the image.
    EXTERN_DLL_EXPORT void RawCreateArrayOnes(int width, int height, double divideBy)
	{
		Mat o = Mat::ones(width, height, CV_32F) / divideBy;
        standardImg = o;
	}
    
    // Function ID: 05.
    // Description: Creates an array of ones from the specified paramaters.
    // Paramater (width): The width for the image.
    // Paramater (height): The height for the image.
    EXTERN_DLL_EXPORT void RawCreateArrayZeros(int width, int height)
	{
		Mat z = Mat::zeros(width, height, CV_8UC1);
        standardImg = z;
	}

    // Function ID: 06.
    // Description: Gets a row from an image.
    // Paramater (row): The row of the image that will be extracted.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawGetRow(int row)
	{
        if (standardImg.rows < row) // Width
        {
            cout << "[C++ Non-Fatal Error] The row value is outside of the image.";
        }

		Mat rowClone = standardImg.row(row).clone();
		standardImg = rowClone;
	}

    // Function ID: 07.
    // Description: Creates an array with random values using the specified dimensions.
    // Paramater (width): The width of the image.
    // Paramater (height): The height of the image.
    // Paramater (min): Minimum rgb grayscale value.
    // Paramater (max): Maximum rgb grayscale value.
    EXTERN_DLL_EXPORT void RawCreateRandomArray(int width, int height, int min, int max)
	{
		Mat r = Mat(width, height, CV_8UC3);
		randu(r, Scalar::all(min), Scalar::all(max));

        standardImg = r;
	}

    // Function ID: 08.
    // Description: Selects a portion of an image.
    // Paramater (x1): The x coordinate for the first set of coordinates.
    // Paramater (y1): The y coordinate for the first set of coordinates.
    // Paramater (x2): The x coordinate for the second set of coordinates.
    // Paramater (y2): The y coordinate for the second set of coordinates.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawGetRegionOfInterest(int x1, int y1, int x2, int y2)
	{
        if (standardImg.cols < x1 || standardImg.cols < x2) // Width
        {
            cout << "[C++ Non-Fatal Error] The x value is outside of the image.";
        }

        else if (standardImg.rows < y1 || standardImg.rows < y2) // Width
        {
            cout << "[C++ Non-Fatal Error] The y value is outside of the image.";
        }

        else 
        {
            Rect r(x1, x2, y1, y2);
            Mat smallImg = standardImg(r);

            standardImg = smallImg;
        }
	}

    // Function ID: 09.
    // Description: Displays a window which shows the standard image.
    // Paramater (winddowName): The name of the displayed window.
    // Recemondation: To be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawDisplayWindow(STRING winddowName)
	{
		namedWindow(winddowName, WINDOW_AUTOSIZE);
		imshow(winddowName, standardImg);
		waitKey();
	}

    // Function ID: 10.
    // Description: Gets a column from an image.
    // Paramater (col): The row of the image that will be extracted.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawGetColumn(int col)
    {
        if (standardImg.rows < col) // Width
        {
            cout << "[C++ Non-Fatal Error] The column value is outside of the image.";
        }

        Mat rowClone = standardImg.col(col).clone();
        standardImg = rowClone;
    }

    // Function ID: 11.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawApplyMaskOnePixel(char list[1])
    {
        Mat_<char> charList(1, 1);
        charList << list[0];

        Mat kernel = charList;
        filter2D(standardImg, standardImg, standardImg.depth(), kernel);
    }

    // Function ID: 12.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawApplyMaskTwoPixels(char list[4])
    {
        Mat_<char> charList(2, 2);
        charList << list[0], list[1], list[2], list[3];

        Mat kernel = charList;
        filter2D(standardImg, standardImg, standardImg.depth(), kernel);
    }

    // Function ID: 13.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawApplyMaskThreePixels(char list[9])
    {
        Mat_<char> charList(3, 3);
        charList << list[0], list[1], list[2], list[3], list[4], list[5], list[6], list[7], list[8];

        Mat kernel = charList;
        filter2D(standardImg, standardImg, standardImg.depth(), kernel);
    }

    // Function ID: 15.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawApplyMaskFourPixels(char list[16])
    {
        Mat_<char> charList(4, 4);
        charList << list[0], list[1], list[2], list[3], list[4], list[5], list[6], list[7], list[8], list[9], 
            list[10], list[11], list[12], list[13], list[14], list[15];

        Mat kernel = charList;
        filter2D(standardImg, standardImg, standardImg.depth(), kernel);
    }

    // Function ID: 16.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawApplyMaskFivePixels(char list[25])
    {
        Mat_<char> charList(5, 5);
        charList << list[0], list[1], list[2], list[3], list[4], list[5], list[6], list[7], list[8], list[9],
            list[10], list[11], list[12], list[13], list[14], list[15], list[16], list[17], list[18], list[19], 
            list[20], list[21], list[22], list[23], list[24];

        Mat kernel = charList;
        filter2D(standardImg, standardImg, standardImg.depth(), kernel);
    }

    // Function ID: 17.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawApplyMaskSixPixels(char list[36])
    {
        Mat_<char> charList(6, 6);
        charList << list[0], list[1], list[2], list[3], list[4], list[5], list[6], list[7], list[8], list[9],
            list[10], list[11], list[12], list[13], list[14], list[15], list[16], list[17], list[18], list[19],
            list[20], list[21], list[22], list[23], list[24], list[25], list[26], list[27], list[28], list[29],
            list[30], list[31], list[32], list[33], list[34], list[35];

        Mat kernel = charList;
        filter2D(standardImg, standardImg, standardImg.depth(), kernel);
    }

    // Function ID: 18.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawApplyMaskSevenPixels(char list[49])
    {
        Mat_<char> charList(7, 7);
        charList << list[0], list[1], list[2], list[3], list[4], list[5], list[6], list[7], list[8], list[9],
            list[10], list[11], list[12], list[13], list[14], list[15], list[16], list[17], list[18], list[19],
            list[20], list[21], list[22], list[23], list[24], list[25], list[26], list[27], list[28], list[29],
            list[30], list[31], list[32], list[33], list[34], list[35], list[36], list[37], list[38], list[39],
            list[40], list[41], list[42], list[43], list[44], list[45], list[46], list[47], list[48];

        Mat kernel = charList;
        filter2D(standardImg, standardImg, standardImg.depth(), kernel);
    }

    // Function ID: 19.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawApplyMaskEightPixels(char list[64])
    {
        Mat_<char> charList(8, 8);
        charList << list[0], list[1], list[2], list[3], list[4], list[5], list[6], list[7], list[8], list[9],
            list[10], list[11], list[12], list[13], list[14], list[15], list[16], list[17], list[18], list[19],
            list[20], list[21], list[22], list[23], list[24], list[25], list[26], list[27], list[28], list[29],
            list[30], list[31], list[32], list[33], list[34], list[35], list[36], list[37], list[38], list[39],
            list[40], list[41], list[42], list[43], list[44], list[45], list[46], list[47], list[48], list[49],
            list[50], list[51], list[52], list[53], list[54], list[55], list[56], list[57], list[58], list[59],
            list[60], list[61], list[62], list[63];

        Mat kernel = charList;
        filter2D(standardImg, standardImg, standardImg.depth(), kernel);
    }

    // Function ID: 20.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawApplyMaskNinePixels(char list[81])
    {
        Mat_<char> charList(9, 9);
        charList << list[0], list[1], list[2], list[3], list[4], list[5], list[6], list[7], list[8], list[9],
            list[10], list[11], list[12], list[13], list[14], list[15], list[16], list[17], list[18], list[19],
            list[20], list[21], list[22], list[23], list[24], list[25], list[26], list[27], list[28], list[29],
            list[30], list[31], list[32], list[33], list[34], list[35], list[36], list[37], list[38], list[39],
            list[40], list[41], list[42], list[43], list[44], list[45], list[46], list[47], list[48], list[49],
            list[50], list[51], list[52], list[53], list[54], list[55], list[56], list[57], list[58], list[59],
            list[60], list[61], list[62], list[63], list[64], list[65], list[66], list[67], list[68], list[69],
            list[70], list[71], list[72], list[73], list[74], list[75], list[76], list[77], list[78], list[79],
            list[80];

        Mat kernel = charList;
        filter2D(standardImg, standardImg, standardImg.depth(), kernel);
    }

    // Function ID: 21.
    // Description: Applies a 1x1 pixel mask over the buffered image.
    // Paramater (list): The mask itself.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawApplyMaskTenPixels(char list[100])
    {
        Mat_<char> charList(10, 10);
        charList << list[0], list[1], list[2], list[3], list[4], list[5], list[6], list[7], list[8], list[9],
            list[10], list[11], list[12], list[13], list[14], list[15], list[16], list[17], list[18], list[19],
            list[20], list[21], list[22], list[23], list[24], list[25], list[26], list[27], list[28], list[29],
            list[30], list[31], list[32], list[33], list[34], list[35], list[36], list[37], list[38], list[39],
            list[40], list[41], list[42], list[43], list[44], list[45], list[46], list[47], list[48], list[49],
            list[50], list[51], list[52], list[53], list[54], list[55], list[56], list[57], list[58], list[59],
            list[60], list[61], list[62], list[63], list[64], list[65], list[66], list[67], list[68], list[69],
            list[70], list[71], list[72], list[73], list[74], list[75], list[76], list[77], list[78], list[79],
            list[80], list[81], list[82], list[83], list[84], list[85], list[86], list[87], list[88], list[89],
            list[90], list[91], list[92], list[93], list[94], list[95], list[96], list[97], list[98], list[99],
            list[100];

        Mat kernel = charList;
        filter2D(standardImg, standardImg, standardImg.depth(), kernel);
    }

    // Function ID: 22.
    // Description: Converts a color image into a gray scale image.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawConvertColorToGray()
	{
		cvtColor(standardImg, standardImg, COLOR_BGR2GRAY);
	}

    // Function ID: 23.
    // Description: Converts a color image into a color image with alpha.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawConvertColorToColorAlpha()
	{
		cvtColor(standardImg, standardImg, COLOR_BGR2BGRA);
	}

    // Function ID: 24.
    // Description: Converts a color image into an HLS color image.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawConvertColorToHLS()
	{
		cvtColor(standardImg, standardImg, COLOR_BGR2HLS);
	}

    // Function ID: 25.
    // Description: Converts a color image into an HSV color image.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawConvertColorToHSV()
	{
		cvtColor(standardImg, standardImg, COLOR_BGR2HSV);
	}

    // Function ID: 26.
    // Description: Switches the r and g color channels.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawConvertBRGToRGB()
	{
		cvtColor(standardImg, standardImg, COLOR_BGR2RGB);
	}

    // Function ID: 27.
    // Description: Switches the r and g color channels and adds an alpha channel.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawConvertBRGToRGBA()
    {
        cvtColor(standardImg, standardImg, COLOR_BGR2RGBA);
    }

    // Function ID: 28.
    // Description: Switches the r and g color channels and adds an alpha channel.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawConvertGrayToRGB()
	{
		cvtColor(standardImg, standardImg, COLOR_GRAY2RGB);
	}

    // Function ID: 29.
    // Description: Converts a grayscale image into a color image.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawConvertGrayToColor()
	{
		cvtColor(standardImg, standardImg, COLOR_GRAY2BGR);
	}

    // Function ID: 30.
    // Description: Increases the brightness of an image.
	// Paramater (alpha): The lower the value, the lower the brightness of the image, the higher the brighter the image, no transformation occurs at value 1.
	// Parameter (beta): Increases/decereases the brightness of the image after the image was tansformed with the alpha value.
	// Example Values: alpha: 0.1, beta: 30.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawIncreaseBrightness(double alpha, double beta)
	{
		// Alpha is contrast, beta is brightness.
		Mat new_image = Mat::zeros(standardImg.size(), standardImg.type());

		for (int y = 0; y < standardImg.rows; y++)
		{
			for (int x = 0; x < standardImg.cols; x++)
			{
				for (int c = 0; c < standardImg.channels(); c++)
				{
					new_image.at<Vec3b>(y, x)[c] = saturate_cast<uchar>(alpha * standardImg.at<Vec3b>(y, x)[c] + beta);
				}
			}
		}

        standardImg = new_image;
	}

	// Function ID: 31.
	// Description: Increases the brightness of an image and/or the saturation of that image?
	// Paramater (gamma): The higher the value, the lower the brightness of the image and higher satuartion, the lower the brighter the image and lower satuartion, no transformation occurs at value 1.
	// Example Values: gamma: 0.5.
	// Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawIncreaseBrightnessSmart(double gamma)
	{
		Mat lookUpTable(1, 256, CV_8U);
		uchar* p = lookUpTable.ptr();

		for (int i = 0; i < 256; ++i)
		{
			p[i] = saturate_cast<uchar>(pow(i / 255.0, gamma) * 255.0);
		}

		Mat res = standardImg.clone();
		LUT(standardImg, lookUpTable, res);

        standardImg = res;
	}

    // Function ID: 32.
    // Description: Adds a constant (one color) border around an image.
	// Paramaters (top, bottom, left, right): The direction of pixels in the margin.
	// Paramaters (r, b, g): The color of the border.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawAddConstMargin(int top, int bottom, int left, int right, int r, int g, int b)
	{
		if (top < standardImg.rows || bottom < standardImg.rows || left < standardImg.cols || right < standardImg.cols)
		{
			copyMakeBorder(standardImg, standardImg, top, bottom, left, right, BORDER_CONSTANT, Scalar(b, g, r));
		}

		else
		{
			WriteLineError("The specified dimensions where outside of the image dimensions.");
		}
	}

	// Function ID: 33.
	// Description: Adds a mirror like border around an image.
	// Paramaters (top, bottom, left, right): The direction of pixels in the margin.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawAddMirrorMargin(int top, int bottom, int left, int right)
	{
		if (top < standardImg.rows || bottom < standardImg.rows || left < standardImg.cols || right < standardImg.cols)
		{
			copyMakeBorder(standardImg, standardImg, top, bottom, left, right, BORDER_DEFAULT);
		}

		else
		{
			WriteLineError("The specified dimensions where outside of the image dimensions.");
		}
	}

	// Function ID: 34.
	// Description: Adds a replicated border around an image.
	// Paramaters (top, bottom, left, right): The direction of pixels in the margin.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawAddReplicatedMargin(int top, int bottom, int left, int right)
	{
		if (top < standardImg.rows || bottom < standardImg.rows || left < standardImg.cols || right < standardImg.cols)
		{
			copyMakeBorder(standardImg, standardImg, top, bottom, left, right, BORDER_REPLICATE);
		}

		else
		{
			WriteLineError("The specified dimensions where outside of the image dimensions.");
		}
	}

	// Function ID: 35.
	// Description: Adds a wrapped border around an image.
	// Paramaters (top, bottom, left, right): The direction of pixels in the margin.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawAddWrapMargin(int top, int bottom, int left, int right)
	{
		if (top < standardImg.rows || bottom < standardImg.rows || left < standardImg.cols || right < standardImg.cols)
		{
			copyMakeBorder(standardImg, standardImg, top, bottom, left, right, BORDER_WRAP, Scalar(0, 0, 0));
		}

		else
		{
			WriteLineError("The specified dimensions where outside of the image dimensions.");
		}
	}

    // Function ID: 36.
    // Description: Draws a hollow ellipse on an image.
	// Paramaters (centerX, centerY): center of the circle.
	// Paramaters (width, height): dimensions of the circle.
	// Paramater (thickness): The thickness of the curve.
	// Paramaters (startAngle, endAngle): The angles of the stand and end of a curve.
	// Paramaters (rgb): The color of the curve.
    // Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawDrawCurve(int centerX, int centerY, int width, int height, double angle, int thickness, double startAngle, double endAngle, int r, int g, int b)
	{
		if (centerX < standardImg.rows || centerY < standardImg.rows || width < standardImg.cols || height < standardImg.cols || thickness < standardImg.rows || thickness < standardImg.cols)
		{
			ellipse(standardImg,
				Point(centerX, centerY),
				Size(width, height),
				angle,
				startAngle,
				endAngle,
				Scalar(b, g, r),
				thickness,
				1);
		}

		else
		{
			WriteLineError("The specified dimensions where outside of the image dimensions.");
		}
	}

    // Function ID: 37.
    // Description: Draws a filled circle on an image.
	// Paramters (centerX, centerY): The center of a circle.
	// Paramter (radius): The radius of a circle.
	// Paramters (r, g, b): The color of a circle.
    // Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawDrawFilledCircle(int centerX, int centerY, int radius, int r, int g, int b)
	{
		if (centerX < standardImg.rows || centerY < standardImg.rows)
		{
			circle(standardImg,
				Point(centerX, centerY),
				radius,
				Scalar(b, g, r),
				FILLED,
				LINE_8);
		}

		else
		{
			WriteLineError("The specified dimensions where outside of the image dimensions.");
		}
	}

    // Function ID: 38.
    // Description: Draws a line from one set of coordinates to another.
	// Paramaters (startX, startY): The first set of coordinates.
	// Paramaters (endX, endY): The second set of coordinates.
	// Paramater (thickness): The thickness of the line.
    // Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawDrawLine(int startX, int startY, int endX, int endY, int thickness)
	{
		if (startX < standardImg.rows || startY < standardImg.rows || endX < standardImg.rows || endY < standardImg.rows)
		{
			int lineType = LINE_8;

			line(standardImg,
				Point(startX, startY),
				Point(endX, endY),
				Scalar(0, 0, 0),
				thickness,
				lineType);
		}

		else
		{
			WriteLineError("The specified dimensions where outside of the image dimensions.");
		}
	}

    // Description: Gets a random color.
	// Basically a utility function.
	Scalar GetRandomColor(RNG& rng)
	{
		int icolor = (unsigned)rng;
		return Scalar(icolor & 255, (icolor >> 8) & 255, (icolor >> 16) & 255);
	}

    // Function ID: 39.
    // Description: Draws a random line on the standard image.
	// Paramater (itterations): The number of times that the line will be drawn.
	// Paramater (x1, y1): The first set of coordinates that the rng will be based around.
	// Paramater (x2, y2): The second set of coordinates that the rng will be based around.
	// Paramters (r, g, b): The color of the line.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawDrawRandomLine(int itterations, int x1, int y1, int x2, int y2, int r, int g, int b, int thickness)
	{
		RNG rng(rand());

		Point pt1, pt2;

		for (int i = 0; i < itterations; i++)
		{
			pt1.x = rng.uniform(x1, x2);
			pt1.y = rng.uniform(y1, y2);
			pt2.x = rng.uniform(x1, x2);
			pt2.y = rng.uniform(y1, y2);

			line(standardImg, pt1, pt2, Scalar(b, g, r), thickness, 8);
		}
	}

	// Function ID: 40.
    // Description: Draws a random line on the standard image with a random color.
	// Paramater (itterations): The number of times that the line will be drawn.
	// Paramater (x1, y1): The first set of coordinates that the rng will be based around.
	// Paramater (x2, y2): The second set of coordinates that the rng will be based around.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawDrawRandomLineRandomColor(int itterations, int x1, int y1, int x2, int y2, int thickness)
	{
		RNG rng(rand());

		Point pt1, pt2;

        for (int i = 0; i < itterations; i++)
        {
            pt1.x = rng.uniform(x1, x2);
            pt1.y = rng.uniform(y1, y2);
            pt2.x = rng.uniform(x1, x2);
            pt2.y = rng.uniform(y1, y2);

            line(standardImg, pt1, pt2, GetRandomColor(rng), thickness, 8);
        }
	}

	// Function ID: 41.
	// Description: Draws a rectangle with random dimension.
	// Paramater (itterations): The number of times that the line will be drawn.
	// Paramater (x1, y1): The first set of coordinates of the in-bounds box that the lines will be allowed to spawn in.
	// Paramater (x2, y2): The second set of coordinates of the in-bounds box that the lines will be allowed to spawn in.
	// Paramters (r, g, b): The color of the rectangle.
	// Paramters (thickness): How thick the edges are of the rectangle.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawDrawRandomHollowRectangle(int itterations, int x1, int y1, int x2, int y2, int r, int g, int b, int thickness)
	{
		RNG rng(rand());

		Point pt1, pt2;
		int lineType = 8;

		for (int i = 0; i < itterations; i++)
		{
			pt1.x = rng.uniform(x1, x2);
			pt1.y = rng.uniform(y1, y2);
			pt2.x = rng.uniform(x1, x2);
			pt2.y = rng.uniform(y1, y2);

			rectangle(standardImg, pt1, pt2, Scalar(b, g, r), MAX(thickness, -1), lineType);
		}
	}

	// Function ID: 42.
	// Description: Draws a rectangle with random dimension.
	// Paramater (itterations): The number of times that the line will be drawn.
	// Paramater (x1, y1): The first set of coordinates of the in-bounds box that the lines will be allowed to spawn in.
	// Paramater (x2, y2): The second set of coordinates of the in-bounds box that the lines will be allowed to spawn in.
	// Paramters (r, g, b): The color of the rectangle.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawDrawRandomHollowRectangleRandomColor(int itterations, int x1, int y1, int x2, int y2, int thickness)
	{
		RNG rng(rand());

		Point pt1, pt2;
		int lineType = 8;

		for (int i = 0; i < itterations; i++)
		{
			pt1.x = rng.uniform(x1, x2);
			pt1.y = rng.uniform(y1, y2);
			pt2.x = rng.uniform(x1, x2);
			pt2.y = rng.uniform(y1, y2);

			rectangle(standardImg, pt1, pt2, GetRandomColor(rng), thickness, lineType);
		}
	}

	// Function ID: 43.
	// Description: Displays text in a random position.
	// Paramater (itterations): The number of times that the text will be drawn.
	// Paramater (text): The text that will be displayed on the image.
	// Paramaters (x1, x2): The first set of coordinates that define the bounding box where text can spawn.
	// Paramaters (y1, y2): The second set of coordinates that define the bounding box where text can spawn.
	// Paramters (r, g, b): The color of the text.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawDisplayRandomTextPosition(int itterations, STRING text, int x1, int y1, int x2, int y2, int r, int g, int b)
	{
		RNG rng(rand());
		int lineType = 8;

		for (int i = 1; i < itterations; i++)
		{
			Point org;
			org.x = rng.uniform(x1, x2);
			org.y = rng.uniform(y1, y2);

			putText(standardImg, text, org, rng.uniform(0, 8),
				rng.uniform(0, 100) * 0.05 + 0.1, Scalar(b, g, r), rng.uniform(1, 10), lineType);
		}
	}

	// Function ID: 44.
	// Description: Displays text in a random position, color and font.
	// Paramater (itterations): The number of times that the text will be drawn.
	// Paramater (text): The text that will be displayed on the image.
	// Paramaters (x1, x2): The first set of coordinates that define the bounding box where text can spawn.
	// Paramaters (y1, y2): The second set of coordinates that define the bounding box where text can spawn.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawDisplayRandomTextPositionRandomColor(int itterations, STRING text, int x1, int y1, int x2, int y2)
	{
		RNG rng(rand());
		int lineType = 8;

		for (int i = 1; i < itterations; i++)
		{
			Point org;
			org.x = rng.uniform(x1, x2);
			org.y = rng.uniform(y1, y2);

			putText(standardImg, text, org, rng.uniform(0, 8),
				rng.uniform(0, 100) * 0.05 + 0.1, GetRandomColor(rng), rng.uniform(1, 10), lineType);
		}
	}

	// Function ID: 45.
	// Description: Blurs the standard image.
	// Paramater (blurSize): The higher the number, the more the blur.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawBlurImage(int blurSize)
	{
		
			medianBlur(standardImg, standardImg, blurSize);
		
	}

	// Function ID: 46.
	// Description: Erodes the standard image using little rectangle shapes.
	// Paramater (erosionSize): The higher the number, the more the erosion.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawErodeImageRectangle(int erosionSize)
	{
		if (erosionSize % 2 == 0)
		{
			int erosion_type = MORPH_RECT;

			Mat element = getStructuringElement(erosion_type,
				Size(2 * erosionSize + 1, 2 * erosionSize + 1),
				Point(erosionSize, erosionSize));

			erode(standardImg, standardImg, element);
		}

		else
		{
			WriteLineError("The blur size paramter is not odd.");
		}
	}

	// Function ID: 47.
	// Description: Erodes the standard image using little cross shapes.
	// Paramater (erosionSize): The higher the number, the more the erosion.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawErodeImageCross(int erosionSize)
	{
		if (erosionSize % 2 == 0)
		{
			int erosion_type = MORPH_CROSS;

			Mat element = getStructuringElement(erosion_type,
				Size(2 * erosionSize + 1, 2 * erosionSize + 1),
				Point(erosionSize, erosionSize));

			erode(standardImg, standardImg, element);
		}

		else
		{
			WriteLineError("The erosion size paramter is not odd.");
		}
	}

	// Function ID: 48.
	// Description: Erodes the standard image using little ellipse shapes.
	// Paramater (erosionSize): The higher the number, the more the erosion.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawErodeImageEllipse(int erosionSize)
	{
		if (erosionSize % 2 == 0)
		{
			int erosion_type = MORPH_ELLIPSE;

			Mat element = getStructuringElement(erosion_type,
				Size(2 * erosionSize + 1, 2 * erosionSize + 1),
				Point(erosionSize, erosionSize));

			erode(standardImg, standardImg, element);
		}

		else
		{
			WriteLineError("The blur size paramter is not odd.");
		}
	}

	// Function ID: 49.
	// Description: Erodes the standard image.
	// Paramater (erosionSize): The higher the number, the more the erosion.
	// Warning: Has to be used in conjunction with other methods.
	// May be the same thing as erode image cross.
	EXTERN_DLL_EXPORT void RawErodeImage(int erosionSize)
	{
		if (erosionSize % 2 == 0)
		{
			int erosion_type = MORPH_ERODE;

			Mat element = getStructuringElement(erosion_type,
				Size(2 * erosionSize + 1, 2 * erosionSize + 1),
				Point(erosionSize, erosionSize));

			erode(standardImg, standardImg, element);
		}

		else
		{
			WriteLineError("The blur size paramter is not odd.");
		}
	}

	// Function ID: 50.
	// Description: Dialates the standard image using little rectangle shapes.
	// Paramater (dialationSize): The higher the number, the more the dialation.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawDialateImageRectangle(int dialationSize)
	{
		if (dialationSize % 2 == 0)
		{
			int dilation_type = MORPH_RECT;

			Mat element = getStructuringElement(dilation_type,
				Size(2 * dialationSize + 1, 2 * dialationSize + 1),
				Point(dialationSize, dialationSize));

			dilate(standardImg, standardImg, element);
		}

		else
		{
			WriteLineError("The blur size paramter is not odd.");
		}
	}

	// Function ID: 51.
	// Description: Dialates the standard image using little cross shapes.
	// Paramater (dialationSize): The higher the number, the more the dialation.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawDialateImageCross(int dialationSize)
	{
		if (dialationSize % 2 == 0)
		{
			int dilation_type = MORPH_CROSS;

			Mat element = getStructuringElement(dilation_type,
				Size(2 * dialationSize + 1, 2 * dialationSize + 1),
				Point(dialationSize, dialationSize));

			dilate(standardImg, standardImg, element);
		}

		else
		{
			WriteLineError("The dialation size paramter is not odd.");
		}
	}

	// Function ID: 52.
	// Description: Dialates the standard image using little ellipse shapes.
	// Paramater (dialationSize): The higher the number, the more the dialation.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawDialateImageEllipse(int dialationSize)
	{
		if (dialationSize % 2 == 0)
		{
			int dilation_type = MORPH_ELLIPSE;

			Mat element = getStructuringElement(dilation_type,
				Size(2 * dialationSize + 1, 2 * dialationSize + 1),
				Point(dialationSize, dialationSize));

			dilate(standardImg, standardImg, element);
		}

		else
		{
			WriteLineError("The dialation size paramter is not odd.");
		}
	}

	// Function ID: 53.
	// Description: Dialates the standard image using little ellipse shapes.
	// Paramater (dialationSize): The higher the number, the more the dialation.
	// Warning: Has to be used in conjunction with other methods
	// May be the same thing as dialate image cross.
	EXTERN_DLL_EXPORT void RawDialateImage(int dialationSize)
	{
		if (dialationSize % 2 == 0)
		{
			int dilation_type = MORPH_DILATE;

			Mat element = getStructuringElement(dilation_type,
				Size(2 * dialationSize + 1, 2 * dialationSize + 1),
				Point(dialationSize, dialationSize));

			dilate(standardImg, standardImg, element);
		}

		else
		{
			WriteLineError("The dialation size paramter is not odd.");
		}
	}

	// Function ID: 54.
	// Description: Also known as opening, removes the background noise from the image.
	// Paramater (kernelSize): The higher the number, the more background niose is removed.
	// Warning: Has to be used in conjunction with other methods.
	// Warning: The kernelSize has to be odd.
	EXTERN_DLL_EXPORT void RawRemoveBackgroundNoise(int kernelSize)
	{
		if (kernelSize % 2 == 0)
		{
			int dilation_type = MORPH_OPEN;

			Mat element = getStructuringElement(dilation_type,
				Size(2 * kernelSize + 1, 2 * kernelSize + 1),
				Point(kernelSize, kernelSize));

			morphologyEx(standardImg, standardImg, dilation_type, element);
		}

		else
		{
			WriteLineError("The dialation size paramter is not odd.");
		}
	}

	// Function ID: 55.
	// Description: If there are horizontal lines in an image, it extracts them.
	// Warning: Has to be used in conjunction with other methods.
	// Warning: Only works with grayscale images.
	EXTERN_DLL_EXPORT void RawGetHorizontalLines()
	{
		Mat output;

		// Apply adaptiveThreshold at the bitwise_not of gray, notice the ~ symbol.
		adaptiveThreshold(~standardImg, output, 255, ADAPTIVE_THRESH_MEAN_C, THRESH_BINARY, 15, -2);

		// Create the images that will use to extract the horizontal and vertical lines.
		Mat horizontal = output.clone();

		// Specify size on horizontal axis.
		int horizontal_size = horizontal.cols / 30;

		// Create structure element for extracting horizontal lines through morphology operations.
		Mat horizontalStructure = getStructuringElement(MORPH_RECT, Size(horizontal_size, 1));

		// Apply morphology operations
		erode(horizontal, horizontal, horizontalStructure, Point(-1, -1));
		dilate(horizontal, horizontal, horizontalStructure, Point(-1, -1));

		standardImg = horizontal;
	}

	// Function ID: 56.
	// Description: If there are vertical lines in an image, it extracts them.
	// Warning: Has to be used in conjunction with other methods.
	// Warning: Only works with grayscale images.
	EXTERN_DLL_EXPORT void RawGetVerticalLines()
	{
		Mat output;

		// Apply adaptiveThreshold at the bitwise_not of gray, notice the ~ symbol.
		adaptiveThreshold(~standardImg, output, 255, ADAPTIVE_THRESH_MEAN_C, THRESH_BINARY, 15, -2);

		Mat vertical = output.clone();

		// Specify size on vertical axis
		int vertical_size = vertical.rows / 30;

		// Create structure element for extracting vertical lines through morphology operations
		Mat verticalStructure = getStructuringElement(MORPH_RECT, Size(1, vertical_size));

		// Apply morphology operations
		erode(vertical, vertical, verticalStructure, Point(-1, -1));
		dilate(vertical, vertical, verticalStructure, Point(-1, -1));

		standardImg = vertical;
	}

	// Function ID: 57.
	// Description: Converts an image to either black or white without any shades of gray.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawConvertToBinary()
	{
		// Apply adaptiveThreshold at the bitwise_not of gray, notice the ~ symbol.
		adaptiveThreshold(~standardImg, standardImg, 255, ADAPTIVE_THRESH_MEAN_C, THRESH_BINARY, 15, -2);
	}

	// Function ID: 58.
	// Description: Converts an image to either black or white without any shades of gray and inverts the result.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawConvertToInverseBinary()
	{
		// Apply adaptiveThreshold at the bitwise_not of gray, notice the ~ symbol.
		adaptiveThreshold(~standardImg, standardImg, 255, ADAPTIVE_THRESH_MEAN_C, THRESH_BINARY_INV, 15, -2);
	}

	// Function ID: 59.
	// Description: Smooths the detected edges of the image.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawSmoothEdges()
	{
		// Step 1.
		Mat edges;
		adaptiveThreshold(standardImg, edges, 255, ADAPTIVE_THRESH_MEAN_C, THRESH_BINARY, 3, -2);

		// Step 2.
		Mat kernel = Mat::ones(2, 2, CV_8UC1);
		dilate(edges, edges, kernel);

		// Step 3.
		Mat smooth;

		// Step 4.
		blur(smooth, smooth, Size(2, 2));

		standardImg = smooth;
	}

	// Function ID: 60.
	// Description: Turns any colors above the threshold value to white and the image itself will get brighter.
	// Paramter (thresholdValue): Any grayscale "rgb" values below that value will turn to white.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawLowThresholdImage(double thresholdValue)
	{
		threshold(standardImg, standardImg, thresholdValue, 255, THRESH_TRUNC);
	}

	// Function ID: 61.
	// Description: Turns any colors above the threshold value to black and the image itself will get brighter.
	// Paramter (thresholdValue): Any grayscale "rgb" values below that value will turn to white.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawHighThresholdImage(double thresholdValue)
	{
		threshold(standardImg, standardImg, thresholdValue, 255, THRESH_TOZERO);
	}

	// Global Warning: Many of the following functions are minorly edited from the documentation examples.

	// Function ID: 62.
	// Description: Detects and draws edges to the standard image, also known as hough line transform.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawDetectEdges()
	{
		Mat output;
		Mat cdst;

		// Edge detection
		Canny(standardImg, output, 50, 200, 3);

		// Copy edges to the images that will display the results in BGR
		cvtColor(output, cdst, COLOR_GRAY2BGR);
		auto cdstP = cdst.clone();

		// Standard Hough Line Transform
		vector<Vec2f> lines; // will hold the results of the detection
		HoughLines(output, lines, 1, CV_PI / 180, 150, 0, 0); // runs the actual detection
		// Draw the lines
		for (size_t i = 0; i < lines.size(); i++)
		{
			float rho = lines[i][0], theta = lines[i][1];
			Point pt1, pt2;
			double a = cos(theta), b = sin(theta);
			double x0 = a * rho, y0 = b * rho;
			pt1.x = cvRound(x0 + 1000 * (-b));
			pt1.y = cvRound(y0 + 1000 * (a));
			pt2.x = cvRound(x0 - 1000 * (-b));
			pt2.y = cvRound(y0 - 1000 * (a));
			line(cdst, pt1, pt2, Scalar(0, 0, 255), 3, LINE_AA);
		}

		// Probabilistic Line Transform
		vector<Vec4i> linesP; // will hold the results of the detection
		HoughLinesP(output, linesP, 1, CV_PI / 180, 50, 50, 10); // runs the actual detection
		// Draw the lines
		for (size_t i = 0; i < linesP.size(); i++)
		{
			Vec4i l = linesP[i];
			line(cdstP, Point(l[0], l[1]), Point(l[2], l[3]), Scalar(0, 0, 255), 3, LINE_AA);
		}

		standardImg = output;
	}

	// Function ID: 63.
	// Description: Tilts the image using the angle paramter and scales it based on the scale paramater, also known as affline transformations.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawTiltImage(double angle, double scale)
	{
		Point2f srcTri[3];
		srcTri[0] = Point2f(0.f, 0.f);
		srcTri[1] = Point2f(standardImg.cols - 1.f, 0.f);
		srcTri[2] = Point2f(0.f, standardImg.rows - 1.f);

		Point2f dstTri[3];
		dstTri[0] = Point2f(0.f, standardImg.rows * 0.33f);
		dstTri[1] = Point2f(standardImg.cols * 0.85f, standardImg.rows * 0.25f);
		dstTri[2] = Point2f(standardImg.cols * 0.15f, standardImg.rows * 0.7f);

		Mat warp_mat = getAffineTransform(srcTri, dstTri);

		Mat warp_dst = Mat::zeros(standardImg.rows, standardImg.cols, standardImg.type());

		warpAffine(standardImg, warp_dst, warp_mat, warp_dst.size());

		Point center = Point(warp_dst.cols / 2, warp_dst.rows / 2);

		Mat rot_mat = getRotationMatrix2D(center, angle, scale);

		Mat warp_rotate_dst;
		warpAffine(warp_dst, warp_rotate_dst, rot_mat, warp_dst.size());

		standardImg = warp_rotate_dst;
	}

	// Function ID: 64.
	// Description: Draws a filled triangle on the standard image with random sides, but fixed amount of sides.
	// Paramater (itterations): The number of polygons to spawn.
	// Paramaters (x1, x2): The first set of bounds where the polygons can spawn.
	// Paramaters (y1, y2): The second set of bounds where the polygons can spawn.
	// Warning: This function is unfinished.
	EXTERN_DLL_EXPORT void RawDrawRandomFilledTriangles(int itterations, int x1, int y1, int x2, int y2)
	{
		RNG rng(rand());

		int lineType = 8;

		for (int i = 0; i < itterations; i++)
		{
			Point pt[2][3];
			pt[0][0].x = rng.uniform(x1, x2);
			pt[0][0].y = rng.uniform(y1, y2);
			pt[0][1].x = rng.uniform(x1, x2);
			pt[0][1].y = rng.uniform(y1, y2);
			pt[0][2].x = rng.uniform(x1, x2);
			pt[0][2].y = rng.uniform(y1, y2);
			pt[1][0].x = rng.uniform(x1, x2);
			pt[1][0].y = rng.uniform(y1, y2);
			pt[1][1].x = rng.uniform(x1, x2);
			pt[1][1].y = rng.uniform(y1, y2);
			pt[1][2].x = rng.uniform(x1, x2);
			pt[1][2].y = rng.uniform(y1, y2);

			const Point* ppt[2] = { pt[0], pt[1] };
			int npt[] = { 3, 3 };

			fillPoly(standardImg, ppt, npt, 2, GetRandomColor(rng), lineType);
		}
	}

	// Function ID: 65.
	// Description: Draws a holllow triangle on the standard image with random sides, but fixed amount of sides.
	// Paramater (itterations): The number of polygons to spawn.
	// Paramaters (x1, x2): The first set of bounds where the polygons can spawn.
	// Paramaters (y1, y2): The second set of bounds where the polygons can spawn.
	// Warning: This function is unfinished.
	EXTERN_DLL_EXPORT void RawDrawRandomHollowTriangles(int itterations, int x1, int y1, int x2, int y2)
	{
		RNG rng(rand());

		int lineType = 8;

		for (int i = 0; i < itterations; i++)
		{
			Point pt[2][3];
			pt[0][0].x = rng.uniform(x1, x2);
			pt[0][0].y = rng.uniform(y1, y2);
			pt[0][1].x = rng.uniform(x1, x2);
			pt[0][1].y = rng.uniform(y1, y2);
			pt[0][2].x = rng.uniform(x1, x2);
			pt[0][2].y = rng.uniform(y1, y2);
			pt[1][0].x = rng.uniform(x1, x2);
			pt[1][0].y = rng.uniform(y1, y2);
			pt[1][1].x = rng.uniform(x1, x2);
			pt[1][1].y = rng.uniform(y1, y2);
			pt[1][2].x = rng.uniform(x1, x2);
			pt[1][2].y = rng.uniform(y1, y2);

			const Point* ppt[2] = { pt[0], pt[1] };
			int npt[] = { 3, 3 };

			polylines(standardImg, ppt, npt, 2, true, GetRandomColor(rng), rng.uniform(1, 10), lineType);
		}
	}

	// Function ID: 66.
	// Description: Gets and draws contours around the edges.
	// Paramater (thresh): The higher the number the more contours.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawGetContours(int thresh)
	{
		RNG rng(rand());

		Mat output;

		Mat canny_output;
		Canny(standardImg, canny_output, thresh, thresh * 2);

		vector<vector<Point> > contours;
		vector<Vec4i> hierarchy;
		findContours(canny_output, contours, hierarchy, RETR_TREE, CHAIN_APPROX_SIMPLE);

		Mat drawing = Mat::zeros(canny_output.size(), CV_8UC3);
		for (size_t i = 0; i < contours.size(); i++)
		{
			Scalar color = Scalar(rng.uniform(0, 256), rng.uniform(0, 256), rng.uniform(0, 256));
			drawContours(drawing, contours, (int)i, color, 2, LINE_8, hierarchy, 0);
		}

		standardImg = drawing;
	}

	// Function ID: 67.
	// Description: Draws a contour around the edges it detects.
	// Paramater (thresh): The higher the number the more contours.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawGetConvexHull(double thresh)
	{
		RNG rng(rand());

		Mat canny_output;
		Canny(standardImg, canny_output, thresh, thresh * 2);

		vector<vector<Point> > contours;
		findContours(canny_output, contours, RETR_TREE, CHAIN_APPROX_SIMPLE);

		vector<vector<Point> >hull(contours.size());
		for (size_t i = 0; i < contours.size(); i++)
		{
			convexHull(contours[i], hull[i]);
		}

		Mat drawing = Mat::zeros(canny_output.size(), CV_8UC3);
		for (size_t i = 0; i < contours.size(); i++)
		{
			Scalar color = Scalar(rng.uniform(0, 256), rng.uniform(0, 256), rng.uniform(0, 256));
			drawContours(drawing, contours, (int)i, color);
			drawContours(drawing, hull, (int)i, color);
		}

		standardImg = canny_output;
	}

	// Function ID: 68.
	// Description: Splits the image apart into multiple layers.
	// Warning: Has to be used in conjunction with other methods.
	EXTERN_DLL_EXPORT void RawWatershedImage()
	{
		// Change the background from white to black, since that will help later to extract
		// better results during the use of Distance Transform
		Mat mask;
		inRange(standardImg, Scalar(255, 255, 255), Scalar(255, 255, 255), mask);
		standardImg.setTo(Scalar(0, 0, 0), mask);

		// Show output image
		//imshow("Black Background Image", src);

		// Create a kernel that we will use to sharpen our image
		Mat kernel = (Mat_<float>(3, 3) <<
			1, 1, 1,
			1, -8, 1,
			1, 1, 1); // an approximation of second derivative, a quite strong kernel

		// do the laplacian filtering as it is
		// well, we need to convert everything in something more deeper then CV_8U
		// because the kernel has some negative values,
		// and we can expect in general to have a Laplacian image with negative values
		// BUT a 8bits unsigned int (the one we are working with) can contain values from 0 to 255
		// so the possible negative number will be truncated
		Mat imgLaplacian;
		filter2D(standardImg, imgLaplacian, CV_32F, kernel);
		Mat sharp;
		standardImg.convertTo(sharp, CV_32F);
		Mat imgResult = sharp - imgLaplacian;

		// convert back to 8bits gray scale
		imgResult.convertTo(imgResult, CV_8UC3);
		imgLaplacian.convertTo(imgLaplacian, CV_8UC3);

		// imshow( "Laplace Filtered Image", imgLaplacian );
		//imshow("New Sharped Image", imgResult);

		// Create binary image from source image
		Mat bw;
		cvtColor(imgResult, bw, COLOR_BGR2GRAY);
		threshold(bw, bw, 40, 255, THRESH_BINARY | THRESH_OTSU);
		//imshow("Binary Image", bw);

		// Perform the distance transform algorithm
		Mat dist;
		distanceTransform(bw, dist, DIST_L2, 3);

		// Normalize the distance image for range = {0.0, 1.0}
		// so we can visualize and threshold it
		normalize(dist, dist, 0, 1.0, NORM_MINMAX);
		//imshow("Distance Transform Image", dist);

		// Threshold to obtain the peaks
		// This will be the markers for the foreground objects
		threshold(dist, dist, 0.4, 1.0, THRESH_BINARY);

		// Dilate a bit the dist image
		Mat kernel1 = Mat::ones(3, 3, CV_8U);
		dilate(dist, dist, kernel1);
		//imshow("Peaks", dist);

		// Create the CV_8U version of the distance image
		// It is needed for findContours()
		Mat dist_8u;
		dist.convertTo(dist_8u, CV_8U);

		// Find total markers
		vector<vector<Point> > contours;
		findContours(dist_8u, contours, RETR_EXTERNAL, CHAIN_APPROX_SIMPLE);

		// Create the marker image for the watershed algorithm
		Mat markers = Mat::zeros(dist.size(), CV_32S);

		// Draw the foreground markers
		for (size_t i = 0; i < contours.size(); i++)
		{
			drawContours(markers, contours, static_cast<int>(i), Scalar(static_cast<int>(i) + 1), -1);
		}

		// Draw the background marker
		circle(markers, Point(5, 5), 3, Scalar(255), -1);
		Mat markers8u;
		markers.convertTo(markers8u, CV_8U, 10);
		//imshow("Markers", markers8u);

		// Perform the watershed algorithm
		watershed(imgResult, markers);

		Mat mark;
		markers.convertTo(mark, CV_8U);
		bitwise_not(mark, mark);
		//    imshow("Markers_v2", mark); // uncomment this if you want to see how the mark
		// image looks like at that point

		// Generate random colors
		vector<Vec3b> colors;
		for (size_t i = 0; i < contours.size(); i++)
		{
			int b = theRNG().uniform(0, 256);
			int g = theRNG().uniform(0, 256);
			int r = theRNG().uniform(0, 256);

			colors.push_back(Vec3b((uchar)b, (uchar)g, (uchar)r));
		}

		// Create the result image
		Mat dst = Mat::zeros(markers.size(), CV_8UC3);

		// Fill labeled objects with random colors
		for (int i = 0; i < markers.rows; i++)
		{
			for (int j = 0; j < markers.cols; j++)
			{
				int index = markers.at<int>(i, j);
				if (index > 0 && index <= static_cast<int>(contours.size()))
				{
					dst.at<Vec3b>(i, j) = colors[index - 1];
				}
			}
		}

		standardImg = dst;
	}

	// Function ID: 69.
	// Description: Gets and draws the corners detected in the image.
	// Paramater (maxCorners): The maximum amount of corners that the function will detect.
	// Warning: Has to be used in conjunction with other methods.
	// Warning: Only works with grayscale images.
	EXTERN_DLL_EXPORT void RawGetCorners(int maxCorners)
	{
		RNG rng(rand());

		maxCorners = MAX(maxCorners, 1);
		vector<Point2f> corners;
		double qualityLevel = 0.01;
		double minDistance = 10;
		int blockSize = 3, gradientSize = 3;
		bool useHarrisDetector = false;
		double k = 0.04;

		Mat copy;

		standardImg.copyTo(copy);

		goodFeaturesToTrack(standardImg,
			corners,
			maxCorners,
			qualityLevel,
			minDistance,
			Mat(),
			blockSize,
			gradientSize,
			useHarrisDetector,
			k);

		//cout << "** Number of corners detected: " << corners.size() << endl;
		int radius = 4;
		for (size_t i = 0; i < corners.size(); i++)
		{
			circle(copy, corners[i], radius, Scalar(rng.uniform(0, 255), rng.uniform(0, 256), rng.uniform(0, 256)), FILLED);
		}

		standardImg = copy;
	}

    // Return types need to be standardized.
    Ptr<Formatted> FormatToDefualt(Mat m)
    {
    	Ptr<Formatted> f = format(m, Formatter::FMT_DEFAULT);
    	return f;
    }

    // Return types need to be standardized.
	Ptr<Formatted> FormatToPython(Mat m)
	{
		Ptr<Formatted> f = format(m, Formatter::FMT_PYTHON);
		return f;
	}

    // Return types need to be standardized.
	Ptr<Formatted> FormatToCSV(Mat m)
	{
		Ptr<Formatted> f = format(m, Formatter::FMT_CSV);
		return f;
	}

    // Return types need to be standardized.
	Ptr<Formatted> FormatToNumpy(Mat m)
	{
		Ptr<Formatted> f = format(m, Formatter::FMT_NUMPY);
		return f;
	}

    // Return types need to be standardized.
	Ptr<Formatted> FormatToC(Mat m)
	{
		Ptr<Formatted> f = format(m, Formatter::FMT_C);
		return f;
	}

    // Debug
    EXTERN_DLL_EXPORT void DebugCheckImageEmpty() 
    {
        cout << standardImg.empty();
    }

	// Utilites
	void WriteLineError(string message) 
	{
		cout << "[C++ Non-Fatal Error] " << message;
	}
}
