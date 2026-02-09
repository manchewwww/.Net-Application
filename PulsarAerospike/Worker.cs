using System.Text;
using System.Text.Json;
using DotPulsar;
using DotPulsar.Extensions;
using Microsoft.Extensions.Options;

namespace PulsarAerospike;

public sealed class Worker : BackgroundService
{
    private readonly PulsarOptions _pulsar;
    private readonly AerospikeDb _db;
    private readonly ILogger<Worker> _log;

    public Worker(IOptions<PulsarOptions> pulsar, AerospikeDb db, ILogger<Worker> log)
    {
        _pulsar = pulsar.Value;
        _db = db;
        _log = log;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await using var client = PulsarClient.Builder()
            .ServiceUrl(new Uri(_pulsar.ServiceUrl))
            .Build();

        await using var consumer = client.NewConsumer(Schema.ByteArray)
            .Topic(_pulsar.Topic)
            .SubscriptionName(_pulsar.Subscription)
            .InitialPosition(SubscriptionInitialPosition.Earliest)
            .Create();

        _log.LogInformation("Consumer started. Topic={Topic} Sub={Sub}", _pulsar.Topic, _pulsar.Subscription);

        while (!stoppingToken.IsCancellationRequested)
        {
            var msg = await consumer.Receive(stoppingToken);

            var json = Encoding.UTF8.GetString(msg.Value());

            try
            {
                using var doc = JsonDocument.Parse(json);
                var id = doc.RootElement.TryGetProperty("id", out var idProp) ? idProp.GetString() : null;
                if (string.IsNullOrWhiteSpace(id))
                    id = Guid.NewGuid().ToString("N");

                _db.Put(id!, new Dictionary<string, object>
                {
                    ["json"] = json,
                    ["ingestedAt"] = DateTime.UtcNow.ToString("o")
                });

                await consumer.Acknowledge(msg, stoppingToken);
                _log.LogInformation("Stored message id={Id}", id);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Failed processing message: {Json}", json);
            }
        }
    }
}
