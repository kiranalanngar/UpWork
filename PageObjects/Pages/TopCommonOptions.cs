using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.Pages
{
    public class TopCommonOptions
    {
        protected IWebDriver _driver;
        public TopCommonOptions(IWebDriver _driver)
        {
            this._driver = _driver;
        }
        IWebElement solutions => _driver.FindElement(By.Id("desktop-solutions-menu-trigger"));
        IWebElement logIn => _driver.FindElement(By.LinkText("LOG IN"));
        IWebElement signUp => _driver.FindElement(By.LinkText("SIGN UP"));
        IWebElement tenToHundred => _driver.FindElement(By.LinkText("10-100 Employees"));


        public StartUps NavigateToSolutions()
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(solutions).Build().Perform();
            tenToHundred.Click();
            return new StartUps(_driver);
        }
    }
}
