using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Grains;
using Orleans.Hosting;

var host = new HostBuilder()
    .UseOrleansClient(client =>
    {
        client.UseLocalhostClustering();
    })
    .Build();

await host.StartAsync();

var clusterClient = (IClusterClient?)host.Services.GetService(typeof(IClusterClient))
    ?? throw new InvalidOperationException("IClusterClient is not registered. Did UseOrleansClient run?");

var grain = clusterClient.GetGrain<ICounterGrain>("my-counter");
var weatherGrain = clusterClient.GetGrain<IWeatherGrain>("my-weather");

Console.WriteLine($"Increment -> {await grain.Increment()}");
Console.WriteLine($"GetCount  -> {await grain.GetCount()}");
Console.WriteLine($"Weather   -> {await weatherGrain.GetWeatherAsync()}");

Console.WriteLine("Press any key to exit...");
Console.ReadKey();

await host.StopAsync();
