namespace AutoPartsShop.Entities
{
	public class CategoryEntity
	{
		public int Id { get; set; }
		public int ParentId { get; set; }
		public string Name { get; set; }
		public string Slug { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	};
}