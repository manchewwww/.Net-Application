namespace Repositories
{
    public class PartRepository
    {
        private static readonly List<PartDto> parts = new();

        public PartDto Add(PartDto part)
        {
            parts.Add(part);
            return part;
        }

        public List<PartDto> GetAll()
        {
            return parts;
        }

        public PartDto? GetById(int id)
        {
            return parts.FirstOrDefault(part => part.Id == id);
        }

        public PartDto? Update(PartDto updatedPart)
        {
            var index = parts.FindIndex(p => p.Id == updatedPart.Id);
            if (index < 0)
            {
                return null;
            }
            parts[index] = updatedPart;
            return updatedPart;
        }

        public PartDto? Delete(int id)
        {
            var existing = parts.FirstOrDefault(p => p.Id == id);
            if (existing != null)
            {
                parts.Remove(existing);
            }
            return existing;
        }
    }
}
