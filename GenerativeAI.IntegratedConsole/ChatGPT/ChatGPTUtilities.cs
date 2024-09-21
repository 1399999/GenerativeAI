namespace GenerativeAI.IntegratedConsole.ChatGPT;

public static class ChatGPTUtilities
{
    static ChatClient InitializeModel()
    {
        ChatClient client = new ChatClient(model: "gpt-3.5-turbo", ChatGPTEnviorment.GetEnviornmentVariable());
        ChatCompletion completion = client.CompleteChat("");

        Console.WriteLine($"============== {completion.Model} ==============\n");

        return client;
    }

    public static (OptionEnum? output, bool worked) ToBool(string str) 
    { 
        if (str.Contains("details"))
        {
            return (null, false);
        }

        else
        {
            return (str.ToOutputEnum(), true);
        }
    }

    public static JsonInput EvaluateSingleExprssion(string[] args, OptionEnum options)
    {
        // Temp.
        args = new string[]
        {
            "9", "9", "9", "9", "9",
        };

        ChatClient client = InitializeModel();

        var output = client.ComputeFunctions1To10(args, "Display a window with the name djksfkj");

        if (!output.worked)
        {
            client.ComputeFunctions22To30(args, "");
        }

        return output.functions;
    }

    static (JsonInput? functions, bool worked) ComputeFunctions1To10(this ChatClient client, string[] args, string chatGPTInput)
    {
        ChatCompletion completion = client.CompleteChat($"If completed, what operation will be completed: " +
            $"a color image loaded, " +
            $"a grayscale image loaded, " +
            $"a rectangle created," +
            $" an array of ones created, " +
            $"an array of zeros created, " +
            $"getting a row, " +
            $"a random array created, " +
            $"getting a region of interest, " +
            $"or displaying a window? " +
            $"From the prompt: \"{chatGPTInput}\".");

        return CompleteFunctions(client, args, completion);
    }

    static (JsonInput? functions, bool worked) ComputeFunctions22To30(this ChatClient client, string[] args, string chatGPTInput)
    {
        ChatCompletion completion = client.CompleteChat($"If completed, what operation will be completed: " +
            $"convertion from a color image to a grayscale image, " +
            $"add an alpha channel to it, " +
            $"convert it to hls, " +
            $"convert it to hsv, " +
            $"switch the red and blue color channels, " +
            $"switch the red and blue color channels and add an alpha value, " +
            $"convert a grayscale image to a color image, " +
            $"or increase the brightness of an image? " +
            $"From the prompt: \"{chatGPTInput}\".");

        return CompleteFunctions(client, args, completion);
    }

    static (JsonInput? functions, bool worked) CompleteFunctions(this ChatClient client, string[] args, ChatCompletion completion)
    {
        (OptionEnum? output, bool worked) = ToBool(completion.ToString());

        if (worked)
        {
            if (output == OptionEnum.GetColorImg)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.GetColorImg,
                    InputPath = args[0],
                }, true);
            }

            else if (output == OptionEnum.GetGrayscaleImg)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.GetGrayscaleImg,
                    InputPath = args[0],
                }, true);
            }

            else if (output == OptionEnum.CreateRect)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.CreateRect,
                    Width = ushort.Parse(args[0]),
                    Height = ushort.Parse(args[1]),
                    RedChannel = byte.Parse(args[2]),
                    GreenChannel = byte.Parse(args[3]),
                    BlueChannel = byte.Parse(args[4]),
                }, true);
            }

            else if (output == OptionEnum.WriteToFile)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.WriteToFile,
                    OutputPath = args[0],
                }, true);
            }

            else if (output == OptionEnum.CreateArrayOnes)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.CreateArrayOnes,
                    Width = ushort.Parse(args[0]),
                    Height = ushort.Parse(args[1]),
                    DivideBy = double.Parse(args[2]),
                }, true);
            }

            else if (output == OptionEnum.CreateArrayZeros)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.CreateArrayZeros,
                    Width = ushort.Parse(args[0]),
                    Height = ushort.Parse(args[1]),
                }, true);
            }

            else if (output == OptionEnum.GetRow)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.GetRow,
                    Row = ushort.Parse(args[0]),
                }, true);
            }

            else if (output == OptionEnum.CreateRandomArray)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.CreateRandomArray,
                    Width = ushort.Parse(args[0]),
                    Height = ushort.Parse(args[1]),
                    MinRGB = byte.Parse(args[2]),
                }, true);
            }

            else if (output == OptionEnum.GetRegionOfInterest)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.GetRegionOfInterest,
                    X1 = ushort.Parse(args[0]),
                    Y1 = ushort.Parse(args[1]),
                    X2 = ushort.Parse(args[2]),
                    Y2 = ushort.Parse(args[3]),
                }, true);
            }

            else if (output == OptionEnum.DisplayWindow)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.DisplayWindow,
                    WindowName = args[0],
                }, true);
            }

            else if (output == OptionEnum.GetColumn)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.GetColumn,
                    Column = ushort.Parse(args[0]),
                }, true);
            }

            //else if (output == OptionEnum.ApplyMaskOnePixel)
            //{
            //    return (new JsonInput()
            //    {
            //        Order = SystemModel.Order++,
            //        FunctionType = OptionEnum.ApplyMaskOnePixel,

            //    }, true);
            //}

            //else if (output == OptionEnum.ApplyMaskTwoPixels)
            //{
            //    return (new JsonInput()
            //    {
            //        Order = SystemModel.Order++,
            //        FunctionType = OptionEnum.ApplyMaskTwoPixels,

            //    }, true);
            //}

            //else if (output == OptionEnum.ApplyMaskThreePixels)
            //{
            //    return (new JsonInput()
            //    {
            //        Order = SystemModel.Order++,
            //        FunctionType = OptionEnum.ApplyMaskThreePixels,

            //    }, true);
            //}

            //else if (output == OptionEnum.ApplyMaskFourPixels)
            //{
            //    return (new JsonInput()
            //    {
            //        Order = SystemModel.Order++,
            //        FunctionType = OptionEnum.ApplyMaskFourPixels,

            //    }, true);
            //}

            //else if (output == OptionEnum.ApplyMaskFivePixels)
            //{
            //    return (new JsonInput()
            //    {
            //        Order = SystemModel.Order++,
            //        FunctionType = OptionEnum.ApplyMaskFivePixels,

            //    }, true);
            //}

            //else if (output == OptionEnum.ApplyMaskSixPixels)
            //{
            //    return (new JsonInput()
            //    {
            //        Order = SystemModel.Order++,
            //        FunctionType = OptionEnum.ApplyMaskSixPixels,

            //    }, true);
            //}

            //else if (output == OptionEnum.ApplyMaskSevenPixels)
            //{
            //    return (new JsonInput()
            //    {
            //        Order = SystemModel.Order++,
            //        FunctionType = OptionEnum.ApplyMaskSevenPixels,

            //    }, true);
            //}

            //else if (output == OptionEnum.ApplyMaskEightPixels)
            //{
            //    return (new JsonInput()
            //    {
            //        Order = SystemModel.Order++,
            //        FunctionType = OptionEnum.ApplyMaskEightPixels,

            //    }, true);
            //}

            //else if (output == OptionEnum.ApplyMaskNinePixels)
            //{
            //    return (new JsonInput()
            //    {
            //        Order = SystemModel.Order++,
            //        FunctionType = OptionEnum.ApplyMaskNinePixels,

            //    }, true);
            //}

            //else if (output == OptionEnum.ApplyMaskTenPixels)
            //{
            //    return (new JsonInput()
            //    {
            //        Order = SystemModel.Order++,
            //        FunctionType = OptionEnum.ApplyMaskTenPixels,

            //    }, true);
            //}

            else if (output == OptionEnum.ConvertColorToGray)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.ConvertColorToGray,
                }, true);
            }

            else if (output == OptionEnum.ConvertColorToColorAlpha)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.ConvertColorToColorAlpha,
                }, true);
            }

            else if (output == OptionEnum.ConvertColorToHLS)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.ConvertColorToHLS,
                }, true);
            }

            else if (output == OptionEnum.ConvertColorToHSV)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.ConvertColorToHSV,
                }, true);
            }

            else if (output == OptionEnum.ConvertBRGToRGB)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.ConvertBRGToRGB,
                }, true);
            }

            else if (output == OptionEnum.ConvertBRGToRGBA)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.ConvertBRGToRGBA,
                }, true);
            }

            else if (output == OptionEnum.ConvertGrayToRGB)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.ConvertGrayToRGB,
                }, true);
            }

            else if (output == OptionEnum.ConvertGrayToColor)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.ConvertGrayToColor,
                }, true);
            }

            else if (output == OptionEnum.IncreaseBrightness)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.IncreaseBrightness,
                    Alpha = double.Parse(args[0]),
                    Beta = double.Parse(args[0]),
                }, true);
            }

            else if (output == OptionEnum.IncreaseBrightnessSmart)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.IncreaseBrightnessSmart,
                    Gamma = double.Parse(args[0]),
                }, true);
            }

            else if (output == OptionEnum.AddConstMargin)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.AddConstMargin,
                    Top = ushort.Parse(args[0]),
                    Bottom = ushort.Parse(args[1]),
                    Left = ushort.Parse(args[2]),
                    Right = ushort.Parse(args[3]),
                    RedChannel = byte.Parse(args[4]),
                    GreenChannel = byte.Parse(args[4]),
                    BlueChannel = byte.Parse(args[4]),
                }, true);
            }

            else if (output == OptionEnum.AddMirrorMargin)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.AddMirrorMargin,
                    Top = ushort.Parse(args[0]),
                    Bottom = ushort.Parse(args[1]),
                    Left = ushort.Parse(args[2]),
                    Right = ushort.Parse(args[3]),
                }, true);
            }

            else if (output == OptionEnum.AddReplicatedMargin)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.AddReplicatedMargin,
                    Top = ushort.Parse(args[0]),
                    Bottom = ushort.Parse(args[1]),
                    Left = ushort.Parse(args[2]),
                    Right = ushort.Parse(args[3]),
                }, true);
            }

            else if (output == OptionEnum.AddWrapMargin)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.AddWrapMargin,
                    Top = ushort.Parse(args[0]),
                    Bottom = ushort.Parse(args[1]),
                    Left = ushort.Parse(args[2]),
                    Right = ushort.Parse(args[3]),
                }, true);
            }

            else if (output == OptionEnum.DrawCurve)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.DrawCurve,
                    CenterX = ushort.Parse(args[0]),
                    CenterY = ushort.Parse(args[1]),
                    Width = ushort.Parse(args[2]),
                    Height = ushort.Parse(args[3]),
                    Angle = double.Parse(args[4]),
                    Thickness = ushort.Parse(args[5]),
                    StartAngle = ushort.Parse(args[6]),
                    EndAngle = ushort.Parse(args[7]),
                    RedChannel = byte.Parse(args[8]),
                    GreenChannel = byte.Parse(args[9]),
                    BlueChannel = byte.Parse(args[10]),
                }, true);
            }

            else if (output == OptionEnum.DrawFilledCircle)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.DrawFilledCircle,
                    CenterX = ushort.Parse(args[0]),
                    CenterY = ushort.Parse(args[1]),
                    Radius = ushort.Parse(args[2]),
                    RedChannel = byte.Parse(args[3]),
                    GreenChannel = byte.Parse(args[4]),
                    BlueChannel = byte.Parse(args[5]),
                }, true);
            }

            else if (output == OptionEnum.DrawLine)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.DrawLine,
                    X1 = ushort.Parse(args[0]),
                    X2 = ushort.Parse(args[1]),
                    Y1 = ushort.Parse(args[2]),
                    Y2 = ushort.Parse(args[3]),
                    Thickness = ushort.Parse(args[4]),
                }, true);
            }

            else if (output == OptionEnum.DrawRandomLine)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.DrawRandomLine,
                    X1 = ushort.Parse(args[0]),
                    X2 = ushort.Parse(args[1]),
                    Y1 = ushort.Parse(args[2]),
                    Y2 = ushort.Parse(args[3]),
                    RedChannel = byte.Parse(args[4]),
                    GreenChannel = byte.Parse(args[5]),
                    BlueChannel = byte.Parse(args[6]),
                    Thickness = ushort.Parse(args[7]),
                }, true);
            }

            else if (output == OptionEnum.DrawRandomLineRandomColor)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = OptionEnum.DrawRandomLineRandomColor,
                    Itterations = uint.Parse(args[0]),
                    X1 = ushort.Parse(args[1]),
                    X2 = ushort.Parse(args[2]),
                    Y1 = ushort.Parse(args[3]),
                    Y2 = ushort.Parse(args[4]),
                    RedChannel = byte.Parse(args[5]),
                    GreenChannel = byte.Parse(args[6]),
                    BlueChannel = byte.Parse(args[7]),
                    Thickness = ushort.Parse(args[8]),
                }, true);
            }

            else if (output == OptionEnum.DrawRandomHollowRectangle)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                    Itterations = uint.Parse(args[0]),
                    X1 = ushort.Parse(args[1]),
                    X2 = ushort.Parse(args[2]),
                    Y1 = ushort.Parse(args[3]),
                    Y2 = ushort.Parse(args[4]),
                    RedChannel = byte.Parse(args[5]),
                    GreenChannel = byte.Parse(args[6]),
                    BlueChannel = byte.Parse(args[7]),
                    Thickness = ushort.Parse(args[8]),
                }, true);
            }

            else if (output == OptionEnum.DrawRandomHollowRectangleRandomColor)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                    Itterations = uint.Parse(args[0]),
                    X1 = ushort.Parse(args[1]),
                    X2 = ushort.Parse(args[2]),
                    Y1 = ushort.Parse(args[3]),
                    Y2 = ushort.Parse(args[4]),
                    Thickness = ushort.Parse(args[5]),
                }, true);
            }

            else if (output == OptionEnum.DisplayRandomTextPosition)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                    Itterations = uint.Parse(args[0]),
                    Text = args[1],
                    X1 = ushort.Parse(args[2]),
                    X2 = ushort.Parse(args[3]),
                    Y1 = ushort.Parse(args[4]),
                    Y2 = ushort.Parse(args[5]),
                    RedChannel = byte.Parse(args[6]),
                    GreenChannel = byte.Parse(args[7]),
                    BlueChannel = byte.Parse(args[8]),
                }, true);
            }

            else if (output == OptionEnum.DisplayRandomTextPositionRandomColor)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                    Itterations = uint.Parse(args[0]),
                    Text = args[1],
                    X1 = ushort.Parse(args[2]),
                    X2 = ushort.Parse(args[3]),
                    Y1 = ushort.Parse(args[4]),
                    Y2 = ushort.Parse(args[5]),
                }, true);
            }

            else if (output == OptionEnum.BlurImage)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                    BlurSize = ushort.Parse(args[0]),
                }, true);
            }

            else if (output == OptionEnum.ErodeImageRectangle)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                    BlurSize = ushort.Parse(args[0]),
                }, true);
            }

            else if (output == OptionEnum.ErodeImageCross)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                    BlurSize = ushort.Parse(args[0]),
                }, true);
            }

            else if (output == OptionEnum.ErodeImageEllipse)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                    BlurSize = ushort.Parse(args[0]),
                }, true);
            }

            else if (output == OptionEnum.ErodeImage)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                    BlurSize = ushort.Parse(args[0]),
                }, true);
            }

            else if (output == OptionEnum.DialateImageRectangle)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                    BlurSize = ushort.Parse(args[0]),
                }, true);
            }

            else if (output == OptionEnum.DialateImageCross)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                    BlurSize = ushort.Parse(args[0]),
                }, true);
            }

            else if (output == OptionEnum.DialateImageEllipse)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                    BlurSize = ushort.Parse(args[0]),
                }, true);
            }

            else if (output == OptionEnum.DialateImage)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                    BlurSize = ushort.Parse(args[0]),
                }, true);
            }

            else if (output == OptionEnum.RemoveBackgroundNoise)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                    BlurSize = ushort.Parse(args[0]),
                }, true);
            }

            else if (output == OptionEnum.GetHorizontalLines)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                }, true);
            }

            else if (output == OptionEnum.GetVerticalLines)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                }, true);
            }

            else if (output == OptionEnum.ConvertToBinary)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                }, true);
            }

            else if (output == OptionEnum.ConvertToInverseBinary)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                }, true);
            }

            else if (output == OptionEnum.SmoothEdges)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                }, true);
            }

            else if (output == OptionEnum.LowThresholdImage)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                    Threshold = byte.Parse(args[0]),
                }, true);
            }

            else if (output == OptionEnum.HighThresholdImage)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                    Threshold = byte.Parse(args[0]),
                }, true);
            }

            else if (output == OptionEnum.DetectEdges)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                    Threshold = byte.Parse(args[0]),
                }, true);
            }

            else if (output == OptionEnum.TiltImage)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                    Angle = double.Parse(args[0]),
                    Scale = double.Parse(args[1]),
                }, true);
            }

            //else if (output == OptionEnum.DrawRandomFilledTriangles)
            //{
            //    return (new JsonInput()
            //    {
            //        Order = SystemModel.Order++,
            //        FunctionType = (OptionEnum)output,

            //    }, true);
            //}

            //else if (output == OptionEnum.DrawRandomHollowTriangles)
            //{
            //    return (new JsonInput()
            //    {
            //        Order = SystemModel.Order++,
            //        FunctionType = (OptionEnum)output,

            //    }, true);
            //}

            else if (output == OptionEnum.GetContours)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                    Threshold = byte.Parse(args[0]),
                }, true);
            }

            else if (output == OptionEnum.GetConvexHull)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                    Threshold = byte.Parse(args[0]),
                }, true);
            }

            else if (output == OptionEnum.WatershedImage)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                }, true);
            }

            else if (output == OptionEnum.GetCorners)
            {
                return (new JsonInput()
                {
                    Order = SystemModel.Order++,
                    FunctionType = (OptionEnum)output,
                    MaxCorners = uint.Parse(args[0]),
                }, true);
            }
        }

        return (null, false);
    }

    static OptionEnum ToOutputEnum(this string str)
    {
        if (str.Contains("color") && str.Contains("image"))
        {
            return OptionEnum.GetColorImg;
        }

        else if (str.Contains("grayscale") && str.Contains("image"))
        {
            return OptionEnum.GetGrayscaleImg;
        }

        else if (str.Contains("rectangle"))
        {
            return OptionEnum.CreateRect;
        }

        else if (str.Contains("array of ones"))
        {
            return OptionEnum.CreateArrayOnes;
        }

        else if (str.Contains("array of zeros"))
        {
            return OptionEnum.CreateArrayZeros;
        }

        else if (str.Contains("row"))
        {
            return OptionEnum.GetRow;
        }

        else if (str.Contains("random array"))
        {
            return OptionEnum.CreateRandomArray;
        }

        else if (str.Contains("region of interest"))
        {
            return OptionEnum.GetRegionOfInterest;
        }

        else if (str.Contains("window"))
        {
            return OptionEnum.DisplayWindow;
        }

        else
        {
            return OptionEnum.GetColorImg;
        }
    }
}
