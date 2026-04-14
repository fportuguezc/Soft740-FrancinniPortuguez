Feature: Login in SauceDemo

 Scenario: Successful login with valid credentials
   Given I am on the login page
   When I fill the login form with user "standard_user" and password "secret_sauce"
   And I click the login button
   Then I should see the "Cart" button

 Scenario: Failed login with invalid credentials
   Given I am on the login page
   When I fill the login form with user "noValid_user" and password "secret_sauce"
   And I click the login button
   Then I should see the error message "Epic sadface: Username and password do not match any user in this service"