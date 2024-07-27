namespace GenerativeAI.IntegratedConsole.Functionality;

public class SeedNavigator
{
    public static void Navigate(int[] seeds)
    {
        InputEnum inputEnum = (InputEnum)seeds[0];
        OutputEnum outputEnum = (OutputEnum)seeds[1];

        Program.WriteLineDebug($"InputEnum: {inputEnum}");
        Program.WriteLineDebug($"OutputEnum: {outputEnum}");

        Options options = new Options() 
        { 
            Input = inputEnum, 
            Output = outputEnum
        };

        List<string> lines = Initialize(options);
        Program.WriteLineDebug($"Initialize(): \n\n{lines.ListToString("\n")}\n");

        lines = lines.AppendToList(InitializeUsings(options));
        Program.WriteLineDebug($"InitializeUsings(): \n\n{lines.ListToString("\n")}\n");

        lines = lines.AppendToList(AddInputFunctionality(options));
        Program.WriteLineDebug($"AddInputFunctionality(): \n\n{lines.ListToString("\n")}\n");

        lines = lines.AppendToList(AddOutputFunctionality(options));
        Program.WriteLineDebug($"AddInputFunctionality(): \n\n{lines.ListToString("\n")}\n");

        Compile(lines);
        Program.WriteLineDebug($"Fully Compiled");
    }

    public static List<string> Initialize(Options options)
    {
        if (!Directory.Exists(Options.DirectoryPath))
        {
            Directory.CreateDirectory(Options.DirectoryPath);
        }

        if (File.Exists(Options.FilePath))
        {
            File.Delete(Options.FilePath);
        }

        Options.FilePath.CreateFile();

        return new List<string>()
        {
            "#################################",
            "## THIS CODE IS AUTO-GENERATED ##",
            "#################################",
            "",
        };
    }

    public static List<string> InitializeUsings(Options options)
    {
        List<string> lines = new();

        bool openCVImported = false;

        if ((options.Input == InputEnum.CVFile || options.Input == InputEnum.CVCamera) && !openCVImported)
        {
            openCVImported = true;

            return new List<string>()
            {
                "import cv2",
                "",
            };
        }

        if ((options.Output == OutputEnum.CVFile || options.Output == OutputEnum.CVCameraWindow) && !openCVImported)
        {
            openCVImported = true;

            return new List<string>()
            {
                "import cv2",
                "",
            };
        }

        return lines;
    }

    public static List<string> AddInputFunctionality(Options options)
    {
        if (options.Input == InputEnum.CVFile)
        {
            return new List<string>()
            {
                $"img = cv2.imread(\'{CentralModel.InputFile.ToOpenCVFileFormat()}\')",
            };
        }

        else if (options.Input == InputEnum.CVCamera)
        {
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

        return new List<string>();
    }

    public static List<string> AddOutputFunctionality(Options options)
    {
        // Not currently compatible with InputEnum.CVCamera.
        if (options.Output == OutputEnum.CVFile)
        {
            return new List<string>()
            {
                $"cv2.imwrite(\'{CentralModel.OutputFile.ToOpenCVFileFormat()}\', img)",
                "",
            };
        }

        else if (options.Output == OutputEnum.CVCameraWindow)
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
                $"\tif cv2.waitKey(20) & 0xFF == {CentralModel.EscapeCharInt}:",
                "\t\tbreak",
                "",
                "# Once script is done, close all windows (just in case you have multiple windows called).",
                "cv2.destroyAllWindows()",
            };
        }

        return new List<string>();
    }

    public static void Compile(List<string> list)
    {
        File.WriteAllLines(Options.FilePath, list);

        Process.Start("python.exe", Options.FilePath);
    }
}
