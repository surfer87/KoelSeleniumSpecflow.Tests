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
    public class KoelUsersPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.ClassName, Using = "btn-green")]
        private IWebElement _addUserButton;

        [FindsBy(How = How.Id, Using = "usersWrapper")]
        private IWebElement _usersWrapper;


        [FindsBy(How = How.ClassName, Using = "user-create")]
        private IWebElement _inputForm;

        [FindsBy(How = How.XPath, Using = "//*[@id='usersWrapper']/div/div/form/div[1]/input")]
        private IWebElement _nameField;

        [FindsBy(How = How.XPath, Using = "//*[@id='usersWrapper']/div/div/form/div[2]/input")]
        private IWebElement _emailField;

        [FindsBy(How = How.XPath, Using = "//*[@id='usersWrapper']/div/div/form/div[3]/input")]
        private IWebElement _passwordField;

        [FindsBy(How = How.XPath, Using = "//*[@id='usersWrapper']/div/div/form/div[4]/button[1]")]
        private IWebElement _createUserButton;

        [FindsBy(How = How.ClassName, Using = "btn-red")]
        private IList<IWebElement> _deleteButtons;

        public KoelUsersPage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(_driver, this);
        }

        public Boolean CheckUserDisplayed(string name)
        {
            IList<IWebElement> allUserTexts = _driver.FindElements(By.ClassName("right"));

            foreach (IWebElement item in allUserTexts)
            {
                if (item.Text.Contains(name))
                {
                    return true;
                }
            }

            return false;
        }

        public void AddUser()
        {
            _addUserButton.Click();
        }

        public void CreateUser()
        {
            _createUserButton.Click();
        }

        public void WaitForCreateUserFormDisplay()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='usersWrapper']/div/div/form/div[4]/button[1]")));
        }

        public string InputNamePath
        {
            set
            {
                _nameField.Clear();
                _nameField.SendKeys(value);
            }
        }

        public string InputEmailPath
        {
            set
            {
                _emailField.Clear();
                _emailField.SendKeys(value);
            }
        }

        public string InputPasswordPath
        {
            set
            {
                _passwordField.Clear();
                _passwordField.SendKeys(value);
            }
        }

        public Boolean UsersPageDisplayed => _usersWrapper.Displayed;

    }
}
