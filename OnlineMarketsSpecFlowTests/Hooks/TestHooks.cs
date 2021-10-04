using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;


namespace OnlineMarketsSpecFlowTests.Hooks
{
    [Binding]
    public class TestHooks
    {
        private DriverHelper _driverHelper;

        public TestHooks(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
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