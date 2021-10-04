@ConfigFiles\\DNS.json
Feature: TestingSiteDNS

Scenario: BuyOfOneProduct
	Given I navigate to the website start page
	When I click on search field and enter the product to search "iPhone 11" on the start page
	And I click on first product in the search results on the product list page
	And I get product name from product details page and put it in scenario context by name 'productNameFromDetailsPage'
	And I click on buy button on the product details page
	And I click on basket button on the product details page
	And I get product name from basket page and put it in scenario context by name 'productNameFromBasketPage'