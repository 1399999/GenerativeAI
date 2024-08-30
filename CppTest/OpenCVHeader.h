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
    EXTERN_DLL_EXPORT void RawConvertColorToGray();
    EXTERN_DLL_EXPORT void RawConvertColorToColorAlpha();
    EXTERN_DLL_EXPORT void RawConvertColorToHLS();
    EXTERN_DLL_EXPORT void RawConvertColorToHSV();
    EXTERN_DLL_EXPORT void RawConvertBRGToRGB();
    EXTERN_DLL_EXPORT void RawConvertBRGToRGBA();
    EXTERN_DLL_EXPORT void RawConvertGrayToRGB();
    EXTERN_DLL_EXPORT void RawConvertGrayToColor();
    EXTERN_DLL_EXPORT void RawIncreaseBrightness(double alpha, double beta);
    EXTERN_DLL_EXPORT void RawIncreaseBrightnessSmart(double gamma);
    EXTERN_DLL_EXPORT void RawAddConstMargin(int top, int bottom, int left, int right, int r, int g, int b);
    EXTERN_DLL_EXPORT void RawAddMirrorMargin(int top, int bottom, int left, int right);
    EXTERN_DLL_EXPORT void RawAddReplicatedMargin(int top, int bottom, int left, int right);
    EXTERN_DLL_EXPORT void RawAddWrapMargin(int top, int bottom, int left, int right);
    EXTERN_DLL_EXPORT void RawDrawCurve(int centerX, int centerY, int width, int height, double angle, int thickness, double startAngle, double endAngle, int r, int g, int b);
    EXTERN_DLL_EXPORT void RawDrawFilledCircle(int centerX, int centerY, int radius, int r, int g, int b);
    EXTERN_DLL_EXPORT void RawDrawLine(int startX, int startY, int endX, int endY, int thickness);
    EXTERN_DLL_EXPORT void RawDrawRandomLine(int itterations, int x1, int y1, int x2, int y2, int r, int g, int b, int thickness);
    EXTERN_DLL_EXPORT void RawDrawRandomLineRandomColor(int itterations, int x1, int y1, int x2, int y2, int thickness);
    EXTERN_DLL_EXPORT void RawDrawRandomHollowRectangle(int itterations, int x1, int y1, int x2, int y2, int r, int g, int b, int thickness);
    EXTERN_DLL_EXPORT void RawDrawRandomHollowRectangleRandomColor(int itterations, int x1, int y1, int x2, int y2, int thickness);
    EXTERN_DLL_EXPORT void RawDisplayRandomTextPosition(int itterations, STRING text, int x1, int y1, int x2, int y2, int r, int g, int b);
    EXTERN_DLL_EXPORT void RawDisplayRandomTextPositionRandomColor(int itterations, STRING text, int x1, int y1, int x2, int y2);
    EXTERN_DLL_EXPORT void RawBlurImage(int blurSize);
    EXTERN_DLL_EXPORT void RawErodeImageRectangle(int erosionSize);
    EXTERN_DLL_EXPORT void RawErodeImageCross(int erosionSize);
    EXTERN_DLL_EXPORT void RawErodeImageEllipse(int erosionSize);
    EXTERN_DLL_EXPORT void RawErodeImage(int erosionSize);
    EXTERN_DLL_EXPORT void RawDialateImageRectangle(int dialationSize);
    EXTERN_DLL_EXPORT void RawDialateImageCross(int dialationSize);
    EXTERN_DLL_EXPORT void RawDialateImageEllipse(int dialationSize);
    EXTERN_DLL_EXPORT void RawDialateImage(int dialationSize);
    EXTERN_DLL_EXPORT void RawRemoveBackgroundNoise(int kernelSize);
    EXTERN_DLL_EXPORT void RawGetHorizontalLines();
    EXTERN_DLL_EXPORT void RawGetVerticalLines();
    EXTERN_DLL_EXPORT void RawConvertToBinary();
    EXTERN_DLL_EXPORT void RawConvertToInverseBinary();
    EXTERN_DLL_EXPORT void RawSmoothEdges();
    EXTERN_DLL_EXPORT void RawLowThresholdImage(double thresholdValue);
    EXTERN_DLL_EXPORT void RawHighThresholdImage(double thresholdValue);
    EXTERN_DLL_EXPORT void RawDetectEdges();
    EXTERN_DLL_EXPORT void RawTiltImage(double angle, double scale);
    EXTERN_DLL_EXPORT void RawDrawRandomFilledTriangles(int itterations, int x1, int y1, int x2, int y2);
    EXTERN_DLL_EXPORT void RawDrawRandomHollowTriangles(int itterations, int x1, int y1, int x2, int y2);
    EXTERN_DLL_EXPORT void RawGetContours(int thresh);
    EXTERN_DLL_EXPORT void RawGetConvexHull(double thresh);
    EXTERN_DLL_EXPORT void RawWatershedImage();
    EXTERN_DLL_EXPORT void RawGetCorners(int maxCorners);

    // Debug functions.
    EXTERN_DLL_EXPORT void DebugCheckImageEmpty();
    void WriteLineError(string message);

    // Temporary functions.
    Ptr<Formatted> FormatToDefualt(Mat m);
    Ptr<Formatted> FormatToPython(Mat m);
    Ptr<Formatted> FormatToCSV(Mat m);
    Ptr<Formatted> FormatToNumpy(Mat m);
    Ptr<Formatted> FormatToC(Mat m);

    Scalar GetRandomColor(RNG& rng);
}
