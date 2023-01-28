using WebBuilder.API.Mongo;
using WebBuilder.API.Services;

namespace WebBuilder.API.Extensions;

public static class IocExtension
{
    public static void AddDependencies(this WebApplicationBuilder builder)
    {

        builder.Services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepositorty<>));

        builder.Services.AddScoped<IGitService, GitService>();
        builder.Services.AddScoped<IBuilderService, BuilderService>();
        builder.Services.AddScoped<IProjectService, ProjectService>();
    }
}