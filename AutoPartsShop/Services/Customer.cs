using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface ICustomerService
    {
        public Task<CustomerResponse> AddCustomerAsync(CustomerCreateRequest request);
        public Task<IEnumerable<CustomerResponse>> GetAllCustomersAsync();
        public Task<CustomerResponse?> GetCustomerByIdAsync(long id);
        public Task<CustomerResponse> UpdateCustomerAsync(long id, CustomerUpdateRequest request);
        public Task<CustomerResponse> DeleteCustomerAsync(long id);
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<CustomerResponse> AddCustomerAsync(CustomerCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddCustomerAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<CustomerResponse>> GetAllCustomersAsync()
        {
            var entities = await _repository.GetAllCustomersAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<CustomerResponse?> GetCustomerByIdAsync(long id)
        {
            var entity = await _repository.GetCustomerByIdAsync(id) ?? throw new NotFoundException("Customer with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<CustomerResponse> UpdateCustomerAsync(long id, CustomerUpdateRequest request)
        {
            var existing = await _repository.GetCustomerByIdAsync(id) ?? throw new NotFoundException("Customer with ID " + id + " not found.");
            existing.Email = request.Email;
            existing.Phone = request.Phone;
            existing.PasswordHash = request.PasswordHash;

            await _repository.UpdateCustomerAsync(existing);
            return existing.ToDto();
        }

        public async Task<CustomerResponse> DeleteCustomerAsync(long id)
        {
            var entity = await _repository.GetCustomerByIdAsync(id) ?? throw new NotFoundException("Customer with ID " + id + " not found.");
            await _repository.DeleteCustomerAsync(entity);
            return entity.ToDto();
        }
    }
}
