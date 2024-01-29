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

        [Then("��� ������ ������� BuildRequestUri ������� ���� (.*)")]
        public void Then����������������BuildRequestUri�����������(string expected)
        {
            string ?_date = _scenarioContext["date"].ToString();
            string _result = WeatherParseHelper.BuildRequestUri(_date);
            Assert.AreEqual(expected, _result, "�������� ��������� ���� ���������");
        }

        [Then("��� ������ ������� ParseRawContent ������� ����������� (.*)")]
        public void Then����������������ParseRawContent������������������(string expected)
        {
            string ?_jsonFromServer = _scenarioContext["jsonFromServer"].ToString();
            string _result = WeatherParseHelper.ParseRawContent(_jsonFromServer);
            Assert.AreEqual(expected, _result, "�������� �������� json � ����������� ���������");
        }

        [Then("��� ������ ������� ParseRawContent ������� ������")]
        public void Then����������������ParseRawContent�������������()
        {
            string? _jsonFromServer = _scenarioContext["jsonFromServer"].ToString();
            Assert.Throws<ArgumentOutOfRangeException>(() => WeatherParseHelper.ParseRawContent(_jsonFromServer));
        }

        [Then("��� ������ ������� ParseContentAsMoscowWeather ������� ����������� (.*)")]
        public void Then����������������ParseContentAsMoscowWeather������������������(string expected)
        {
            string ?_date = _scenarioContext["date"].ToString();
            string ?_jsonFromServer = _scenarioContext["jsonFromServer"].ToString();
            WeatherParser parser = new(_date);
            string _result = parser.ParseContentAsMoscowWeather(_jsonFromServer);
            Assert.AreEqual(expected, _result, "�������� �������� json � ����������� � ������ ���������");
        }

        [Then("��� ������ ������� ParseContentAsMoscowWeather ������� ������")]
        public void Then����������������ParseContentAsMoscowWeather�������������()
        {
            string? _date = _scenarioContext["date"].ToString();
            string? _jsonFromServer = _scenarioContext["jsonFromServer"].ToString();
            WeatherParser parser = new(_date);
            Assert.Throws<JsonReaderException>(() => parser.ParseContentAsMoscowWeather(_jsonFromServer));
        }

    }
}
