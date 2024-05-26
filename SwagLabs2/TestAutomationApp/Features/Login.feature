Feature: Login

  Scenario: Successful login
    Given the user is on the login page
    When the user enters valid credentials
    Then the user is redirected to the dashboard

  Scenario: Unsuccessful login with invalid credentials
    Given the user is on the login page
    When the user enters invalid credentials
    Then an error message is displayed

  Scenario: Verify login screen elements
    Given the user navigates to the application URL
    Then the login screen should be displayed
    And the username and password textboxes should be enabled and empty
    And the login button should be enabled

  Scenario: Web shop test page is loaded after login
    Given the user is on the login page
    When the user enters valid credentials
    Then the web shop test page should be loaded