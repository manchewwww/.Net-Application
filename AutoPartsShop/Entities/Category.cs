namespace AutoPartsShop.Entities
{
	public class CategoryEntity
	{
		public int Id { get; set; }
		public int ParentId { get; set; }
		public string Name { get; set; } = null!;
		public string Slug { get; set; } = null!;
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	};
}