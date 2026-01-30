namespace AutoPartsShop.Entities
{
	public class BrandEntity
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public required string Country { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	};
}