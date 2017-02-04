Feature: KoelShuffleQueueSongs
	In order to quickly play all my songs
	As a Koel user
	I want to view and shuffle all my songs from the queue page

@mytag
Scenario: Click current queue and shuffle all songs
	Given I am on the Koel home screen
	And I select current queue
	When I press shuffle all songs
	Then the song queue is listed 
	And the song starts playing
