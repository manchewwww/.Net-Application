using Logger.Models;
using Logger.Repositories;

namespace Logger.Services;

public sealed class ItemService
{
    private readonly ItemRepository _repository;

    public ItemService(ItemRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Item>> GetAllAsync() => _repository.GetAllAsync();

    public Task<Item?> GetByIdAsync(string id) => _repository.GetByIdAsync(id);

    public Task CreateAsync(Item item) => _repository.CreateAsync(item);

    public Task UpdateAsync(string id, Item item) => _repository.UpdateAsync(id, item);

    public Task DeleteAsync(string id) => _repository.DeleteAsync(id);
}
