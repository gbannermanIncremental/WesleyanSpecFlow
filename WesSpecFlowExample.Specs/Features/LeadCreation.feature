@Leads
Feature: Lead creation
Creation of lead entities on the new lead form
Initial tests to ensure the page can be loaded and new leads can be added

Scenario: Can open the new lead form
	Given I am logged in with Financial Consultant privileges
	When I open the new lead form
	Then I have the new lead form displayed

Scenario Outline: Can add a new lead to the system
	Given I am logged in with Financial Consultant privileges
	And I open the new lead form
	When I save a last name <lastName> and phone number <phoneNumber>
	Then I have a new lead record with subject containing <lastName>

	Examples:
		| phoneNumber | lastName |
		| 07771234567 | Hughes   |
		| 07123456789 | Smith    |