Feature: KoelAddSongToFavourites
	In order to have easy access to my favourite songs
	As a Koel user
	I want to be able to add songs to a favourites list and view them

@mytag
Scenario: Add a song to the Favourites
	Given I am on the Koel home screen
	And I select all songs
	And I select a song to play called Enthusiast
	And the song starts playing
	And I select the favourite button for the song
	When I view the favourites list
	Then I see in the favourites list the song called Enthusiast
