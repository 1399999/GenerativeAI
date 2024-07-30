namespace GenerativeAI.IntegratedConsole.Functionality.CodeWriting;

public static class OutputFunctionality
{
    public static List<string> AddOutputFunctionality(Options options)
    {
        List<string> output = new List<string>();

        // Not currently compatible with InputEnum.CVCamera.
        if (options.Output == OutputEnum.CVFile)
        {
            output = AddOutputCVFile();
        }

        else if (options.Output == OutputEnum.CVCameraWindow)
        {
            output = AddOutputCVCameraWindow();
        }

        return output;
    }

    public static List<string> AddOutputCVFile()
    {
        Variable? varName = SystemModel.Variables.FirstOrDefault(x => x.Type == VariableType.ImgLayer1);

        if (varName == null)
        {
            varName = SystemModel.Variables[0];
        }

        return new List<string>()
        {
            $"cv2.imwrite(\'{InputModel.OutputFile.ToOpenCVFileFormat()}\', {varName.Name})",
            "",
        };
    }

    public static List<string> AddOutputCVCameraWindow()
    {
        return new List<string>()
        {
            "# Runs forever until we break with Esc key on keyboard.",
            "while True: ",
            "\t",
            "\t# Get the current frame.",
            "\tret, frame = cam.read()",
            "\t",
            "\t# Shows the image window.",
            "\tcv2.imshow('my_drawing', frame)",
            "\t",
            "\t# Breaks when escape key (is int \"27\") is hit after waiting 20 seconds.",
            $"\tif cv2.waitKey(20) & 0xFF == {InputModel.EscapeCharInt}:",
            "\t\tbreak",
            "",
            "# Once script is done, close all windows (just in case you have multiple windows called).",
            "cv2.destroyAllWindows()",
        };
    }
}
