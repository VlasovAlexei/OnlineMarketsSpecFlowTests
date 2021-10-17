using TechTalk.SpecFlow;
using OnlineMarketsSpecFlowTests.Hooks;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium;
using Xunit;
using System.Threading;

namespace OnlineMarketsSpecFlowTests.Steps
{
    [Binding]
    public class BuyProduct
    {
        private DriverHelper _driverHelper;
        private Website website;
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;
        private WebDriverWait wait;

        public BuyProduct(DriverHelper driverHelper, ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _driverHelper = driverHelper;
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
            var tagInfo = _featureContext.FeatureInfo.Tags.First();
            website = (Website)_featureContext[tagInfo];
            wait = new WebDriverWait(driverHelper.Driver, TimeSpan.FromSeconds(10));
        }

        [Given(@"I navigate to the website start page")]
        public void GivenINavigateToTheWebsiteStartPage()
        {
            _driverHelper.Driver.Navigate().GoToUrl(website.Url);
        }

        [When(@"I enter text '(.*)' to search field and press Enter")]
        public void WhenIEnterTextToSearchFieldAndPressEnter(string itemForSearch)
        {
            var searchField = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(website.Pages.StartPage.SearchField)));
            searchField.Clear();
            searchField.SendKeys(itemForSearch + Keys.Enter);
        }

        [When(@"I click on first product in the search results on the product list page")]
        public void WhenIClickOnFirstProductInTheSearchResultsOnTheProductListPage()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(website.Pages.ProductListPage.SelectedItem))).Click();
        }

        [When(@"I get product name from product details page and put it in scenario context by name '(.*)'")]
        public void WhenIGetProductNameFromProductDetailsPageAndPutItInScenarioContextByName(string _expectedResult)
        {
            var expectedResult = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(website.Pages.ProductDetailsPage.NameOfItem)));
            var expectedResultFormated = expectedResult.Text.ToLower().Replace(",", string.Empty);
            _scenarioContext[_expectedResult] = expectedResultFormated;
        }

        [When(@"I click on buy button on the product details page")]

        public void WhenIClickOnBuyButtonOnTheProductDetailsPage()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(website.Pages.ProductDetailsPage.AddToBasketButton))).Click();
        }

        [When(@"I click on basket button on the product details page")]
        public void WhenIClickOnBasketButtonOnTheProductDetailsPage()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(website.Pages.ProductDetailsPage.BasketButton))).Click();
        }

        [When(@"I get product name from basket page and put it in scenario context by name '(.*)'")]
        public void WhenIGetProductNameFromBasketPageAndPutItInScenarioContextByName(string _actualResult)
        {
            var actualResult = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(website.Pages.BasketPage.NameOfItem)));
            var actualResultFormated = actualResult.Text.ToLower().Replace(",", string.Empty);
            _scenarioContext[_actualResult] = actualResultFormated;
        }

        [Then(@"I validate count of products in basket is '(.*)'")]
        public void ThenIValidateCountOfProductsInBasketIs(int expectedCount)
        {
            var actualCount = _driverHelper.Driver.FindElements(By.XPath(website.Pages.BasketPage.NameOfItem)).Count;
            Assert.Equal(expectedCount, actualCount);
        }

        [Then(@"I validate equality of two scenario context values by keys: '(.*)' and '(.*)'")]
        public void ThenIValidateEqualityOfTwoScenarioContextValuesByKeysAnd(string _expectedResult, string _actualResult)
        {
            var expectedResult = (string)_scenarioContext[_expectedResult];
            var actualResult = (string)_scenarioContext[_actualResult];
            Assert.Contains(expectedResult, actualResult);
        }

        [When(@"I'm waiting ""(.*)"" milliseconds")]
        public void WhenIMWaitingMillisecondsForThePageToBecomeStatic(int timeWaiting)
        {
            Thread.Sleep(timeWaiting);
        }
    }
}