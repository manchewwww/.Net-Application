namespace AutoPartsShop.Entities.Catalog
{
	public class CategoryEntity(int id, int parentId, string name, string slug, DateTime createdAt, DateTime updatedAt)
	{
		public int Id { get; set; } = id;
		public int ParentId { get; set; } = parentId;
		public string Name { get; set; } = name;
		public string Slug { get; set; } = slug;
		public DateTime CreatedAt { get; set; } = createdAt;
		public DateTime UpdatedAt { get; set; } = updatedAt;
	};
}