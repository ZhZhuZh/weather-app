using FirstApp.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace FirstApp.Cmd;

[Route("api/weather")]
[ApiController]
[Authorize]
public class Controller : ControllerBase
{
    private readonly Context _context;

    public Controller(Context context)
    {
        _context = context;
    }

    [HttpGet("MoskowWeather")]
    public async Task<ActionResult<string>> GetMoscowWeather([FromQuery] string date)
    {
        using HttpClient client = new();

        string response = await client.GetStringAsync($"https://archive-api.open-meteo.com/v1/archive?latitude=55.7522&longitude=37.6156&start_date={date}&end_date={date}&hourly=temperature_2m&timezone=Europe%2FMoscow");
        JObject joResponse = JObject.Parse(response);
        JObject? ojObject = (JObject?)joResponse["hourly"]; 
        JArray? array = (JArray?)ojObject?["temperature_2m"];
        string temperature = (array?[0].ToString() ?? "0") + "°C";

        return temperature;
    }

    [HttpGet("SaveMoskowWeather")]
    public async Task<ActionResult<MoscowWeatherByDate>> AddMoscowWeather([FromQuery] string date)
    {
        MoscowWeatherByDate weather = new MoscowWeatherByDate(date, GetWeatherDataAndParse(date).Result);
        await _context.MoscowWeatherByDate.AddAsync(weather);
        await _context.SaveChangesAsync();
        return weather;
    }

    private async Task<string> GetWeatherDataAndParse(string date)
    {
        using HttpClient client = new();

        string response = await client.GetStringAsync($"https://archive-api.open-meteo.com/v1/archive?latitude=55.7522&longitude=37.6156&start_date={date}&end_date={date}&hourly=temperature_2m&timezone=Europe%2FMoscow");

        JObject joResponse = JObject.Parse(response);
        JObject? ojObject = (JObject?)joResponse["hourly"];
        JArray? array = (JArray?)ojObject?["temperature_2m"];
        string temperature = (array?[0].ToString() ?? "0");

        return temperature;
    }
}
