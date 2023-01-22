namespace WebBuilder.API.Entities;

public class Project
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? GitWebUrl { get; set; }
    public string? Description { get; set; }
    public string? GitName { get; set; }
}