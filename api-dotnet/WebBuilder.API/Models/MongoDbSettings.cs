namespace WebBuilder.API.Models;

public interface IMongoDbSettings
{
    string? DatabaseName { get; }
    string? ConnectionString { get; }
}
public class MongoDbSettings : IMongoDbSettings
{
    public string? DatabaseName { get; }
    public string? ConnectionString { get; }
}
