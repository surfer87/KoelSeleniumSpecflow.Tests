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
    public class KoelAllSongsPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.ClassName, Using = "allSongs")]
        private IWebElement _allSongs;

        [FindsBy(How = How.Id, Using = "songsWrapper")]
        private IWebElement _songsWrapper;

        [FindsBy(How = How.ClassName, Using = "song-item")]
        private IWebElement _songItem;

        [FindsBy(How = How.XPath, Using = "//*[@id='songsWrapper']/div/ul/li[1]/span[1]")]
        private IWebElement _playSong;

        [FindsBy(How = How.ClassName, Using = "song-item")]
        private IList<IWebElement> _songsList;

        [FindsBy(How = How.ClassName, Using = "like")]
        private IWebElement _favouriteASong;

        [FindsBy(How = How.ClassName, Using = "favorites")]
        private IWebElement _favouritesButton;

        [FindsBy(How = How.ClassName, Using = "plyr--playing")]
        private IWebElement _songPlaying;

        public KoelAllSongsPage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(_driver, this);
        }

        public void RightClickSong()
        {
            var action = new OpenQA.Selenium.Interactions.Actions(_driver);
            action.ContextClick(_songItem);
            action.Perform();
        }

        public void LeftClickPlay()
        {
            _playSong.Click();
        }

        public void FavouriteASong()
        {
            _favouriteASong.Click();
        }

        public KoelFavouritesPage SelectFavouritesList()
        {
            _favouritesButton.Click();

            return new KoelFavouritesPage(_driver);
        }

        public void WaitForSongItem()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("song-item")));
        }

        public void WaitForSongPlay()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("plyr--playing")));
        }

        public Boolean AllSongsPageDisplayed => _allSongs.Displayed;
        public Boolean AllSongsDisplayed => _songsWrapper.Displayed;
        public Boolean SongMenuDisplayed => _playSong.Displayed;
        public IList<IWebElement> SongsList => _songsList;
        public IWebElement SongItem => _songItem;
        public IWebElement SongPlaying => _songPlaying;
    }
}
