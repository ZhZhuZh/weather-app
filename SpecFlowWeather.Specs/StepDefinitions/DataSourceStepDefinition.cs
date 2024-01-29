using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowWeather.Specs.StepDefinitions
{
    [Binding]
    public class DataSourceStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;

        public DataSourceStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("json ответ сервера (.*)")]
        public void WhenJsonОтветСервера(string jsonFromServer)
        {
            _scenarioContext["jsonFromServer"] = jsonFromServer; 
        }

        [Given("дата (.*)")]
        public void GivenDateIs(string date)
        {
            _scenarioContext["date"] = date;
        }
    }
}
