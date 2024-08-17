#include <opencv2/core.hpp>
#include <opencv2/imgcodecs.hpp>
#include <opencv2/highgui.hpp>
#include <opencv2/imgproc.hpp>
#include <iostream>
#include <fstream>
#include <windows.h>
#include "opencv2/features2d.hpp"

using namespace cv;
using namespace std;

#define EXTERN_DLL_EXPORT extern "C" __declspec(dllexport)
#define STRING const char *

namespace OpenCVUtilities
{
    const string tempOutputfilePath = "C:\\Temp\\CppFileIOTest.txt";
    const string tempInputPath = "C:\\Users\\mzheb\\Downloads\\saturn-v2.jpg";

    // Standard functions.
    EXTERN_DLL_EXPORT void GetImgColor(STRING path);
    EXTERN_DLL_EXPORT void GetImgGrayscale(STRING path);
    EXTERN_DLL_EXPORT void CreateRect(int x, int y, int r, int g, int b);
    EXTERN_DLL_EXPORT void WriteToFile(STRING path);
    EXTERN_DLL_EXPORT void CreateArrayOnes(int width, int height, double divideBy);
    EXTERN_DLL_EXPORT void CreateArrayZeros(int width, int height);
    EXTERN_DLL_EXPORT void CreateManualArray(Mat_<double> input);
    EXTERN_DLL_EXPORT void GetRow(int row);
    EXTERN_DLL_EXPORT void CreateRandomArray(int width, int height, int min, int max);
    EXTERN_DLL_EXPORT void GetRegionOfInterest(int x1, int y1, int x2, int y2);
    EXTERN_DLL_EXPORT void DisplayWindow(STRING winddowName);

    // Debug functions.
    EXTERN_DLL_EXPORT void DebugCheckImageEmpty();

    // Temporary functions.
    Ptr<Formatted> FormatToDefualt(Mat m);
    Ptr<Formatted> FormatToPython(Mat m);
    Ptr<Formatted> FormatToCSV(Mat m);
    Ptr<Formatted> FormatToNumpy(Mat m);
    Ptr<Formatted> FormatToC(Mat m);
}
