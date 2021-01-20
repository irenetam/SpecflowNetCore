Feature: LoginHerokuapp3
	In order to avoid silly mistakes
	As a user
	I want to be login the page

@mytag
Scenario Outline: InvalidLoginHerokuapp3
	Given I have navigated to the Login Page is
	When I enter some info below:
		| Login    | Password             |
		| LoginB   | passwordB            | 
	And I click the Login button
	Then I am logged into the Home Page and do something