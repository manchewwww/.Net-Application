using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface IPartFitmentService
    {
        public Task<PartFitmentResponse> AddPartFitmentAsync(PartFitmentCreateRequest request);
        public Task<IEnumerable<PartFitmentResponse>> GetAllPartFitmentsAsync();
        public Task<PartFitmentResponse?> GetPartFitmentByIdAsync(long id);
        public Task<PartFitmentResponse> UpdatePartFitmentAsync(long id, PartFitmentUpdateRequest request);
        public Task<PartFitmentResponse> DeletePartFitmentAsync(long id);
    }

    public class PartFitmentService : IPartFitmentService
    {
        private readonly IPartFitmentRepository _repository;

        public PartFitmentService(IPartFitmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<PartFitmentResponse> AddPartFitmentAsync(PartFitmentCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddPartFitmentAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<PartFitmentResponse>> GetAllPartFitmentsAsync()
        {
            var entities = await _repository.GetAllPartFitmentsAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<PartFitmentResponse?> GetPartFitmentByIdAsync(long id)
        {
            var entity = await _repository.GetPartFitmentByIdAsync(id) ?? throw new NotFoundException("PartFitment with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<PartFitmentResponse> UpdatePartFitmentAsync(long id, PartFitmentUpdateRequest request)
        {
            var existing = await _repository.GetPartFitmentByIdAsync(id) ?? throw new NotFoundException("PartFitment with ID " + id + " not found.");
            existing.PartId = request.PartId;
            existing.VariantId = request.VariantId;
            existing.Fitment = request.Fitment;
            existing.Notes = request.Notes;

            await _repository.UpdatePartFitmentAsync(existing);
            return existing.ToDto();
        }

        public async Task<PartFitmentResponse> DeletePartFitmentAsync(long id)
        {
            var entity = await _repository.GetPartFitmentByIdAsync(id) ?? throw new NotFoundException("PartFitment with ID " + id + " not found.");
            await _repository.DeletePartFitmentAsync(entity);
            return entity.ToDto();
        }
    }
}
