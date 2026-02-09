using Aerospike.Client;
using Microsoft.Extensions.Options;
using System.Text.Json;


namespace AerospikeTest
{
    public sealed class AerospikeDb : IDisposable
    {
        private readonly AerospikeClient _client;
        private readonly AerospikeOptions _options;

        public AerospikeDb(IOptions<AerospikeOptions> options)
        {
            _options = options.Value;

            if (_options.Hosts == null || _options.Hosts.Count == 0)
                throw new InvalidOperationException("Aerospike:Hosts is empty in configuration.");

            var policy = new ClientPolicy
            {
                timeout = _options.TimeoutMs,
            };

            var hostString = string.Join(",", _options.Hosts.Select(h => $"{h.Address}:{h.Port}"));
            var hosts = Aerospike.Client.Host.ParseHosts(hostString, null, 0);

            _client = new AerospikeClient(policy, hosts);

            if (!_client.Connected)
            {
                throw new InvalidOperationException("Failed to connect to Aerospike (client not connected).");
            }
        }

        public Key KeyFromString(string userKey) => new Key(_options.Namespace, _options.Set, userKey);

        public WritePolicy DefaultWritePolicy() => new WritePolicy
        {
            expiration = _options.DefaultTtlSeconds
        };

        public void Put(string userKey, Dictionary<string, object> bins)
        {
            var key = KeyFromString(userKey);
            var writePolicy = DefaultWritePolicy();


            var aerospikeBins = bins
                .Select(kv => new { kv.Key, Val = ConvertToAerospikeValue(kv.Value) })
                .Where(x => x.Val != null)
                .Select(x => new Bin(x.Key, x.Val))
                .ToArray();
            _client.Put(writePolicy, key, aerospikeBins);
        }

        public Dictionary<string, object>? Get(string userKey)
        {
            var key = KeyFromString(userKey);
            var record = _client.Get(null, key);
            return record?.bins;
        }


        public bool Delete(string userKey)
        {
            var key = KeyFromString(userKey);
            return _client.Delete(null, key);
        }

        public void Dispose() => _client?.Close();

        private static object ConvertToAerospikeValue(object value)
        {
            if (value is JsonElement je)
            {
                return je.ValueKind switch
                {
                    JsonValueKind.String => je.GetString()!,
                    JsonValueKind.Number => je.TryGetInt64(out var l) ? l
                                           : je.TryGetDouble(out var d) ? d
                                           : je.GetDecimal(),
                    JsonValueKind.True => true,
                    JsonValueKind.False => false,
                    JsonValueKind.Null => null!,
                    JsonValueKind.Object => je.GetRawText(),
                    JsonValueKind.Array => je.GetRawText(),
                    _ => je.GetRawText()
                };
            }

            // Already a primitive type
            return value;
        }
    }
}
