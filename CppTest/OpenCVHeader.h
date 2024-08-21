#include <opencv2/core.hpp>
#include <opencv2/imgcodecs.hpp>
#include <opencv2/highgui.hpp>
#include <opencv2/imgproc.hpp>
#include <iostream>
#include "opencv2/features2d.hpp"

using namespace cv;
using namespace std;

#define EXTERN_DLL_EXPORT extern "C" __declspec(dllexport)
#define STRING const char *

namespace OpenCVUtilities
{
    // Standard functions.
    EXTERN_DLL_EXPORT void RawGetImgColor(STRING path);
    EXTERN_DLL_EXPORT void RawGetImgGrayscale(STRING path);
    EXTERN_DLL_EXPORT void RawCreateRect(int x, int y, int r, int g, int b);
    EXTERN_DLL_EXPORT void RawWriteToFile(STRING path);
    EXTERN_DLL_EXPORT void RawCreateArrayOnes(int width, int height, double divideBy);
    EXTERN_DLL_EXPORT void RawCreateArrayZeros(int width, int height);
    EXTERN_DLL_EXPORT void RawGetRow(int row);
    EXTERN_DLL_EXPORT void RawCreateRandomArray(int width, int height, int min, int max);
    EXTERN_DLL_EXPORT void RawGetRegionOfInterest(int x1, int y1, int x2, int y2);
    EXTERN_DLL_EXPORT void RawDisplayWindow(STRING winddowName);
    EXTERN_DLL_EXPORT void RawGetColumn(int col);
    EXTERN_DLL_EXPORT void RawApplyMaskOnePixel(char list[1]);
    EXTERN_DLL_EXPORT void RawApplyMaskTwoPixels(char list[4]);
    EXTERN_DLL_EXPORT void RawApplyMaskThreePixels(char list[9]);
    EXTERN_DLL_EXPORT void RawApplyMaskFourPixels(char list[16]);
    EXTERN_DLL_EXPORT void RawApplyMaskFivePixels(char list[25]);
    EXTERN_DLL_EXPORT void RawApplyMaskSixPixels(char list[36]);
    EXTERN_DLL_EXPORT void RawApplyMaskSevenPixels(char list[49]);
    EXTERN_DLL_EXPORT void RawApplyMaskEightPixels(char list[64]);
    EXTERN_DLL_EXPORT void RawApplyMaskNinePixels(char list[81]);
    EXTERN_DLL_EXPORT void RawApplyMaskTenPixels(char list[100]);
    EXTERN_DLL_EXPORT void ConvertColorToGray();
    EXTERN_DLL_EXPORT void ConvertColorToColorAlpha();
    EXTERN_DLL_EXPORT void ConvertColorToHLS();
    EXTERN_DLL_EXPORT void ConvertColorToHSV();
    EXTERN_DLL_EXPORT void ConvertBRGToRGB();
    EXTERN_DLL_EXPORT void ConvertBRGToRGBA();
    EXTERN_DLL_EXPORT void ConvertGrayToRGB();
    EXTERN_DLL_EXPORT void ConvertGrayToColor();

    // Debug functions.
    EXTERN_DLL_EXPORT void DebugCheckImageEmpty();

    // Temporary functions.
    Ptr<Formatted> FormatToDefualt(Mat m);
    Ptr<Formatted> FormatToPython(Mat m);
    Ptr<Formatted> FormatToCSV(Mat m);
    Ptr<Formatted> FormatToNumpy(Mat m);
    Ptr<Formatted> FormatToC(Mat m);
}
