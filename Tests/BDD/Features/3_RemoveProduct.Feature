Feature: Remove product from cart in SauceDemo

Scenario: Successful remove product from cart
    Given I am logged on SaudeDemo
    When I select the product to add the cart
    Then I should see the product added to the cart
    When I select the product to remove from the cart
    Then I should not see the product removed from the cart    