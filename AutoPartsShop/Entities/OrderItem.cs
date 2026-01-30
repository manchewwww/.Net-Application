namespace AutoPartsShop.Entities
{
    public class OrderItemEntity(int id, int orderId, int partId, string sku, string name, int quantity, decimal unitPrice, decimal totalPrice)
    {
        public int Id { get; set; } = id;
        public int OrderId { get; set; } = orderId;
        public int PartId { get; set; } = partId;
        public string Sku { get; set; } = sku;
        public string Name { get; set; } = name;
        public int Quantity { get; set; } = quantity;
        public decimal UnitPrice { get; set; } = unitPrice;
        public decimal TotalPrice { get; set; } = totalPrice;
    }
}