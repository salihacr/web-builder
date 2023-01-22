using System;
using WebBuilder.API.Constants;
using WebBuilder.API.Helpers;

namespace WebBuilder.API.Services;

/// <summary>
/// Git methods
/// </summary>
public interface IGitService
{
    bool CloneProject(string url);
    bool PullProject(string projectName);
}


public class Git : IGitService
{
    public bool CloneProject(string url)
    {
        string result = CMD.RunCommand($"{GitKeywords.CLONE + url}");

        if(result.Contains(Common.ERROR) || result.Contains(Common.FATAL))
        {
            return false;
        }

        if(result.Contains(Common.RESOLVING_DELTAS) && result.Contains(Common.DONE))
        {
            return true;
        }
        return false;

    }

    public bool PullProject(string projectName)
    {
        string result = CMD.RunCommand(GitKeywords.PULL, projectName);
        if (result.Contains(Common.ERROR) || result.Contains(Common.FATAL))
        {
            return false;
        }
        throw new NotImplementedException();
    }
}