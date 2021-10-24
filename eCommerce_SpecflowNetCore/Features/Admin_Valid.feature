Feature: eCom Admin Account Login: Valid Credentails

@smoke
Scenario: Successful Login with valid credentials
	Given User opens URL "https://admin-demo.nopcommerce.com/login"
	When User enters username: "admin@yourstore.com"
	And User enters Password: "admin"
	Then Click on login
	And User click on Logout link

@DataDriven
Scenario Outline: Login with valid credentials -> Data Driven
    Given User opens URL "https://admin-demo.nopcommerce.com/login"
    When User enters username: "<email>"
    And User enters Password: "<password>"
    Then Click on login
    And User click on Logout link

    Examples:
      | email | password |
      | admin7@yourstore.com |  admin7  |
      | admin8@yourstore.com |  admin8  |
      | admin@yourstore.com  |  admin   |
      | admin@yourstore.com  |  admin   |
