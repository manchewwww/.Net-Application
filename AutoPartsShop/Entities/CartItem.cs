namespace AutoPartsShop.Entities
{
    public class CartItemEntity
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int PartId { get; set; }
        public int Quantity { get; set; }
    }
}