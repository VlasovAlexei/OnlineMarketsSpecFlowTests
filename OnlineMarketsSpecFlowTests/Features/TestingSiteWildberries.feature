@ConfigFiles\\WILDBERRIES.json
Feature: TestingSiteWildberries

Scenario: BuyOfOneProduct
	Given I navigate to the website start page
	When I enter text 'iphone 11' to search field and press Enter on the start page
	And I click on first product in the search results on the product list page
	And I get product name from product details page and put it in scenario context by name 'productNameFromDetailsPage'
	And I click on buy button on the product details page
	And I click on basket button on the product details page
	And I get product name from basket page and put it in scenario context by name 'productNameFromBasketPage'
	Then I validate count of products in basket is '1'
	Then I validate equality of two scenario context values by keys: 'productNameFromDetailsPage' and 'productNameFromBasketPage'
