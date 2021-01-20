Feature: LoginPageObject
	In order to avoid silly mistakes
	As a user
	I want to be login the page

Background: 
	Given I navigated to the Login Page successfully

@invalid
Scenario Outline: InvalidLoginApp
	When I enter username '<Login>' and  password '<Password>'
	And I submit the Login button
	Then I am logged into the Home Page and display Message '<Message>'

	Examples: 
		| Login    | Password             | Message                   |
		| LoginB   | passwordB            | Your username is invalid! |
		|          | SuperSecretPassword! | Your username is invalid! |
		| tomsmith |                      | Your password is invalid! |
		| tomsmith | passwordB            | Your password is invalid! |

@valid
Scenario: ValidLoginApp
	When I enter username 'tomsmith' and  password 'SuperSecretPassword!'
	And I submit the Login button
	Then I am logged into the Home Page and display Message 'You logged into a secure area!'