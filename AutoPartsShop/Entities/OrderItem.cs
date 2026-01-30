namespace AutoPartsShop.Entities
{

    public class OrderItemEntity
    {

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PartId { get; set; }
        public string Sku { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}