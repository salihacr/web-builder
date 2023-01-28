using WebBuilder.API.Attributes;
using WebBuilder.API.Mongo;

namespace WebBuilder.API.Entities;

[BsonCollection(nameof(Project))]
public class Project : BaseDocumentObject
{
    public string? Name { get; set; }
    public string? GitWebUrl { get; set; }
    public string? Description { get; set; }
    public string? GitRepoName { get; set; }
}