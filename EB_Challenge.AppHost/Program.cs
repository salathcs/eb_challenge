var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.EB_Challenge_ApiService>("apiservice");
var videosService = builder.AddProject<Projects.EB_Challenge_VideosService>("videosservice");

builder.AddProject<Projects.EB_Challenge_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithEnvironment("videosservice", videosService.GetEndpoint("https"));

builder.Build().Run();
