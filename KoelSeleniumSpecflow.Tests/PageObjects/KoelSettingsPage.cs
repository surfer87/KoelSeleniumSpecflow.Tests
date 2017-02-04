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
    public class KoelSettingsPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "inputSettingsPath")]
        private IWebElement _inputSettingsPath;

        [FindsBy(How = How.XPath, Using = "//*[@id='settingsWrapper']/form/div[2]/button")]
        private IWebElement _scanButton;

        [FindsBy(How = How.ClassName, Using = "confirm")]
        private IWebElement _goAheadButton;

        public KoelSettingsPage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(_driver, this);
        }

        public KoelHomePage SelectScan()
        {
            _scanButton.Click();

            return new KoelHomePage(_driver);
        }

        public KoelSettingsPage SelectGoAhead()
        {
            _goAheadButton.Click();

            return new KoelSettingsPage(_driver);
        }

        public void WaitForAlert()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("sweet-alert")));
        }

        public void WaitForError()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("sa-error-container")));
        }

        public string InputSettingsPath
        {
            set
            {
                _inputSettingsPath.Clear();
                _inputSettingsPath.SendKeys(value);
            }
        }
    }
}
