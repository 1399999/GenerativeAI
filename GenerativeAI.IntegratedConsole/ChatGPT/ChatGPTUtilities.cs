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

        return output.functions;
    }

    static (JsonInput? functions, bool worked) ComputeFunctions1To10(this ChatClient client, string[] args, string chatGPTInput)
    {
        ChatCompletion completion = client.CompleteChat($"If completed, what operation will be completed: a color image loaded, a grayscale image loaded, a rectangle created, an array of ones created, an array of zeros created, getting a row, a random array created, getting a region of interest, or displaying a window? From the prompt: \"{chatGPTInput}\".");

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
