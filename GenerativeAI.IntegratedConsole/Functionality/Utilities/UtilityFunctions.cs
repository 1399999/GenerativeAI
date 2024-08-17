namespace GenerativeAI.IntegratedConsole.Functionality.Utilities;

public static class UtilityFunctions
{
    #region List Functions

    public static List<List<T>> SplitList<T>(this List<T> list, int chunkSize)
    {
        int listCount = list.Count;
        int numOfChunks = (int)Math.Ceiling((double)listCount / chunkSize);

        List<List<T>> splitList = new(numOfChunks);

        for (int i = 0; i < numOfChunks; i++)
        {
            int startIndex = i * chunkSize;
            int endIndex = Math.Min(startIndex + chunkSize, listCount);
            int chunkLength = endIndex - startIndex;

            splitList.Add(list.GetRange(startIndex, chunkLength));
        }

        return splitList;
    }

    public static string ListToString<T>(this List<T> list, string splitter)
    {
        string output = string.Empty;

        for (int i = 0; i < list.Count; i++)
        {
            if (i == list.Count - 1)
            {
                output += list[i];
            }

            else
            {
                output += list[i];
                output += splitter;
            }
        }

        return output;
    }

    public static List<T> ListListToList<T>(this List<List<T>> ll)
    {
        List<T> output = new();

        foreach (List<T> list in ll)
        {
            foreach (var item in list)
            {
                output.Add(item);
            }
        }

        return output;
    }

    public static List<T> AppendToList<T>(this List<T> list, List<T> list2)
    {
        foreach (var item in list2)
        {
            list.Add(item);
        }

        return list;
    }

    public static List<T> AppendToList<T>(this List<T> list, List<T> list2, int afterIndex)
    {
        for (int i = 0; i < list2.Count; i++)
        {
            if (i > afterIndex)
            {
                list.Add(list2[i]);
            }
        }

        return list;
    }

    public static List<T> CopyList<T>(this List<T> oldList)
    {
        List<T> newList = new List<T>(oldList.Count);

        oldList.ForEach((item) =>
        {
            newList.Add(item);
        });

        return newList;
    }

    public static List<List<T>> CopyList<T>(this List<List<T>> list)
    {
        var output = new List<List<T>>(list.Count);

        foreach (var item in list)
        {
            var tempItem = new List<T>();

            foreach (var str in item)
            {
                tempItem.Add(str);
            }

            output.Add(tempItem);
        }

        return output;
    }

    public static List<T> FillRange<T>(this List<T> list, int fromIdx, int toIdx, T fill) // Is inclusive
    {
        List<T> output = new();

        for (int i = 0; i < list.Count; i++)
        {
            output.Add(list[i]);

            if (i >= fromIdx && i <= toIdx)
            {
                output[^1] = fill;
            }
        }

        return output;
    }

    public static List<T> DeleteRange<T>(this List<T> list, int fromIdx, int toIdx) // Is inclusive
    {
        List<T> output = new();

        for (int i = 0; i < list.Count; i++)
        {
            if (!(i >= fromIdx && i <= toIdx))
            {
                output.Add(list[i]);
            }
        }

        return output;
    }

    public static List<string> RemoveEmptyItems(this List<string> list)
    {
        List<string> output = new();

        foreach (string item in list)
        {
            if (!string.IsNullOrWhiteSpace(item))
            {
                output.Add(item);
            }
        }

        return output;
    }

    public static List<int> DivideIndex(this int index, int divider) => new List<int>()
    {
        index / divider,
        (int) Math.Floor((double) index % divider),
    };

    public static bool IsListInt(this List<string> list)
    {
        foreach (var item in list)
        {
            if (!int.TryParse(item, out int result))
            {
                return false;
            }
        }

        return true;
    }

    public static bool IsListInRange(this List<string> list, int start, int end)
    {
        foreach (var item in list)
        {
            int i = int.Parse(item);

            if (!(i >= start && i <= end))
            {
                return false;
            }
        }

        return true;
    }

    public static int[] StringToIntArray(this string[] array)
    {
        int[] output = new int[array.Length];

        for (int i = 0; i < array.Length; i++)
        {
            output[i] = int.Parse(array[i]);
        }

        return output;
    }

    #endregion
    #region File Functions

    public static void CreateFile(this string filePath)
    {
        using (FileStream fs = File.Create(filePath)) ;
    }

    public static void TryCreateFile(this string filePath, string[] contents)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        filePath.CreateFile();

        using (StreamWriter outputFile = new StreamWriter(filePath))
        {
            foreach (string line in contents)
            {
                outputFile.WriteLine(line);
            }
        }
    }

    public static void OutputProgramResultsInFile(this List<string> list)
    {
        const string dirPath = "C:\\MyAISettings\\AlgorithmOutput\\";

        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }

        File.WriteAllLines($"{dirPath}" +
            $"{DateTime.Now.Day}" +
            $"-{DateTime.Now.Month}" +
            $"-{DateTime.Now.Year}" +
            $"T{DateTime.Now.Hour}" +
            $"-{DateTime.Now.Minute}" +
            $"-{DateTime.Now.Second}" +
            $"-{DateTime.Now.Millisecond}.txt",
            list);
    }
    #endregion
    #region Miscallenous Functions
    public static int GetCurrentOutputNumber()
    {
        List<string> files = Directory.GetFiles(InputModel.OutputDirectoryPath).OrderBy(x => File.GetLastWriteTime(x)).ToList();

        return int.Parse(files[^1].Split('\\')[^1].Substring(3, 3));
    }
    #endregion
    #region Short Functions
    public static string GetNextOutputPath() => Path.Combine(InputModel.OutputDirectoryPath, $"Img{++InputModel.InitialImageNumber}.png");
    public static int FloorTo(this double num, int floorTo) => (int)Math.Floor((double)num / floorTo) * floorTo;
    public static int AllowDivideByZero(this int i) => i != 0 ? i : int.MinValue;
    public static int GetSingleIndex(this int x, int y, int divider) => x * divider + y;
    public static int RoundDown(this decimal d) => Convert.ToInt32(Math.Floor(d));
    public static string ToOpenCVFileFormat(this string path) => path.Replace('\\', '/');
    #endregion
}
