var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql");
var sqldb = sql.AddDatabase("sqldb");

var apiService = builder.AddProject<Projects.EB_Challenge_ApiService>("apiservice");
var videosService = builder.AddProject<Projects.EB_Challenge_VideosService>("videosservice");
var signalrservice = builder.AddProject<Projects.EB_Challenge_SignalRService>("signalrservice");
var domainservice = builder.AddProject<Projects.EB_Challenge_DomainService>("domainservice")
    .WithReference(sqldb);

builder.AddProject<Projects.EB_Challenge_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(domainservice)
    .WithEnvironment("videosservice", videosService.GetEndpoint("https"))
    .WithEnvironment("signalrservice", signalrservice.GetEndpoint("https"));

builder.Build().Run();
