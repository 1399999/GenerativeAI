#include <opencv2/core.hpp>
#include <opencv2/imgcodecs.hpp>
#include <opencv2/highgui.hpp>
#include <opencv2/imgproc.hpp>
#include <iostream>
#include <fstream>
#include <string>
#include <windows.h>   // WinApi header.
#include "opencv2/features2d.hpp"

using namespace cv;
using namespace std;

#define EXTERN_DLL_EXPORT extern "C" __declspec(dllexport)
#define STRING const char *

namespace OpenCVUtilities
{
    const string tempOutputfilePath = "C:\\Temp\\CppFileIOTest.txt";
    const string tempInputPath = "C:\\Users\\mzheb\\Downloads\\saturn-v2.jpg";

    EXTERN_DLL_EXPORT void GetImgColor(STRING path);
    EXTERN_DLL_EXPORT void GetImgGrayscale(STRING path);
    EXTERN_DLL_EXPORT void CreateRect(int x, int y, Scalar rgb);
    EXTERN_DLL_EXPORT void WriteToFile(STRING path);

    EXTERN_DLL_EXPORT void DebugCheckImageEmpty();

    void Copy(Mat matrix);
}
