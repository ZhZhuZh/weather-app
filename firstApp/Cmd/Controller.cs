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

    [HttpGet("MoskowWeather")]
    public async Task<ActionResult<string>> MoscowWeather([FromQuery] string date, IWeatherHandler weatherHandler)
    {
        return await weatherHandler.GetMoscowWeather(date);
    }

    [HttpGet("SaveMoskowWeather")]
    public async Task<ActionResult<MoscowWeatherByDate>> AddMoscowWeather([FromQuery] string date, IWeatherHandler weatherHandler)
    {
        return await weatherHandler.SaveMoscowWeather(date);
    }
    
}
