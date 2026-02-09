using System.Text;
using DotPulsar;
using DotPulsar.Abstractions;
using DotPulsar.Extensions;
using Microsoft.Extensions.Options;

namespace PulsarAerospike;

public sealed class PulsarProducer : IAsyncDisposable
{
    private readonly IPulsarClient _client;
    private readonly IProducer<byte[]> _producer;

    public PulsarProducer(IOptions<PulsarOptions> opt)
    {
        var options = opt.Value;

        _client = PulsarClient.Builder()
            .ServiceUrl(new Uri(options.ServiceUrl))
            .Build();

        _producer = _client.NewProducer(Schema.ByteArray)
            .Topic(options.Topic)
            .Create();
    }

    public async Task SendJsonAsync(string json, CancellationToken ct)
    {
        var payload = Encoding.UTF8.GetBytes(json);
        await _producer.Send(payload, ct);
    }

    public async ValueTask DisposeAsync()
    {
        await _producer.DisposeAsync();
        await _client.DisposeAsync();
    }
}
