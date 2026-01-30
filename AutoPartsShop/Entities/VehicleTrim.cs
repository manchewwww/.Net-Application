namespace AutoPartsShop.Entities
{
    public class VehicleTrimEntity(int id, int modelId, DateTime yearFrom, DateTime yearTo, string engineCode, string displacement, string? fuelType, string? bodyType,
     string[] notes, DateTime createdAt, DateTime updatedAt)
    {
        public int Id { get; set; } = id;
        public int ModelId { get; set; } = modelId;
        public DateTime YearFrom { get; set; } = yearFrom;
        public DateTime YearTo { get; set; } = yearTo;
        public string EngineCode { get; set; } = engineCode;
        public string Displacement { get; set; } = displacement;
        public string? FuelType { get; set; } = fuelType;
        public string? BodyType { get; set; } = bodyType;
        public string[] Notes { get; set; } = notes;
        public DateTime CreatedAt { get; set; } = createdAt;
        public DateTime UpdatedAt { get; set; } = updatedAt;
    };
}