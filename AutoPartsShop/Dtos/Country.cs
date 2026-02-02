namespace AutoPartsShop.Dtos
{
    public record CountryCreateRequest(string Name, string Code);

    public record CountryUpdateRequest(string Name, string Code);

    public record CountryResponse(long Id, string Name, string Code);
}