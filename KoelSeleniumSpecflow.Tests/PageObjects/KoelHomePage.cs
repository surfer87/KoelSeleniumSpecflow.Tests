using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoelSeleniumSpecflow.Tests
{
    public class KoelHomePage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "homeWrapper")]
        private IWebElement _homeWrapper;

        [FindsBy(How = How.ClassName, Using = "name")]
        private IWebElement _username;

        [FindsBy(How = How.ClassName, Using = "queue")]
        private IWebElement _queueButton;

        [FindsBy(How = How.ClassName, Using = "songs")]
        private IWebElement _allSongsButton;

        [FindsBy(How = How.ClassName, Using = "settings")]
        private IWebElement _settingsButton;

        [FindsBy(How = How.ClassName, Using = "users")]
        private IWebElement _usersButton;

        [FindsBy(How = How.ClassName, Using = "logout")]
        private IWebElement _logoutButton;

        [FindsBy(How = How.ClassName, Using = "cover")]
        private IWebElement _mostPlayedSong;
        [FindsBy(How = How.ClassName, Using = "recent")]
        private IWebElement _recentlyPlayed;
        [FindsBy(How = How.ClassName, Using = "recently-added")]
        private IWebElement _recentlyAdded;
        [FindsBy(How = How.ClassName, Using = "top-artists")]
        private IWebElement _topArtists;
        [FindsBy(How = How.ClassName, Using = "top-albums")]
        private IWebElement _topAlbums;

        [FindsBy(How = How.ClassName, Using = "plyr--playing")]
        private IWebElement _songPlaying;

        public KoelHomePage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(_driver, this);
        }

        public KoelSettingsPage SelectSettings()
        {
            _settingsButton.Click();

            return new KoelSettingsPage(_driver);
        }

        public KoelPreferencesPage SelectProfile()
        {
            _username.Click();

            return new KoelPreferencesPage(_driver);
        }

        public KoelQueuePage SelectQueue()
        {
            _queueButton.Click();

            return new KoelQueuePage(_driver);
        }

        public KoelAllSongsPage SelectAllSongs()
        {
            _allSongsButton.Click();

            return new KoelAllSongsPage(_driver);
        }

        public KoelUsersPage SelectUsers()
        {
            _usersButton.Click();

            return new KoelUsersPage(_driver);
        }

        public KoelLoginPage SelectLogout()
        {
            _logoutButton.Click();

            return new KoelLoginPage(_driver);
        }

        public void WaitForHomeWrapper()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("homeWrapper")));
        }

        public void WaitForSongPlay()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("plyr--playing")));
        }

        public string Username => _username.Text;
        public string Address => _driver.Url;
        public IWebElement MostPlayedSong => _mostPlayedSong;
        public IWebElement RecentlyPlayed => _recentlyPlayed;
        public IWebElement RecentlyAdded => _recentlyAdded;
        public IWebElement TopArtists => _topArtists;
        public IWebElement TopAlbums => _topAlbums;
        public IWebElement SongPlaying => _songPlaying;

        public IWebElement HomeWrapper => _homeWrapper;
    }
}
