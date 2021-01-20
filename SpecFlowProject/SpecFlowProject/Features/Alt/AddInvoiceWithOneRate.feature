Feature: AddInvoiceWithOneRate
	In order to avoid silly mistakes
	I want to add a new invoice with one rate

@mytag
Scenario: Add a new invoice with one rate successfully
	Given I have accessed application via url 'https://localhost:5001/'
	And the login page should be displayed
	When I enter username ''
	And click next button
	Then the password login should be displayed
	When I enter password ''
	And click sign in button
	Then the budget tracker page should be displayed
	When I click on a project name 'Carlson Testing'
	Then project page should be displayed
	When I click on invoices tab 
	And I click on add invoice button
	Then popup add invoice should be showed
	When I add a new invoice by typing as below
	| number | date     | billingMonth | internalRate | description         | devLineDescription | billingRate | devAmount | creditDescription  | creditRate | newCredit | creditAmount | nonDevLineDes    | nonDevAmount | usPaidAmount | nonDevPaidAmount | usJiraTimeLoggedOverride | usWitheldHoursOverride |
	| abc    | 10/10/2020 | 10/01/2020     | 100          | invoice description | dev line desc      | 140         | 120       | credit description | 140        | 230       | 200          | non dev line des | 200          | 2000         | 2000             | 20					   | 2                      |
	Then the message result '' should be displayed