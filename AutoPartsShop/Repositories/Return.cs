using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface IReturnRepository
    {
        public Task<ReturnEntity> AddReturnAsync(ReturnEntity entity);
        public Task<IEnumerable<ReturnEntity>> GetAllReturnsAsync();
        public Task<ReturnEntity?> GetReturnByIdAsync(long id);
        public Task UpdateReturnAsync(ReturnEntity entity);
        public Task DeleteReturnAsync(ReturnEntity entity);
    }

    public class ReturnRepository : Repository<ReturnEntity>, IReturnRepository
    {
        public ReturnRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<ReturnEntity> AddReturnAsync(ReturnEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<ReturnEntity>> GetAllReturnsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<ReturnEntity?> GetReturnByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateReturnAsync(ReturnEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeleteReturnAsync(ReturnEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
