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
    EXTERN_DLL_EXPORT void RawCreateManualArray(Mat_<double> input)
	{
		Mat m = input;
        standardImg = m;
	}

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
