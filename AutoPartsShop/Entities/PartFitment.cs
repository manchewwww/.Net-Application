using AutoPartsShop.Enums;

namespace AutoPartsShop.Entities
{
    public class PartFitmentEntity
    {
        public int Id { get; set; }
        public int TrimId { get; set; }
        public FitmentType FitmentType { get; set; }
        public string[] Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}