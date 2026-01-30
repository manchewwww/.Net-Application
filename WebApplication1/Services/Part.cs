using WebApplication1.Dtos;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class PartService(PartRepository repository)
    {
        private readonly PartRepository partRepository = repository;

        public PartDto AddPart(PartDto part)
        {
            return partRepository.Add(part);
        }

        public List<PartDto> GetAllParts()
        {
            return partRepository.GetAll();
        }

        public PartDto? GetPartById(int id)
        {
            return partRepository.GetById(id);
        }

        public PartDto? UpdatePart(PartDto part)
        {
            return partRepository.Update(part);
        }

        public PartDto? DeletePart(int id)
        {
            return partRepository.Delete(id);
        }
    }
}
