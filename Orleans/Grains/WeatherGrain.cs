namespace Orleans.Grains
{
    public class WeatherGrain : Grain, IWeatherGrain
    {
        public Task<string> GetWeatherAsync()
        {
            return Task.FromResult("The current weather is sunny with a high of 25°C.");
        }
    }
}