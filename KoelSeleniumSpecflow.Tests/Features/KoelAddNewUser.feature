Feature: KoelAddNewUser
	In order for new people to use Koel
	As a Koel admin
	I want to be able to add new Koel user accounts

@mytag
Scenario: Add a new user
	Given I am on the Koel home screen
	And I select Users
	And I select Add
	And I enter a name of t_bob
	And I enter an email of bob@test.com
	And I enter a password of bobpasswd
	When I press create
	Then the a new user should be displayed with the name t_bob