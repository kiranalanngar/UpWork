using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.Pages
{
    public class StartUps
    {
        protected IWebDriver _driver;
        public StartUps(IWebDriver driver)
        {
            this._driver = driver;
        }

        IWebElement customerLogoSection => _driver.FindElement(By.XPath("//div[@data-qa='logo']"));
        IWebElement microsoftLogo => _driver.FindElement(By.XPath("//img[@data-qa='microsoft']"));
        IWebElement airBnBLogo => _driver.FindElement(By.XPath("//img[@data-qa='airbnb']"));
        IWebElement geLogo => _driver.FindElement(By.XPath("//img[@data-qa='ge']"));
        IWebElement automaticLogo => _driver.FindElement(By.XPath("//img[@data-qa='automatic']"));
        IWebElement bisselLogo => _driver.FindElement(By.XPath("//img[@data-qa='bissel']"));
        IWebElement cotyLogo => _driver.FindElement(By.XPath("//img[@data-qa='coty']"));

        public void customerLogoSectionDisplayed()
        {
            bool logoSectionDisplayed= customerLogoSection.Displayed;
            Assert.IsTrue(logoSectionDisplayed);
        }
        public void allCustomerLogoDisplayed()
        {
            if (microsoftLogo.Displayed && geLogo.Displayed && airBnBLogo.Displayed && automaticLogo.Displayed && bisselLogo.Displayed && cotyLogo.Displayed)
            {
                bool customerLogosDisplayed = true;
                Assert.IsTrue(customerLogosDisplayed);
            }
        }
    }
}
