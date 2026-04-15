Feature: Add product to cart in SauceDemo

Scenario: Successful add product to cart
    Given I am logged on SaudeDemo
    When I select a product to add the cart
	Then I should see the cart quantity according to the products added