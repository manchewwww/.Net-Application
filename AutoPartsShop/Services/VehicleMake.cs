using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface IVehicleMakeService
    {
        public Task<VehicleMakeResponse> AddVehicleMakeAsync(VehicleMakeCreateRequest request);
        public Task<IEnumerable<VehicleMakeResponse>> GetAllVehicleMakesAsync();
        public Task<VehicleMakeResponse?> GetVehicleMakeByIdAsync(long id);
        public Task<VehicleMakeResponse> UpdateVehicleMakeAsync(long id, VehicleMakeUpdateRequest request);
        public Task<VehicleMakeResponse> DeleteVehicleMakeAsync(long id);
    }

    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly IVehicleMakeRepository _repository;

        public VehicleMakeService(IVehicleMakeRepository repository)
        {
            _repository = repository;
        }

        public async Task<VehicleMakeResponse> AddVehicleMakeAsync(VehicleMakeCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddVehicleMakeAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<VehicleMakeResponse>> GetAllVehicleMakesAsync()
        {
            var entities = await _repository.GetAllVehicleMakesAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<VehicleMakeResponse?> GetVehicleMakeByIdAsync(long id)
        {
            var entity = await _repository.GetVehicleMakeByIdAsync(id) ?? throw new NotFoundException("VehicleMake with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<VehicleMakeResponse> UpdateVehicleMakeAsync(long id, VehicleMakeUpdateRequest request)
        {
            var existing = await _repository.GetVehicleMakeByIdAsync(id) ?? throw new NotFoundException("VehicleMake with ID " + id + " not found.");
            existing.Name = request.Name;

            await _repository.UpdateVehicleMakeAsync(existing);
            return existing.ToDto();
        }

        public async Task<VehicleMakeResponse> DeleteVehicleMakeAsync(long id)
        {
            var entity = await _repository.GetVehicleMakeByIdAsync(id) ?? throw new NotFoundException("VehicleMake with ID " + id + " not found.");
            await _repository.DeleteVehicleMakeAsync(entity);
            return entity.ToDto();
        }
    }
}
