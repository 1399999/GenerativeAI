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

        else if (option == OptionEnum.CreateManualArray) // 6
        {
            throw new NotImplementedException("This feature is currently disabled due to its paramaters being abnormal.");
        }

        else if (option == OptionEnum.GetRow) // 7
        {
            throw new NotImplementedException("This feature is currently disabled due to its paramaters being difficult to validate.");
        }

        else if (option == OptionEnum.CreateRandomArray) // 8
        {
            OpenCVUtilities.CreateRandomArray(SystemModel.StaticInput.Width,
                SystemModel.StaticInput.Height,
                SystemModel.StaticInput.MinRGB,
                SystemModel.StaticInput.MaxRGB);
        }

        else if (option == OptionEnum.GetRegionOfInterest) // 9
        {
            throw new NotImplementedException("This feature is currently disabled due to its paramaters being difficult to validate.");
        }

        else if (option == OptionEnum.DisplayWindow) // 10
        {
            OpenCVUtilities.DisplayWindow(SystemModel.StaticInput.WindowName);
        }

        else if (option == OptionEnum.GetColumn) // 11
        {
            OpenCVUtilities.GetColumn(SystemModel.StaticInput.Column);
        }
    }
}
