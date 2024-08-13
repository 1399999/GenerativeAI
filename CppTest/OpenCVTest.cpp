//#include "OpenCVHeader.h"
//
//// Warning: No validation is taking place
//namespace OpenCVUtilities
//{
//	// 7
//	Mat GetRow(Mat m)
//	{
//		Mat rowClone = m.row(1).clone();
//		return rowClone;
//	}
//
//	// 8
//	Mat CreateRandomArray(int x, int y, int min, int max)
//	{
//		Mat r = Mat(x, y, CV_8UC3);
//		randu(r, Scalar::all(min), Scalar::all(max));
//	}
//
//	// 9
//	Ptr<Formatted> FormatToDefualt(Mat m)
//	{
//		Ptr<Formatted> f = format(m, Formatter::FMT_DEFAULT);
//		return f;
//	}
//
//	// 10
//	Ptr<Formatted> FormatToPython(Mat m)
//	{
//		Ptr<Formatted> f = format(m, Formatter::FMT_PYTHON);
//		return f;
//	}
//
//	// 11
//	Ptr<Formatted> FormatToCSV(Mat m)
//	{
//		Ptr<Formatted> f = format(m, Formatter::FMT_CSV);
//		return f;
//	}
//
//	// 12
//	Ptr<Formatted> FormatToNumpy(Mat m)
//	{
//		Ptr<Formatted> f = format(m, Formatter::FMT_NUMPY);
//		return f;
//	}
//
//	// 13
//	Ptr<Formatted> FormatToC(Mat m)
//	{
//		Ptr<Formatted> f = format(m, Formatter::FMT_C);
//		return f;
//	}
//
//	// 15
//	Mat ScanImageAndReduceColors(Mat I, const uchar* const table)
//	{
//		Mat output;
//
//		Mat lookUpTable(1, 256, CV_8U);
//		uchar* p = lookUpTable.ptr();
//
//		for (int i = 0; i < 256; ++i)
//		{
//			p[i] = table[i];
//			LUT(I, lookUpTable, output);
//		}
//
//		return output;
//	}
//
//	// 16
//	Mat ApplyMask(Mat src, Mat kernel)
//	{
//		// For example:
//		//Mat kernel = (Mat_<char>(3, 3) << 0, -1, 0,
//		//	-1, 5, -1,
//		//	0, -1, 0);
//
//		Mat output;
//		filter2D(src, output, src.depth(), kernel);
//
//		return output;
//	}
//	
//	// 17
//	EXTERN_DLL_EXPORT void WriteToFile(string filePath, Mat img)
//	{
//		imwrite(filePath, img);
//	}*/
//	
//	EXTERN_DLL_EXPORT void WriteToFile(string filePath)
//	{
//		imwrite(filePath, OpenCVUtilities::inputImg);
//	}
//	
//	/*// 18
//	Scalar GetIntensityGrayScale(Mat img, int x, int y)
//	{
//		Scalar intensity = img.at<uchar>(Point(x, y));
//		return intensity;
//	}
//
//	// 19
//	void GetIntensityColor(Mat img, int x, int y)
//	{
//		Vec3b intensity = img.at<Vec3b>(y, x);
//		uchar blue = intensity.val[0];
//		uchar green = intensity.val[1];
//		uchar red = intensity.val[2];
//	}
//
//	// 20
//	void GetIntensityFloatColor(Mat img, int x, int y)
//	{
//		Vec3f intensity = img.at<Vec3f>(y, x);
//		float blue = intensity.val[0];
//		float green = intensity.val[1];
//		float red = intensity.val[2];
//	}
//
//	// 21
//	Mat GetRegionOfInterest(Mat img, int x1, int y1, int x2, int y2)
//	{
//		Rect r(x1, x2, y1, y2);
//		Mat smallImg = img(r);
//
//		return smallImg;
//	}
//
//	// 22
//	Mat ConvertColorToGray(Mat img)
//	{
//		Mat grey;
//		cvtColor(img, grey, COLOR_BGR2GRAY);
//
//		return img;
//	}
//
//	// 23
//	Mat ConvertColorToColorAlpha(Mat img)
//	{
//		Mat grey;
//		cvtColor(img, grey, COLOR_BGR2BGRA);
//
//		return img;
//	}
//
//	// 24
//	Mat ConvertColorToHLS(Mat img)
//	{
//		Mat grey;
//		cvtColor(img, grey, COLOR_BGR2HLS);
//
//		return img;
//	}
//
//	// 25
//	Mat ConvertColorToHSV(Mat img)
//	{
//		Mat grey;
//		cvtColor(img, grey, COLOR_BGR2HSV);
//
//		return img;
//	}
//
//	// 26
//	Mat ConvertBRGToRGB(Mat img)
//	{
//		Mat grey;
//		cvtColor(img, grey, COLOR_BGR2RGB);
//
//		return img;
//	}
//
//	// 27
//	Mat ConvertBRGToRGBA(Mat img)
//	{
//		Mat grey;
//		cvtColor(img, grey, COLOR_BGR2RGBA);
//
//		return img;
//	}
//
//	// 28
//	Mat ConvertGrayToRGB(Mat img)
//	{
//		Mat grey;
//		cvtColor(img, grey, COLOR_GRAY2RGB);
//
//		return img;
//	}
//
//	// 29
//	Mat ConvertGrayToColor(Mat img)
//	{
//		Mat grey;
//		cvtColor(img, grey, COLOR_GRAY2BGR);
//
//		return img;
//	}
//
//	// 30
//	void DisplayWindow(Mat img, string winddowName)
//	{
//		namedWindow(winddowName, WINDOW_AUTOSIZE);
//		imshow(winddowName, img);
//		waitKey();
//	}
//
//	// 31
//	Mat BlendImages(Mat src1, double alpha, Mat src2, double beta)
//	{
//		Mat dst;
//		addWeighted(src1, alpha, src2, beta, 0.0, dst);
//
//		return dst;
//	}
//
//	// 32
//	Mat IncreaseBrightness(Mat image, int alpha, int beta)
//	{
//		// Alpha is contrast, beta is brightness.
//		Mat new_image = Mat::zeros(image.size(), image.type());
//
//		for (int y = 0; y < image.rows; y++)
//		{
//			for (int x = 0; x < image.cols; x++)
//			{
//				for (int c = 0; c < image.channels(); c++)
//				{
//					new_image.at<Vec3b>(y, x)[c] = saturate_cast<uchar>(alpha * image.at<Vec3b>(y, x)[c] + beta);
//				}
//			}
//		}
//
//		return new_image;
//	}
//
//	// 33
//	Mat IncreaseBrightnessSmart(Mat img, int gamma_)
//	{
//		Mat lookUpTable(1, 256, CV_8U);
//		uchar* p = lookUpTable.ptr();
//		for (int i = 0; i < 256; ++i)
//			p[i] = saturate_cast<uchar>(pow(i / 255.0, gamma_) * 255.0);
//
//		Mat res = img.clone();
//		LUT(img, lookUpTable, res);
//
//		return res;
//	}
//
//	// 34
//	Mat AddMarginSmart(Mat img)
//	{
//		Mat padded;                            //expand input image to optimal size
//		int m = getOptimalDFTSize(img.rows);
//		int n = getOptimalDFTSize(img.cols); // on the border add zero values
//		copyMakeBorder(img, padded, 0, m - img.rows, 0, n - img.cols, BORDER_CONSTANT, Scalar::all(0));
//
//		Mat planes[] = { Mat_<float>(padded), Mat::zeros(padded.size(), CV_32F) };
//		Mat complexI;
//		merge(planes, 2, complexI);         // Add to the expanded another plane with zeros
//
//		dft(complexI, complexI);            // this way the result may fit in the source matrix
//
//		// compute the magnitude and switch to logarithmic scale
//		// => log(1 + sqrt(Re(DFT(I))^2 + Im(DFT(I))^2))
//		split(complexI, planes);                   // planes[0] = Re(DFT(I), planes[1] = Im(DFT(I))
//		magnitude(planes[0], planes[1], planes[0]);// planes[0] = magnitude
//		Mat magI = planes[0];
//
//		magI += Scalar::all(1);                    // switch to logarithmic scale
//		log(magI, magI);
//
//		// crop the spectrum, if it has an odd number of rows or columns
//		magI = magI(Rect(0, 0, magI.cols & -2, magI.rows & -2));
//
//		// rearrange the quadrants of Fourier image  so that the origin is at the image center
//		int cx = magI.cols / 2;
//		int cy = magI.rows / 2;
//
//		Mat q0(magI, Rect(0, 0, cx, cy));   // Top-Left - Create a ROI per quadrant
//		Mat q1(magI, Rect(cx, 0, cx, cy));  // Top-Right
//		Mat q2(magI, Rect(0, cy, cx, cy));  // Bottom-Left
//		Mat q3(magI, Rect(cx, cy, cx, cy)); // Bottom-Right
//
//		Mat tmp;                           // swap quadrants (Top-Left with Bottom-Right)
//		q0.copyTo(tmp);
//		q3.copyTo(q0);
//		tmp.copyTo(q3);
//
//		q1.copyTo(tmp);                    // swap quadrant (Top-Right with Bottom-Left)
//		q2.copyTo(q1);
//		tmp.copyTo(q2);
//
//		normalize(magI, magI, 0, 1, NORM_MINMAX); // Transform the matrix with float values into a
//		// viewable image form (float between values 0 and 1).
//
//		return magI;
//	}
//
//	// 35
//	void DrawHollowEllipse(Mat img, double angle, int thickness, int lineType, int centerX, int centerY, int width, int height, double startAngle, double endAngle, int r, int g, int b)
//	{
//		// Do not know what lineType is, my theory is that it is an enum.
//
//		ellipse(img,
//			Point(centerX, centerY),
//			Size(width, height),
//			angle,
//			startAngle,
//			endAngle,
//			Scalar(r, g, b),
//			thickness,
//			lineType);
//	}
//
//	// 36
//	Mat DrawFilledCircle(Mat img, int centerX, int centerY, int radius, int r, int g, int b)
//	{
//		circle(img,
//			Point(centerX, centerY),
//			radius,
//			Scalar(r, g, b),
//			FILLED,
//			LINE_8);
//
//		return img;
//	}
//
//	// 37
//	void DrawPolygon(Mat img, Point coords[])
//	{
//		int lineType = LINE_8;
//
//		const Point* ppt[1] = { coords };
//		int npt[] = { 20 };
//
//		fillPoly(img,
//			ppt,
//			npt,
//			1,
//			Scalar(255, 255, 255),
//			lineType);
//	}
//
//	// 38
//	void DrawLine(Mat img, int startX, int startY, int endX, int endY)
//	{
//		int thickness = 2;
//		int lineType = LINE_8;
//
//		line(img,
//			Point(startX, startY),
//			Point(endX, endY),
//			Scalar(0, 0, 0),
//			thickness,
//			lineType);
//	}
//
//	// 39
//	static Scalar GetRandomColor(RNG& rng)
//	{
//		int icolor = (unsigned)rng;
//		return Scalar(icolor & 255, (icolor >> 8) & 255, (icolor >> 16) & 255);
//	}
//
//	// 40
//	void DrawRandomLine(Mat image, string window_name, RNG rng, int itterations, Scalar rgb, int x1, int y1, int x2, int y2)
//	{
//		Point pt1, pt2;
//
//		for (int i = 0; i < itterations; i++)
//		{
//			pt1.x = rng.uniform(x1, x2);
//			pt1.y = rng.uniform(y1, y2);
//			pt2.x = rng.uniform(x1, x2);
//			pt2.y = rng.uniform(y1, y2);
//
//			line(image, pt1, pt2, rgb, rng.uniform(1, 10), 8);
//		}
//	}
//
//	// 41
//	Mat DrawRandomLineRandomColor(Mat image, RNG rng, int itterations, int x1, int y1, int x2, int y2)
//	{
//		Point pt1, pt2;
//
//		for (int i = 0; i < itterations; i++)
//		{
//			pt1.x = rng.uniform(x1, x2);
//			pt1.y = rng.uniform(y1, y2);
//			pt2.x = rng.uniform(x1, x2);
//			pt2.y = rng.uniform(y1, y2);
//
//			line(image, pt1, pt2, GetRandomColor(rng), rng.uniform(1, 10), 8);
//		}
//
//		return image;
//	}
//
//	// 42
//	Mat DrawRandomRectangle(Mat image, RNG rng, int itterations, Scalar rgb, int x1, int y1, int x2, int y2)
//	{
//		Point pt1, pt2;
//		int lineType = 8;
//		int thickness = rng.uniform(-3, 10);
//
//		for (int i = 0; i < itterations; i++)
//		{
//			pt1.x = rng.uniform(x1, x2);
//			pt1.y = rng.uniform(y1, y2);
//			pt2.x = rng.uniform(x1, x2);
//			pt2.y = rng.uniform(y1, y2);
//
//			rectangle(image, pt1, pt2, rgb, MAX(thickness, -1), lineType);
//		}
//
//		return image;
//	}
//
//	// 43
//	Mat DrawRandomRectangleRandomNumber(Mat img, RNG rng, int itterations, int x1, int y1, int x2, int y2)
//	{
//		Point pt1, pt2;
//		int lineType = 8;
//		int thickness = rng.uniform(-3, 10);
//
//		for (int i = 0; i < itterations; i++)
//		{
//			pt1.x = rng.uniform(x1, x2);
//			pt1.y = rng.uniform(y1, y2);
//			pt2.x = rng.uniform(x1, x2);
//			pt2.y = rng.uniform(y1, y2);
//
//			rectangle(img, pt1, pt2, GetRandomColor(rng) MAX(thickness, -1), lineType);
//		}
//
//		return img;
//	}
//
//	// 44
//	Mat DisplayRandomTextPosition(Mat img, RNG rng, int itterations, string text, Scalar rgb, int x1, int y1, int x2, int y2)
//	{
//		int lineType = 8;
//
//		for (int i = 1; i < itterations; i++)
//		{
//			Point org;
//			org.x = rng.uniform(x1, x2);
//			org.y = rng.uniform(y1, y2);
//
//			putText(img, text, org, rng.uniform(0, 8),
//				rng.uniform(0, 100) * 0.05 + 0.1, rgb, rng.uniform(1, 10), lineType);
//		}
//
//		return img;
//	}
//
//	// 45
//	Mat DisplayRandomTextPosition(Mat img, RNG rng, int itterations, string text, int x1, int y1, int x2, int y2)
//	{
//		int lineType = 8;
//
//		for (int i = 1; i < itterations; i++)
//		{
//			Point org;
//			org.x = rng.uniform(x1, x2);
//			org.y = rng.uniform(y1, y2);
//
//			putText(img, text, org, rng.uniform(0, 8),
//				rng.uniform(0, 100) * 0.05 + 0.1, GetRandomColor(rng), rng.uniform(1, 10), lineType);
//		}
//
//		return img;
//	}
//
//	// 46
//	Mat BlurImage(Mat img, int kernelSize)
//	{
//		Mat output;
//
//		medianBlur(img, output, kernelSize);
//
//		return output;
//	}
//
//	// 47
//	Mat ErodeImageRectangle(Mat img, int erosionSize)
//	{
//		Mat output;
//
//		int erosion_type = MORPH_RECT;
//
//		Mat element = getStructuringElement(erosion_type,
//			Size(2 * erosionSize + 1, 2 * erosionSize + 1),
//			Point(erosionSize, erosionSize));
//
//		erode(img, output, element);
//
//		return output;
//	}
//
//	// 48
//	Mat ErodeImageCross(Mat img, int erosionSize)
//	{
//		Mat output;
//
//		int erosion_type = MORPH_CROSS;
//
//		Mat element = getStructuringElement(erosion_type,
//			Size(2 * erosionSize + 1, 2 * erosionSize + 1),
//			Point(erosionSize, erosionSize));
//
//		erode(img, output, element);
//
//		return output;
//	}
//
//	// 48
//	Mat ErodeImageEllipse(Mat img, int erosionSize)
//	{
//		Mat output;
//
//		int erosion_type = MORPH_ELLIPSE;
//
//		Mat element = getStructuringElement(erosion_type,
//			Size(2 * erosionSize + 1, 2 * erosionSize + 1),
//			Point(erosionSize, erosionSize));
//
//		erode(img, output, element);
//
//		return output;
//	}
//
//	// 49
//	Mat ErodeImage(Mat img, int erosionSize)
//	{
//		Mat output;
//
//		int erosion_type = MORPH_ERODE;
//
//		Mat element = getStructuringElement(erosion_type,
//			Size(2 * erosionSize + 1, 2 * erosionSize + 1),
//			Point(erosionSize, erosionSize));
//
//		erode(img, output, element);
//
//		return output;
//	}
//
//	// 50
//	Mat DialateRectangle(Mat img, int dialationSize)
//	{
//		Mat output;
//
//		int dilation_type = MORPH_RECT;
//
//		Mat element = getStructuringElement(dilation_type,
//			Size(2 * dialationSize + 1, 2 * dialationSize + 1),
//			Point(dialationSize, dialationSize));
//
//		dilate(img, output, element);
//
//		return output;
//	}
//
//	// 51
//	Mat DialateCross(Mat img, int dialationSize)
//	{
//		Mat output;
//
//		int dilation_type = MORPH_CROSS;
//
//		Mat element = getStructuringElement(dilation_type,
//			Size(2 * dialationSize + 1, 2 * dialationSize + 1),
//			Point(dialationSize, dialationSize));
//
//		dilate(img, output, element);
//
//		return output;
//	}
//
//	// 52
//	Mat DialateEllipse(Mat img, int dialationSize)
//	{
//		Mat output;
//
//		int dilation_type = MORPH_ELLIPSE;
//
//		Mat element = getStructuringElement(dilation_type,
//			Size(2 * dialationSize + 1, 2 * dialationSize + 1),
//			Point(dialationSize, dialationSize));
//
//		dilate(img, output, element);
//
//		return output;
//	}
//
//	// 53
//	Mat DialateImage(Mat img, int dialationSize)
//	{
//		Mat output;
//
//		int dilation_type = MORPH_DILATE;
//
//		Mat element = getStructuringElement(dilation_type,
//			Size(2 * dialationSize + 1, 2 * dialationSize + 1),
//			Point(dialationSize, dialationSize));
//
//		dilate(img, output, element);
//
//		return output;
//	}
//
//	// 54, also known as Opening.
//	Mat RemoveBackgroundNoise(Mat img, int kernelSize)
//	{
//		Mat output;
//
//		int dilation_type = MORPH_OPEN;
//
//		Mat element = getStructuringElement(dilation_type,
//			Size(2 * kernelSize + 1, 2 * kernelSize + 1),
//			Point(kernelSize, kernelSize));
//
//		morphologyEx(img, output, dilation_type, element);
//
//		return output;
//	}
//
//	// 55, also known as Closing.
//	Mat RemoveForegroundNoise(Mat img, int kernelSize)
//	{
//		Mat output;
//
//		int dilation_type = MORPH_CLOSE;
//
//		Mat element = getStructuringElement(dilation_type,
//			Size(2 * kernelSize + 1, 2 * kernelSize + 1),
//			Point(kernelSize, kernelSize));
//
//		morphologyEx(img, output, dilation_type, element);
//
//		return output;
//	}
//
//	// 56, also known as Morphological Gradient.
//	Mat GetOutline(Mat img, int kernelSize)
//	{
//		Mat output;
//
//		int dilation_type = MORPH_GRADIENT;
//
//		Mat element = getStructuringElement(dilation_type,
//			Size(2 * kernelSize + 1, 2 * kernelSize + 1),
//			Point(kernelSize, kernelSize));
//
//		morphologyEx(img, output, dilation_type, element);
//
//		return output;
//	}
//
//	// 57
//	Mat GetTopHat(Mat img, int kernelSize)
//	{
//		Mat output;
//
//		int dilation_type = MORPH_TOPHAT;
//
//		Mat element = getStructuringElement(dilation_type,
//			Size(2 * kernelSize + 1, 2 * kernelSize + 1),
//			Point(kernelSize, kernelSize));
//
//		morphologyEx(img, output, dilation_type, element);
//
//		return output;
//	}
//
//	// 58
//	Mat GetBlackHat(Mat img, int kernelSize)
//	{
//		Mat output;
//
//		int dilation_type = MORPH_BLACKHAT;
//
//		Mat element = getStructuringElement(dilation_type,
//			Size(2 * kernelSize + 1, 2 * kernelSize + 1),
//			Point(kernelSize, kernelSize));
//
//		morphologyEx(img, output, dilation_type, element);
//
//		return output;
//	}
//
//	// 59
//	Mat GetHitMiss(Mat img, Mat kernel)
//	{
//		Mat output;
//
//		int dilation_type = MORPH_HITMISS;
//
//		morphologyEx(img, output, dilation_type, kernel);
//
//		return output;
//	}
//
//	// 60
//	Mat GetHorizontalLines(Mat img)
//	{
//		Mat output;
//
//		// Apply adaptiveThreshold at the bitwise_not of gray, notice the ~ symbol.
//		adaptiveThreshold(~img, output, 255, ADAPTIVE_THRESH_MEAN_C, THRESH_BINARY, 15, -2);
//
//		// Create the images that will use to extract the horizontal and vertical lines.
//		Mat horizontal = output.clone();
//
//		// Specify size on horizontal axis.
//		int horizontal_size = horizontal.cols / 30;
//
//		// Create structure element for extracting horizontal lines through morphology operations.
//		Mat horizontalStructure = getStructuringElement(MORPH_RECT, Size(horizontal_size, 1));
//
//		// Apply morphology operations
//		erode(horizontal, horizontal, horizontalStructure, Point(-1, -1));
//		dilate(horizontal, horizontal, horizontalStructure, Point(-1, -1));
//
//		return horizontal;
//	}
//
//	// 61
//	Mat ConvertToBinary(Mat img)
//	{
//		Mat output;
//
//		// Apply adaptiveThreshold at the bitwise_not of gray, notice the ~ symbol.
//		adaptiveThreshold(~img, output, 255, ADAPTIVE_THRESH_MEAN_C, THRESH_BINARY, 15, -2);
//
//		return output;
//	}
//
//	// 62
//	Mat ConvertToInverseBinary(Mat img)
//	{
//		Mat output;
//
//		// Apply adaptiveThreshold at the bitwise_not of gray, notice the ~ symbol.
//		adaptiveThreshold(~img, output, 255, ADAPTIVE_THRESH_MEAN_C, THRESH_BINARY_INV, 15, -2);
//
//		return output;
//	}
//
//	// 63
//	Mat GetVerticalLines(Mat img)
//	{
//		Mat output;
//
//		// Apply adaptiveThreshold at the bitwise_not of gray, notice the ~ symbol.
//		adaptiveThreshold(~img, output, 255, ADAPTIVE_THRESH_MEAN_C, THRESH_BINARY, 15, -2);
//
//		Mat vertical = output.clone();
//
//		// Specify size on vertical axis
//		int vertical_size = vertical.rows / 30;
//
//		// Create structure element for extracting vertical lines through morphology operations
//		Mat verticalStructure = getStructuringElement(MORPH_RECT, Size(1, vertical_size));
//
//		// Apply morphology operations
//		erode(vertical, vertical, verticalStructure, Point(-1, -1));
//		dilate(vertical, vertical, verticalStructure, Point(-1, -1));
//
//		return vertical;
//	}
//
//	// 64
//	Mat SmoothEdges(Mat img)
//	{
//		// Step 1
//		Mat edges;
//		adaptiveThreshold(img, edges, 255, ADAPTIVE_THRESH_MEAN_C, THRESH_BINARY, 3, -2);
//
//		// Step 2
//		Mat kernel = Mat::ones(2, 2, CV_8UC1);
//		dilate(edges, edges, kernel);
//
//		// Step 3
//		Mat smooth;
//
//		// Step 4
//		blur(smooth, smooth, Size(2, 2));
//
//		return smooth;
//	}
//
//	// 66
//	Mat ZoomIn(Mat img, int multiplier)
//	{
//		Mat output;
//
//		pyrUp(img, output, Size(img.cols * multiplier, img.rows * multiplier));
//
//		return output;
//	}
//
//	// 67
//	Mat ZoomOut(Mat img, int multiplier)
//	{
//		Mat output;
//
//		pyrUp(img, output, Size(img.cols / multiplier, img.rows / multiplier));
//
//		return output;
//	}
//
//	// 68
//	Mat ConvertToTruncated(Mat img, double thresholdValue, double maxBinaryValue)
//	{
//		Mat output;
//
//		threshold(img, output, thresholdValue, maxBinaryValue, THRESH_TRUNC);
//
//		return output;
//	}
//
//	// 70
//	Mat ConvertToZero(Mat img, double thresholdValue, double maxBinaryValue)
//	{
//		Mat output;
//
//		threshold(img, output, thresholdValue, maxBinaryValue, THRESH_TOZERO);
//
//		return output;
//	}
//
//	// 71
//	Mat AddConstantBorder(Mat img, Scalar value, int top, int bottom, int left, int right)
//	{
//		Mat output;
//
//		copyMakeBorder(img, output, top, bottom, left, right, BORDER_CONSTANT, value);
//
//		return output;
//	}
//
//	// 72
//	Mat AddReplicateBorder(Mat img, Scalar value, int top, int bottom, int left, int right)
//	{
//		Mat output;
//
//		copyMakeBorder(img, output, top, bottom, left, right, BORDER_REPLICATE, value);
//
//		return output;
//	}
//
//	// 73
//	Mat EdgeDetection(Mat img, int kernelSize)
//	{
//		Mat output;
//
//		blur(img, output, Size(kernelSize, kernelSize));
//
//		const int lowThreshold = 0;
//		const int ratio = 3;
//
//		Canny(output, output, lowThreshold, lowThreshold * ratio, kernelSize);
//
//		output = Scalar::all(0);
//
//		return output;
//	}
//
//	// 74
//	Mat HoughLineTransform(Mat img)
//	{
//		Mat output;
//		Mat cdst;
//
//		// Edge detection
//		Canny(img, output, 50, 200, 3);
//
//		// Copy edges to the images that will display the results in BGR
//		cvtColor(output, cdst, COLOR_GRAY2BGR);
//		auto cdstP = cdst.clone();
//
//		// Standard Hough Line Transform
//		vector<Vec2f> lines; // will hold the results of the detection
//		HoughLines(output, lines, 1, CV_PI / 180, 150, 0, 0); // runs the actual detection
//		// Draw the lines
//		for (size_t i = 0; i < lines.size(); i++)
//		{
//			float rho = lines[i][0], theta = lines[i][1];
//			Point pt1, pt2;
//			double a = cos(theta), b = sin(theta);
//			double x0 = a * rho, y0 = b * rho;
//			pt1.x = cvRound(x0 + 1000 * (-b));
//			pt1.y = cvRound(y0 + 1000 * (a));
//			pt2.x = cvRound(x0 - 1000 * (-b));
//			pt2.y = cvRound(y0 - 1000 * (a));
//			line(cdst, pt1, pt2, Scalar(0, 0, 255), 3, LINE_AA);
//		}
//
//		// Probabilistic Line Transform
//		vector<Vec4i> linesP; // will hold the results of the detection
//		HoughLinesP(output, linesP, 1, CV_PI / 180, 50, 50, 10); // runs the actual detection
//		// Draw the lines
//		for (size_t i = 0; i < linesP.size(); i++)
//		{
//			Vec4i l = linesP[i];
//			line(cdstP, Point(l[0], l[1]), Point(l[2], l[3]), Scalar(0, 0, 255), 3, LINE_AA);
//		}
//
//		return output;
//	}
//
//	// 75
//	Mat HoughCircleTransform(Mat img)
//	{
//		Mat gray;
//		cvtColor(img, gray, COLOR_BGR2GRAY);
//
//		medianBlur(gray, gray, 5);
//
//		vector<Vec3f> circles;
//		HoughCircles(gray, circles, HOUGH_GRADIENT, 1,
//			gray.rows / 16,  // change this value to detect circles with different distances to each other
//			100, 30, 1, 30 // change the last two parameters
//			// (min_radius & max_radius) to detect larger circles
//		);
//
//		for (size_t i = 0; i < circles.size(); i++)
//		{
//			Vec3i c = circles[i];
//			Point center = Point(c[0], c[1]);
//			// circle center
//			circle(img, center, 1, Scalar(0, 100, 100), 3, LINE_AA);
//			// circle outline
//			int radius = c[2];
//			circle(img, center, radius, Scalar(255, 0, 255), 3, LINE_AA);
//		}
//
//		return img;
//	}
//
//	// 76
//	Mat AfflineTransformations(Mat img, double angle, double scale)
//	{
//		Point2f srcTri[3];
//		srcTri[0] = Point2f(0.f, 0.f);
//		srcTri[1] = Point2f(img.cols - 1.f, 0.f);
//		srcTri[2] = Point2f(0.f, img.rows - 1.f);
//
//		Point2f dstTri[3];
//		dstTri[0] = Point2f(0.f, img.rows * 0.33f);
//		dstTri[1] = Point2f(img.cols * 0.85f, img.rows * 0.25f);
//		dstTri[2] = Point2f(img.cols * 0.15f, img.rows * 0.7f);
//
//		Mat warp_mat = getAffineTransform(srcTri, dstTri);
//
//		Mat warp_dst = Mat::zeros(img.rows, img.cols, img.type());
//
//		warpAffine(img, warp_dst, warp_mat, warp_dst.size());
//
//		Point center = Point(warp_dst.cols / 2, warp_dst.rows / 2);
//
//		Mat rot_mat = getRotationMatrix2D(center, angle, scale);
//
//		Mat warp_rotate_dst;
//		warpAffine(warp_dst, warp_rotate_dst, rot_mat, warp_dst.size());
//
//		return warp_rotate_dst;
//	}
//
//	// 77
//	Mat GetHistogram(Mat img)
//	{
//		Mat output;
//
//		equalizeHist(img, output);
//
//		return output;
//	}
//
//	// 78
//	Mat GetHistogramColors(Mat img)
//	{
//		int histSize = 256;
//		Mat b_hist, g_hist, r_hist;
//
//		int hist_w = 512, hist_h = 400;
//		int bin_w = cvRound((double)hist_w / histSize);
//
//		Mat histImage(hist_h, hist_w, CV_8UC3, Scalar(0, 0, 0));
//
//		normalize(b_hist, b_hist, 0, histImage.rows, NORM_MINMAX, -1, Mat());
//		normalize(g_hist, g_hist, 0, histImage.rows, NORM_MINMAX, -1, Mat());
//		normalize(r_hist, r_hist, 0, histImage.rows, NORM_MINMAX, -1, Mat());
//
//		line(histImage, Point(bin_w, hist_h - cvRound(b_hist.at<float>(0))),
//			Point(bin_w, hist_h - cvRound(b_hist.at<float>(0))),
//			Scalar(255, 0, 0), 2, 8, 0);
//		line(histImage, Point(bin_w, hist_h - cvRound(g_hist.at<float>(0))),
//			Point(bin_w, hist_h - cvRound(g_hist.at<float>(0))),
//			Scalar(0, 255, 0), 2, 8, 0);
//		line(histImage, Point(bin_w, hist_h - cvRound(r_hist.at<float>(0))),
//			Point(bin_w, hist_h - cvRound(r_hist.at<float>(0))),
//			Scalar(0, 0, 255), 2, 8, 0);
//	}
//
//	// 79
//	/*Mat TemplateMatch(Mat img)
//	{
//		Mat output;
//
//		Mat img_display;
//		img.copyTo(img_display);
//
//		int result_cols = img.cols - templ.cols + 1;
//		int result_rows = img.rows - templ.rows + 1;
//
//		output.create(result_rows, result_cols, CV_32FC1);
//
//		matchTemplate(img, templ, output, 0, mask);
//		matchTemplate(img, templ, output, 0);
//
//		normalize(result, result, 0, 1, NORM_MINMAX, -1, Mat());
//
//		double minVal; double maxVal; Point minLoc; Point maxLoc;
//		Point matchLoc;
//
//		minMaxLoc(result, &minVal, &maxVal, &minLoc, &maxLoc, Mat());
//
//		if (match_method == TM_SQDIFF || match_method == TM_SQDIFF_NORMED)
//		{
//			matchLoc = minLoc;
//		}
//		else
//		{
//			matchLoc = maxLoc;
//		}
//
//		rectangle(img_display, matchLoc, Point(matchLoc.x + templ.cols, matchLoc.y + templ.rows), Scalar::all(0), 2, 8, 0);
//		rectangle(result, matchLoc, Point(matchLoc.x + templ.cols, matchLoc.y + templ.rows), Scalar::all(0), 2, 8, 0);
//	}*/
//
//	// 80
//	/*Mat DrawRandomFilledPolygon(Mat image, RNG rng, int itterations)
//	{
//		int lineType = 8;
//
//		for (int i = 0; i < itterations; i++)
//		{
//			Point pt[2][3];
//			pt[0][0].x = rng.uniform(x_1, x_2);
//			pt[0][0].y = rng.uniform(y_1, y_2);
//			pt[0][1].x = rng.uniform(x_1, x_2);
//			pt[0][1].y = rng.uniform(y_1, y_2);
//			pt[0][2].x = rng.uniform(x_1, x_2);
//			pt[0][2].y = rng.uniform(y_1, y_2);
//			pt[1][0].x = rng.uniform(x_1, x_2);
//			pt[1][0].y = rng.uniform(y_1, y_2);
//			pt[1][1].x = rng.uniform(x_1, x_2);
//			pt[1][1].y = rng.uniform(y_1, y_2);
//			pt[1][2].x = rng.uniform(x_1, x_2);
//			pt[1][2].y = rng.uniform(y_1, y_2);
//
//			const Point* ppt[2] = { pt[0], pt[1] };
//			int npt[] = { 3, 3 };
//
//			fillPoly(image, ppt, npt, 2, GetRandomColor(rng), lineType);
//		}
//	}*/
//
//	// 81
//	/*Mat DrawRandomHollowPolygon(Mat image, RNG rng, int itterations)
//	{
//		int lineType = 8;
//
//		for (int i = 0; i < itterations; i++)
//		{
//			Point pt[2][3];
//			pt[0][0].x = rng.uniform(x_1, x_2);
//			pt[0][0].y = rng.uniform(y_1, y_2);
//			pt[0][1].x = rng.uniform(x_1, x_2);
//			pt[0][1].y = rng.uniform(y_1, y_2);
//			pt[0][2].x = rng.uniform(x_1, x_2);
//			pt[0][2].y = rng.uniform(y_1, y_2);
//			pt[1][0].x = rng.uniform(x_1, x_2);
//			pt[1][0].y = rng.uniform(y_1, y_2);
//			pt[1][1].x = rng.uniform(x_1, x_2);
//			pt[1][1].y = rng.uniform(y_1, y_2);
//			pt[1][2].x = rng.uniform(x_1, x_2);
//			pt[1][2].y = rng.uniform(y_1, y_2);
//
//			const Point* ppt[2] = { pt[0], pt[1] };
//			int npt[] = { 3, 3 };
//
//			polylines(image, ppt, npt, 2, true, randomColor(rng), rng.uniform(1, 10), lineType);
//
//			imshow(window_name, image);
//			if (waitKey(DELAY) >= 0)
//			{
//				return -1;
//			}
//		}
//		return 0;
//	}*
//
//	// 82
//	Mat GetContours(int img, int thresh, RNG rng)
//	{
//		Mat output;
//
//		Mat canny_output;
//		Canny(img, canny_output, thresh, thresh * 2);
//
//		vector<vector<Point> > contours;
//		vector<Vec4i> hierarchy;
//		findContours(canny_output, contours, hierarchy, RETR_TREE, CHAIN_APPROX_SIMPLE);
//
//		Mat drawing = Mat::zeros(canny_output.size(), CV_8UC3);
//		for (size_t i = 0; i < contours.size(); i++)
//		{
//			Scalar color = Scalar(rng.uniform(0, 256), rng.uniform(0, 256), rng.uniform(0, 256));
//			drawContours(drawing, contours, (int)i, color, 2, LINE_8, hierarchy, 0);
//		}
//
//		return output;
//	}
//
//	// 83
//	Mat GetConvexHull(Mat img, double thresh, RNG rng)
//	{
//		Mat canny_output;
//		Canny(img, canny_output, thresh, thresh * 2);
//
//		vector<vector<Point> > contours;
//		findContours(canny_output, contours, RETR_TREE, CHAIN_APPROX_SIMPLE);
//
//		vector<vector<Point> >hull(contours.size());
//		for (size_t i = 0; i < contours.size(); i++)
//		{
//			convexHull(contours[i], hull[i]);
//		}
//
//		Mat drawing = Mat::zeros(canny_output.size(), CV_8UC3);
//		for (size_t i = 0; i < contours.size(); i++)
//		{
//			Scalar color = Scalar(rng.uniform(0, 256), rng.uniform(0, 256), rng.uniform(0, 256));
//			drawContours(drawing, contours, (int)i, color);
//			drawContours(drawing, hull, (int)i, color);
//		}
//
//		return canny_output;
//	}
//
//	// 84
//	Mat CreateBoundingBox(Mat img, int thresh, RNG rng)
//	{
//		Mat canny_output;
//		Canny(img, canny_output, thresh, thresh * 2);
//
//		vector<vector<Point> > contours;
//		findContours(canny_output, contours, RETR_TREE, CHAIN_APPROX_SIMPLE);
//
//		vector<vector<Point> > contours_poly(contours.size());
//		vector<Rect> boundRect(contours.size());
//		vector<Point2f>centers(contours.size());
//		vector<float>radius(contours.size());
//
//		for (size_t i = 0; i < contours.size(); i++)
//		{
//			approxPolyDP(contours[i], contours_poly[i], 3, true);
//			boundRect[i] = boundingRect(contours_poly[i]);
//			minEnclosingCircle(contours_poly[i], centers[i], radius[i]);
//		}
//
//		Mat drawing = Mat::zeros(canny_output.size(), CV_8UC3);
//
//		for (size_t i = 0; i < contours.size(); i++)
//		{
//			Scalar color = Scalar(rng.uniform(0, 256), rng.uniform(0, 256), rng.uniform(0, 256));
//			drawContours(drawing, contours_poly, (int)i, color);
//			rectangle(drawing, boundRect[i].tl(), boundRect[i].br(), color, 2);
//			circle(drawing, centers[i], (int)radius[i], color, 2);
//		}
//
//		return canny_output;
//	}
//
//	// 85
//	Mat CreateBoundingBoxRotatedEllipses(Mat img, int thresh, RNG rng)
//	{
//		Mat canny_output;
//		Canny(img, canny_output, thresh, thresh * 2);
//		vector<vector<Point> > contours;
//		findContours(canny_output, contours, RETR_TREE, CHAIN_APPROX_SIMPLE, Point(0, 0));
//
//		vector<RotatedRect> minRect(contours.size());
//		vector<RotatedRect> minEllipse(contours.size());
//		for (size_t i = 0; i < contours.size(); i++)
//		{
//			minRect[i] = minAreaRect(contours[i]);
//			if (contours[i].size() > 5)
//			{
//				minEllipse[i] = fitEllipse(contours[i]);
//			}
//		}
//
//		Mat drawing = Mat::zeros(canny_output.size(), CV_8UC3);
//		for (size_t i = 0; i < contours.size(); i++)
//		{
//			Scalar color = Scalar(rng.uniform(0, 256), rng.uniform(0, 256), rng.uniform(0, 256));
//			// contour
//			drawContours(drawing, contours, (int)i, color);
//			// ellipse
//			ellipse(drawing, minEllipse[i], color, 2);
//			// rotated rectangle
//			Point2f rect_points[4];
//			minRect[i].points(rect_points);
//			for (int j = 0; j < 4; j++)
//			{
//				line(drawing, rect_points[j], rect_points[(j + 1) % 4], color);
//			}
//		}
//	}
//
//	// 86, not renamed.
//	Mat ImageMoments(Mat img, int thresh, RNG rng)
//	{
//		Mat canny_output;
//		Canny(img, canny_output, thresh, thresh * 2, 3);
//		vector<vector<Point> > contours;
//		findContours(canny_output, contours, RETR_TREE, CHAIN_APPROX_SIMPLE);
//
//		vector<Moments> mu(contours.size());
//		for (size_t i = 0; i < contours.size(); i++)
//		{
//			mu[i] = moments(contours[i]);
//		}
//
//		vector<Point2f> mc(contours.size());
//		for (size_t i = 0; i < contours.size(); i++)
//		{
//			//add 1e-5 to avoid division by zero
//			mc[i] = Point2f(static_cast<float>(mu[i].m10 / (mu[i].m00 + 1e-5)),
//				static_cast<float>(mu[i].m01 / (mu[i].m00 + 1e-5)));
//			cout << "mc[" << i << "]=" << mc[i] << endl;
//		}
//
//		Mat drawing = Mat::zeros(canny_output.size(), CV_8UC3);
//		for (size_t i = 0; i < contours.size(); i++)
//		{
//			Scalar color = Scalar(rng.uniform(0, 256), rng.uniform(0, 256), rng.uniform(0, 256));
//			drawContours(drawing, contours, (int)i, color, 2);
//			circle(drawing, mc[i], 4, color, -1);
//		}
//
//		return drawing;
//	}
//
//	// 87, not renamed.
//	Mat WatershedAlgorithm(Mat src)
//	{
//		// Change the background from white to black, since that will help later to extract
//		// better results during the use of Distance Transform
//		Mat mask;
//		inRange(src, Scalar(255, 255, 255), Scalar(255, 255, 255), mask);
//		src.setTo(Scalar(0, 0, 0), mask);
//
//		// Show output image
//		//imshow("Black Background Image", src);
//
//		// Create a kernel that we will use to sharpen our image
//		Mat kernel = (Mat_<float>(3, 3) <<
//			1, 1, 1,
//			1, -8, 1,
//			1, 1, 1); // an approximation of second derivative, a quite strong kernel
//
//		// do the laplacian filtering as it is
//		// well, we need to convert everything in something more deeper then CV_8U
//		// because the kernel has some negative values,
//		// and we can expect in general to have a Laplacian image with negative values
//		// BUT a 8bits unsigned int (the one we are working with) can contain values from 0 to 255
//		// so the possible negative number will be truncated
//		Mat imgLaplacian;
//		filter2D(src, imgLaplacian, CV_32F, kernel);
//		Mat sharp;
//		src.convertTo(sharp, CV_32F);
//		Mat imgResult = sharp - imgLaplacian;
//
//		// convert back to 8bits gray scale
//		imgResult.convertTo(imgResult, CV_8UC3);
//		imgLaplacian.convertTo(imgLaplacian, CV_8UC3);
//
//		// imshow( "Laplace Filtered Image", imgLaplacian );
//		//imshow("New Sharped Image", imgResult);
//
//		// Create binary image from source image
//		Mat bw;
//		cvtColor(imgResult, bw, COLOR_BGR2GRAY);
//		threshold(bw, bw, 40, 255, THRESH_BINARY | THRESH_OTSU);
//		//imshow("Binary Image", bw);
//
//		// Perform the distance transform algorithm
//		Mat dist;
//		distanceTransform(bw, dist, DIST_L2, 3);
//
//		// Normalize the distance image for range = {0.0, 1.0}
//		// so we can visualize and threshold it
//		normalize(dist, dist, 0, 1.0, NORM_MINMAX);
//		//imshow("Distance Transform Image", dist);
//
//		// Threshold to obtain the peaks
//		// This will be the markers for the foreground objects
//		threshold(dist, dist, 0.4, 1.0, THRESH_BINARY);
//
//		// Dilate a bit the dist image
//		Mat kernel1 = Mat::ones(3, 3, CV_8U);
//		dilate(dist, dist, kernel1);
//		//imshow("Peaks", dist);
//
//		// Create the CV_8U version of the distance image
//		// It is needed for findContours()
//		Mat dist_8u;
//		dist.convertTo(dist_8u, CV_8U);
//
//		// Find total markers
//		vector<vector<Point> > contours;
//		findContours(dist_8u, contours, RETR_EXTERNAL, CHAIN_APPROX_SIMPLE);
//
//		// Create the marker image for the watershed algorithm
//		Mat markers = Mat::zeros(dist.size(), CV_32S);
//
//		// Draw the foreground markers
//		for (size_t i = 0; i < contours.size(); i++)
//		{
//			drawContours(markers, contours, static_cast<int>(i), Scalar(static_cast<int>(i) + 1), -1);
//		}
//
//		// Draw the background marker
//		circle(markers, Point(5, 5), 3, Scalar(255), -1);
//		Mat markers8u;
//		markers.convertTo(markers8u, CV_8U, 10);
//		//imshow("Markers", markers8u);
//
//		// Perform the watershed algorithm
//		watershed(imgResult, markers);
//
//		Mat mark;
//		markers.convertTo(mark, CV_8U);
//		bitwise_not(mark, mark);
//		//    imshow("Markers_v2", mark); // uncomment this if you want to see how the mark
//		// image looks like at that point
//
//		// Generate random colors
//		vector<Vec3b> colors;
//		for (size_t i = 0; i < contours.size(); i++)
//		{
//			int b = theRNG().uniform(0, 256);
//			int g = theRNG().uniform(0, 256);
//			int r = theRNG().uniform(0, 256);
//
//			colors.push_back(Vec3b((uchar)b, (uchar)g, (uchar)r));
//		}
//
//		// Create the result image
//		Mat dst = Mat::zeros(markers.size(), CV_8UC3);
//
//		// Fill labeled objects with random colors
//		for (int i = 0; i < markers.rows; i++)
//		{
//			for (int j = 0; j < markers.cols; j++)
//			{
//				int index = markers.at<int>(i, j);
//				if (index > 0 && index <= static_cast<int>(contours.size()))
//				{
//					dst.at<Vec3b>(i, j) = colors[index - 1];
//				}
//			}
//		}
//
//		// Visualize the final image
//		//imshow("Final Result", dst);
//	}
//
//	// 88
//	VideoCapture GetVideo(string path)
//	{
//		VideoCapture inputVideo(path);
//	}
//
//	// 89, not really renamed.
//	Mat GetHarrisCorners(Mat src, Mat src_gray, int thresh)
//	{
//		int blockSize = 2;
//		int apertureSize = 3;
//		double k = 0.04;
//
//		Mat dst = Mat::zeros(src.size(), CV_32FC1);
//		cornerHarris(src_gray, dst, blockSize, apertureSize, k);
//
//		Mat dst_norm, dst_norm_scaled;
//		normalize(dst, dst_norm, 0, 255, NORM_MINMAX, CV_32FC1, Mat());
//		convertScaleAbs(dst_norm, dst_norm_scaled);
//
//		for (int i = 0; i < dst_norm.rows; i++)
//		{
//			for (int j = 0; j < dst_norm.cols; j++)
//			{
//				if ((int)dst_norm.at<float>(i, j) > thresh)
//				{
//					circle(dst_norm_scaled, Point(j, i), 5, Scalar(0), 2, 8, 0);
//				}
//			}
//		}
//
//		return dst_norm_scaled;
//	}
//
//	// 90, not really renamed.
//	Mat GetShiTomasiCorners(Mat src, Mat src_gray, int maxCorners, RNG rng)
//	{
//		maxCorners = MAX(maxCorners, 1);
//		vector<Point2f> corners;
//		double qualityLevel = 0.01;
//		double minDistance = 10;
//		int blockSize = 3, gradientSize = 3;
//		bool useHarrisDetector = false;
//		double k = 0.04;
//
//		Mat copy = src.clone();
//
//		goodFeaturesToTrack(src_gray,
//			corners,
//			maxCorners,
//			qualityLevel,
//			minDistance,
//			Mat(),
//			blockSize,
//			gradientSize,
//			useHarrisDetector,
//			k);
//
//
//		//cout << "** Number of corners detected: " << corners.size() << endl;
//		int radius = 4;
//		for (size_t i = 0; i < corners.size(); i++)
//		{
//			circle(copy, corners[i], radius, Scalar(rng.uniform(0, 255), rng.uniform(0, 256), rng.uniform(0, 256)), FILLED);
//		}
//
//		return copy;
//	}
//	// 91, not really renamed.
//	Mat GetCornerSubpixels(Mat src, Mat src_gray, int maxCorners, RNG rng)
//	{
//		maxCorners = MAX(maxCorners, 1);
//		vector<Point2f> corners;
//		double qualityLevel = 0.01;
//		double minDistance = 10;
//		int blockSize = 3, gradientSize = 3;
//		bool useHarrisDetector = false;
//		double k = 0.04;
//
//		Mat copy = src.clone();
//
//		goodFeaturesToTrack(src_gray,
//			corners,
//			maxCorners,
//			qualityLevel,
//			minDistance,
//			Mat(),
//			blockSize,
//			gradientSize,
//			useHarrisDetector,
//			k);
//
//
//		//cout << "** Number of corners detected: " << corners.size() << endl;
//		int radius = 4;
//		for (size_t i = 0; i < corners.size(); i++)
//		{
//			circle(copy, corners[i], radius, Scalar(rng.uniform(0, 255), rng.uniform(0, 256), rng.uniform(0, 256)), FILLED);
//		}
//
//		//namedWindow(source_window);
//		//imshow(source_window, copy);
//
//		Size winSize = Size(5, 5);
//		Size zeroZone = Size(-1, -1);
//		TermCriteria criteria = TermCriteria(TermCriteria::EPS + TermCriteria::COUNT, 40, 0.001);
//
//		cornerSubPix(src_gray, corners, winSize, zeroZone, criteria);
//
//		//for (size_t i = 0; i < corners.size(); i++)
//		//{
//		//	cout << " -- Refined Corner [" << i << "]  (" << corners[i].x << "," << corners[i].y << ")" << endl;
//		//}
//
//		return copy;
//	} */
//
//
//	/* To be tested:
//		File Input and Output using XML and YAML files,
//		How to use the OpenCV parallel_for_ to parallelize your code,
//		Vectorizing your code using Universal Intrinsics,
//		Thresholding Operations using inRange,
//		Making your own linear filters!,
//		Sobel Derivatives,
//		Laplace Operator,
//		Object detection with Generalized Ballard and Guil Hough Transform,
//		Remapping,
//		Histogram Comparison,
//		Back Projection,
//		Point Polygon Test,
//		Out-of-focus Deblur Filter,
//		Motion Deblur Filter,
//		Periodic Noise Removing Filter,
//		Adding a Trackbar to our applications!,
//		Periodic Noise Removing Filter,
//		Using Kinect and other OpenNI compatible depth sensors,
//		Object Detection (objdetect module) (entire section),
//		Creating your own corner detector,
//		Feature Detection,
//		Feature Description,
//		Feature Matching with FLANN,
//		Features2D + Homography to find a known object,
//		Detection of planar objects,
//		AKAZE local features matching,
//		AKAZE and ORB planar tracking,
//		Basic concepts of the homography explained with code,
//	*/
//
//	/* To be tested, but not interested:
//		Reading Geospatial Raster files with GDAL,
//		Video Input with OpenCV and similarity measurement,
//		Using Orbbec Astra 3D cameras,
//		Using Creative Senz3D and other Intel RealSense SDK compatible depth sensors,
//		Using Wayland highgui-backend in Ubuntu,
//	*/
//
//	/* OpenCV Theory:
//		Point:
//			It represents a 2D point, specified by its image coordinates x and y, we can define it as:
//				Point pt =  Point(10, 8);
//		Scalar:
//			Represents a 4-element vector. The type Scalar is widely used in OpenCV for passing pixel values.
//			In this tutorial, we will use it extensively to represent BGR color values (3 parameters). It is not necessary to define the last argument if it is not going to be used.
//			Let's see an example, if we are asked for a color argument and we give:
//				Scalar( a, b, c )
//			We would be defining a BGR color such as: Blue = a, Green = b and Red = c.
//	*/
//}
