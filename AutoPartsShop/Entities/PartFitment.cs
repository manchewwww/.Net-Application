using AutoPartsShop.Enums;

namespace AutoPartsShop.Entities
{
    public class PartFitment(int id, int trimId, FitmentType fitmentType, string[] notes, DateTime createdAt, DateTime updatedAt)
    {
        public int Id { get; set; } = id;
        public int TrimId { get; set; } = trimId;
        public FitmentType FitmentType { get; set; } = fitmentType;
        public string[] Notes { get; set; } = notes;
        public DateTime CreatedAt { get; set; } = createdAt;
        public DateTime UpdatedAt { get; set; } = updatedAt;
    }
}