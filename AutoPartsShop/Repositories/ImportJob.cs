using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface IImportJobRepository
    {
        public Task<ImportJobEntity> AddImportJobAsync(ImportJobEntity entity);
        public Task<IEnumerable<ImportJobEntity>> GetAllImportJobsAsync();
        public Task<ImportJobEntity?> GetImportJobByIdAsync(long id);
        public Task UpdateImportJobAsync(ImportJobEntity entity);
        public Task DeleteImportJobAsync(ImportJobEntity entity);
    }

    public class ImportJobRepository : Repository<ImportJobEntity>, IImportJobRepository
    {
        public ImportJobRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<ImportJobEntity> AddImportJobAsync(ImportJobEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<ImportJobEntity>> GetAllImportJobsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<ImportJobEntity?> GetImportJobByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateImportJobAsync(ImportJobEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeleteImportJobAsync(ImportJobEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
