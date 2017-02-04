using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoelSeleniumSpecflow.Tests
{
    public class KoelQueuePage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.ClassName, Using = "song-list-wrap")]
        private IWebElement _queuedSongs;

        [FindsBy(How = How.Id, Using = "queueWrapper")]
        private IWebElement _queueWrapper;

        [FindsBy(How = How.ClassName, Using = "start")]
        private IWebElement _queueStartPlaying;

        public KoelQueuePage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(_driver, this);
        }

        public void QueueStartPlaying()
        {
            _queueStartPlaying.Click();
        }

        public string Address => _driver.Url;
        public Boolean QueuePageDisplayed => _queueWrapper.Displayed;
        public Boolean QueueDisplayed => _queuedSongs.Displayed;
    }
}
