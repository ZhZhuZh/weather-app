using FirstApp.Cmd;
using Newtonsoft.Json;
using NUnit.Framework;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;

namespace SpecFlowWeather.Specs.StepDefinitions
{
    [Binding]
    public sealed class MoscowWeatherStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public MoscowWeatherStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Then("при вызове команды BuildRequestUri получаю путь (.*)")]
        public void ThenПриВызовеКомандыBuildRequestUriПолучаюПуть(string expected)
        {
            string ?_date = _scenarioContext["date"].ToString();
            string _result = WeatherParseHelper.BuildRequestUri(_date);
            Assert.AreEqual(expected, _result, "Проверка получения пути провалена");
        }

        [Then("при вызове команды ParseRawContent получаю температуру (.*)")]
        public void ThenПриВызовеКомандыParseRawContentПолучаюТемпературу(string expected)
        {
            string ?_jsonFromServer = _scenarioContext["jsonFromServer"].ToString();
            string _result = WeatherParseHelper.ParseRawContent(_jsonFromServer);
            Assert.AreEqual(expected, _result, "Проверка парсинга json в температуру провалена");
        }

        [Then("при вызове команды ParseRawContent получаю ошибку")]
        public void ThenПриВызовеКомандыParseRawContentПолучаюОшибку()
        {
            string? _jsonFromServer = _scenarioContext["jsonFromServer"].ToString();
            Assert.Throws<ArgumentOutOfRangeException>(() => WeatherParseHelper.ParseRawContent(_jsonFromServer));
        }

        [Then("при вызове команды ParseContentAsMoscowWeather получаю температуру (.*)")]
        public void ThenПриВызовеКомандыParseContentAsMoscowWeatherПолучаюТемпературу(string expected)
        {
            string ?_date = _scenarioContext["date"].ToString();
            string ?_jsonFromServer = _scenarioContext["jsonFromServer"].ToString();
            WeatherParser parser = new(_date);
            string _result = parser.ParseContentAsMoscowWeather(_jsonFromServer);
            Assert.AreEqual(expected, _result, "Проверка парсинга json в температуру в Москве провалена");
        }

        [Then("при вызове команды ParseContentAsMoscowWeather получаю ошибку")]
        public void ThenПриВызовеКомандыParseContentAsMoscowWeatherПолучаюОшибку()
        {
            string? _date = _scenarioContext["date"].ToString();
            string? _jsonFromServer = _scenarioContext["jsonFromServer"].ToString();
            WeatherParser parser = new(_date);
            Assert.Throws<JsonReaderException>(() => parser.ParseContentAsMoscowWeather(_jsonFromServer));
        }

    }
}
