namespace GenerativeAI.IntegratedConsole.Functionality.CodeWriting;

public static class InputFunctionality
{
    public static List<string> AddInputFunctionality(Options options)
    {
        List<string> output = new List<string>();

        int warningTracker = SystemModel.Variables.Count;

        if (options.Input == InputEnum.CVFile)
        {
            output = AddCVMultipleFilesInput();
        }

        else if (options.Input == InputEnum.CVCamera)
        {
            output = AddCVCameraInput();
        }

        else if (options.Input == InputEnum.CVGrayScale)
        {
            output = AddGrayscaleInput();
        }

        if (warningTracker == SystemModel.Variables.Count)
        {
            Program.WriteLineWarning("The number of variables has not increased when completing the input section.");
        }

        return output;
    }

    //public static List<string> AddCVFileInput()
    //{
    //    SystemModel.Variables.Add(new Variable()
    //    {
    //        Name = "img",
    //        Type = VariableType.InputImg,
    //    });

    //    return new List<string>()
    //    {
    //        $"img = cv2.imread(\'{InputModel.InputFile.ToOpenCVFileFormat()}\')",
    //    };
    //}

    public static List<string> AddCVCameraInput()
    {
        SystemModel.Variables.Add(new Variable()
        {
            Name = "cam",
            Type = VariableType.InputDriver,
        });

        SystemModel.Variables.Add(new Variable()
        {
            Name = "ret",
            Type = VariableType.Bool,
        });

        return new List<string>()
        {
            "# Start video capture.",
            "cam = cv2.VideoCapture(0)",
            "",
            "# Get the current frame.",
            "ret, frame = cam.read()",
            "",
            "if (not ret):",
            "\tprint(\'Python error: The camera reader failed.\')",
            "",
            "# This names the window so we can reference it.",
            "cv2.namedWindow(winname = 'my_drawing')",
            "",
        };
    }

    public static List<string> AddCVMultipleFilesInput()
    {
        List<string> output = new List<string>();

        for (int i = 0; i < InputModel.InputFiles.Length; i++)
        {
            SystemModel.Variables.Add(new Variable()
            {
                Name = $"img{i}",
                Type = VariableType.InputImg,
            });

            output.Add($"img{i} = cv2.imread(\'{InputModel.InputFiles[i].ToOpenCVFileFormat()}\')");
        }

        return output;
    }

    public static List<string> AddGrayscaleInput()
    {
        List<string> output = new List<string>();

        for (int i = 0; i < InputModel.InputFiles.Length; i++)
        {
            SystemModel.Variables.Add(new Variable()
            {
                Name = $"img{i}",
                Type = VariableType.InputImg,
            });

            output.Add($"img{i} = cv2.imread(\'{InputModel.InputFiles[i].ToOpenCVFileFormat()}\', 0)");
        }

        return output;
    }
}
