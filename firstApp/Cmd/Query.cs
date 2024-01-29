using HotChocolate.Authorization;

namespace FirstApp.Cmd
{
    public class Query
    {
        public async Task<string> MoskowWeather([Service] IWeatherHandler weatherHandler, string date) => 
            await weatherHandler.GetMoscowWeather(date);
    }
}
