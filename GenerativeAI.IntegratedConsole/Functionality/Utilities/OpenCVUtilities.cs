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
    /// <Based-on>

    /// large_img = img1
    /// small_img = img2

    /// x_offset = 0
    /// y_offset = 0

    /// x_end = x_offset + small_img.shape[1] # Width
    /// y_end = y_offset + small_img.shape[0] # Height

    /// # Y first, x second.

    /// large_img[y_offset: y_end, # From y-offset to y-offset + the image's y.
    /// x_offset: x_end] = small_img # From y-offset to x-offset + the image's x.
    /// </Based-on>

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

    /// <based-on>
    /// x_offset = 934 - 600 # Width of larger image - width of smaller image.
    /// y_offset = 1401 - 600 # Height of larger image - height of smaller image.

    /// rows, cols, channels = img2.shape # Width height and rgb channels split into thier own variables.

    /// # roi = img1[0:rows, 0:cols] # TOP LEFT CORNER
    /// roi = img1[y_offset: 1401, x_offset: 943] # BOTTOM RIGHT CORNER, region of interest.
    /// img2gray = cv2.cvtColor(img2, cv2.COLOR_RGB2GRAY) # Create a "mask" of the logo.

    /// # The white parts will be allowed through and the black parts wont so we are going to have to inverse this.
    /// mask_inv = cv2.bitwise_not(img2gray)

    /// print(mask_inv.shape) # The problem is that it does not have 3 color channels.

    /// white_background = np.full(img2.shape, 255, dtype = np.uint8) # Just a white only background.
    /// bk = cv2.bitwise_or(white_background, white_background, mask = mask_inv) # Converts the image to have 3 color channels.
    /// fg = cv2.bitwise_or(img2, img2, mask = mask_inv) # Blends the 2 images together.

    /// final_roi = cv2.bitwise_or(roi, fg) # Blends the do not copy and the image in the region of interest.

    /// large_img = img1
    /// small_img = final_roi

    /// large_img[y_offset:y_offset + small_img.shape[0], x_offset:x_offset + small_img.shape[1]] = small_img # Combine images together.

    /// cv2.imwrite(save_path, large_img)
    /// </based-on>

    public static List<string> BlendImageWithMask(Variable smallImg, Variable largeImg, Variable output)
    {
        return new List<string>()
        {
            $"x_offset = {largeImg.Name}.shape[1] - {smallImg.Name}.shape[1] # Width of larger image - width of smaller image.",
            $"y_offset = {largeImg.Name}.shape[0] - {smallImg.Name}.shape[0] # Height of larger image - height of smaller image.",
            "",
            $"rows, cols, channels = {smallImg.Name}.shape # Width height and rgb channels split into thier own variables.",
            "",
            $"roi = {largeImg.Name}[y_offset: {largeImg.Name}.shape[1], x_offset: {largeImg.Name}.shape[0]] # BOTTOM RIGHT CORNER, region of interest.",
            $"img2gray = cv2.cvtColor({smallImg.Name}, cv2.COLOR_RGB2GRAY) # Create a \"mask\" of the logo.",
            "",
            $"# The white parts will be allowed through and the black parts wont so we are going to have to inverse this.",
            $"mask_inv = cv2.bitwise_not(img2gray)",
            "",
            $"# The problem is that it does not have 3 color channels.",
            $"white_background = np.full({smallImg.Name}.shape, 255, dtype = np.uint8) # Just a white only background.",
            $"bk = cv2.bitwise_or(white_background, white_background, mask = mask_inv) # Converts the image to have 3 color channels.",
            $"fg = cv2.bitwise_or({smallImg.Name}, {smallImg.Name}, mask = mask_inv) # Blends the 2 images together.",
            "",
            $"final_roi = cv2.bitwise_or(roi, fg) # Blends the do not copy and the image in the region of interest.",
            "",
            $"large_img = {largeImg.Name}",
            $"small_img = final_roi",
            "",
            $"large_img[y_offset:y_offset + small_img.shape[0], x_offset:x_offset + small_img.shape[1]] = small_img # Combine images together.",
        };
    }

    #endregion
}
