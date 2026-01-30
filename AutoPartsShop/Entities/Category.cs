namespace AutoPartsShop.Entities
{
	public class CategoryEntity
	{
		public int Id { get; set; }
		public int ParentId { get; set; }
		public required string Name { get; set; }
		public required string Slug { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	};
}