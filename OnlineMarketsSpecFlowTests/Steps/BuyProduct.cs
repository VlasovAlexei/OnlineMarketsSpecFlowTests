using TechTalk.SpecFlow;
using OnlineMarketsSpecFlowTests.Hooks;

namespace OnlineMarketsSpecFlowTests.Steps
{
    [Binding]
    public class BuyProduct
    {
        private DriverHelper _driverHelper;

        public BuyProduct(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
        }
    }
}