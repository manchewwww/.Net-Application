namespace AutoPartsShop.Dtos
{
    public record CategoryCreateRequest(long? ParentCategoryId, string Name, string Slug);

    public record CategoryUpdateRequest(long? ParentCategoryId, string Name, string Slug);

    public record CategoryResponse(long Id, long? ParentCategoryId, string Name, string Slug);
}
