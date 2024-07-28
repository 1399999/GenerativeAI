namespace GenerativeAI.IntegratedConsole.Functionality.Navigator;

public class SeedNavigator
{
    public static void Navigate(int[] seeds)
    {
        InputEnum inputEnum = (InputEnum)seeds[InputModel.InputIndex];
        ImageTransformationEnum imageEnum = (ImageTransformationEnum)seeds[InputModel.ImageIndex];
        OutputEnum outputEnum = (OutputEnum)seeds[InputModel.OutputIndex];

        Program.WriteLineDebug($"InputEnum: {inputEnum}");
        Program.WriteLineDebug($"OutputEnum: {outputEnum}");

        Options options = new Options()
        {
            Input = inputEnum,
            ImageTransformation = imageEnum,
            Output = outputEnum
        };

        List<string> lines = Initialize(options);
        Program.WriteLineDebug($"Initialize(): \n\n{lines.ListToString("\n")}\n");

        lines = lines.AppendToList(InitializeUsings(options));
        Program.WriteLineDebug($"InitializeUsings(): \n\n{lines.ListToString("\n")}\n");

        lines = lines.AppendToList(InputFunctionality.AddInputFunctionality(options));
        Program.WriteLineDebug($"AddInputFunctionality(): \n\n{lines.ListToString("\n")}\n");

        lines = lines.AppendToList(ImageFunctionality.AddImageTransformationFunctionality(options));
        Program.WriteLineDebug($"AddOutputFunctionality(): \n\n{lines.ListToString("\n")}\n");

        lines = lines.AppendToList(OutputFunctionality.AddOutputFunctionality(options));
        Program.WriteLineDebug($"AddOutputFunctionality(): \n\n{lines.ListToString("\n")}\n");

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

        if ((options.Input == InputEnum.CVFile || options.Input == InputEnum.CVCamera || options.Input == InputEnum.CVMultipleFiles) && !openCVImported)
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

    public static void Compile(List<string> list)
    {
        File.WriteAllLines(Options.FilePath, list);

        Process.Start("python.exe", Options.FilePath);
    }
}
