using Microsoft.Extensions.Options;
using WebBuilder.API.Models;

namespace WebBuilder.API.Extensions;

public static class AppSettingsExtension
{
    public static void ConfigureAppSettings(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
        builder.Services.AddSingleton<IMongoDbSettings>(serviceProvider =>
            serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
    }
}