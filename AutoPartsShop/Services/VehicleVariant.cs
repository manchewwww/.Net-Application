using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface IVehicleVariantService
    {
        public Task<VehicleVariantResponse> AddVehicleVariantAsync(VehicleVariantCreateRequest request);
        public Task<IEnumerable<VehicleVariantResponse>> GetAllVehicleVariantsAsync();
        public Task<VehicleVariantResponse?> GetVehicleVariantByIdAsync(long id);
        public Task<VehicleVariantResponse> UpdateVehicleVariantAsync(long id, VehicleVariantUpdateRequest request);
        public Task<VehicleVariantResponse> DeleteVehicleVariantAsync(long id);
    }

    public class VehicleVariantService : IVehicleVariantService
    {
        private readonly IVehicleVariantRepository _repository;

        public VehicleVariantService(IVehicleVariantRepository repository)
        {
            _repository = repository;
        }

        public async Task<VehicleVariantResponse> AddVehicleVariantAsync(VehicleVariantCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddVehicleVariantAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<VehicleVariantResponse>> GetAllVehicleVariantsAsync()
        {
            var entities = await _repository.GetAllVehicleVariantsAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<VehicleVariantResponse?> GetVehicleVariantByIdAsync(long id)
        {
            var entity = await _repository.GetVehicleVariantByIdAsync(id) ?? throw new NotFoundException("VehicleVariant with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<VehicleVariantResponse> UpdateVehicleVariantAsync(long id, VehicleVariantUpdateRequest request)
        {
            var existing = await _repository.GetVehicleVariantByIdAsync(id) ?? throw new NotFoundException("VehicleVariant with ID " + id + " not found.");
            existing.ModelId = request.ModelId;
            existing.YearFrom = request.YearFrom;
            existing.YearTo = request.YearTo;
            existing.EngineCode = request.EngineCode;
            existing.Notes = request.Notes;

            await _repository.UpdateVehicleVariantAsync(existing);
            return existing.ToDto();
        }

        public async Task<VehicleVariantResponse> DeleteVehicleVariantAsync(long id)
        {
            var entity = await _repository.GetVehicleVariantByIdAsync(id) ?? throw new NotFoundException("VehicleVariant with ID " + id + " not found.");
            await _repository.DeleteVehicleVariantAsync(entity);
            return entity.ToDto();
        }
    }
}
