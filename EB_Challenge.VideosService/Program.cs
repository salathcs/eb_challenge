using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/videos/{filename}", ([FromRoute] string fileName) =>
{
    var filePath = Path.Combine($"{app.Configuration["VideosLocation"]}", fileName);
    var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
    return Results.File(fileStream, "video/mp4");
});

app.Run();
