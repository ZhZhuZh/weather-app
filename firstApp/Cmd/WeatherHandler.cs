
using FirstApp.Infrastructure;
using Newtonsoft.Json.Linq;

namespace FirstApp.Cmd;



public class WeatherHandler : IWeatherHandler
{
    private static readonly HttpClient s_client = new();
    private readonly Context _context;

    public WeatherHandler(Context context)
    {
        _context = context;
    }

    public async Task<string> GetMoscowWeather(string date)
    {
        WeatherParser parser = new(date);

        string response = await s_client.GetStringAsync(parser.RequestUri);

        return parser.ParseContentAsMoscowWeather(response);
    }

    public async Task<MoscowWeatherByDate> SaveMoscowWeather(string date)
    {
        WeatherSaver saver = new(date);

        string response = await s_client.GetStringAsync(saver.RequestUri);

        MoscowWeatherByDate entity = saver.MapContentToView(response);
        
        await _context.MoscowWeatherByDate.AddAsync(entity);
        await _context.SaveChangesAsync();
        
        return entity;
    }
}
