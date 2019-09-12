Feature: Shopping_Cart
	As a customer I want to be able to
	a)Filter products
	b)Sort products
	c)Add to cart products
	d)See products in cart

@0001
Scenario: Add products to cart
	Given I see desired webshop https://www.elkor.lv
	When I select desired product group and sort products by price
	Then I see products in descending order
	When I Add to cart 2 products
	Then I see 2 desired products in cart
	And I empty my shopping cart