namespace GenerativeAI.IntegratedConsole.Functionality.Utilities;

public static class OpenCVUtilities
{
    #region Basics

    public static string ImRead(string path)
    {
        SystemModel.Variables.Add(new Variable()
        {
            Name = $"img{SystemModel.LastVarNum++}",
            Type = VariableType.InputImg,
        });

        return $"cv2.imread('{path.ToOpenCVFileFormat()}')";
    }

    public static string Resize(Variable input, Variable output, int x, int y)
    {
        SystemModel.Variables.Add(output);

        return $"{output.Name} = cv2.resize({input.Name}, ({x}, {y}))";
    }

    #endregion
    #region Simple Specifics

    public static string BlendImages(Variable img1, Variable img2, Variable output, double alpha, double beta, double gamma = 0)
    {
        SystemModel.Variables.Add(output);

        return $"{output.Name} = cv2.addWeighted(src1 = {img1}, alpha = {alpha}, src2 = {img2}, beta = {beta}, gamma = {gamma})";
    }

    #endregion

    #region Complex Specifics
    /// <summary>
    /// Based on:

    /// large_img = img1
    /// small_img = img2

    /// x_offset = 0
    /// y_offset = 0

    /// x_end = x_offset + small_img.shape[1] # Width
    /// y_end = y_offset + small_img.shape[0] # Height

    /// # Y first, x second.

    /// large_img[y_offset: y_end, # From y-offset to y-offset + the image's y.
    /// x_offset: x_end] = small_img # From y-offset to x-offset + the image's x.
    /// </summary>
    /// <returns></returns>

    public static List<string> OverlayImage(Variable smallImg, Variable largeImg, Variable output, int xOffset, int yOffset)
    {
        SystemModel.Variables.Add(output);

        return new List<string>()
        {
            $"x_offset = {xOffset}",
            $"y_offset = {yOffset}",
            "",
            $"x_end = x_offset + {smallImg.Name}.shape[1] # Width",
            $"y_end = y_offset + {smallImg.Name}.shape[0] # Height",
            "",
            $"{largeImg.Name}[y_offset: y_end, # From y-offset to y-offset + the image's y.",
            $"x_offset: x_end] = {smallImg.Name} # From y-offset to x-offset + the image's x.",
        };
    }

    #endregion
}
