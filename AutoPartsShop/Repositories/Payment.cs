using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface IPaymentRepository
    {
        public Task<PaymentEntity> AddPaymentAsync(PaymentEntity entity);
        public Task<IEnumerable<PaymentEntity>> GetAllPaymentsAsync();
        public Task<PaymentEntity?> GetPaymentByIdAsync(long id);
        public Task UpdatePaymentAsync(PaymentEntity entity);
        public Task DeletePaymentAsync(PaymentEntity entity);
    }

    public class PaymentRepository : Repository<PaymentEntity>, IPaymentRepository
    {
        public PaymentRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<PaymentEntity> AddPaymentAsync(PaymentEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<PaymentEntity>> GetAllPaymentsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<PaymentEntity?> GetPaymentByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdatePaymentAsync(PaymentEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeletePaymentAsync(PaymentEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
