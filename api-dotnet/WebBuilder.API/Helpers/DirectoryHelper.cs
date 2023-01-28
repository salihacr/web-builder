namespace WebBuilder.API.Helpers;

public static class DirectoryHelper
{
    public static bool DirectoryExists(string folderName)
    {
        string path = getPath(folderName);
        return Directory.Exists(path) ? true : false;
    }
    public static string getPath(string folderName = "")
    {
        string projectsPath = getProjectsPath();
        folderName = string.IsNullOrEmpty(folderName) ? string.Empty : $"\\{folderName}";
        string path = projectsPath + folderName;
        return path;
    }
    public static string getProjectsPath()
    {
        string basePath = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
        string path = basePath + "\\projects";

        if (!Directory.Exists(path))
        {
            createProjectsFolder();
        }
        return path;

    }
    private static void createProjectsFolder()
    {
        string basePath = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
        string path = basePath + "\\projects";
        System.IO.Directory.CreateDirectory(path);
    }
}