namespace FirstApp.Cmd
{
    public class WeatherSaver
    {
        private readonly string _date;

        public WeatherSaver(string date)
        {
            _date = date;
        }

        public string RequestUri => WeatherParseHelper.BuildRequestUri(_date);

        public MoscowWeatherByDate MapContentToView(string content)
        {
            return new MoscowWeatherByDate(_date, WeatherParseHelper.ParseRawContent(content));
        }
    }
}
