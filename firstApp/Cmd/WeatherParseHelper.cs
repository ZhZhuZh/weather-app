using Newtonsoft.Json.Linq;

namespace FirstApp.Cmd
{
    public class WeatherParseHelper
    {
        public static string ParseRawContent(string content)
        {
            Console.WriteLine(content);
            JObject joResponse = JObject.Parse(content);
            JObject? ojObject = (JObject?)joResponse["hourly"];
            JArray? array = (JArray?)ojObject?["temperature_2m"];
            string temperature = array?[0].ToString() ?? "0";

            return temperature;
        }

        public static string BuildRequestUri(string date)
        {
            return $"https://archive-api.open-meteo.com/v1/archive?latitude=55.7522&longitude=37.6156&start_date={date}&end_date={date}&hourly=temperature_2m&timezone=Europe%2FMoscow";
        }
    }
}
