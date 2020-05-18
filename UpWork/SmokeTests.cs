using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using PageObjects.Pages;
using System;

namespace UpWork
{
    public class SmokeTests
    {
        IWebDriver _driver = new FirefoxDriver();
        //HomePage homePage;
        //TopCommonOptions topCommonOptions;
        //StartUps startUps;
        //WebDev webDev;
        [SetUp]
        public void OpenUpWorkWebsite()
        {
            _driver.Manage().Window.Maximize();
            //_driver.Manage().Cookies.DeleteAllCookies();
            _driver.Navigate().GoToUrl("https://www.upwork.com/");
        }
        [Test]
        public void VerifyDeveloperSectionInWebDevPage()
        {
            HomePage homePage = new HomePage(_driver);
            WebDev webDev = homePage.NavigateToWebDev();
            webDev.checkDevRatesSectionDisplayed();
            webDev.checkDevelopersSection();
        }

        [Test]
        public void VerifyNavigateToSmallBusiness()
        {
            TopCommonOptions topCommonOptions = new TopCommonOptions(_driver);
            StartUps startUps = topCommonOptions.NavigateToSolutions();
            startUps.customerLogoSectionDisplayed();
            startUps.allCustomerLogoDisplayed();
        }

        [Test]
        public void VerifyUserIsAbleToNavigateToAllCateroriesPage()
        {
            HomePage homePage = new HomePage(_driver);
            SeeAllCategories seeAllCategories = homePage.NavigateAllCategories();
            seeAllCategories.allCategoriesDisplayed();
        }


        [Test]
        public void checkAllLinks()
        {
            HomePage homePage = new HomePage(_driver);
            SeeAllCategories seeAllCategories = homePage.NavigateAllCategories();

            seeAllCategories.verifyAllLink();
        }





        [TearDown]
        public void closeBrowser()
        {
            if(TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string name = TestContext.CurrentContext.Test.Name;
                Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
                ss.SaveAsFile($@"C:\Users\User\source\repos\UpWork\UpWork\FailedTestCaseScreenShots\{name}.PnG", ScreenshotImageFormat.Png);

            }
            _driver.Close();
        }
    }
}
