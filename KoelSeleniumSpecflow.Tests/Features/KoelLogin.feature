Feature: KoelLogin
	In order to gain access to my Koel
	As a music lover
	I want to login to Koel with my credentials


Scenario: Login Completed Successfully
	Given I am on the Koel login screen
		And I have entered my email address of admin@mykoel.com
		And I have entered my password of adminpasswd
	When I press log in
	Then I am taken to my Koel home screen

Scenario: Login Unsuccessful Wrong Password
	Given I am on the Koel login screen
		And I have entered my email address of admin@mykoel.com
		And I have entered my password of qwerty123
	When I press log in
	Then I remain on the Koel login screen

Scenario: Login Unsuccessful Wrong Email
	Given I am on the Koel login screen
		And I have entered my email address of admin123@mykoel.com
		And I have entered my password of adminpasswd
	When I press log in
	Then I remain on the Koel login screen
