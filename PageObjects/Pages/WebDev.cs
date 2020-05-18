using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace PageObjects.Pages
{
    public  class WebDev
    {
        protected IWebDriver _driver;

        public WebDev(IWebDriver driver)
        {
            _driver = driver;
        }
        IWebElement devRates => _driver.FindElement(By.XPath("//div[@class='vs-tab-content']"));



        public void checkDevRatesSectionDisplayed()
        {
            bool displayed=devRates.Displayed;
        }

        public void checkDevelopersSection()
        {
            IList<IWebElement> devList = _driver.FindElements(By.XPath("//div[@data-qa='fl-tile']"));
            int count = 0;
            for (int i = 0; i < devList.Count; i++)
            {
                if (devList[i].Displayed)
                {
                    count++;
                }
            }
            Assert.AreEqual(4, count);
        }
    }
}