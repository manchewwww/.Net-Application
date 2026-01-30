namespace AutoPartsShop.Entities
{
	public class BrandEntity
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string Country { get; set; } = null!;
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	};
}