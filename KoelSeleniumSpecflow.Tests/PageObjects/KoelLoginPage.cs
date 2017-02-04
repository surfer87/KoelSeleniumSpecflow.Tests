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
    public class KoelLoginPage
    {
        private readonly IWebDriver _driver;
        // koel login page url + port
        private const string _pageUri = @"";

        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/form/input[1]")]
        private IWebElement _emailAddress;

        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/form/input[2]")]
        private IWebElement _password;

        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/form/button")]
        private IWebElement _loginButton;

        public KoelLoginPage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(_driver, this);
        }

        public static KoelLoginPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(_pageUri);

            return new KoelLoginPage(driver);
        }

        public KoelHomePage SelectLogin()
        {
            _loginButton.Click();

            return new KoelHomePage(_driver);
        }

        public void WaitForLoginScreen()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("login-wrapper")));
        }

        public string EmailAddress
        {
            set
            {
                _emailAddress.SendKeys(value);
            }
        }

        public string Password
        {
            set
            {
                _password.SendKeys(value);
            }
        }

        public string Address => _driver.Url;
    }
}
