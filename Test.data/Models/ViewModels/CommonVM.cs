public static class Paths
{
    public static string RootPath { get; set; }
}

public static class CommonJsonDataPath
{
    public static string SeedJsonData { get; set; } = @"\SeedJsonData\";
}

public static class CommonPathForCSV
{
    public static string CSVPathForDB { get; set; }
    public static string CSVPathForDownload { get; set; } = @"\Base64ToCSV\";
}