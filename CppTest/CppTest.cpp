#include "OpenCVHeader.h"

int main(int argc, char** argv)
{
    return 0;
}

namespace OpenCVUtilities 
{
    Mat standardImg;

    // Function ID: 0.
    // Description: Gets an image from the path specified in color.
    // Paramater (path): The path, which the image is going to be read.
    EXTERN_DLL_EXPORT void RawGetImgColor(STRING path)
    {
        Mat img;
        img = imread(path, IMREAD_COLOR); // path
        
        standardImg = img;
    }

    // Function ID: 1.
    // Description: Gets an image from the path specified in grayscale.
    // Paramater (path): The path, which the image is going to be read.
	EXTERN_DLL_EXPORT void RawGetImgGrayscale(STRING path)
	{
		Mat img;
		img = imread(path, IMREAD_GRAYSCALE); // path

        standardImg = img;
	}

    // Function ID: 2.
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

    // Function ID: 3.
    // Description: Writes the image stored inside "standardImg" to the specified path.
    // Paramater (path): The path, which the image is going to be written.
    EXTERN_DLL_EXPORT void RawWriteToFile(STRING path)
    {
        imwrite(path, standardImg);
    }

    // Function ID: 4.
    // Description: Creates an array of ones from the specified paramaters, that can be divided by "divideBy" to produce a needed value of each cell of the array.
    // Paramater (width): The width for the image.
    // Paramater (height): The height for the image.
    // Paramater (divideBy): The value for dividing the image.
    EXTERN_DLL_EXPORT void RawCreateArrayOnes(int width, int height, double divideBy)
	{
		Mat o = Mat::ones(width, height, CV_32F) / divideBy;
        standardImg = o;
	}
    
    // Function ID: 5.
    // Description: Creates an array of ones from the specified paramaters.
    // Paramater (width): The width for the image.
    // Paramater (height): The height for the image.
    EXTERN_DLL_EXPORT void RawCreateArrayZeros(int width, int height)
	{
		Mat z = Mat::zeros(width, height, CV_8UC1);
        standardImg = z;
	}

    // Function ID: 6.
    // Description: Creates an array of ones from the specified paramaters.
    // Paramater (input): All pixels of the image.
    // Warning: Has to be used in conjunction with other methods.
    /*EXTERN_DLL_EXPORT void RawCreateManualArray(double input[])
	{
        Mat_<double> dsfds= 

        standardImg = input;
	}*/

    // Function ID: 7.
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

    // Function ID: 8.
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

    // Function ID: 9.
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

    // Function ID: 10.
    // Description: Displays a window which shows the standard image.
    // Paramater (winddowName): The name of the displayed window.
    // Recemondation: To be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void RawDisplayWindow(STRING winddowName)
	{
		namedWindow(winddowName, WINDOW_AUTOSIZE);
		imshow(winddowName, standardImg);
		waitKey();
	}

    // Function ID: 11.
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

    // Function ID: 12.
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

    // Function ID: 13.
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

    // Function ID: 15.
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

    // Function ID: 16.
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

    // Function ID: 17.
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

    // Function ID: 18.
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

    // Function ID: 19.
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

    // Function ID: 20.
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

    // Function ID: 21.
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

    // Function ID: 22.
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

    //   // Function ID: 23.
	//Scalar GetIntensityGrayScale(int x, int y)
	//{
	//	Scalar intensity = standardImg.at<uchar>(Point(x, y));
	//	return intensity;
	//}

 //   // Function ID: 24.
	//void GetIntensityColor(int x, int y)
	//{
	//	Vec3b intensity = standardImg.at<Vec3b>(y, x);
	//	uchar blue = intensity.val[0];
	//	uchar green = intensity.val[1];
	//	uchar red = intensity.val[2];
	//}

 //   // Function ID: 25.
	//void GetIntensityFloatColor(int x, int y)
	//{
	//	Vec3f intensity = standardImg.at<Vec3f>(y, x);
	//	float blue = intensity.val[0];
	//	float green = intensity.val[1];
	//	float red = intensity.val[2];
	//}

    // Function ID: 26.
    // Description: Converts a color image into a gray scale image.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void ConvertColorToGray()
	{
		cvtColor(standardImg, standardImg, COLOR_BGR2GRAY);
	}

    // Function ID: 27.
    // Description: Converts a color image into a color image with alpha.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void ConvertColorToColorAlpha()
	{
		cvtColor(standardImg, standardImg, COLOR_BGR2BGRA);
	}

    // Function ID: 28.
    // Description: Converts a color image into an HLS color image.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void ConvertColorToHLS()
	{
		cvtColor(standardImg, standardImg, COLOR_BGR2HLS);
	}

    // Function ID: 29.
    // Description: Converts a color image into an HSV color image.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void ConvertColorToHSV()
	{
		cvtColor(standardImg, standardImg, COLOR_BGR2HSV);
	}

    // Function ID: 30.
    // Description: Switches the r and g color channels.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void ConvertBRGToRGB()
	{
		cvtColor(standardImg, standardImg, COLOR_BGR2RGB);
	}

    // Function ID: 31.
    // Description: Switches the r and g color channels and adds an alpha channel.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void ConvertBRGToRGBA()
    {
        cvtColor(standardImg, standardImg, COLOR_BGR2RGBA);
    }

    // Function ID: 32.
    // Description: Switches the r and g color channels and adds an alpha channel.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void ConvertGrayToRGB()
	{
		cvtColor(standardImg, standardImg, COLOR_GRAY2RGB);
	}

    // Function ID: 33.
    // Description: Converts a grayscale image into a color image.
    // Warning: Has to be used in conjunction with other methods.
    EXTERN_DLL_EXPORT void ConvertGrayToColor()
	{
		cvtColor(standardImg, standardImg, COLOR_GRAY2BGR);
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
}
