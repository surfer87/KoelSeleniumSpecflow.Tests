using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Xunit;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using System.Diagnostics;
using Xunit.Abstractions;

namespace KoelSeleniumSpecflow.Tests
{
    [Binding]
    public class KoelSteps
    {
        private IWebDriver _driver;

        // page objects
        private KoelLoginPage _koelLoginPage;
        private KoelHomePage _koelHomePage;
        private KoelSettingsPage _koelSettingsPage;
        private KoelPreferencesPage _koelPreferencesPage;
        private KoelQueuePage _koelQueuePage;
        private KoelAllSongsPage _koelAllSongsPage;
        private KoelFavouritesPage _koelFavouritesPage;
        private KoelUsersPage _koelUsersPage;

        // url and port number for koel, i.e. http://192.168.1.1:1234
        // amend loginpage _pageUri as well
        private string url = "";

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _driver.Dispose();
        }




        /* LOGIN STEPS */

        [Given(@"I am on the Koel login screen")]
        public void GivenIAmOnTheKoelLoginScreen()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();

            _koelLoginPage = KoelLoginPage.NavigateTo(_driver);
            
        }
        
        [Given(@"I have entered my email address of (.*)")]
        public void GivenIHaveEnteredMyEmailAddressOf(string emailAddress)
        {
            _koelLoginPage.EmailAddress = emailAddress;
        }
        
        [Given(@"I have entered my password of (.*)")]
        public void GivenIHaveEnteredMyPasswordOf(string password)
        {
            _koelLoginPage.Password = password;
        }
        
        [When(@"I press log in")]
        public void WhenIPressLogIn()
        {
            _koelHomePage = _koelLoginPage.SelectLogin();
        }
        
        [Then(@"I am taken to my Koel home screen")]
        public void ThenIAmTakenToMyKoelHomeScreen()
        {
            _koelHomePage.WaitForHomeWrapper();

            Assert.Equal(url+"/#!/home", _koelHomePage.Address);
            Assert.Equal("admin", _koelHomePage.Username);
        }

        [Then(@"I remain on the Koel login screen")]
        public void ThenIRemainOnTheKoelLoginScreen()
        {
            Assert.Equal(url, _koelLoginPage.Address);
        }





        /* MUSIC SCAN STEPS */

        [Given(@"I am on the Koel home screen")]
        public void GivenIAmOnTheKoelHomeScreen()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();
            _koelLoginPage = KoelLoginPage.NavigateTo(_driver);
            _koelLoginPage.EmailAddress = "admin@myKoel.com";
            _koelLoginPage.Password = "adminpasswd";
            _koelHomePage = _koelLoginPage.SelectLogin();

            _koelHomePage.WaitForHomeWrapper();
            Assert.Equal(url+"/#!/home", _koelHomePage.Address);
        }

        [Given(@"I select the Settings button")]
        public void GivenISelectTheSettingsButton()
        {
            _koelSettingsPage = _koelHomePage.SelectSettings();
        }

        [Given(@"I have entered my music folder path of (.*)")]
        public void GivenIHaveEnteredMyMusicFolderPathOf(string inputSettingsPath)
        {
            _koelSettingsPage.InputSettingsPath = inputSettingsPath;
        }

        [When(@"I press the scan button")]
        public void WhenIPressTheScanButton()
        {
            _koelHomePage = _koelSettingsPage.SelectScan();
        }


        [Then(@"I see the media path warning on-screen")]
        public void ThenISeeTheMediaPathWarningOn_Screen()
        {
            _koelSettingsPage.WaitForAlert();

            Assert.Equal(url+"/#!/settings", _koelHomePage.Address);
        }


        [Given(@"I press the scan button")]
        public void GivenIPressTheScanButton()
        {
            _koelHomePage = _koelSettingsPage.SelectScan();
        }

        [Given(@"I see the media path warning on-screen")]
        public void GivenISeeTheMediaPathWarningOn_Screen()
        {
            _koelSettingsPage.WaitForAlert();

            Assert.Equal(url+"/#!/settings", _koelHomePage.Address);
        }

        [When(@"I press the go ahead button")]
        public void WhenIPressTheGoAheadButton()
        {
            _koelSettingsPage = _koelSettingsPage.SelectGoAhead();
        }

        [Then(@"I see the Something went wrong error message")]
        public void ThenISeeTheSomethingWentWrongErrorMessage()
        {
            _koelSettingsPage.WaitForError();

            Assert.Equal(url+"/#!/settings", _koelHomePage.Address);
        }



        /* PREFERENCE CHANGES STEPS */
        [Given(@"I select the Profile button")]
        public void GivenISelectTheProfileButton()
        {
            _koelPreferencesPage = _koelHomePage.SelectProfile();
        }

        [Given(@"I have entered my name of (.*)")]
        public void GivenIHaveEnteredMyNameOfAdmin(string name)
        {
            _koelPreferencesPage.InputNamePath = name;
        }

        [Given(@"I press the save button")]
        public void GivenIPressTheSaveButton()
        {
            _koelPreferencesPage.SelectSave();
        }

        [When(@"I press the confirm button")]
        public void WhenIPressTheConfirmButton()
        {
            _koelPreferencesPage.WaitForConfirm();
            _koelPreferencesPage.SelectOK();
        }

        [Then(@"I see my updated name of (.*)")]
        public void ThenISeeMyUpdatedNameOf(string name)
        {
            Assert.Equal(name, _koelPreferencesPage.ProfileName);
        }



        [Given(@"I have entered my email of (.*)")]
        public void GivenIHaveEnteredMyEmailOfAdminMykoel_Com(string email)
        {
            _koelPreferencesPage.InputEmailPath = email;
        }

        [Then(@"I see my updated email of (.*)")]
        public void ThenISeeMyUpdatedEmailOfAdminMykoel_Com(string email)
        {
            Assert.Equal(email, _koelPreferencesPage.ProfileEmail);
        }



        [Given(@"I select the Close Notification button")]
        public void GivenISelectTheCloseNotificationButton()
        {
            _koelPreferencesPage.SelectCloseNotification();
        }

        [When(@"I press the save button")]
        public void WhenIPressTheSaveButton()
        {
            _koelPreferencesPage.SelectSave();
        }

        [Then(@"I see the Close Notification option is selected")]
        public void ThenISeeTheCloseNotificationOptionIsSelected()
        {
            Assert.True(_koelPreferencesPage.IsCloseKoelChecked);
        }



        /* LOGOUT STEPS */
        [When(@"I press logout")]
        public void WhenIPressLogout()
        {
            _koelLoginPage = _koelHomePage.SelectLogout();
        }

        [Then(@"I am taken to my Koel login screen")]
        public void ThenIAmTakenToMyKoelLoginScreen()
        {
            _koelLoginPage.WaitForLoginScreen();
            Assert.Equal(url+"/#!/home", _koelLoginPage.Address);
        }



        /* HOME SCREEN INFO PANEL */
        [Then(@"I see the most played song")]
        public void ThenISeeTheMostPlayedSong()
        {
            Assert.True(_koelHomePage.MostPlayedSong.Displayed);
        }

        [Then(@"I see the most recently played song")]
        public void ThenISeeTheMostRecentlyPlayedSong()
        {
            Assert.True(_koelHomePage.RecentlyPlayed.Displayed);
        }

        [Then(@"I see the most recently added song")]
        public void ThenISeeTheMostRecentlyAddedSong()
        {
            Assert.True(_koelHomePage.RecentlyAdded.Displayed);
        }

        [Then(@"I see the top artists")]
        public void ThenISeeTheTopArtists()
        {
            Assert.True(_koelHomePage.TopArtists.Displayed);
        }

        [Then(@"I see the top albums")]
        public void ThenISeeTheTopAlbums()
        {
            Assert.True(_koelHomePage.TopAlbums.Displayed);
        }



        /* PLAY SONG FROM HOME SCREEN */
        [When(@"I press play on the most played song")]
        public void WhenIPressPlayOnTheMostPlayedSong()
        {
            _koelHomePage.MostPlayedSong.Click();
        }

        [Then(@"the song starts playing")]
        public void ThenTheSongStartsPlaying()
        {
            _koelHomePage.WaitForSongPlay();

            Assert.True(_koelHomePage.SongPlaying.Displayed);
        }



        /* VIEW/QUEUE ALL SONGS AND SHUFFLE */
        [Given(@"I select current queue")]
        public void GivenISelectCurrentQueue()
        {
            _koelQueuePage = _koelHomePage.SelectQueue();
        }

        [When(@"I press shuffle all songs")]
        public void WhenIPressShuffleAllSongs()
        {
            Assert.True(_koelQueuePage.QueuePageDisplayed);
            _koelQueuePage.QueueStartPlaying();
        }

        [Then(@"the song queue is listed")]
        public void ThenTheSongQueueIsListed()
        {
            Assert.True(_koelQueuePage.QueueDisplayed);
        }


        /* VIEW ALL SONGS AND PLAY A SONG */
        [Given(@"I select all songs")]
        public void GivenISelectAllSongs()
        {
            _koelAllSongsPage = _koelHomePage.SelectAllSongs();
            Assert.True(_koelAllSongsPage.AllSongsPageDisplayed);
            Assert.True(_koelAllSongsPage.AllSongsDisplayed);
        }

        [When(@"I select a song to play")]
        public void WhenISelectASongToPlay()
        {
            _koelAllSongsPage.RightClickSong();
            Assert.True(_koelAllSongsPage.SongMenuDisplayed);

            _koelAllSongsPage.LeftClickPlay();
        }


        /* ADD SONG TO FAVOURITES */
        [Given(@"I select a song to play called (.*)")]
        public void GivenISelectASongToPlayCalled(string title)
        {
            _koelAllSongsPage.WaitForSongItem();

            foreach (IWebElement song in _koelAllSongsPage.SongsList)
            {
                if (song.Text.Contains(title))
                {
                    Actions action = new Actions(_driver);
                    action.DoubleClick(song).Perform();
                }
            }
        }

        [Given(@"the song starts playing")]
        public void GivenTheSongStartsPlaying()
        {
            _koelAllSongsPage.WaitForSongPlay();

            Assert.True(_koelAllSongsPage.SongPlaying.Displayed);
        }

        [Given(@"I select the favourite button for the song")]
        public void GivenISelectTheFavouriteButtonForTheSong()
        {
            _koelAllSongsPage.FavouriteASong();
        }

        [When(@"I view the favourites list")]
        public void WhenIViewTheFavouritesList()
        {
            _koelFavouritesPage = _koelAllSongsPage.SelectFavouritesList();
        }

        [Then(@"I see in the favourites list the song called (.*)")]
        public void ThenISeeInTheFavouritesListTheSongCalled(string title)
        {
            Assert.True(_koelFavouritesPage.FavouritesDisplayed);
            Assert.True(_koelFavouritesPage.FavouritesWrapperDisplayed);

            _koelFavouritesPage.WaitForFavouritesDisplay();

            Boolean titleFoundInFavourites = false;
            foreach (IWebElement song in _koelFavouritesPage.SongsList)
            {
                if (song.Text.Contains(title))
                {
                    titleFoundInFavourites = true;
                }
            }
            Assert.True(titleFoundInFavourites);

            // clean-up by re-selecting like button so we can re-run from fresh next time
            _koelFavouritesPage.FavouriteASong();
        }



        /* ADD NEW USER */

        [Given(@"I select Users")]
        public void GivenISelectUsers()
        {
            _koelUsersPage = _koelHomePage.SelectUsers();

            Assert.True(_koelUsersPage.UsersPageDisplayed);
        }

        [Given(@"I select Add")]
        public void GivenISelectAdd()
        {
            _koelUsersPage.AddUser();
        }

        [Given(@"I enter a name of (.*)")]
        public void GivenIEnterANameOf(string name)
        {
            _koelUsersPage.InputNamePath = name;
        }

        [Given(@"I enter an email of (.*)")]
        public void GivenIEnterAnEmailOf(string email)
        {
            _koelUsersPage.InputEmailPath = email;
        }

        [Given(@"I enter a password of (.*)")]
        public void GivenIEnterAPasswordOf(string password)
        {
            _koelUsersPage.InputPasswordPath = password;
        }

        [When(@"I press create")]
        public void WhenIPressCreate()
        {
            _koelUsersPage.WaitForCreateUserFormDisplay();
            _koelUsersPage.CreateUser();
        }

        [Then(@"the a new user should be displayed with the name (.*)")]
        public void ThenTheANewUserShouldBeDisplayedWithTheNameBob(string searchName)
        {
            Assert.True(_koelUsersPage.CheckUserDisplayed(searchName));
        }


    }
}
