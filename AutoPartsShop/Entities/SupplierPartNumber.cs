using AutoPartsShop.Enums;

namespace AutoPartsShop.Entities
{
    public class SupplierPartNumberEntity
    {
        public long Id { get; set; }
        public long SupplierPartId { get; set; }
        public PartNumberType Type { get; set; }
        public string Value { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
