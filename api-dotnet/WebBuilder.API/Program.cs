using WebBuilder.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("test", policy =>
//                      {
//                          policy.AllowAnyOrigin();
//                          policy.AllowAnyHeader();
//                          policy.AllowAnyMethod();
//                      });
//});

// AppSettings.json Configuration
builder.ConfigureAppSettings();

// Add services to the container.
builder.AddDependencies();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseCors("test");

app.UseAuthorization();

app.MapControllers();

app.Run();
