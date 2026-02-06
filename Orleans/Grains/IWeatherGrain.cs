namespace Orleans.Grains
{
    public interface IWeatherGrain : IGrainWithStringKey
    {
        Task<string> GetWeatherAsync();
    }
}