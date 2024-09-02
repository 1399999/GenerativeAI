namespace GenerativeAI.IntegratedConsole.Functionality.Navigator;

public static class SeedNavigator
{
    public static void Navigate()
    {
        foreach (var function in InputModel.StandardInput)
        {
            if (function.FunctionType == OptionEnum.WriteToFile && string.IsNullOrEmpty(function.OutputPath))
            {
                function.OutputPath = UtilityFunctions.GetNextOutputPath();
            }

            function.ExecuteOption();
        }
    }

    #pragma warning disable CS8629

    public static void ExecuteOption(this JsonInput input)
    {
        OptionEnum option = input.FunctionType;

        if (option == OptionEnum.GetColorImg) // 0
        {
            OpenCVUtilities.GetImgColor(input.InputPath);
        }

        else if (option == OptionEnum.GetGrayscaleImg) // 1
        {
            OpenCVUtilities.GetImgGrayscale(input.InputPath);
        }

        else if (option == OptionEnum.CreateRect) // 2
        {
            OpenCVUtilities.CreateRect((byte) input.Width,
                (byte) input.Height,
                (byte) input.RedChannel,
                (byte) input.BlueChannel,
                (byte) input.GreenChannel);
        }

        else if (option == OptionEnum.WriteToFile) // 3
        {
            OpenCVUtilities.WriteToFile(input.OutputPath);
        }

        else if (option == OptionEnum.CreateArrayOnes) // 4
        {
            OpenCVUtilities.CreateArrayOnes((byte) input.Width,
                (byte) input.Height,
                (byte) input.DivideBy);
        }

        else if (option == OptionEnum.CreateArrayZeros) // 5
        {
            OpenCVUtilities.CreateArrayZeros((byte) input.Width,
                (byte) input.Height);
        }

        else if (option == OptionEnum.GetRow) // 6
        {
            OpenCVUtilities.GetRow(input.Row);
        }

        else if (option == OptionEnum.CreateRandomArray) // 7
        {
            OpenCVUtilities.CreateRandomArray((byte) input.Width,
                (byte) input.Height,
                (byte) input.MinRGB,
                (byte) input.MaxRGB);
        }

        else if (option == OptionEnum.GetRegionOfInterest) // 8
        {
            OpenCVUtilities.GetRegionOfInterest(input.X1, input.Y1, input.X2, input.Y2);
        }

        else if (option == OptionEnum.DisplayWindow) // 9
        {
            OpenCVUtilities.DisplayWindow(input.WindowName);
        }

        else if (option == OptionEnum.GetColumn) // 10
        {
            OpenCVUtilities.GetColumn(input.Column);
        }

        else if (option == OptionEnum.ApplyMaskOnePixel) // 11
        {
            throw new NotImplementedException();
        }

        else if (option == OptionEnum.ApplyMaskTwoPixels) // 12
        {
            throw new NotImplementedException();
        }

        else if (option == OptionEnum.ApplyMaskThreePixels) // 13
        {
            throw new NotImplementedException();
        }

        else if (option == OptionEnum.ApplyMaskFourPixels) // 15
        {
            throw new NotImplementedException();
        }

        else if (option == OptionEnum.ApplyMaskFivePixels) // 16
        {
            throw new NotImplementedException();
        }

        else if (option == OptionEnum.ApplyMaskSixPixels) // 17
        {
            throw new NotImplementedException();
        }

        else if (option == OptionEnum.ApplyMaskSevenPixels) // 18
        {
            throw new NotImplementedException();
        }

        else if (option == OptionEnum.ApplyMaskEightPixels) // 19
        {
            throw new NotImplementedException();
        }

        else if (option == OptionEnum.ApplyMaskNinePixels) // 20
        {
            throw new NotImplementedException();
        }

        else if (option == OptionEnum.ApplyMaskTenPixels) // 21
        {
            throw new NotImplementedException();
        }

        else if (option == OptionEnum.ConvertColorToGray) // 22
        {
            OpenCVUtilities.ConvertColorToGray();
        }
        else if (option == OptionEnum.ConvertColorToColorAlpha) // 23
        {
            OpenCVUtilities.ConvertColorToColorAlpha();
        }

        else if (option == OptionEnum.ConvertColorToHLS) // 24
        {
            OpenCVUtilities.ConvertColorToHLS();
        }

        else if (option == OptionEnum.ConvertColorToHSV) // 25
        {
            OpenCVUtilities.ConvertColorToHSV();
        }

        else if (option == OptionEnum.ConvertBRGToRGB) // 26
        {
            OpenCVUtilities.SwitchColorChannels();
        }

        else if (option == OptionEnum.ConvertBRGToRGBA) // 27
        {
            OpenCVUtilities.SwitchColorChannelsAlpha();
        }

        else if (option == OptionEnum.ConvertGrayToRGB) // 28
        {
            OpenCVUtilities.ConvertGrayToColorSwitchChannels();
        }

        else if (option == OptionEnum.ConvertGrayToColor) // 29
        {
            OpenCVUtilities.ConvertGrayToColor();
        }
        else if (option == OptionEnum.IncreaseBrightness) // 30
        {
            OpenCVUtilities.IncreaseBrightness(input.Alpha, 
                input.Beta);
        }

        else if (option == OptionEnum.IncreaseBrightnessSmart) // 31
        {
            OpenCVUtilities.IncreaseBrightnessSmart(input.Gamma);
        }

        else if (option == OptionEnum.AddConstMargin) // 32
        {
            OpenCVUtilities.AddConstMargin(input.Top, 
                input.Bottom, 
                input.Left, 
                input.Right,
                (byte) input.RedChannel,
                (byte) input.BlueChannel,
                (byte) input.GreenChannel);
        }

        else if (option == OptionEnum.AddMirrorMargin) // 33
        {
            OpenCVUtilities.AddMirrorMargin(input.Top, 
                input.Bottom, 
                input.Left, 
                input.Right);
        }

        else if (option == OptionEnum.AddReplicatedMargin) // 34
        {
            OpenCVUtilities.AddReplicatedMargin(input.Top, 
                input.Bottom, 
                input.Left, 
                input.Right);
        }

        else if (option == OptionEnum.AddWrapMargin) // 35
        {
            OpenCVUtilities.AddWrapMargin(input.Top, 
                input.Bottom, 
                input.Left, 
                input.Right);
        }

        else if (option == OptionEnum.DrawCurve) // 36
        {
            OpenCVUtilities.DrawCurve(input.CenterX,
                input.CenterY, 
                input.CirleWidth, 
                input.CirleHeight, 
                input.Angle, 
                input.Thickness, 
                input.StartAngle, 
                input.EndAngle,
                (byte) input.RedChannel,
                (byte)input.GreenChannel,
                (byte)input.BlueChannel);
        }

        else if (option == OptionEnum.DrawFilledCircle) // 37
        {
            OpenCVUtilities.DrawFilledCircle(input.CenterX,
                input.CenterY,
                input.Radius,
                (byte)input.RedChannel,
                (byte)input.GreenChannel,
                (byte)input.BlueChannel);
        }

        else if (option == OptionEnum.DrawLine) // 38
        {
            OpenCVUtilities.DrawLine(input.X1,
                input.Y1,
                input.X2,
                input.Y2,
                input.Thickness);
        }

        else if (option == OptionEnum.DrawRandomLine) // 39
        {
            OpenCVUtilities.DrawRandomLine(input.Itterations, 
                input.X1, 
                input.Y1, 
                input.X2, 
                input.Y2,
                (byte) input.RedChannel,
                (byte) input.GreenChannel,
                (byte) input.BlueChannel,
                input.Thickness);
        }

        else if (option == OptionEnum.DrawRandomLineRandomColor) // 40
        {
            OpenCVUtilities.DrawRandomLineRandomColor(input.Itterations,
                input.X1,
                input.Y1,
                input.X2,
                input.Y2,
                input.Thickness);
        }

        else if (option == OptionEnum.DrawRandomHollowRectangle) // 41
        {
            OpenCVUtilities.DrawRandomHollowRectangle(input.Itterations,
                input.X1,
                input.Y1,
                input.X2,
                input.Y2,
                (byte)input.RedChannel,
                (byte) input.GreenChannel,
                (byte) input.BlueChannel,
                input.Thickness);
        }

        else if (option == OptionEnum.DrawRandomHollowRectangleRandomColor) // 42
        {
            OpenCVUtilities.DrawRandomHollowRectangleRandomColor(input.Itterations,
                input.X1,
                input.Y1,
                input.X2,
                input.Y2,
                input.Thickness);
        }

        else if (option == OptionEnum.DisplayRandomTextPosition) // 43
        {
            OpenCVUtilities.DisplayRandomTextPosition(input.Itterations,
                input.Text,
                input.X1,
                input.Y1,
                input.X2,
                input.Y2,
                (byte) input.RedChannel,
                (byte) input.GreenChannel,
                (byte) input.BlueChannel);
        }
        else if (option == OptionEnum.DisplayRandomTextPositionRandomColor) // 44
        {
            OpenCVUtilities.DisplayRandomTextPositionRandomColor(input.Itterations,
                input.Text,
                input.X1,
                input.Y1,
                input.X2,
                input.Y2);
        }

        else if (option == OptionEnum.BlurImage) // 45
        {
            OpenCVUtilities.BlurImage(input.BlurSize);
        }

        else if (option == OptionEnum.ErodeImageRectangle) // 46
        {
            OpenCVUtilities.ErodeImageRectangle(input.BlurSize);
        }

        else if (option == OptionEnum.ErodeImageEllipse) // 47
        {
            OpenCVUtilities.ErodeImageEllipse(input.BlurSize);
        }

        else if (option == OptionEnum.ErodeImage) // 48
        {
            OpenCVUtilities.ErodeImage(input.BlurSize);
        }

        else if (option == OptionEnum.DialateImageRectangle) // 49
        {
            OpenCVUtilities.DialateImageRectangle(input.BlurSize);
        }

        else if (option == OptionEnum.DialateImageCross) // 50
        {
            OpenCVUtilities.DialateImageCross(input.BlurSize);
        }

        else if (option == OptionEnum.DialateImage) // 51
        {
            OpenCVUtilities.DialateImage(input.BlurSize);
        }

        else if (option == OptionEnum.RemoveBackgroundNoise) // 52
        {
            OpenCVUtilities.RemoveBackgroundNoise(input.BlurSize);
        }

        else if (option == OptionEnum.GetHorizontalLines) // 53
        {
            OpenCVUtilities.GetHorizontalLines();
        }

        else if (option == OptionEnum.GetVerticalLines) // 54
        {
            OpenCVUtilities.GetVerticalLines();
        }

        else if (option == OptionEnum.ConvertToBinary) // 55
        {
            OpenCVUtilities.ConvertToBinary();
        }

        else if (option == OptionEnum.ConvertToInverseBinary) // 56
        {
            OpenCVUtilities.ConvertToInverseBinary();
        }

        else if (option == OptionEnum.SmoothEdges) // 57
        {
            OpenCVUtilities.SmoothEdges();
        }

        else if (option == OptionEnum.LowThresholdImage) // 58
        {
            OpenCVUtilities.LowThresholdImage(input.Threshold);
        }
        else if (option == OptionEnum.HighThresholdImage) // 59
        {
            OpenCVUtilities.HighThresholdImage(input.Threshold);
        }

        else if (option == OptionEnum.DetectEdges) // 60
        {
            OpenCVUtilities.DetectEdges(input.Threshold);
        }

        else if (option == OptionEnum.TiltImage) // 61
        {
            OpenCVUtilities.TiltImage(input.Angle, 
                input.Scale);
        }

        //else if (option == OptionEnum.DrawRandomFilledTriangles) // 62
        //{
        //    OpenCVUtilities.DrawRandomFilledTriangles(input.Itterations,
        //        input.X1,
        //        input.Y1,
        //        input.X2,
        //        input.Y2);
        //}

        //else if (option == OptionEnum.DrawRandomHollowTriangles) // 63
        //{
        //    OpenCVUtilities.DrawRandomHollowTriangles(input.Itterations,
        //        input.X1,
        //        input.Y1,
        //        input.X2,
        //        input.Y2);
        //}

        else if (option == OptionEnum.GetContours) // 64
        {
            OpenCVUtilities.GetContours(input.Threshold);
        }

        else if (option == OptionEnum.GetConvexHull) // 65
        {
            OpenCVUtilities.GetConvexHull(input.Threshold);
        }

        else if (option == OptionEnum.WatershedImage) // 66
        {
            OpenCVUtilities.WatershedImage();
        }

        else if (option == OptionEnum.GetCorners) // 67
        {
            OpenCVUtilities.GetCorners((int) input.MaxCorners);
        }
    }

    #pragma warning restore CS8629
}
