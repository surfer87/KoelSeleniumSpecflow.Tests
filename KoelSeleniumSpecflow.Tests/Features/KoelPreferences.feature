Feature: KoelPreferences
	In order to change my preferences on Koel
	As a Koel user
	I want to be able to update my profile on Koel

@mytag
Scenario: Change Name
	Given I am on the Koel home screen
		And I select the Profile button
		And I have entered my name of admin123
		And I press the save button
	When I press the confirm button
	Then I see my updated name of admin123

Scenario: Change Email
	Given I am on the Koel home screen
		And I select the Profile button
		And I have entered my email of admin123@mykoel.com
		And I press the save button
	When I press the confirm button
	Then I see my updated email of admin123@mykoel.com

Scenario: Change Close Koel Notification
	Given I am on the Koel home screen
		And I select the Profile button
		And I select the Close Notification button
	When I press the save button
	Then I see the Close Notification option is selected
