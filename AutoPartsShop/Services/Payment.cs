using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface IPaymentService
    {
        public Task<PaymentResponse> AddPaymentAsync(PaymentCreateRequest request);
        public Task<IEnumerable<PaymentResponse>> GetAllPaymentsAsync();
        public Task<PaymentResponse?> GetPaymentByIdAsync(long id);
        public Task<PaymentResponse> UpdatePaymentAsync(long id, PaymentUpdateRequest request);
        public Task<PaymentResponse> DeletePaymentAsync(long id);
    }

    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repository;

        public PaymentService(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaymentResponse> AddPaymentAsync(PaymentCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddPaymentAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<PaymentResponse>> GetAllPaymentsAsync()
        {
            var entities = await _repository.GetAllPaymentsAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<PaymentResponse?> GetPaymentByIdAsync(long id)
        {
            var entity = await _repository.GetPaymentByIdAsync(id) ?? throw new NotFoundException("Payment with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<PaymentResponse> UpdatePaymentAsync(long id, PaymentUpdateRequest request)
        {
            var existing = await _repository.GetPaymentByIdAsync(id) ?? throw new NotFoundException("Payment with ID " + id + " not found.");
            existing.OrderId = request.OrderId;
            existing.Provider = request.Provider;
            existing.ProviderRef = request.ProviderRef;
            existing.Status = request.Status;
            existing.Amount = request.Amount;

            await _repository.UpdatePaymentAsync(existing);
            return existing.ToDto();
        }

        public async Task<PaymentResponse> DeletePaymentAsync(long id)
        {
            var entity = await _repository.GetPaymentByIdAsync(id) ?? throw new NotFoundException("Payment with ID " + id + " not found.");
            await _repository.DeletePaymentAsync(entity);
            return entity.ToDto();
        }
    }
}
