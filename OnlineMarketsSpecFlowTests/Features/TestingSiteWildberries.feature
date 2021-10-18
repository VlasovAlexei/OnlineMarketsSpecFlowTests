@ConfigFiles\\WILDBERRIES.json
Feature: TestingSiteWildberries

Scenario: BuyOfOneProduct
	Given I navigate to the website start page
	And I create list of 'selectedItems' and put it in scenario context
	And I create list of 'ItemsInBasket' and put it in scenario context
	When I enter text 'iphone 11' to search field and press Enter
	And I click on first product in the search results on the product list page
	And I get product name from product details page and add it in 'selectedItems' list
	And I click on buy button on the product details page
	And I click on basket button on the product details page
	And I get product name from basket page and add it in 'ItemsInBasket' and put it in scenario context
	Then I validate count of products in basket is '1'
	Then I validate equality of two scenario context list by keys: 'ItemsInBasket' and 'selectedItems'