namespace AutoPartsShop.Entities
{
    public class CartItem(int id, int cartId, int partId, int quantity)
    {
        public int Id { get; set; } = id;
        public int CartId { get; set; } = cartId;
        public int PartId { get; set; } = partId;
        public int Quantity { get; set; } = quantity;
    }
}