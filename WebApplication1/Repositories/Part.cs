using WebApplication1.Dtos;

namespace WebApplication1.Repositories
{
    public class PartRepository
    {
        private static readonly int nextId = 1;
        private static readonly List<PartDto> parts = [];

        public static PartDto Add(PartDto part)
        {
            part.Id = nextId++;
            parts.Add(part);
            return part;
        }

        public static List<PartDto> GetAll()
        {
            return parts;
        }

        public static PartDto? GetById(int id)
        {
            return parts.FirstOrDefault(part => part.Id == id);
        }

        public static PartDto? Update(PartDto updatedPart)
        {
            var index = parts.FindIndex(p => p.Id == updatedPart.Id);
            if (index < 0)
            {
                return null;
            }
            parts[index] = updatedPart;
            return updatedPart;
        }

        public static PartDto? Delete(int id)
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
