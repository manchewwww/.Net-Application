namespace AutoPartsShop.Entities
{
    public class PartSupplierLinkEntity
    {
        public long PartId { get; set; }
        public long SupplierPartId { get; set; }
        public int Priority { get; set; } = 1;
        public bool IsPrimary { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
