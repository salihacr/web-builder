using System;
using System.Diagnostics;
using System.Text;
using WebBuilder.API.Constants;

namespace WebBuilder.API.Helpers;

public static class CMD
{
    public static string RunCommand(string command, string folderName = "")
    {
        try
        {
            using (Process process = createProcess(folderName))
            {
                process.Start();
                process.StandardInput.WriteLine(command);
                process.StandardInput.Flush();
                process.StandardInput.Close();

                StringBuilder sb = new StringBuilder();
                while (!process.StandardOutput.EndOfStream)
                {
                    sb.Append(process.StandardOutput.ReadLine());
                    Console.WriteLine(sb.ToString());
                }
                process.WaitForExit();
                return sb.ToString();
            }
        }
        catch (Exception ex)
        {
            return Constants.Common.ERROR;
        }
    }

    private static Process createProcess(string folderName = "")
    {
        ProcessStartInfo processStartInfo = new ProcessStartInfo();
        processStartInfo.WorkingDirectory = getPath(folderName);
        processStartInfo.FileName = "cmd.exe";
        processStartInfo.RedirectStandardInput = true;
        processStartInfo.RedirectStandardOutput = true;
        processStartInfo.UseShellExecute = false;
        processStartInfo.CreateNoWindow = false;
        Process process = new Process();
        process.StartInfo = processStartInfo;
        return process;
    }

    private static string getPath(string folderName = "")
    {
        string projectsPath = getProjectsPath();
        folderName = string.IsNullOrEmpty(folderName) ? string.Empty : $"\\{folderName}";
        string path = projectsPath + folderName;
        return path;
    }
    private static string getProjectsPath()
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