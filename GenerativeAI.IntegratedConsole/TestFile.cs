namespace GenerativeAI.IntegratedConsole;

// A lot of functionality in this file is hardcoded.
public static class TestFile
{
    public static string[] InvalidSeedArray { get; } = new string[]
    {
        "0.0.1", // File input,         no processing,  camera output,  invalid.
        "0.1.1", // File input,         blending,       camera output,  invalid.
        "1.0.0", // Camera input,       no processing,  file output,    invalid.
        "1.1.0", // Camera input,       blending,       file output,    invalid.
        "1.1.1", // Camera input,       blending,       camera output,  invalid.
        "2.0.1", // Grayscale input,    no processing,  camera output,  invalid.
        "2.1.1", // Grayscale input,    blending,       camera output,  invalid.
    };

    private static string[] SeedArray { get; } = new string[]
    {
        "0.0.0", // File input,         no processing,  file output,    valid.
        "0.0.1", // File input,         no processing,  camera output,  invalid.
        "0.1.0", // File input,         blending,       file output,    valid.
        "0.1.1", // File input,         blending,       camera output,  invalid.
        "1.0.0", // Camera input,       no processing,  file output,    invalid.
        "1.0.1", // Camera input,       no processing,  camera output,  valid.
        "1.1.0", // Camera input,       blending,       file output,    invalid.
        "1.1.1", // Camera input,       blending,       camera output,  invalid.
        "2.0.0", // Grayscale input,    no processing,  file output,    valid.
        "2.0.1", // Grayscale input,    no processing,  camera output,  invalid.
        "2.1.0", // Grayscale input,    blending,       file output,    valid.
        "2.1.1", // Grayscale input,    blending,       camera output,  invalid.
    };

    private static string[] OneInputFile { get; } = new string[]
    {
        @"C:\ComputerVisionCourse\ImgSaves\Img1.jpg",
    };

    private static string[] TwoInputFiles { get; } = new string[]
    {
        @"C:\ComputerVisionCourse\ImgSaves\Img1.jpg",
        @"C:\ComputerVisionCourse\ImgSaves\Img2.jpg",
    };

    private static int InitialImageNumber { get; set; }

    public static void TestAllCases()
    {
        string str = Directory.GetFiles(@"C:\GenerativeAITests\").Last(x => int.TryParse(x.Split('\\')[2].Substring(3, 3), out int result));

        InitialImageNumber = int.Parse(str.Split('\\')[2].Substring(3, 3));

        Random random = new Random();

        foreach (string seed in SeedArray)
        {
            SystemModel.Variables.Clear();

            bool error = random.NextDouble() < 0.5 ? true : false;

            if (Validate(seed, error, random.NextDouble(), random.NextDouble()))
            {
                int[] vectors = SystemModel.Seed.Split('.').StringToIntArray();
                SeedNavigator.Navigate(vectors);
            }
        }
    }

    public static bool Validate(string seed, bool error, double alpha, double beta)
    {
        if (!Program.ValidateSeed(seed))
        {
            return false;
        }

        InputEnum inputEnum = (InputEnum)int.Parse(SystemModel.Seed.Split('.')[InputModel.InputIndex]);
        ImageTransformationEnum imageEnum = (ImageTransformationEnum)int.Parse(SystemModel.Seed.Split('.')[InputModel.ImageIndex]);
        OutputEnum outputEnum = (OutputEnum)int.Parse(SystemModel.Seed.Split('.')[InputModel.OutputIndex]);

        if (inputEnum == InputEnum.CVFile && !InputValidation.ValidateInputFiles(error ? TwoInputFiles : OneInputFile))
        {
            return false;
        }

        else if (inputEnum == InputEnum.CVGrayScale)
        {
            InputModel.Grayscale = true;

            if (!InputValidation.ValidateInputFiles(error ? TwoInputFiles : OneInputFile))
            {
                return false;
            }
        }

        if (imageEnum == ImageTransformationEnum.BlendImages && !ImageValidation.ValidateBlendedImage(alpha.ToString(), beta.ToString()))
        {
            return false;
        }

        if (outputEnum == OutputEnum.CVFile && !OutputValidation.ValidateOutputFile(GetOutputFile()))
        {
            return false;
        }

        return true;
    }

    private static string GetOutputFile()
    {
        return $"C:\\GenerativeAITests\\Img{++InitialImageNumber}.png";
    }
}
