﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SpecFlowWeather.Specs.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Сохранение температуры в Москве за определенную дату")]
    public partial class СохранениеТемпературыВМосквеЗаОпределеннуюДатуFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "SaveMoscowWeather.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("ru-RU"), "Features", "Сохранение температуры в Москве за определенную дату", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Получить сущность для сохранения из даты и json ответа от сервера")]
        public virtual void ПолучитьСущностьДляСохраненияИзДатыИJsonОтветаОтСервера()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Получить сущность для сохранения из даты и json ответа от сервера", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 3
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
 testRunner.Given(@"json ответ сервера {""latitude"":55.782074,""longitude"":37.576374,""generationtime_ms"":0.04398822784423828,""utc_offset_seconds"":10800,""timezone"":""Europe/Moscow"",""timezone_abbreviation"":""MSK"",""elevation"":141.0,""hourly_units"":{""time"":""iso8601"",""temperature_2m"":""°C""},""hourly"":{""time"":[""2021-10-10T00:00"",""2021-10-10T01:00"",""2021-10-10T02:00"",""2021-10-10T03:00"",""2021-10-10T04:00"",""2021-10-10T05:00"",""2021-10-10T06:00"",""2021-10-10T07:00"",""2021-10-10T08:00"",""2021-10-10T09:00"",""2021-10-10T10:00"",""2021-10-10T11:00"",""2021-10-10T12:00"",""2021-10-10T13:00"",""2021-10-10T14:00"",""2021-10-10T15:00"",""2021-10-10T16:00"",""2021-10-10T17:00"",""2021-10-10T18:00"",""2021-10-10T19:00"",""2021-10-10T20:00"",""2021-10-10T21:00"",""2021-10-10T22:00"",""2021-10-10T23:00""],""temperature_2m"":[1.1,0.7,0.5,0.7,0.2,0.5,0.9,1.3,2.4,4.2,6.1,8.2,9.7,10.9,11.6,13.2,12.6,9.5,6.6,5.6,4.5,3.6,2.9,2.2]}}", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Дано ");
#line hidden
#line 5
 testRunner.Given("дата 2020-10-10", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Дано ");
#line hidden
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "Temperature",
                            "Date"});
                table1.AddRow(new string[] {
                            "1,1",
                            "2020-10-10"});
#line 6
 testRunner.Then("при вызове команды MapContentToView получаю сущность", ((string)(null)), table1, "То ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
