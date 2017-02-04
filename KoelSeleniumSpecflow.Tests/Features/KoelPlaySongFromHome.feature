Feature: KoelPlaySongFromHome
	In order to quickly play a song
	As a Koel user
	I want to click play on a song from my home screen

@mytag
Scenario: Play most played song from home screen
	Given I am on the Koel home screen
	When I press play on the most played song
	Then the song starts playing

