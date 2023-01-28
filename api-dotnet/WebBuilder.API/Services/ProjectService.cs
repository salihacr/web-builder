using MongoDB.Bson;
using System.Web;
using WebBuilder.API.Constants;
using WebBuilder.API.Dtos;
using WebBuilder.API.Entities;
using WebBuilder.API.Helpers;
using WebBuilder.API.Mongo;

namespace WebBuilder.API.Services;

public interface IProjectService
{
    Task<string> Create(CreateProjectDto projectDto);
    Task<bool> Update(UpdateProjectDto projectDto);
    Task<bool> Delete(string id);
    Task<List<ProjectDto>> GetAll();
    Task<ProjectDto> GetById(string id);
}
public class ProjectService : IProjectService
{
    private readonly IMongoRepository<Project> _projectRepository;
    private readonly IGitService _gitService;

    public ProjectService(
        IMongoRepository<Project> projectRepository,
        IGitService gitService)
    {
        _projectRepository = projectRepository;
        _gitService = gitService;
    }

    public async Task<string> Create(CreateProjectDto projectDto)
    {
        var projectExists = await isProjectExists(projectDto.GitWebUrl);
        if (projectExists)
        {
            throw new Exception("Project already exists");
        }

        var project = new Project()
        {
            Name = projectDto.Name,
            Description = projectDto.Description,
            GitWebUrl = HttpUtility.UrlDecode(projectDto.GitWebUrl),
            GitRepoName = projectDto.SetGitName(projectDto.GitWebUrl),
        };

        var isPulled = CloneProject(project.GitWebUrl);

        var result = await _projectRepository.InsertOneAsync(project);
        return result;

    }

    private async Task<bool> isProjectExists(string projectGitUrl)
    {
        var result = await _projectRepository.FindOneAsync(item => item.GitWebUrl == projectGitUrl);
        return result == null ? false : true;
    }

    public async Task<bool> Update(UpdateProjectDto projectDto)
    {
        var project = new Project()
        {
            Id = new ObjectId(projectDto.Id),
            Name = projectDto.Name,
            Description = projectDto.Description,
        };
        var result = await _projectRepository.ReplaceOneAsync(project);
        return result;
    }

    public async Task<bool> Delete(string id)
    {
        var result = await _projectRepository.DeleteByIdAsync(id);
        return result;
    }

    public async Task<ProjectDto> GetById(string id)
    {
        var data = await _projectRepository.FindByIdAsync(id);
        if (data != null)
        {
            var returnData = new ProjectDto()
            {
                Id = data.Id.ToString(),
                Name = data.Name,
                Description = data.Description,
                GitWebUrl = data.GitWebUrl
            };
            return returnData;
        }
        return null;
    }
    public async Task<List<ProjectDto>> GetAll()
    {
        var data = await _projectRepository.FilterByAsync(x => true);
        if (data != null && data.Count > 0)
        {
            var returnData = new List<ProjectDto>();
            data.ForEach(item =>
            {
                returnData.Add(new ProjectDto()
                {
                    Id = item.Id.ToString(),
                    Name = item.Name,
                    Description = item.Description,
                    GitWebUrl = item.GitWebUrl
                });
            });
            return returnData;
        }
        return null;
    }

    private bool CloneProject(string projectGitUrl)
    {
        var result = _gitService.CloneProject(projectGitUrl);
        return result;
    }
}