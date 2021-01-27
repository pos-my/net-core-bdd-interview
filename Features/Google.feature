Feature: Google
	As a traveler, I want to have vacation in Malaysia

@mytag
Scenario: Validate Google Search Result for Top Places to Visit in Malaysia
	Given "traveler" wants to have a vacation in Malaysia
	When I perform a Google Search for "vacation in Malaysia"
	Then the user will see Advertisement on top of search result
		| Destinations |
		| Kuala Lumpur |
		| Langkawi     |
		| Penang       |
		| George Town  |
	And the section titled details
		| Titles                 |
		| Popular destinations   |
		| People also ask        |
		| People also search for |
	And has Southeast Asia countries
		| Countries        |
		| Singapore    |
		| Indonesia    |
		| Philippines   |
		| Kuala Lumpur |
		| Thailand     |
	And I will see related searches suggestions
	Then I will click on that suggest Top Places to visit
	And I will see that the browser no longer on Google page