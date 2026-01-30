using AutoPartsShop.Enums;

namespace AutoPartsShop.Entities
{
    public class PartNumberEntity
    {
        public long Id { get; set; }
        public long PartId { get; set; }
        public PartNumberType Type { get; set; }
        public string Value { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
