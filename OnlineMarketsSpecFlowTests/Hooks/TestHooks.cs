using Newtonsoft.Json;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Linq;
using TechTalk.SpecFlow;

namespace OnlineMarketsSpecFlowTests.Hooks
{
    [Binding]
    public class TestHooks
    {
        private DriverHelper _driverHelper;
        private readonly FeatureContext _featureContext;

        public TestHooks(DriverHelper driverHelper, FeatureContext featureContext)
        {
            _driverHelper = driverHelper;
            _featureContext = featureContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var tagInfo = _featureContext.FeatureInfo.Tags.First();
            Website configElements = JsonConvert.DeserializeObject<Website>(File.ReadAllText(tagInfo));
            _featureContext[tagInfo] = configElements;

            ChromeOptions option = new ChromeOptions();
            option.AddArguments("start-maximized");
            option.AddArguments("--disable-notifications");
            _driverHelper.Driver = new ChromeDriver(option);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driverHelper.Driver.Quit();
        }
    }
}