using System;
using WebBuilder.API.Constants;
using WebBuilder.API.Helpers;
using WebBuilder.API.Utilities;

namespace WebBuilder.API.Services;

/// <summary>
/// Git methods
/// </summary>
public interface IGitService
{
    bool CloneProject(string url);
    bool PullProject(string projectName);
}


public class GitService : IGitService
{
    public bool CloneProject(string url)
    {
        string result = CMD.RunCommand($"{GitKeywords.CLONE + url}");
        string gitName = url.SetGitName();
        bool exists = DirectoryHelper.DirectoryExists(gitName);
        return exists;
    }

    public bool PullProject(string projectName)
    {
        string result = CMD.RunCommand(GitKeywords.PULL, projectName);
        if (result.Contains(Common.ERROR) || result.Contains(Common.FATAL))
        {
            return false;
        }
        return true;
    }
}