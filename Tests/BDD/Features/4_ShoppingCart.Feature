Feature: Checkout process in SauceDemo

Scenario: Successful checkout process with valid data 
    Given I am logged on SaudeDemo
	When I select a product to add the cart
	Then I should see the cart quantity according to the products added
	When I click the cart button
	Then I should see the products added to the cart
    When I click the checkout button
    And I fill the checkout form with firstname "Fran" lastname "Portuguez" and zipcode "123456"
    And I click the continue button
    And I click the finish button
    Then I should see the checkout success message

Scenario: Failed checkout process with invalid data 
    Given I am logged on SaudeDemo
	When I select a product to add the cart
	Then I should see the cart quantity according to the products added
	When I click the cart button
	Then I should see the products added to the cart
    When I click the checkout button
    And I fill the checkout form with firstname "Fran" lastname "Portuguez" and zipcode ""
    And I click the continue button
    Then I should see the checkout error message