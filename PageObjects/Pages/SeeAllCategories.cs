using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageObjects.Extensions;
using System.Net.Http;
using System.Net;

namespace PageObjects.Pages
{
    public class SeeAllCategories
    {
        IWebDriver _driver = new FirefoxDriver();
        public SeeAllCategories(IWebDriver driver)
        {
            this._driver = driver;
        }
        IList<IWebElement> allCategories => _driver.FindElements(By.XPath("//div[@data-qa='cat-tile']"));

        IList<IWebElement> allLinks => _driver.FindElementsByDataQa("link");

        public void verifyAllLink()
        {
            int count = allLinks.Count;
            for(int i = 0; i < count; i++)
            {
                var link = allLinks[i];
                var href = link.GetAttribute("href");


                if (string.IsNullOrEmpty(href))
                    continue;
                using(var webclient = new HttpClient())
                {
                    var response = webclient.GetAsync(href).Result;
                    Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                }
            }

        }



        public void allCategoriesDisplayed()
        {
            int counter = 0;
            for (int i = 0; i < allCategories.Count; i++)
            {
                if (allCategories[i].Displayed)
                {
                    counter++;
                }
            }
            Assert.AreEqual(12, counter);
        }
    }
}
