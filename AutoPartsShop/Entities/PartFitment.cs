using AutoPartsShop.Enums;

namespace AutoPartsShop.Entities
{
    public class PartFitmentEntity
    {
        public long Id { get; set; }
        public long PartId { get; set; }
        public long VariantId { get; set; }
        public FitmentType Fitment { get; set; } = FitmentType.DIRECT_FIT;
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
