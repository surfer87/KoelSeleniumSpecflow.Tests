Feature: KoelAllSongsPlay
	In order to view and play all my songs
	As a Koel user
	I want to view all my songs from the all songs page

@mytag
Scenario: Right-click song and play
	Given I am on the Koel home screen
	And I select all songs
	When I select a song to play
	Then the song starts playing
