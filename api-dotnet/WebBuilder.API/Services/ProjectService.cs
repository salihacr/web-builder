using WebBuilder.API.Constants;
using WebBuilder.API.Helpers;

namespace WebBuilder.API.Services;

public interface IProjectService
{
    bool CloneProject(string url);
    bool PullProject(string projectName);
}
public class ProjectService : IProjectService
{
    public bool CloneProject(string url)
    {
        return true;
    }

    public bool PullProject(string projectName)
    {
        throw new NotImplementedException();
    }
}