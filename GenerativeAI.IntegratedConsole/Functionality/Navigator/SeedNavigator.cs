namespace GenerativeAI.IntegratedConsole.Functionality.Navigator;

public static class SeedNavigator
{
    public static void Navigate(int[] vectors)
    {
        foreach (var vector in vectors)
        {
            OptionEnum option = (OptionEnum)vector;

            option.ExecuteOption();
        }
    }

    public static void ExecuteOption(this OptionEnum option)
    {
        if (option == OptionEnum.GetImgColor) // 0
        {
            OpenCVUtilities.GetImgColor(SystemModel.StaticInput.InputPath);
        }

        else if (option == OptionEnum.GetImgGrayscale) // 1
        {
            OpenCVUtilities.GetImgGrayscale(SystemModel.StaticInput.InputPath);
        }

        else if (option == OptionEnum.CreateRect) // 2
        {
            OpenCVUtilities.CreateRect(SystemModel.StaticInput.Width,
                SystemModel.StaticInput.Height,
                SystemModel.StaticInput.RedChannel,
                SystemModel.StaticInput.BlueChannel,
                SystemModel.StaticInput.GreenChannel);
        }

        else if (option == OptionEnum.WriteToFile) // 3
        {
            OpenCVUtilities.WriteToFile(SystemModel.StaticInput.OutputPath);
        }

        else if (option == OptionEnum.CreateArrayOnes) // 4
        {
            OpenCVUtilities.CreateArrayOnes(SystemModel.StaticInput.Width,
                SystemModel.StaticInput.Height,
                SystemModel.StaticInput.DivideBy);
        }

        else if (option == OptionEnum.CreateArrayZeros) // 5
        {
            OpenCVUtilities.CreateArrayZeros(SystemModel.StaticInput.Width,
                SystemModel.StaticInput.Height);
        }

        else if (option == OptionEnum.GetRow) // 6
        {
            OpenCVUtilities.GetRow(SystemModel.StaticInput.Row);
        }

        else if (option == OptionEnum.CreateRandomArray) // 7
        {
            OpenCVUtilities.CreateRandomArray(SystemModel.StaticInput.Width,
                SystemModel.StaticInput.Height,
                SystemModel.StaticInput.MinRGB,
                SystemModel.StaticInput.MaxRGB);
        }

        else if (option == OptionEnum.GetRegionOfInterest) // 8
        {
            OpenCVUtilities.GetRegionOfInterest(SystemModel.StaticInput.X1, SystemModel.StaticInput.Y1, SystemModel.StaticInput.X2, SystemModel.StaticInput.Y2);
        }

        else if (option == OptionEnum.DisplayWindow) // 9
        {
            OpenCVUtilities.DisplayWindow(SystemModel.StaticInput.WindowName);
        }

        else if (option == OptionEnum.GetColumn) // 10
        {
            OpenCVUtilities.GetColumn(SystemModel.StaticInput.Column);
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
            OpenCVUtilities.IncreaseBrightness(SystemModel.StaticInput.Alpha, 
                SystemModel.StaticInput.Beta);
        }

        else if (option == OptionEnum.IncreaseBrightnessSmart) // 31
        {
            OpenCVUtilities.IncreaseBrightnessSmart(SystemModel.StaticInput.Gamma);
        }

        else if (option == OptionEnum.AddConstMargin) // 32
        {
            OpenCVUtilities.AddConstMargin(SystemModel.StaticInput.Top, 
                SystemModel.StaticInput.Bottom, 
                SystemModel.StaticInput.Left, 
                SystemModel.StaticInput.Right, 
                SystemModel.StaticInput.RedChannel, 
                SystemModel.StaticInput.BlueChannel, 
                SystemModel.StaticInput.GreenChannel);
        }

        else if (option == OptionEnum.AddMirrorMargin) // 33
        {
            OpenCVUtilities.AddMirrorMargin(SystemModel.StaticInput.Top, 
                SystemModel.StaticInput.Bottom, 
                SystemModel.StaticInput.Left, 
                SystemModel.StaticInput.Right);
        }

        else if (option == OptionEnum.AddReplicatedMargin) // 34
        {
            OpenCVUtilities.AddReplicatedMargin(SystemModel.StaticInput.Top, 
                SystemModel.StaticInput.Bottom, 
                SystemModel.StaticInput.Left, 
                SystemModel.StaticInput.Right);
        }

        else if (option == OptionEnum.AddWrapMargin) // 35
        {
            OpenCVUtilities.AddWrapMargin(SystemModel.StaticInput.Top, 
                SystemModel.StaticInput.Bottom, 
                SystemModel.StaticInput.Left, 
                SystemModel.StaticInput.Right);
        }

        else if (option == OptionEnum.DrawCurve) // 36
        {
            OpenCVUtilities.DrawCurve(SystemModel.StaticInput.CenterX,
                SystemModel.StaticInput.CenterY, 
                SystemModel.StaticInput.CirleWidth, 
                SystemModel.StaticInput.CirleHeight, 
                SystemModel.StaticInput.Angle, 
                SystemModel.StaticInput.Thickness, 
                SystemModel.StaticInput.StartAngle, 
                SystemModel.StaticInput.EndAngle, 
                SystemModel.StaticInput.RedChannel, 
                SystemModel.StaticInput.GreenChannel, 
                SystemModel.StaticInput.BlueChannel);
        }

        else if (option == OptionEnum.DrawFilledCircle) // 37
        {
            OpenCVUtilities.DrawFilledCircle(SystemModel.StaticInput.CenterX,
                SystemModel.StaticInput.CenterY,
                SystemModel.StaticInput.Radius,
                SystemModel.StaticInput.RedChannel,
                SystemModel.StaticInput.GreenChannel,
                SystemModel.StaticInput.BlueChannel);
        }

        else if (option == OptionEnum.DrawLine) // 38
        {
            OpenCVUtilities.DrawLine(SystemModel.StaticInput.X1,
                SystemModel.StaticInput.Y1,
                SystemModel.StaticInput.X2,
                SystemModel.StaticInput.Y2,
                SystemModel.StaticInput.Thickness);
        }

        else if (option == OptionEnum.DrawRandomLine) // 39
        {
            OpenCVUtilities.DrawRandomLine(SystemModel.StaticInput.Itterations, 
                SystemModel.StaticInput.X1, 
                SystemModel.StaticInput.Y1, 
                SystemModel.StaticInput.X2, 
                SystemModel.StaticInput.Y2,
                SystemModel.StaticInput.RedChannel,
                SystemModel.StaticInput.GreenChannel,
                SystemModel.StaticInput.BlueChannel,
                SystemModel.StaticInput.Thickness);
        }

        else if (option == OptionEnum.DrawRandomLineRandomColor) // 40
        {
            OpenCVUtilities.DrawRandomLineRandomColor(SystemModel.StaticInput.Itterations,
                SystemModel.StaticInput.X1,
                SystemModel.StaticInput.Y1,
                SystemModel.StaticInput.X2,
                SystemModel.StaticInput.Y2,
                SystemModel.StaticInput.Thickness);
        }

        else if (option == OptionEnum.DrawRandomHollowRectangle) // 41
        {
            OpenCVUtilities.DrawRandomHollowRectangle(SystemModel.StaticInput.Itterations,
                SystemModel.StaticInput.X1,
                SystemModel.StaticInput.Y1,
                SystemModel.StaticInput.X2,
                SystemModel.StaticInput.Y2,
                SystemModel.StaticInput.RedChannel,
                SystemModel.StaticInput.GreenChannel,
                SystemModel.StaticInput.BlueChannel,
                SystemModel.StaticInput.Thickness);
        }

        else if (option == OptionEnum.DrawRandomHollowRectangleRandomColor) // 42
        {
            OpenCVUtilities.DrawRandomHollowRectangleRandomColor(SystemModel.StaticInput.Itterations,
                SystemModel.StaticInput.X1,
                SystemModel.StaticInput.Y1,
                SystemModel.StaticInput.X2,
                SystemModel.StaticInput.Y2,
                SystemModel.StaticInput.Thickness);
        }

        else if (option == OptionEnum.DisplayRandomTextPosition) // 43
        {
            OpenCVUtilities.DisplayRandomTextPosition(SystemModel.StaticInput.Itterations,
                SystemModel.StaticInput.Text,
                SystemModel.StaticInput.X1,
                SystemModel.StaticInput.Y1,
                SystemModel.StaticInput.X2,
                SystemModel.StaticInput.Y2,
                SystemModel.StaticInput.RedChannel,
                SystemModel.StaticInput.GreenChannel,
                SystemModel.StaticInput.BlueChannel);
        }
        else if (option == OptionEnum.DisplayRandomTextPositionRandomColor) // 44
        {
            OpenCVUtilities.DisplayRandomTextPositionRandomColor(SystemModel.StaticInput.Itterations,
                SystemModel.StaticInput.Text,
                SystemModel.StaticInput.X1,
                SystemModel.StaticInput.Y1,
                SystemModel.StaticInput.X2,
                SystemModel.StaticInput.Y2);
        }

        else if (option == OptionEnum.BlurImage) // 45
        {
            OpenCVUtilities.BlurImage(SystemModel.StaticInput.BlurSize);
        }

        else if (option == OptionEnum.ErodeImageRectangle) // 46
        {
            OpenCVUtilities.ErodeImageRectangle(SystemModel.StaticInput.BlurSize);
        }

        else if (option == OptionEnum.ErodeImageEllipse) // 47
        {
            OpenCVUtilities.ErodeImageEllipse(SystemModel.StaticInput.BlurSize);
        }

        else if (option == OptionEnum.ErodeImage) // 48
        {
            OpenCVUtilities.ErodeImage(SystemModel.StaticInput.BlurSize);
        }

        else if (option == OptionEnum.DialateImageRectangle) // 49
        {
            OpenCVUtilities.DialateImageRectangle(SystemModel.StaticInput.BlurSize);
        }

        else if (option == OptionEnum.DialateImageCross) // 50
        {
            OpenCVUtilities.DialateImageCross(SystemModel.StaticInput.BlurSize);
        }

        else if (option == OptionEnum.DialateImage) // 51
        {
            OpenCVUtilities.DialateImage(SystemModel.StaticInput.BlurSize);
        }

        else if (option == OptionEnum.RemoveBackgroundNoise) // 52
        {
            OpenCVUtilities.RemoveBackgroundNoise(SystemModel.StaticInput.BlurSize);
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
            OpenCVUtilities.LowThresholdImage(SystemModel.StaticInput.Threshold);
        }
        else if (option == OptionEnum.HighThresholdImage) // 59
        {
            OpenCVUtilities.HighThresholdImage(SystemModel.StaticInput.Threshold);
        }

        else if (option == OptionEnum.DetectEdges) // 60
        {
            OpenCVUtilities.DetectEdges(SystemModel.StaticInput.Threshold);
        }

        else if (option == OptionEnum.TiltImage) // 61
        {
            OpenCVUtilities.TiltImage(SystemModel.StaticInput.Angle, 
                SystemModel.StaticInput.Scale);
        }

        else if (option == OptionEnum.DrawRandomFilledTriangles) // 62
        {
            OpenCVUtilities.DrawRandomFilledTriangles(SystemModel.StaticInput.Itterations,
                SystemModel.StaticInput.X1,
                SystemModel.StaticInput.Y1,
                SystemModel.StaticInput.X2,
                SystemModel.StaticInput.Y2);
        }

        else if (option == OptionEnum.DrawRandomHollowTriangles) // 63
        {
            OpenCVUtilities.DrawRandomHollowTriangles(SystemModel.StaticInput.Itterations,
                SystemModel.StaticInput.X1,
                SystemModel.StaticInput.Y1,
                SystemModel.StaticInput.X2,
                SystemModel.StaticInput.Y2);
        }

        else if (option == OptionEnum.GetContours) // 64
        {
            OpenCVUtilities.GetContours(SystemModel.StaticInput.Threshold);
        }

        else if (option == OptionEnum.GetConvexHull) // 65
        {
            OpenCVUtilities.GetConvexHull(SystemModel.StaticInput.Threshold);
        }

        else if (option == OptionEnum.WatershedImage) // 66
        {
            OpenCVUtilities.WatershedImage();
        }

        else if (option == OptionEnum.GetCorners) // 67
        {
            OpenCVUtilities.GetCorners((int) SystemModel.StaticInput.MaxCorners);
        }
    }
}
