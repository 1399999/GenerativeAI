#include "OpenCVHeader.h"

namespace OpenCVUtilities
{
	// 0
	Mat ReadImgColor(string path)
	{
		Mat img;
		img = imread(tempInputPath, IMREAD_COLOR); // path

		return img;
	}

	// 1
	Mat ReadImgGrayscale(string path)
	{
		Mat img;
		img = imread(tempInputPath, IMREAD_GRAYSCALE); // path

		return img;
	}

	// 2
	Mat Copy(Mat matrix)
	{
		Mat img(matrix);

		return img;
	}

	// 3
	Mat CreateRect(int x, int y, int r, int g, int b)
	{
		// CV_8UC3 is written in this format: CV_[The number of bits per item][Signed or Unsigned][Type Prefix]C[The channel number]

		Mat rect(x, y, CV_8UC3, Scalar(r, g, b));
		return rect;
	}

	// 4
	Mat CreateArrayOnes(int x, int y)
	{
		Mat o = Mat::ones(x, y, CV_32F);
		return o;
	}

	// 5
	Mat CreateArrayZeros(int x, int y)
	{
		Mat z = Mat::zeros(x, y, CV_8UC1);
		return z;
	}

	// 6
	Mat CreateManualArray(Mat_<double> input)
	{
		Mat m = input;
		return m;
	}

	// 7
	Mat GetRow(Mat m)
	{
		Mat rowClone = m.row(1).clone();
		return rowClone;
	}

	// 8
	Mat CreateRandomArray(int x, int y, int min, int max)
	{
		Mat r = Mat(x, y, CV_8UC3);
		randu(r, Scalar::all(min), Scalar::all(max));
	}

	// 9
	Ptr<Formatted> FormatToDefualt(Mat m)
	{
		Ptr<Formatted> f = format(m, Formatter::FMT_DEFAULT);
		return f;
	}

	// 10
	Ptr<Formatted> FormatToPython(Mat m)
	{
		Ptr<Formatted> f = format(m, Formatter::FMT_PYTHON);
		return f;
	}

	// 11
	Ptr<Formatted> FormatToCSV(Mat m)
	{
		Ptr<Formatted> f = format(m, Formatter::FMT_CSV);
		return f;
	}

	// 12
	Ptr<Formatted> FormatToNumpy(Mat m)
	{
		Ptr<Formatted> f = format(m, Formatter::FMT_NUMPY);
		return f;
	}

	// 13
	Ptr<Formatted> FormatToC(Mat m)
	{
		Ptr<Formatted> f = format(m, Formatter::FMT_C);
		return f;
	}

	// 15
	Mat ScanImageAndReduceColors(Mat I, const uchar* const table)
	{
		Mat output;

		Mat lookUpTable(1, 256, CV_8U);
		uchar* p = lookUpTable.ptr();

		for (int i = 0; i < 256; ++i)
		{
			p[i] = table[i];
			LUT(I, lookUpTable, output);
		}

		return output;
	}

	// 16
	Mat ApplyMask(Mat src, Mat kernel)
	{
		// For example:
		/*Mat kernel = (Mat_<char>(3, 3) << 0, -1, 0,
			-1, 5, -1,
			0, -1, 0);*/

		Mat output;
		filter2D(src, output, src.depth(), kernel);

		return output;
	}

	// 17
	void WriteToFile(string filePath, Mat img)
	{
		imwrite(filePath, img);
	}

	// 18
	Scalar GetIntensityGrayScale(Mat img, int x, int y)
	{
		Scalar intensity = img.at<uchar>(Point(x, y));
		return intensity;
	}

	// 19
	void GetIntensityColor(Mat img, int x, int y)
	{
		Vec3b intensity = img.at<Vec3b>(y, x);
		uchar blue = intensity.val[0];
		uchar green = intensity.val[1];
		uchar red = intensity.val[2];
	}

	// 20
	void GetIntensityFloatColor(Mat img, int x, int y)
	{
		Vec3f intensity = img.at<Vec3f>(y, x);
		float blue = intensity.val[0];
		float green = intensity.val[1];
		float red = intensity.val[2];
	}

	// 21
	Mat GetRegionOfInterest(Mat img, int x1, int y1, int x2, int y2)
	{
		Rect r(x1, x2, y1, y2);
		Mat smallImg = img(r);

		return smallImg;
	}

	// 22
	Mat ConvertColorToGray(Mat img)
	{
		Mat grey;
		cvtColor(img, grey, COLOR_BGR2GRAY);

		return img;
	}

	// 23
	Mat ConvertColorToColorAlpha(Mat img)
	{
		Mat grey;
		cvtColor(img, grey, COLOR_BGR2BGRA);

		return img;
	}

	// 24
	Mat ConvertColorToHLS(Mat img)
	{
		Mat grey;
		cvtColor(img, grey, COLOR_BGR2HLS);

		return img;
	}

	// 25
	Mat ConvertColorToHSV(Mat img)
	{
		Mat grey;
		cvtColor(img, grey, COLOR_BGR2HSV);

		return img;
	}

	// 26
	Mat ConvertBRGToRGB(Mat img)
	{
		Mat grey;
		cvtColor(img, grey, COLOR_BGR2RGB);

		return img;
	}

	// 27
	Mat ConvertBRGToRGBA(Mat img)
	{
		Mat grey;
		cvtColor(img, grey, COLOR_BGR2RGBA);

		return img;
	}

	// 28
	Mat ConvertGrayToRGB(Mat img)
	{
		Mat grey;
		cvtColor(img, grey, COLOR_GRAY2RGB);

		return img;
	}

	// 29
	Mat ConvertGrayToColor(Mat img)
	{
		Mat grey;
		cvtColor(img, grey, COLOR_GRAY2BGR);

		return img;
	}

	// 30
	void DisplayWindow(Mat img, string winddowName)
	{
		namedWindow(winddowName, WINDOW_AUTOSIZE);
		imshow(winddowName, img);
		waitKey();
	}

	// 31
	Mat BlendImages(Mat src1, double alpha, Mat src2, double beta)
	{
		Mat dst;
		addWeighted(src1, alpha, src2, beta, 0.0, dst);

		return dst;
	}

	// 32
	Mat IncreaseBrightness(Mat image, int alpha, int beta)
	{
		// Alpha is contrast, beta is brightness.
		Mat new_image = Mat::zeros(image.size(), image.type());

		for (int y = 0; y < image.rows; y++)
		{
			for (int x = 0; x < image.cols; x++)
			{
				for (int c = 0; c < image.channels(); c++)
				{
					new_image.at<Vec3b>(y, x)[c] = saturate_cast<uchar>(alpha * image.at<Vec3b>(y, x)[c] + beta);
				}
			}
		}

		return new_image;
	}

	// 33
	Mat IncreaseBrightnessSmart(Mat img, int gamma_)
	{
		Mat lookUpTable(1, 256, CV_8U);
		uchar* p = lookUpTable.ptr();
		for (int i = 0; i < 256; ++i)
			p[i] = saturate_cast<uchar>(pow(i / 255.0, gamma_) * 255.0);

		Mat res = img.clone();
		LUT(img, lookUpTable, res);

		return res;
	}

	// 34
	Mat AddMarginSmart(Mat img)
	{
		Mat padded;                            //expand input image to optimal size
		int m = getOptimalDFTSize(img.rows);
		int n = getOptimalDFTSize(img.cols); // on the border add zero values
		copyMakeBorder(img, padded, 0, m - img.rows, 0, n - img.cols, BORDER_CONSTANT, Scalar::all(0));

		Mat planes[] = { Mat_<float>(padded), Mat::zeros(padded.size(), CV_32F) };
		Mat complexI;
		merge(planes, 2, complexI);         // Add to the expanded another plane with zeros

		dft(complexI, complexI);            // this way the result may fit in the source matrix

		// compute the magnitude and switch to logarithmic scale
		// => log(1 + sqrt(Re(DFT(I))^2 + Im(DFT(I))^2))
		split(complexI, planes);                   // planes[0] = Re(DFT(I), planes[1] = Im(DFT(I))
		magnitude(planes[0], planes[1], planes[0]);// planes[0] = magnitude
		Mat magI = planes[0];

		magI += Scalar::all(1);                    // switch to logarithmic scale
		log(magI, magI);

		// crop the spectrum, if it has an odd number of rows or columns
		magI = magI(Rect(0, 0, magI.cols & -2, magI.rows & -2));

		// rearrange the quadrants of Fourier image  so that the origin is at the image center
		int cx = magI.cols / 2;
		int cy = magI.rows / 2;

		Mat q0(magI, Rect(0, 0, cx, cy));   // Top-Left - Create a ROI per quadrant
		Mat q1(magI, Rect(cx, 0, cx, cy));  // Top-Right
		Mat q2(magI, Rect(0, cy, cx, cy));  // Bottom-Left
		Mat q3(magI, Rect(cx, cy, cx, cy)); // Bottom-Right

		Mat tmp;                           // swap quadrants (Top-Left with Bottom-Right)
		q0.copyTo(tmp);
		q3.copyTo(q0);
		tmp.copyTo(q3);

		q1.copyTo(tmp);                    // swap quadrant (Top-Right with Bottom-Left)
		q2.copyTo(q1);
		tmp.copyTo(q2);

		normalize(magI, magI, 0, 1, NORM_MINMAX); // Transform the matrix with float values into a
		// viewable image form (float between values 0 and 1).

		return magI;
	}

	// 35
	void DrawHollowEllipse(Mat img, double angle, int thickness, int lineType, int centerX, int centerY, int width, int height, double startAngle, double endAngle, int r, int g, int b)
	{
		// Do not know what lineType is, my theory is that it is an enum.

		ellipse(img,
			Point(centerX, centerY),
			Size(width, height),
			angle,
			startAngle,
			endAngle,
			Scalar(r, g, b),
			thickness,
			lineType);
	}

	// 36
	Mat DrawFilledCircle(Mat img, int centerX, int centerY, int radius, int r, int g, int b)
	{
		circle(img,
			Point(centerX, centerY),
			radius,
			Scalar(r, g, b),
			FILLED,
			LINE_8);

		return img;
	}

	// 37
	void DrawPolygon(Mat img, Point coords[])
	{
		int lineType = LINE_8;

		const Point* ppt[1] = { coords };
		int npt[] = { 20 };

		fillPoly(img,
			ppt,
			npt,
			1,
			Scalar(255, 255, 255),
			lineType);
	}

	// 38
	void DrawLine(Mat img, int startX, int startY, int endX, int endY)
	{
		int thickness = 2;
		int lineType = LINE_8;

		line(img,
			Point(startX, startY),
			Point(endX, endY),
			Scalar(0, 0, 0),
			thickness,
			lineType);
	}

	// 39
	static Scalar GetRandomColor(RNG& rng)
	{
		int icolor = (unsigned)rng;
		return Scalar(icolor & 255, (icolor >> 8) & 255, (icolor >> 16) & 255);
	}

	// 40
	void DrawRandomLine(Mat image, string window_name, RNG rng, int itterations, Scalar rgb, int x1, int y1, int x2, int y2)
	{
		Point pt1, pt2;

		for (int i = 0; i < itterations; i++)
		{
			pt1.x = rng.uniform(x1, x2);
			pt1.y = rng.uniform(y1, y2);
			pt2.x = rng.uniform(x1, x2);
			pt2.y = rng.uniform(y1, y2);

			line(image, pt1, pt2, rgb, rng.uniform(1, 10), 8);
		}
	}

	// 41
	Mat DrawRandomLineRandomColor(Mat image, RNG rng, int itterations, int x1, int y1, int x2, int y2)
	{
		Point pt1, pt2;

		for (int i = 0; i < itterations; i++)
		{
			pt1.x = rng.uniform(x1, x2);
			pt1.y = rng.uniform(y1, y2);
			pt2.x = rng.uniform(x1, x2);
			pt2.y = rng.uniform(y1, y2);

			line(image, pt1, pt2, GetRandomColor(rng), rng.uniform(1, 10), 8);
		}

		return image;
	}

	// 42
	Mat DrawRandomRectangle(Mat image, RNG rng, int itterations, Scalar rgb, int x1, int y1, int x2, int y2)
	{
		Point pt1, pt2;
		int lineType = 8;
		int thickness = rng.uniform(-3, 10);

		for (int i = 0; i < itterations; i++)
		{
			pt1.x = rng.uniform(x1, x2);
			pt1.y = rng.uniform(y1, y2);
			pt2.x = rng.uniform(x1, x2);
			pt2.y = rng.uniform(y1, y2);

			rectangle(image, pt1, pt2, rgb, MAX(thickness, -1), lineType);
		}

		return image;
	}

	// 43
	Mat DrawRandomRectangleRandomNumber(Mat img, RNG rng, int itterations, int x1, int y1, int x2, int y2)
	{
		Point pt1, pt2;
		int lineType = 8;
		int thickness = rng.uniform(-3, 10);

		for (int i = 0; i < itterations; i++)
		{
			pt1.x = rng.uniform(x1, x2);
			pt1.y = rng.uniform(y1, y2);
			pt2.x = rng.uniform(x1, x2);
			pt2.y = rng.uniform(y1, y2);

			rectangle(img, pt1, pt2, GetRandomColor(rng) MAX(thickness, -1), lineType);
		}

		return img;
	}

	// 44
	Mat DisplayRandomTextPosition(Mat img, RNG rng, int itterations, string text, Scalar rgb, int x1, int y1, int x2, int y2)
	{
		int lineType = 8;

		for (int i = 1; i < itterations; i++)
		{
			Point org;
			org.x = rng.uniform(x1, x2);
			org.y = rng.uniform(y1, y2);

			putText(img, text, org, rng.uniform(0, 8),
				rng.uniform(0, 100) * 0.05 + 0.1, rgb, rng.uniform(1, 10), lineType);
		}

		return img;
	}

	// 45
	Mat DisplayRandomTextPosition(Mat img, RNG rng, int itterations, string text, int x1, int y1, int x2, int y2)
	{
		int lineType = 8;

		for (int i = 1; i < itterations; i++)
		{
			Point org;
			org.x = rng.uniform(x1, x2);
			org.y = rng.uniform(y1, y2);

			putText(img, text, org, rng.uniform(0, 8),
				rng.uniform(0, 100) * 0.05 + 0.1, GetRandomColor(rng), rng.uniform(1, 10), lineType);
		}

		return img;
	}

	// 46
	Mat BlurImage(Mat img, int kernelSize)
	{
		Mat output;

		medianBlur(img, output, kernelSize);

		return output;
	}

	// 47
	Mat ErodeImageRectangle(Mat img, int erosionSize)
	{
		Mat output;

		int erosion_type = MORPH_RECT;

		Mat element = getStructuringElement(erosion_type,
			Size(2 * erosionSize + 1, 2 * erosionSize + 1),
			Point(erosionSize, erosionSize));

		erode(img, output, element);

		return output;
	}

	// 48
	Mat ErodeImageCross(Mat img, int erosionSize)
	{
		Mat output;

		int erosion_type = MORPH_CROSS;

		Mat element = getStructuringElement(erosion_type,
			Size(2 * erosionSize + 1, 2 * erosionSize + 1),
			Point(erosionSize, erosionSize));

		erode(img, output, element);

		return output;
	}

	// 48
	Mat ErodeImageEllipse(Mat img, int erosionSize)
	{
		Mat output;

		int erosion_type = MORPH_ELLIPSE;

		Mat element = getStructuringElement(erosion_type,
			Size(2 * erosionSize + 1, 2 * erosionSize + 1),
			Point(erosionSize, erosionSize));

		erode(img, output, element);

		return output;
	}

	// 49
	Mat ErodeImage(Mat img, int erosionSize)
	{
		Mat output;

		int erosion_type = MORPH_ERODE;

		Mat element = getStructuringElement(erosion_type,
			Size(2 * erosionSize + 1, 2 * erosionSize + 1),
			Point(erosionSize, erosionSize));

		erode(img, output, element);

		return output;
	}

	// 50
	Mat DialateRectangle(Mat img, int dialationSize)
	{
		Mat output;

		int dilation_type = MORPH_RECT;

		Mat element = getStructuringElement(dilation_type,
			Size(2 * dialationSize + 1, 2 * dialationSize + 1),
			Point(dialationSize, dialationSize));

		dilate(img, output, element);

		return output;
	}

	// 51
	Mat DialateCross(Mat img, int dialationSize)
	{
		Mat output;

		int dilation_type = MORPH_CROSS;

		Mat element = getStructuringElement(dilation_type,
			Size(2 * dialationSize + 1, 2 * dialationSize + 1),
			Point(dialationSize, dialationSize));

		dilate(img, output, element);

		return output;
	}

	// 52
	Mat DialateEllipse(Mat img, int dialationSize)
	{
		Mat output;

		int dilation_type = MORPH_ELLIPSE;

		Mat element = getStructuringElement(dilation_type,
			Size(2 * dialationSize + 1, 2 * dialationSize + 1),
			Point(dialationSize, dialationSize));

		dilate(img, output, element);

		return output;
	}

	// 53
	Mat DialateImage(Mat img, int dialationSize)
	{
		Mat output;

		int dilation_type = MORPH_DILATE;

		Mat element = getStructuringElement(dilation_type,
			Size(2 * dialationSize + 1, 2 * dialationSize + 1),
			Point(dialationSize, dialationSize));

		dilate(img, output, element);

		return output;
	}

	// 54, also known as Opening.
	Mat RemoveBackgroundNoise()
	{
		
	}

	/*if (dilation_elem == 0) { dilation_type = MORPH_RECT; }
	else if (dilation_elem == 1) { dilation_type = MORPH_CROSS; }
	else if (dilation_elem == 2) { dilation_type = MORPH_ELLIPSE; }*/

	// For testingr
	/*Mat DrawRandomFilledPolygon(Mat image, RNG rng, int itterations)
	{
		int lineType = 8;

		for (int i = 0; i < itterations; i++)
		{
			Point pt[2][3];
			pt[0][0].x = rng.uniform(x_1, x_2);
			pt[0][0].y = rng.uniform(y_1, y_2);
			pt[0][1].x = rng.uniform(x_1, x_2);
			pt[0][1].y = rng.uniform(y_1, y_2);
			pt[0][2].x = rng.uniform(x_1, x_2);
			pt[0][2].y = rng.uniform(y_1, y_2);
			pt[1][0].x = rng.uniform(x_1, x_2);
			pt[1][0].y = rng.uniform(y_1, y_2);
			pt[1][1].x = rng.uniform(x_1, x_2);
			pt[1][1].y = rng.uniform(y_1, y_2);
			pt[1][2].x = rng.uniform(x_1, x_2);
			pt[1][2].y = rng.uniform(y_1, y_2);

			const Point* ppt[2] = { pt[0], pt[1] };
			int npt[] = { 3, 3 };

			fillPoly(image, ppt, npt, 2, GetRandomColor(rng), lineType);
		}
	}*/

	// For testing
	/*Mat DrawRandomHollowPolygon(Mat image, RNG rng, int itterations)
	{
		int lineType = 8;

		for (int i = 0; i < itterations; i++)
		{
			Point pt[2][3];
			pt[0][0].x = rng.uniform(x_1, x_2);
			pt[0][0].y = rng.uniform(y_1, y_2);
			pt[0][1].x = rng.uniform(x_1, x_2);
			pt[0][1].y = rng.uniform(y_1, y_2);
			pt[0][2].x = rng.uniform(x_1, x_2);
			pt[0][2].y = rng.uniform(y_1, y_2);
			pt[1][0].x = rng.uniform(x_1, x_2);
			pt[1][0].y = rng.uniform(y_1, y_2);
			pt[1][1].x = rng.uniform(x_1, x_2);
			pt[1][1].y = rng.uniform(y_1, y_2);
			pt[1][2].x = rng.uniform(x_1, x_2);
			pt[1][2].y = rng.uniform(y_1, y_2);

			const Point* ppt[2] = { pt[0], pt[1] };
			int npt[] = { 3, 3 };

			polylines(image, ppt, npt, 2, true, randomColor(rng), rng.uniform(1, 10), lineType);

			imshow(window_name, image);
			if (waitKey(DELAY) >= 0)
			{
				return -1;
			}
		}
		return 0;
	}*/

	/* To be tested:
		File Input and Output using XML and YAML files,
		How to use the OpenCV parallel_for_ to parallelize your code,
		Vectorizing your code using Universal Intrinsics,
	*/

	/* OpenCV Theory:
		Point:
			It represents a 2D point, specified by its image coordinates x and y, we can define it as:
				Point pt =  Point(10, 8);
		Scalar:
			Represents a 4-element vector. The type Scalar is widely used in OpenCV for passing pixel values.
			In this tutorial, we will use it extensively to represent BGR color values (3 parameters). It is not necessary to define the last argument if it is not going to be used.
			Let's see an example, if we are asked for a color argument and we give:
				Scalar( a, b, c )
			We would be defining a BGR color such as: Blue = a, Green = b and Red = c.
	*/
}
