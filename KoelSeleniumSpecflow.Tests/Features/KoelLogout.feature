Feature: KoelLogout
	In order to exit Koel
	As a Koel user
	I want to securely logout of Koel

@mytag
Scenario: Logout Completed Successfully
	Given I am on the Koel home screen
	When I press logout
	Then I am taken to my Koel login screen
