namespace GenerativeAI.IntegratedConsole.Functionality;

public static class ImageFunctionality
{
    public static List<string> AddImageTransformationFunctionality(Options options)
    {
        List<string> output = new List<string>();

        if (options.ImageTransformation == ImageTransformationEnum.BlendImages)
        {
            output = AddBlendImage();
        }

        return output;
    }

    public static List<string> AddBlendImage()
    {
        SystemModel.Variables.Add(new Variable()
        {
            Name = "blendedImg",
            Type = VariableType.ImgLayer1,
        });

        // Example: blended_img = cv2.addWeighted(src1 = img1, alpha = 0.8, src2 = img2, beta = 0.1, gamma = 0).

        return new List<string>()
        {
            "",
            $"y, x, channels = {SystemModel.Variables[InputModel.FirstVariableIndex].Name}.shape",
            "",
            $"if {SystemModel.Variables[InputModel.FirstVariableIndex].Name}.shape != {SystemModel.Variables[InputModel.SecondVariableIndex].Name}.shape:",
            "",
            $"\t{SystemModel.Variables[InputModel.SecondVariableIndex].Name} = cv2.resize({SystemModel.Variables[InputModel.SecondVariableIndex].Name}, (x, y))",
            "",
            $"blendedImg = cv2.addWeighted(src1 = {SystemModel.Variables[InputModel.FirstVariableIndex].Name}, alpha = {InputModel.Alpha}, src2 = {SystemModel.Variables[InputModel.SecondVariableIndex].Name}, beta = {InputModel.Beta}, gamma = 0)",
        };
    }
}
