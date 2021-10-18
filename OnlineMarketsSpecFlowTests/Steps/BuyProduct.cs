using TechTalk.SpecFlow;
using OnlineMarketsSpecFlowTests.Hooks;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium;
using Xunit;
using System.Threading;
using System.Collections.Generic;

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

        [Given(@"I create list of '(.*)' and put it in scenario context")]
        public void GivenICreateListOfAndPutItInScenarioContext(string _collection)
        {
            var itemList = new List<string>();
            _scenarioContext[_collection] = itemList;
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

        [When(@"I'm waiting ""(.*)"" milliseconds")]
        public void WhenIMWaitingMillisecondsForThePageToBecomeStatic(int timeWaiting)
        {
            Thread.Sleep(timeWaiting);
        }

        [When(@"I get product name from product details page and add it in '(.*)' list")]
        public void WhenIGetProductNameFromProductDetailsPageAndAddItInList(string _collection)
        {
            var selectedItem = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(website.Pages.ProductDetailsPage.NameOfItem)));
            var selectedItemFormated = selectedItem.Text.ToLower().Replace(",", string.Empty);
            var selectedItemList = (List<string>)_scenarioContext[_collection];
            selectedItemList.Add(selectedItemFormated);
        }

        [When(@"I get product name from basket page and add it in '(.*)' and put it in scenario context")]
        public void WhenIGetProductNameFromBasketPageAndAddItInAndPutItInScenarioContext(string _collection)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(website.Pages.BasketPage.NameOfItem)));
            var basketItems = _driverHelper.Driver.FindElements(By.XPath(website.Pages.BasketPage.NameOfItem));
            var basketItemList = (List<string>)_scenarioContext[_collection];

            foreach (var basketItem in basketItems)
            {
                var basketItemFormated = basketItem.Text.ToLower().Replace(",", string.Empty);
                basketItemList.Add(basketItemFormated);
            }
        }

        [Then(@"I validate equality of two scenario context list by keys: '(.*)' and '(.*)'")]
        public void ThenIValidateEqualityOfTwoScenarioContextListByKeysAnd(string _expectedResult, string _actualResult)
        {
            var basketItemList = (List<string>)_scenarioContext[_expectedResult];
            var selectedItemList = (List<string>)_scenarioContext[_actualResult];
            List<string> selectedItemListReverse = selectedItemList.GetRange(0, selectedItemList.Count);
            selectedItemListReverse.Reverse();
            bool selectedItemInBasket = (basketItemList.SequenceEqual(selectedItemList) || (basketItemList.SequenceEqual(selectedItemListReverse)));
            Assert.True(selectedItemInBasket);
        }

        [Then(@"I validate count of products in basket is '(.*)'")]
        public void ThenIValidateCountOfProductsInBasketIsEqual(int expectedCount)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(website.Pages.BasketPage.NameOfItem)));
            var actualCount = _driverHelper.Driver.FindElements(By.XPath(website.Pages.BasketPage.NameOfItem)).Count;
            Assert.Equal(expectedCount, actualCount);
        }
    }
}