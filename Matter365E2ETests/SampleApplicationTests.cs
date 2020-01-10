using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Matter365E2ETests
{
    [TestClass]
    [TestCategory("SampleAppOne")]
    public class SampleApplicationTests
    {
        internal TestUser TestUser { get; private set; }
        internal TestUser EmergencyContactUser { get; private set; }

        private IWebDriver Driver { get; set; }

        private SampleApplicationPage sampleApplicationPage;

        [TestInitialize]
        public void SetupForEverySingleTestMethod()
        {
            Driver = GetChromeDriver();
            sampleApplicationPage = new SampleApplicationPage(Driver);

            TestUser = new TestUser();
            TestUser.FirstName = "Nenad";
            TestUser.LastName = "Rakic";

            EmergencyContactUser = new TestUser();
            EmergencyContactUser.FirstName = "Jelena";
            EmergencyContactUser.LastName = "Vukosav";
        }

        [TestMethod]
        [Description("Validate that user is able to fill out the form successfully using valid data")]
        public void Test1()
        {
            SetGenderTypes(Gender.Female, Gender.Female);

            sampleApplicationPage.GoTo();
            sampleApplicationPage.FilOutEmergencyContractForm(EmergencyContactUser);
            var ultimateQAHomePage = sampleApplicationPage.FilOutPrimaryContactFormAndSubmit(TestUser);

            AssertPageVisible(ultimateQAHomePage);
        }

        [TestMethod]
        [Description("Fake 2nd test.")]
        public void Test2()
        {
            sampleApplicationPage.GoTo();

            var ultimateQAHomePage = sampleApplicationPage.FilOutPrimaryContactFormAndSubmit(TestUser);
            AssertPageVisibleVariation2(ultimateQAHomePage);
        }

        [TestMethod]
        [Description("Validate that when selecting the other gender type, the form is submitted successfully")]
        public void Test3()
        {
            SetGenderTypes(Gender.Other, Gender.Other);

            sampleApplicationPage.GoTo();
            sampleApplicationPage.FilOutEmergencyContractForm(EmergencyContactUser);
            var ultimateQAHomePage = sampleApplicationPage.FilOutPrimaryContactFormAndSubmit(TestUser);
            AssertPageVisible(ultimateQAHomePage);
        }

        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            Driver.Close();
            Driver.Quit();
        }

        private IWebDriver GetChromeDriver()
        {
            //var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //return new ChromeDriver(outPutDirectory);
            return new ChromeDriver("Drivers/");
        }

        private static void AssertPageVisible(UltimateQAHomePage ultimateQAHomePage)
        {
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible");
        }
        private static void AssertPageVisibleVariation2(UltimateQAHomePage ultimateQAHomePage)
        {
            Assert.IsFalse(!ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible");
        }

        private void SetGenderTypes(Gender primaryContact, Gender emergencyContact)
        {
            EmergencyContactUser.GenderType = primaryContact;
            TestUser.GenderType = emergencyContact;
        }

    }
}
