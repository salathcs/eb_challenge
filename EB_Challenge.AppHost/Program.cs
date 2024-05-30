var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.EB_Challenge_ApiService>("apiservice");

builder.AddProject<Projects.EB_Challenge_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
