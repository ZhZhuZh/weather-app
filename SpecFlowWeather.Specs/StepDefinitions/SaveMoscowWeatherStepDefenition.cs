using FirstApp.Cmd;
using NUnit.Framework;

namespace SpecFlowWeather.Specs.StepDefinitions
{
    [Binding]
    public class SaveMoscowWeatherStepDefenition
    {
        private readonly ScenarioContext _scenarioContext;
        private string? _date;
        private string? _jsonFromServer;

        public SaveMoscowWeatherStepDefenition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _jsonFromServer = _scenarioContext["jsonFromServer"].ToString();
            _date = _scenarioContext["date"].ToString();
        }

        [Then("при вызове команды MapContentToView получаю сущность")]
        public void ThenПриВызовеКомандыMapContentToViewПолучаюСущность(Table table)
        {
            TableRow row = table.Rows[0];
            WeatherSaver _weatherSaver = new(_date);
            MoscowWeatherByDate _result = _weatherSaver.MapContentToView(_jsonFromServer);
            Assert.IsNotNull(_result);

            Assert.AreEqual(row["Date"], _result.Date);
            Assert.AreEqual(row["Temperature"], _result.Temperature);
        }
    }
}
