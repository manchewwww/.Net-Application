using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface IPartFitmentRepository
    {
        public Task<PartFitmentEntity> AddPartFitmentAsync(PartFitmentEntity entity);
        public Task<IEnumerable<PartFitmentEntity>> GetAllPartFitmentsAsync();
        public Task<PartFitmentEntity?> GetPartFitmentByIdAsync(long id);
        public Task UpdatePartFitmentAsync(PartFitmentEntity entity);
        public Task DeletePartFitmentAsync(PartFitmentEntity entity);
    }

    public class PartFitmentRepository : Repository<PartFitmentEntity>, IPartFitmentRepository
    {
        public PartFitmentRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<PartFitmentEntity> AddPartFitmentAsync(PartFitmentEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<PartFitmentEntity>> GetAllPartFitmentsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<PartFitmentEntity?> GetPartFitmentByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdatePartFitmentAsync(PartFitmentEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeletePartFitmentAsync(PartFitmentEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
