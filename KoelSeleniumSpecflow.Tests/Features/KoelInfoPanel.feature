Feature: KoelInfoPanel
	In order to access my music easily
	As a Koel user
	I want my music information displayed on my home screen

@mytag
Scenario: Display the most played song
	Given I am on the Koel home screen
	Then I see the most played song

Scenario: Display the most recently played song
	Given I am on the Koel home screen
	Then I see the most recently played song

Scenario: Display the most recently added song
	Given I am on the Koel home screen
	Then I see the most recently added song

Scenario: Display the top artists
	Given I am on the Koel home screen
	Then I see the top artists

Scenario: Display the top albums
	Given I am on the Koel home screen
	Then I see the top albums
