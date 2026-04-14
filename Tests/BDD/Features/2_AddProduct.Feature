Feature: Add product to cart in SauceDemo

Scenario: Successful add product to cart
    Given I am logged on SaudeDemo
    When I select the product to add the cart
    Then I should see the product added to the cart    