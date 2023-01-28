using System.Diagnostics;
using System.Text;

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
                    sb.AppendLine(process.StandardOutput.ReadLine());
                    Console.WriteLine(process.StandardOutput.ReadLine());
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
        processStartInfo.WorkingDirectory = DirectoryHelper.getPath(folderName);
        processStartInfo.FileName = "cmd.exe";
        processStartInfo.RedirectStandardInput = true;
        processStartInfo.RedirectStandardOutput = true;
        processStartInfo.UseShellExecute = false;
        processStartInfo.CreateNoWindow = true;
        Process process = new Process();
        process.StartInfo = processStartInfo;
        return process;
    }
}