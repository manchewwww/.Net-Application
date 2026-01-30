namespace AutoPartsShop.Entities
{
    public class VehicleVariantEntity
    {
        public long Id { get; set; }
        public long ModelId { get; set; }
        public int YearFrom { get; set; }
        public int YearTo { get; set; }
        public string? EngineCode { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
