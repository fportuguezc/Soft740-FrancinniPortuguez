Feature: Sorted process in SauceDemo

Scenario: Successful sorted low to high by products price
    Given I am logged on SaudeDemo
    When I select the price low to high order option
    Then I should see the products ordered by price low to high