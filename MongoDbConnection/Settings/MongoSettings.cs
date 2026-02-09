namespace Logger.Settings;

public sealed class MongoSettings
{
    public string ConnectionString { get; init; } = string.Empty;
    public string DatabaseName { get; init; } = string.Empty;
    public string CollectionName { get; init; } = string.Empty;
}
