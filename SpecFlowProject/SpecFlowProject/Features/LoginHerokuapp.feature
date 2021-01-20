Feature: LoginHerokuapp
	In order to avoid silly mistakes
	As a user
	I want to be login the page

Background: 
	Given I have navigated to the Login Page

@invalid
Scenario Outline: InvalidLoginHerokuapp
	When I enter username: '<Login>'
	And I enter password: '<Password>'
	And I press the Login button
	Then I am logged into the Home Page and show Message '<Message>'

	Examples: 
		| Login    | Password             | Message                   |
		| LoginB   | passwordB            | Your username is invalid! |
		|          | SuperSecretPassword! | Your username is invalid! |
		| tomsmith |                      | Your password is invalid! |
		| tomsmith | passwordB            | Your password is invalid! |

@valid
Scenario: ValidLoginHerokuapp
	When I enter username: 'tomsmith'
	And I enter password: 'SuperSecretPassword!'
	And I press the Login button
	Then I am logged into the Home Page and show Message 'You logged into a secure area!'