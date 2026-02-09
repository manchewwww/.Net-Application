namespace AerospikeTest
{
    public sealed class AerospikeOptions
    {
        public List<AerospikeHost> Hosts { get; set; } = [];
        public string Namespace { get; set; } = "";
        public string Set { get; set; } = "";
        public int DefaultTtlSeconds { get; set; } = 0;
        public int TimeoutMs { get; set; } = 1000;
        public int MaxRetries { get; set; } = 1;
    }

    public sealed class AerospikeHost
    {
        public string Address { get; set; } = "127.0.0.1";
        public int Port { get; set; } = 3000;
    }
}