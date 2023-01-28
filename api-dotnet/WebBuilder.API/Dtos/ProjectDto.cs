namespace WebBuilder.API.Dtos;

public class ProjectDto
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? GitWebUrl { get; set; }
    public string? Description { get; set; }
    public string? GitRepoName { get; set; }
}

public class CreateProjectDto : BaseCreateUpdateProjectDto
{
    public string? GitWebUrl { get; set; }
    public string SetGitName(string url)
    {
        string[] words = url.Split("/");
        string repoName = words[words.Length - 1];
        repoName = repoName.Replace(".git", "");
        return repoName;
    }
}

public class UpdateProjectDto : BaseCreateUpdateProjectDto
{
    public string? Id { get; set; }
}

public class BaseCreateUpdateProjectDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}