namespace FirstApp.Cmd
{
    public interface IWeatherHandler
    {
        Task<string> GetMoscowWeather(string date);
        Task<MoscowWeatherByDate> SaveMoscowWeather(string date);
    }
}
