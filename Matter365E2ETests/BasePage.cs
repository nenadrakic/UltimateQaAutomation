using OpenQA.Selenium;

namespace Matter365E2ETests
{
    internal class BasePage
    {
        protected IWebDriver Driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
