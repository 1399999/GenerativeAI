//#include "OpenCVHeader.h"
//
//namespace OpenCVUtilities
//{
// All of these are temporary functions, and so the explanations behind them are not accurate.
// 
//    // Function ID: 6.
    // Description: Creates an array of ones from the specified paramaters.
    // Paramater (input): All pixels of the image.
    // Warning: Has to be used in conjunction with other methods.
    // EXTERN_DLL_EXPORT void RawCreateManualArray(double input[])
	// {
    //     Mat_<double> dsfds= 
	//
    //     standardImg = input;
	// }

//   // Function ID: 23.
	//Scalar RawGetIntensityGrayScale(int x, int y)
	//{
	//	Scalar intensity = standardImg.at<uchar>(Point(x, y));
	//	return intensity;
	//}

 //   // Function ID: 24.
	//void RawGetIntensityColor(int x, int y)
	//{
	//	Vec3b intensity = standardImg.at<Vec3b>(y, x);
	//	uchar blue = intensity.val[0];
	//	uchar green = intensity.val[1];
	//	uchar red = intensity.val[2];
	//}

 //   // Function ID: 25.
	//void RawGetIntensityFloatColor(int x, int y)
	//{
	//	Vec3f intensity = standardImg.at<Vec3f>(y, x);
	//	float blue = intensity.val[0];
	//	float green = intensity.val[1];
	//	float red = intensity.val[2];
	//}

//   // Function ID: 34.
	//Mat BlendImages(Mat src1, double alpha, Mat src2, double beta)
	//{
	//	Mat dst;
	//	addWeighted(src1, alpha, src2, beta, 0.0, dst);

	//	return dst;
	//}

 //   // Function ID: 43.
 //   // Description: Draws a polygon using a set of points.
 //   // Warning: Has to be used in conjunction with other methods.
	//void DrawPolygon(Point coords[])
	//{
	//	int lineType = LINE_8;

	//	const Point* ppt[1] = { coords };
	//	int npt[] = { 20 };

	//	fillPoly(standardImg,
	//		ppt,
	//		npt,
	//		1,
	//		Scalar(255, 255, 255),
	//		lineType);
	//}

//// Function ID: 61.
	//EXTERN_DLL_EXPORT void RawRemoveForegroundNoise(int kernelSize)
	//{
	//	int dilation_type = MORPH_CLOSE;

	//	Mat element = getStructuringElement(dilation_type,
	//		Size(2 * kernelSize + 1, 2 * kernelSize + 1),
	//		Point(kernelSize, kernelSize));

	//	morphologyEx(standardImg, standardImg, dilation_type, element);
	//}

	//// Function ID: 62.
	//EXTERN_DLL_EXPORT void RawGetOutline(int kernelSize)
	//{
	//	int dilation_type = MORPH_GRADIENT;

	//	Mat element = getStructuringElement(dilation_type,
	//		Size(2 * kernelSize + 1, 2 * kernelSize + 1),
	//		Point(kernelSize, kernelSize));

	//	morphologyEx(standardImg, standardImg, dilation_type, element);
	//}

	//// Function ID: 63.
	//EXTERN_DLL_EXPORT void RawGetTopHat(int kernelSize)
	//{
	//	int dilation_type = MORPH_TOPHAT;

	//	Mat element = getStructuringElement(dilation_type,
	//		Size(2 * kernelSize + 1, 2 * kernelSize + 1),
	//		Point(kernelSize, kernelSize));

	//	morphologyEx(standardImg, standardImg, dilation_type, element);
	//}

	//// Function ID: 64.
	//EXTERN_DLL_EXPORT void RawGetBlackHat(int kernelSize)
	//{
	//	int dilation_type = MORPH_BLACKHAT;

	//	Mat element = getStructuringElement(dilation_type,
	//		Size(2 * kernelSize + 1, 2 * kernelSize + 1),
	//		Point(kernelSize, kernelSize));

	//	morphologyEx(standardImg, standardImg, dilation_type, element);
	//}

	//// Function ID: 64.
	//EXTERN_DLL_EXPORT void RawGetHitMiss(int kernelSize)
	//{
	//	int dilation_type = MORPH_HITMISS;

	//	Mat element = getStructuringElement(dilation_type,
	//		Size(2 * kernelSize + 1, 2 * kernelSize + 1),
	//		Point(kernelSize, kernelSize));

	//	morphologyEx(standardImg, standardImg, dilation_type, element);
	//}

	//// Function ID: 70.
	//// Description: Zooms into the center of an image.
	//// Warning: Has to be used in conjunction with other methods.
	//EXTERN_DLL_EXPORT void RawZoomIn(int multiplier)
	//{
	//	pyrUp(standardImg, standardImg, Size(standardImg.cols * multiplier, standardImg.rows * multiplier));
	//}

	//// Function ID: 71.
	//// Description: Zooms into the center of an image.
	//// Warning: Has to be used in conjunction with other methods.
	//EXTERN_DLL_EXPORT void RawZoomOut(int multiplier)
	//{
	//	pyrUp(standardImg, standardImg, Size(standardImg.cols / multiplier, standardImg.rows / multiplier));
	//}

//// Function ID: 74.
	//// Description: Gets the frequency by which colors are distributed in an image and plots them to a histogram.
	//// Warning: Has to be used in conjunction with other methods.
	//// Warning: Can only be used for grayscale images.
	//EXTERN_DLL_EXPORT void RawGetHistogramGrayscale()
	//{
	//	equalizeHist(standardImg, standardImg);
	//}

	//// Function ID: 75.
	//// Description: Gets the frequency by which colors are distributed in an image and plots them to a histogram.
	//// Warning: Has to be used in conjunction with other methods.
	//// Warning: Can only be used for color images.
	//EXTERN_DLL_EXPORT void RawGetHistogramColor()
	//{
	//	int histSize = 256;
	//	Mat b_hist, g_hist, r_hist;

	//	int hist_w = 512, hist_h = 400;
	//	int bin_w = cvRound((double)hist_w / histSize);

	//	Mat histImage(hist_h, hist_w, CV_8UC3, Scalar(0, 0, 0));

	//	normalize(b_hist, b_hist, 0, histImage.rows, NORM_MINMAX, -1, Mat());
	//	normalize(g_hist, g_hist, 0, histImage.rows, NORM_MINMAX, -1, Mat());
	//	normalize(r_hist, r_hist, 0, histImage.rows, NORM_MINMAX, -1, Mat());

	//	line(histImage, Point(bin_w, hist_h - cvRound(b_hist.at<float>(0))),
	//		Point(bin_w, hist_h - cvRound(b_hist.at<float>(0))),
	//		Scalar(255, 0, 0), 2, 8, 0);
	//	line(histImage, Point(bin_w, hist_h - cvRound(g_hist.at<float>(0))),
	//		Point(bin_w, hist_h - cvRound(g_hist.at<float>(0))),
	//		Scalar(0, 255, 0), 2, 8, 0);
	//	line(histImage, Point(bin_w, hist_h - cvRound(r_hist.at<float>(0))),
	//		Point(bin_w, hist_h - cvRound(r_hist.at<float>(0))),
	//		Scalar(0, 0, 255), 2, 8, 0);
	//}

//// Function ID: 77.
	//// Warning: Has to be used in conjunction with other methods.
	//EXTERN_DLL_EXPORT void RawHoughCircleTransform()
	//{
	//	Mat gray;
	//	cvtColor(standardImg, gray, COLOR_BGR2GRAY);

	//	medianBlur(gray, gray, 5);

	//	vector<Vec3f> circles;
	//	HoughCircles(gray, circles, HOUGH_GRADIENT, 1,
	//		gray.rows / 16,  // change this value to detect circles with different distances to each other
	//		100, 30, 1, 30 // change the last two parameters
	//		// (min_radius & max_radius) to detect larger circles
	//	);

	//	for (size_t i = 0; i < circles.size(); i++)
	//	{
	//		Vec3i c = circles[i];
	//		Point center = Point(c[0], c[1]);
	//		// circle center
	//		circle(standardImg, center, 1, Scalar(0, 100, 100), 3, LINE_AA);
	//		// circle outline
	//		int radius = c[2];
	//		circle(standardImg, center, radius, Scalar(255, 0, 255), 3, LINE_AA);
	//	}
	//}

//// 79, too difficult to implment.
	//Mat TemplateMatch(Mat img)
	//{
	//	Mat output;

	//	Mat img_display;
	//	img.copyTo(img_display);

	//	int result_cols = img.cols - templ.cols + 1;
	//	int result_rows = img.rows - templ.rows + 1;

	//	output.create(result_rows, result_cols, CV_32FC1);

	//	matchTemplate(img, templ, output, 0, mask);
	//	matchTemplate(img, templ, output, 0);

	//	normalize(result, result, 0, 1, NORM_MINMAX, -1, Mat());

	//	double minVal; double maxVal; Point minLoc; Point maxLoc;
	//	Point matchLoc;

	//	minMaxLoc(result, &minVal, &maxVal, &minLoc, &maxLoc, Mat());

	//	if (match_method == TM_SQDIFF || match_method == TM_SQDIFF_NORMED)
	//	{
	//		matchLoc = minLoc;
	//	}
	//	else
	//	{
	//		matchLoc = maxLoc;
	//	}

	//	rectangle(img_display, matchLoc, Point(matchLoc.x + templ.cols, matchLoc.y + templ.rows), Scalar::all(0), 2, 8, 0);
	//	rectangle(result, matchLoc, Point(matchLoc.x + templ.cols, matchLoc.y + templ.rows), Scalar::all(0), 2, 8, 0);
	//}

//// Function ID: 84.
	//// Description: Another countor thing.
	//// Paramater (thresh): The higher the number the more contours.
	//EXTERN_DLL_EXPORT void RawCreateBoundingBox(int thresh)
	//{
	//	RNG rng(rand());

	//	Mat canny_output;
	//	Canny(standardImg, canny_output, thresh, thresh * 2);

	//	vector<vector<Point> > contours;
	//	findContours(canny_output, contours, RETR_TREE, CHAIN_APPROX_SIMPLE);

	//	vector<vector<Point> > contours_poly(contours.size());
	//	vector<Rect> boundRect(contours.size());
	//	vector<Point2f>centers(contours.size());
	//	vector<float>radius(contours.size());

	//	for (size_t i = 0; i < contours.size(); i++)
	//	{
	//		approxPolyDP(contours[i], contours_poly[i], 3, true);
	//		boundRect[i] = boundingRect(contours_poly[i]);
	//		minEnclosingCircle(contours_poly[i], centers[i], radius[i]);
	//	}

	//	Mat drawing = Mat::zeros(canny_output.size(), CV_8UC3);

	//	for (size_t i = 0; i < contours.size(); i++)
	//	{
	//		Scalar color = Scalar(rng.uniform(0, 256), rng.uniform(0, 256), rng.uniform(0, 256));
	//		drawContours(drawing, contours_poly, (int)i, color);
	//		rectangle(drawing, boundRect[i].tl(), boundRect[i].br(), color, 2);
	//		circle(drawing, centers[i], (int)radius[i], color, 2);
	//	}

	//	standardImg = canny_output;
	//}

	//// Function ID: 85.
	//// Description: Another countor thing.
	//// Paramater (thresh): The higher the number the more contours.
	//EXTERN_DLL_EXPORT void RawCreateBoundingBoxRotatedEllipses(int thresh)
	//{
	//	RNG rng(rand());

	//	Mat canny_output;
	//	Canny(standardImg, canny_output, thresh, thresh * 2);
	//	vector<vector<Point> > contours;
	//	findContours(canny_output, contours, RETR_TREE, CHAIN_APPROX_SIMPLE, Point(0, 0));

	//	vector<RotatedRect> minRect(contours.size());
	//	vector<RotatedRect> minEllipse(contours.size());
	//	for (size_t i = 0; i < contours.size(); i++)
	//	{
	//		minRect[i] = minAreaRect(contours[i]);
	//		if (contours[i].size() > 5)
	//		{
	//			minEllipse[i] = fitEllipse(contours[i]);
	//		}
	//	}

	//	Mat drawing = Mat::zeros(canny_output.size(), CV_8UC3);
	//	for (size_t i = 0; i < contours.size(); i++)
	//	{
	//		Scalar color = Scalar(rng.uniform(0, 256), rng.uniform(0, 256), rng.uniform(0, 256));
	//		// contour
	//		drawContours(drawing, contours, (int)i, color);
	//		// ellipse
	//		ellipse(drawing, minEllipse[i], color, 2);
	//		// rotated rectangle
	//		Point2f rect_points[4];
	//		minRect[i].points(rect_points);
	//		for (int j = 0; j < 4; j++)
	//		{
	//			line(drawing, rect_points[j], rect_points[(j + 1) % 4], color);
	//		}
	//	}
	//}

	//// Function ID: 86.
	//// Description: Another countor thing, not renamed.
	//// Paramater (thresh): The higher the number the more contours.
	//EXTERN_DLL_EXPORT void ImageMoments(int thresh)
	//{
	//	RNG rng(rand());

	//	Mat canny_output;
	//	Canny(standardImg, canny_output, thresh, thresh * 2, 3);
	//	vector<vector<Point> > contours;
	//	findContours(canny_output, contours, RETR_TREE, CHAIN_APPROX_SIMPLE);

	//	vector<Moments> mu(contours.size());
	//	for (size_t i = 0; i < contours.size(); i++)
	//	{
	//		mu[i] = moments(contours[i]);
	//	}

	//	vector<Point2f> mc(contours.size());
	//	for (size_t i = 0; i < contours.size(); i++)
	//	{
	//		//add 1e-5 to avoid division by zero
	//		mc[i] = Point2f(static_cast<float>(mu[i].m10 / (mu[i].m00 + 1e-5)),
	//			static_cast<float>(mu[i].m01 / (mu[i].m00 + 1e-5)));
	//		cout << "mc[" << i << "]=" << mc[i] << endl;
	//	}

	//	Mat drawing = Mat::zeros(canny_output.size(), CV_8UC3);
	//	for (size_t i = 0; i < contours.size(); i++)
	//	{
	//		Scalar color = Scalar(rng.uniform(0, 256), rng.uniform(0, 256), rng.uniform(0, 256));
	//		drawContours(drawing, contours, (int)i, color, 2);
	//		circle(drawing, mc[i], 4, color, -1);
	//	}

	//	standardImg = drawing;
	//}

//// Function ID: 88.
	//VideoCapture GetVideo(string path)
	//{
	//	VideoCapture inputVideo(path);
	//}

	// Function ID: 89, not really renamed.
	//Mat GetHarrisCorners(Mat src, Mat src_gray, int thresh)
	//{
	//	int blockSize = 2;
	//	int apertureSize = 3;
	//	double k = 0.04;

	//	Mat dst = Mat::zeros(src.size(), CV_32FC1);
	//	cornerHarris(src_gray, dst, blockSize, apertureSize, k);

	//	Mat dst_norm, dst_norm_scaled;
	//	normalize(dst, dst_norm, 0, 255, NORM_MINMAX, CV_32FC1, Mat());
	//	convertScaleAbs(dst_norm, dst_norm_scaled);

	//	for (int i = 0; i < dst_norm.rows; i++)
	//	{
	//		for (int j = 0; j < dst_norm.cols; j++)
	//		{
	//			if ((int)dst_norm.at<float>(i, j) > thresh)
	//			{
	//				circle(dst_norm_scaled, Point(j, i), 5, Scalar(0), 2, 8, 0);
	//			}
	//		}
	//	}

	//	return dst_norm_scaled;
	//}

//// Function ID: 91.
	//// Description: Gets and draws the corners detected in the image.
	//// Paramater (maxCorners): The maximum amount of corners that the function will detect.
	//// Warning: Has to be used in conjunction with other methods.
	//// Warning: Only works with grayscale images.
	//EXTERN_DLL_EXPORT void GetCornerSubpixels(int maxCorners)
	//{
	//	RNG rng(rand());

	//	maxCorners = MAX(maxCorners, 1);
	//	vector<Point2f> corners;
	//	double qualityLevel = 0.01;
	//	double minDistance = 10;
	//	int blockSize = 3, gradientSize = 3;
	//	bool useHarrisDetector = false;
	//	double k = 0.04;

	//	Mat copy = RawCreateArrayZerosCopy(standardImg.rows, standardImg.cols);

	//	goodFeaturesToTrack(standardImg,
	//		corners,
	//		maxCorners,
	//		qualityLevel,
	//		minDistance,
	//		Mat(),
	//		blockSize,
	//		gradientSize,
	//		useHarrisDetector,
	//		k);


	//	//cout << "** Number of corners detected: " << corners.size() << endl;
	//	int radius = 4;
	//	for (size_t i = 0; i < corners.size(); i++)
	//	{
	//		circle(copy, corners[i], radius, Scalar(rng.uniform(0, 255), rng.uniform(0, 256), rng.uniform(0, 256)), FILLED);
	//	}

	//	Size winSize = Size(5, 5);
	//	Size zeroZone = Size(-1, -1);
	//	TermCriteria criteria = TermCriteria(TermCriteria::EPS + TermCriteria::COUNT, 40, 0.001);

	//	cornerSubPix(standardImg, corners, winSize, zeroZone, criteria);

	//	//for (size_t i = 0; i < corners.size(); i++)
	//	//{
	//	//	cout << " -- Refined Corner [" << i << "]  (" << corners[i].x << "," << corners[i].y << ")" << endl;
	//	//}

	//	standardImg = copy;
	//}

	//// ?
	//EXTERN_DLL_EXPORT void ScanImageAndReduceColors(const uchar* const table)
	//{
	//	Mat output;

	//	Mat lookUpTable(1, 256, CV_8U);
	//	uchar* p = lookUpTable.ptr();

	//	for (int i = 0; i < 256; ++i)
	//	{
	//		p[i] = table[i];
	//		LUT(standardImg, lookUpTable, output);
	//	}

	//	standardImg = output;
	//}

//
	/* To be tested:
		File Input and Output using XML and YAML files,
		How to use the OpenCV parallel_for_ to parallelize your code,
		Vectorizing your code using Universal Intrinsics,
		Thresholding Operations using inRange,
		Making your own linear filters!,
		Sobel Derivatives,
		Laplace Operator,
		Object detection with Generalized Ballard and Guil Hough Transform,
		Remapping,
		Histogram Comparison,
		Back Projection,
		Point Polygon Test,
		Out-of-focus Deblur Filter,
		Motion Deblur Filter,
		Periodic Noise Removing Filter,
		Adding a Trackbar to our applications!,
		Periodic Noise Removing Filter,
		Using Kinect and other OpenNI compatible depth sensors,
		Object Detection (objdetect module) (entire section),
		Creating your own corner detector,
		Feature Detection,
		Feature Description,
		Feature Matching with FLANN,
		Features2D + Homography to find a known object,
		Detection of planar objects,
		AKAZE local features matching,
		AKAZE and ORB planar tracking,
		Basic concepts of the homography explained with code,
	*/

	/* To be tested, but not interested:
		Reading Geospatial Raster files with GDAL,
		Video Input with OpenCV and similarity measurement,
		Using Orbbec Astra 3D cameras,
		Using Creative Senz3D and other Intel RealSense SDK compatible depth sensors,
		Using Wayland highgui-backend in Ubuntu,
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
// }
