using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.Pages
{
    public class HomePage:TopCommonOptions
    {
        public HomePage(IWebDriver _driver) : base(_driver)
        {
            base._driver = _driver;
        }


        IWebElement webDev => _driver.FindElement(By.LinkText("Web Dev"));
        IWebElement mobileDev => _driver.FindElement(By.LinkText("Mobile Dev"));
        IWebElement allCategories => _driver.FindElement(By.XPath("//a[text()=' See All Categories ']"));
        public WebDev NavigateToWebDev()
        {
            webDev.Click();
            return new WebDev(_driver);
        }
        public SeeAllCategories NavigateAllCategories()
        {
            allCategories.Click();
            return new SeeAllCategories(_driver);
        }
    }
}
