using EB_Challenge.DomainService;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddSqlServerDbContext<VideosDbContext>("sqldb");
builder.Services.AddTransient<VideosService>();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/getVideos", async (VideosService service) =>
{
    var syncVideo = await service.GetSyncVideo();
    return Results.Ok(syncVideo.VideoDatas);
})
.WithName("GetVideos")
.WithOpenApi();

app.MapPut("/addVideo", async (VideosService service, [FromBody] VideoDatas videoDatas) =>
{
    await service.AddVideo(videoDatas);
    return Results.Ok();
})
.WithName("AddVideo")
.WithOpenApi();

app.MapDelete("/resetVideos", async (VideosService service) =>
{
    await service.ClearVideos();
    return Results.Ok();
})
.WithName("ResetVideos")
.WithOpenApi();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<VideosDbContext>();
await context.Database.EnsureCreatedAsync();

app.Run();

