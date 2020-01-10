using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace Matter365E2ETests
{
    internal class SampleApplicationPage : BasePage
    {
        public SampleApplicationPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsVisible
        {
            get
               {
                return Driver.Title.Contains(PageTitle);
               }
            internal set { }
        }

        string PageTitle => "Sample Application Lifecycle - Sprint 4 - Ultimate QA";

        By FirstName = By.XPath("//input[@name='firstname']");
        By LastName = By.XPath("//input[@name='lastname']");
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//input[@type='submit']"));

        By FirstNameForEmergency = By.Id("f2");
        By LastNameForEmergency = By.Id("l2");
        public IWebElement SubmitButtonForEmergency => Driver.FindElement(By.Id("submit2"));


        public IWebElement FemaleGenderRadioButton => Driver.FindElement(By.XPath("//input[@name='gender'][@value='female']"));
        public IWebElement OtherGenderRadioButton => Driver.FindElement(By.XPath("//input[@name='gender'][@value='other']"));
        public IWebElement FemaleGenderRadioButtonForEmergencyContact => Driver.FindElement(By.Id("radio2-f"));



        internal void FilOutEmergencyContractForm(TestUser emergencyContactUser)
        {
            SetGenderForEmergencyContract(emergencyContactUser);
            Driver.FindElement(FirstNameForEmergency).SendKeys(emergencyContactUser.FirstName);
            Driver.FindElement(LastNameForEmergency).SendKeys(emergencyContactUser.LastName);
        }

        private void SetGenderForEmergencyContract(TestUser user)
        {
            switch (user.GenderType)
            {
                case Gender.Male:
                    break;
                case Gender.Female:
                    FemaleGenderRadioButtonForEmergencyContact.Click();
                    break;
                case Gender.Other:
                    break;
            }
        }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://ultimateqa.com/sample-application-lifecycle-sprint-4/");
            Assert.IsTrue(IsVisible, $"Sample application page was not visible. Expected => {PageTitle}" + $"Actual=>{Driver.Title}");
        }

        internal UltimateQAHomePage FilOutPrimaryContactFormAndSubmit(TestUser user)
        {
            SetGender(user);
            Driver.FindElement(FirstName).SendKeys(user.FirstName);
            Driver.FindElement(LastName).SendKeys(user.LastName);
            SubmitButton.Submit();
            return new UltimateQAHomePage(Driver);
        }

        private void SetGender(TestUser user)
        {
            switch (user.GenderType)
            {
                case Gender.Male:
                    break;
                case Gender.Female:
                    FemaleGenderRadioButton.Click();
                    break;
                case Gender.Other:
                    OtherGenderRadioButton.Click();
                    break;
            }
        }
    }
}