Feature: AddCucumberOutline
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: Add two numbers Outlline
	Given the first number <first>
	And the second number <second>
	When let the two numbers are added
	Then so the result should be <result>

	Examples:
		| first | second	| result	|
		| 12	| 5			| 15		|
		| 20	| 5			| 25		|