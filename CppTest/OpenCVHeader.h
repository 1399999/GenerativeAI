#include <opencv2/core.hpp>
#include <opencv2/imgcodecs.hpp>
#include <opencv2/highgui.hpp>
#include <opencv2/imgproc.hpp>
#include <iostream>
#include <fstream>
#include <string>

using namespace cv;
using namespace std;

namespace OpenCVUtilities
{
    const string filePath = "C:\\Temp\\CppFileIOTest.txt";
    const string tempInputPath = "C:\\Users\\mzheb\\Downloads\\saturn-v2.jpg";

    void ImReadColor(char** argv);
    void ImReadGrayscale(char** argv);
    void WriteToFile(string message);
}
