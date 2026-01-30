namespace AutoPartsShop.Entities.Catalog
{
	public class BrandEntity(int id, string name, string country, DateTime createdAt, DateTime updatedAt)
	{
		public int Id { get; set; } = id;
		public string Name { get; set; } = name;
		public string Country { get; set; } = country;
		public DateTime CreatedAt { get; set; } = createdAt;
		public DateTime UpdatedAt { get; set; } = updatedAt;
	};
}