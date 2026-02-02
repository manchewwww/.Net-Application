using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface IAddressService
    {
        public Task<AddressResponse> AddAddressAsync(AddressCreateRequest request);
        public Task<IEnumerable<AddressResponse>> GetAllAddressesAsync();
        public Task<AddressResponse?> GetAddressByIdAsync(long id);
        public Task<AddressResponse> UpdateAddressAsync(long id, AddressUpdateRequest request);
        public Task<AddressResponse> DeleteAddressAsync(long id);
    }

    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repository;

        public AddressService(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddressResponse> AddAddressAsync(AddressCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddAddressAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<AddressResponse>> GetAllAddressesAsync()
        {
            var entities = await _repository.GetAllAddressesAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<AddressResponse?> GetAddressByIdAsync(long id)
        {
            var entity = await _repository.GetAddressByIdAsync(id) ?? throw new NotFoundException("Address with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<AddressResponse> UpdateAddressAsync(long id, AddressUpdateRequest request)
        {
            var existing = await _repository.GetAddressByIdAsync(id) ?? throw new NotFoundException("Address with ID " + id + " not found.");
            existing.CustomerId = request.CustomerId;
            existing.Type = request.Type;
            existing.Name = request.Name;
            existing.Line1 = request.Line1;
            existing.Line2 = request.Line2;
            existing.City = request.City;
            existing.Region = request.Region;
            existing.PostalCode = request.PostalCode;
            existing.CountryId = request.CountryId;
            existing.IsDefault = request.IsDefault;

            await _repository.UpdateAddressAsync(existing);
            return existing.ToDto();
        }

        public async Task<AddressResponse> DeleteAddressAsync(long id)
        {
            var entity = await _repository.GetAddressByIdAsync(id) ?? throw new NotFoundException("Address with ID " + id + " not found.");
            await _repository.DeleteAddressAsync(entity);
            return entity.ToDto();
        }
    }
}
