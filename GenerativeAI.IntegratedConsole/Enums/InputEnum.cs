namespace GenerativeAI.IntegratedConsole.Enums;

public enum InputEnum
{
    CVFile = 0, // Using OpenCV, not compatible with ImageTransformationEnum.BlendImages.
    CVCamera = 1, // Using OpenCV.
    CVMultipleFiles = 2, // Using OpenCV.
}
