namespace FirstApp.Cmd
{
    public class WeatherParser
    {
        private readonly string _date;

        public WeatherParser(string date)
        {
            _date = date;
        }

        public string RequestUri => WeatherParseHelper.BuildRequestUri(_date);

        public string ParseContentAsMoscowWeather(string content)
        {
            return WeatherParseHelper.ParseRawContent(content) + "°C";
        }
    }
}
