@Leads
Feature: Qualifying leads
Qualification of lead entities 

Scenario Outline: Can qualify lead into advice opportunity as an SRC
	Given I am logged in as a SRC user
	And I add a contact with segment <segment>
	And I add that contact to a lead
	When I qualify the lead as opportunityType <type>
	Then I can find and view the created opportunity

	Examples:
		| segment         | type   |
		| Hospital Doctor | advice |