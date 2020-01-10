using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Support.UI;
using System;

namespace Matter365E2ETests
{
    internal class UltimateQAHomePage: BasePage
    {
        public WebDriverWait wait;

        public UltimateQAHomePage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        By ViewAllCoursesLink = By.LinkText("VIEW ALL COURSES");

        public IWebElement ViewAllCoursesButton => wait.Until(ExpectedConditions.ElementExists(ViewAllCoursesLink));

        public bool IsVisible => ViewAllCoursesButton.Displayed;


        //public bool IsVisible => wait.Until(d=>d.FindElement(ViewAllCoursesLink)).Displayed;
    }
}