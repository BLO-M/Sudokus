var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Sudokus_ApiService>("apiservice");

builder.AddProject<Projects.Sudokus_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
