using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface IVehicleModelService
    {
        public Task<VehicleModelResponse> AddVehicleModelAsync(VehicleModelCreateRequest request);
        public Task<IEnumerable<VehicleModelResponse>> GetAllVehicleModelsAsync();
        public Task<VehicleModelResponse?> GetVehicleModelByIdAsync(long id);
        public Task<VehicleModelResponse> UpdateVehicleModelAsync(long id, VehicleModelUpdateRequest request);
        public Task<VehicleModelResponse> DeleteVehicleModelAsync(long id);
    }

    public class VehicleModelService : IVehicleModelService
    {
        private readonly IVehicleModelRepository _repository;

        public VehicleModelService(IVehicleModelRepository repository)
        {
            _repository = repository;
        }

        public async Task<VehicleModelResponse> AddVehicleModelAsync(VehicleModelCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddVehicleModelAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<VehicleModelResponse>> GetAllVehicleModelsAsync()
        {
            var entities = await _repository.GetAllVehicleModelsAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<VehicleModelResponse?> GetVehicleModelByIdAsync(long id)
        {
            var entity = await _repository.GetVehicleModelByIdAsync(id) ?? throw new NotFoundException("VehicleModel with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<VehicleModelResponse> UpdateVehicleModelAsync(long id, VehicleModelUpdateRequest request)
        {
            var existing = await _repository.GetVehicleModelByIdAsync(id) ?? throw new NotFoundException("VehicleModel with ID " + id + " not found.");
            existing.MakeId = request.MakeId;
            existing.Name = request.Name;

            await _repository.UpdateVehicleModelAsync(existing);
            return existing.ToDto();
        }

        public async Task<VehicleModelResponse> DeleteVehicleModelAsync(long id)
        {
            var entity = await _repository.GetVehicleModelByIdAsync(id) ?? throw new NotFoundException("VehicleModel with ID " + id + " not found.");
            await _repository.DeleteVehicleModelAsync(entity);
            return entity.ToDto();
        }
    }
}
