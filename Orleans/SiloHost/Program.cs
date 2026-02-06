using Microsoft.Extensions.Hosting;
using Orleans.Hosting;

await Host.CreateDefaultBuilder(args)
    .UseOrleans(silo =>
    {
        silo.UseLocalhostClustering()
            .AddMemoryGrainStorageAsDefault();
    })
    .RunConsoleAsync();
