using HotChocolate.Authorization;

namespace FirstApp.Cmd
{
    public class Mutation
    {
        public async Task<MoscowWeatherByDate> SaveMoscowWeather([Service] IWeatherHandler weatherHandler, string date) =>
            await weatherHandler.SaveMoscowWeather(date);
    }
}
