// CppTest.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "OpenCVHeader.h"

EXTERN_DLL_EXPORT int main(int argc, char** argv)
{
    // Test Function 0.

    //// Test Function 1.
    //Mat file2 = OpenCVUtilities::GetImgGrayscale(OpenCVUtilities::tempInputPath);

    //// Test Function 2.
    //Mat file3 = OpenCVUtilities::Copy(file2);

    //HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
    //// you can loop k higher to see more color choices
    //for (int k = 1; k < 255; k++)
    //{
    //    // pick the colorattribute k you want
    //    SetConsoleTextAttribute(hConsole, k);
    //    cout << k << "Hello, World!" << endl;
    //}

    return 0;
}

//void TurnTextToBlue(HANDLE hConsole)
//{
//    // Picks the colorattribute for blue (10).
//    SetConsoleTextAttribute(hConsole, 10);
//}
//
//void TurnTextToGreen(HANDLE hConsole)
//{
//    // Picks the colorattribute for blue (10).
//    SetConsoleTextAttribute(hConsole, 10);
//}

namespace OpenCVUtilities 
{
    Mat inputImg;

    // Function ID: 0.
    // Description: Gets an image from the path specified in color.
    // Paramater (path): The path, which the image is going to be read.
    EXTERN_DLL_EXPORT void GetImgColor(STRING path)
    {
        Mat img;

        cout << path;

        img = imread(path, IMREAD_COLOR); // path
        
        inputImg = img;
    }

    // Function ID: 1.
	// Description: Gets an image from the path specified in grayscale.
	// Paramater (path): The path, which the image is going to be read.
	EXTERN_DLL_EXPORT void GetImgGrayscale(STRING path)
	{
		Mat img;
		img = imread(path, IMREAD_GRAYSCALE); // path

        inputImg = img;
	}

    // May be removed.
    void Copy(Mat matrix)
    {
        Mat img(matrix);

        inputImg = img;
    }

    // Function ID: 2.
    // Description: Creates a rectangle from the specified parameters.
    // Paramater (x): The x position for the rectangle.
    // Paramater (y): The y position for the rectangle.
    // Paramater (rgb): The color of the rectangle.
    // Format (CV_8UC3): CV_[The number of bits per item][Signed or Unsigned][Type Prefix]C[The channel number].
    // ?: Dont know about width and height.
    // Defualts: CreateRect(100, 100, Scalar(0, 0, 0));
    EXTERN_DLL_EXPORT void CreateRect(int x, int y, Scalar rgb)
	{
		Mat rect(x, y, CV_8UC3, rgb);
        inputImg = rect;
	}

    // Function ID: 3.
    // Description: Writes the image stored inside "inputImg" to the specified path.
    // Paramater (path): The path, which the image is going to be written.
    EXTERN_DLL_EXPORT void WriteToFile(STRING path)
    {
        imwrite(path, inputImg);
    }

 //   // Function ID: 4.
 //   // Description: Creates an array of ones from the specified paramaters, that can be divided by "divideBy" to produce a needed value of each cell of the array.
 //   // Paramater (width): The width for the image.
 //   // Paramater (height): The height for the image.
 //   // Paramater (divideBy): The value for dividing the image.
 //   EXTERN_DLL_EXPORT void CreateArrayOnes(int width, int height, double divideBy)
	//{
	//	Mat o = Mat::ones(width, height, CV_32F) / divideBy;
 //       inputImg = o;
	//}
 //   
 //   // Function ID: 5.
 //   // Description: Creates an array of ones from the specified paramaters.
 //   // Paramater (width): The width for the image.
 //   // Paramater (height): The height for the image.
 //   EXTERN_DLL_EXPORT void CreateArrayZeros(int width, int height)
	//{
	//	Mat z = Mat::zeros(width, height, CV_8UC1);
 //       inputImg = z;
	//}

 //   // Function ID: 6.
 //   // Description: Creates an array of ones from the specified paramaters.
 //   // Paramater (input): All pixels of the image.
 //   EXTERN_DLL_EXPORT void CreateManualArray(Mat_<double> input)
	//{
	//	Mat m = input;
 //       inputImg = m;
	//}

    // Debug
    EXTERN_DLL_EXPORT void DebugCheckImageEmpty() 
    {
        cout << inputImg.empty();
    }
}

// Questions: 2, 6

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
