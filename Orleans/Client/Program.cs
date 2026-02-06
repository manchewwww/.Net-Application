using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Grains;
using Orleans.Hosting;
using System.Diagnostics;


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
var test = new Orleans.Client.Test();


await Bench("Grain Increment", warmup: 20, iters: 1000, () => grain.Increment());
await Bench("Grain GetCount", warmup: 20, iters: 1000, () => grain.GetCount());
await Bench("Grain GetWeather", warmup: 20, iters: 1000, () => weatherGrain.GetWeatherAsync());
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

await host.StopAsync();



static async Task Bench(string name, int warmup, int iters, Func<Task> action)
{
    // Warm-up
    for (int i = 0; i < warmup; i++) await action();

    var times = new double[iters];
    for (int i = 0; i < iters; i++)
    {
        var sw = Stopwatch.StartNew();
        await action();
        sw.Stop();
        times[i] = sw.Elapsed.TotalMilliseconds;
    }

    Array.Sort(times);
    double avg = times.Average();
    double p95 = times[(int)(iters * 0.95)];

    Console.WriteLine($"{name}: avg={avg:F4} ms, p95={p95:F4} ms, min={times[0]:F4} ms, max={times[^1]:F4} ms");
}