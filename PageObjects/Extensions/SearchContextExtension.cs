using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.Extensions
{
    public static class SearchContextExtension
    {
        public static IWebElement FindElementByDataQa(this IWebDriver searchContext,string dataQa)
        {
            return searchContext.FindElement(By.XPath($"//*[@data-qa={dataQa}]"));
        }
        public static IList<IWebElement> FindElementsByDataQa(this IWebDriver driver,string dataQa)
        {
            return driver.FindElements(By.XPath($"//*[@data-qa={dataQa}]"));
        }
    }
}
