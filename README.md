# OnlineMarketsSpecFlowTests

The project will allow to test the websites of stores with various products, excluding manual testing, which takes a huge amount of time.

The tests contain a product search through the search field and adding it to the basket. But the main point of this test is to check the existence of the product in the basket.

Code is clean and easy to understand by keeping tests and element locators separated. This was done thanks to the Page Object Model pattern.

SeleniumWebDriver was used for browser UI interaction.

## Getting started

Download and Install:

1. .Net 5.0
2. Chrome Browser v.94
3. Visual Studio 2019 (or VS Code or Rider)

Note: In this project the Chrome browser of 94.0.4606.81 version was used together with Selenium.WebDriver.ChromeDriver v.94.0.4606.6100 for running test scripts.

If you have another version of the Chrome browser installed, you need to download the corresponding version of Selenium.WebDriver.ChromeDriver.

## How to use
1. Clone this framework into your local directory with comand:

`$ git clone https://github.com/VlasovAlexei/OnlineMarketsSpecFlowTests.git`

2. Open the project in Visual Studio.

3. To run the tests, go to Test Explorer and select the necessary tests.

## Results 

Test results of four shop sites:

• [DNS](https://github.com/VlasovAlexei/OnlineMarketsSpecFlowTests/blob/master/TestsResults/DNSTestBuy.gif)

• [Wildberries](https://github.com/VlasovAlexei/OnlineMarketsSpecFlowTests/blob/master/TestsResults/WildberriesTestBuy.gif)

• [Eldorado](https://github.com/VlasovAlexei/OnlineMarketsSpecFlowTests/blob/master/TestsResults/EldoradoTestBuy.gif)

• [Citilink](https://github.com/VlasovAlexei/OnlineMarketsSpecFlowTests/blob/master/TestsResults/CitilinkTestBuy.gif)

---
**This project was created by:**

- https://github.com/VlasovAlexei
- https://github.com/VlasovAndr

**Resources**
- [Selenium](http://www.seleniumhq.org/)
- [SpecFlow](http://specflow.org/)
- [SpecFlow Documentation](https://docs.specflow.org/)
