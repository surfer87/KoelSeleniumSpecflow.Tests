Feature: KoelMusicScan
	In order to listen to my music on Koel
	As a Koel user
	I want to be able to upload my music to Koel

@mytag
Scenario: Valid Music Folder
	Given I am on the Koel home screen
		And I select the Settings button
		And I have entered my music folder path of /home/user/music
	When I press the scan button
	Then I am taken to my Koel home screen

Scenario: Change Media Path Warning
	Given I am on the Koel home screen
		And I select the Settings button
		And I have entered my music folder path of /home/user/music2
	When I press the scan button
	Then I see the media path warning on-screen

Scenario: Invalid Media Path
	Given I am on the Koel home screen
		And I select the Settings button
		And I have entered my music folder path of /home/user/music2
		And I press the scan button
		And I see the media path warning on-screen
	When I press the go ahead button
	Then I see the Something went wrong error message
