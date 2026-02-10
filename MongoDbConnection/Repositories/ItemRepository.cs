using Logger.Models;
using Logger.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Logger.Repositories;

public sealed class ItemRepository
{
    private readonly IMongoCollection<Item> _items;

    public ItemRepository(IMongoClient mongoClient, IOptions<MongoSettings> settings)
    {
        var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
        _items = database.GetCollection<Item>(settings.Value.CollectionName);
    }

    public Task<List<Item>> GetAllAsync() => _items.Find(_ => true).ToListAsync();

    public async Task<Item?> GetByIdAsync(string id) => await _items.Find(item => item.Id == id).FirstOrDefaultAsync();

    public Task CreateAsync(Item item) => _items.InsertOneAsync(item);

    public Task UpdateAsync(string id, Item item) => _items.ReplaceOneAsync(existing => existing.Id == id, item);

    public Task DeleteAsync(string id) => _items.DeleteOneAsync(existing => existing.Id == id);
}
