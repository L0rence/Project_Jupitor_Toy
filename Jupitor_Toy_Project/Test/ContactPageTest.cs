using System;
using Jupitor_Toy_Project.Pages;
using Jupitor_Toy_Project.Utilities;
using NUnit.Framework;

namespace Jupitor_Toy_Project.Test
{
    [TestFixture]
    public class ContactPageTest : CommonDriver
    {
         
        [Test]
        public void ContactPageErrorValidationTest()
        {
            //Home page object
            HomePage homePageObj = new HomePage(driver);
            homePageObj.NavigateToContactPage();
            //Contact Page objects
            ContactPage contactPageObj = new ContactPage(driver);
            contactPageObj.ClickSubmitBtn();
            contactPageObj.ForenameValidation();
            contactPageObj.EmailValidation();
            contactPageObj.MessageValidation();
            
            //contactPageObj.EnterForename();
            //contactPageObj.EnterEmail();
            //contactPageObj.EnterMessage();

        }

        [Test]
        [Repeat(5)]
        public void ContactPage_Populate_ValidationTest()
        {
            //Home page object
            HomePage homePageObj = new HomePage(driver);
            homePageObj.NavigateToContactPage();
            //Contact Page objects
            ContactPage contactPageObj = new ContactPage(driver);
            contactPageObj.EnterForename();
            contactPageObj.EnterEmail();
            contactPageObj.EnterMessage();
            contactPageObj.ClickSubmitBtn();
            contactPageObj.SuccessMessageTxt();

        }
       
    }
}
