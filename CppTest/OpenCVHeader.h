#include <opencv2/core.hpp>
#include <opencv2/imgcodecs.hpp>
#include <opencv2/highgui.hpp>
#include <opencv2/imgproc.hpp>
#include <iostream>
#include <fstream>
#include "opencv2/features2d.hpp"

using namespace cv;
using namespace std;

#define EXTERN_DLL_EXPORT extern "C" __declspec(dllexport)
#define STRING const char *

namespace OpenCVUtilities
{
    const string tempOutputfilePath = "C:\\Temp\\CppFileIOTest.txt";

    // Standard functions.
    EXTERN_DLL_EXPORT void RawGetImgColor(STRING path);
    EXTERN_DLL_EXPORT void RawGetImgGrayscale(STRING path);
    EXTERN_DLL_EXPORT void RawCreateRect(int x, int y, int r, int g, int b);
    EXTERN_DLL_EXPORT void RawWriteToFile(STRING path);
    EXTERN_DLL_EXPORT void RawCreateArrayOnes(int width, int height, double divideBy);
    EXTERN_DLL_EXPORT void RawCreateArrayZeros(int width, int height);
    EXTERN_DLL_EXPORT void RawCreateManualArray(Mat_<double> input);
    EXTERN_DLL_EXPORT void RawGetRow(int row);
    EXTERN_DLL_EXPORT void RawCreateRandomArray(int width, int height, int min, int max);
    EXTERN_DLL_EXPORT void RawGetRegionOfInterest(int x1, int y1, int x2, int y2);
    EXTERN_DLL_EXPORT void RawDisplayWindow(STRING winddowName);
    EXTERN_DLL_EXPORT void RawGetColumn(int col);

    // Debug functions.
    EXTERN_DLL_EXPORT void DebugCheckImageEmpty();

    // Temporary functions.
    Ptr<Formatted> FormatToDefualt(Mat m);
    Ptr<Formatted> FormatToPython(Mat m);
    Ptr<Formatted> FormatToCSV(Mat m);
    Ptr<Formatted> FormatToNumpy(Mat m);
    Ptr<Formatted> FormatToC(Mat m);
}
