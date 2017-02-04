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
    public class KoelPreferencesPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "inputProfileName")]
        private IWebElement _inputProfileName;

        [FindsBy(How = How.Id, Using = "inputProfileEmail")]
        private IWebElement _inputProfileEmail;

        [FindsBy(How = How.XPath, Using = "//*[@class='preferences']/div[2]/label/input")]
        private IWebElement _confirmCloseKoel;

        [FindsBy(How = How.XPath, Using = "//*[@id='profileWrapper']/div/form/div[4]/button")]
        private IWebElement _saveButton;

        [FindsBy(How = How.ClassName, Using = "confirm")]
        private IWebElement _okButton;

        public string ProfileName => _inputProfileName.GetAttribute("value");
        public string ProfileEmail => _inputProfileEmail.GetAttribute("value");

        public Boolean IsCloseKoelChecked => _confirmCloseKoel.Selected;

        public KoelPreferencesPage(IWebDriver driver)
        {
            _driver = driver;
      
            PageFactory.InitElements(_driver, this);
        }

        public void SelectSave()
        {
            _saveButton.Click();
        }

        public void SelectOK()
        {
            _okButton.Click();
        }

        public void SelectCloseNotification()
        {
            _confirmCloseKoel.Click();
        }

        public void WaitForConfirm()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("confirm")));
        }

        public string InputNamePath
        {
            set
            {
                _inputProfileName.Clear();
                _inputProfileName.SendKeys(value);
            }
        }

        public string InputEmailPath
        {
            set
            {
                _inputProfileEmail.Clear();
                _inputProfileEmail.SendKeys(value);
            }
        }
    }
}
