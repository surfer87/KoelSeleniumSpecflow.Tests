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
    public class KoelFavouritesPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "favoritesWrapper")]
        private IWebElement _favouritesWrapper;

        [FindsBy(How = How.ClassName, Using = "favorites")]
        private IWebElement _favourites;

        [FindsBy(How = How.ClassName, Using = "like")]
        private IWebElement _favouriteASong;

        [FindsBy(How = How.XPath, Using = "//*[@id='favoritesWrapper']/div[1]/table/tbody/tr")]
        private IList<IWebElement> _songsList;

        public KoelFavouritesPage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(_driver, this);
        }

        public void FavouriteASong()
        {
            _favouriteASong.Click();
        }

        public void WaitForFavouritesDisplay()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='favoritesWrapper']/div[1]/table/tbody/tr")));
        }

        public Boolean FavouritesDisplayed => _favourites.Displayed;
        public Boolean FavouritesWrapperDisplayed => _favouritesWrapper.Displayed;
        public IList<IWebElement> SongsList => _songsList;
    }
}
