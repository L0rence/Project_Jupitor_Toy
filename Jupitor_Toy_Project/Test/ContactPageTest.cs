using System;
using AventStack.ExtentReports;
using Jupitor_Toy_Project.Pages;
using Jupitor_Toy_Project.Utilities;
using NUnit.Framework;

namespace Jupitor_Toy_Project.Test
{
    [TestFixture]
    public class ContactPageTest : CommonDriver
    {
        ExtentTest test = null;


        [Test]
        public void ContactPageErrorValidationTest()
        {
            try
            {
                test = extent.CreateTest("BuyFunnyCowFluffyBunnyTest").Info("Test Started");
                test.Log(Status.Pass, "Buy Funny cow and Fluffy Bunny Test is called");

                //Home page object
                HomePage homePageObj = new HomePage(driver);
                homePageObj.NavigateToContactPage();
                //Contact Page objects
                ContactPage contactPageObj = new ContactPage(driver);
                contactPageObj.ClickSubmitBtn();
                contactPageObj.ForenameValidation();
                contactPageObj.EmailValidation();
                contactPageObj.MessageValidation();
                test.Log(Status.Pass, "Error Validation is successfully");
                test.Pass("Test Passed");

                //contactPageObj.EnterForename();
                //contactPageObj.EnterEmail();
                //contactPageObj.EnterMessage();
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, ex.StackTrace.ToString());
                test.Fail("Test Failed");

            }


        }

        [Test]
        [Repeat(5)]
        public void ContactPage_Populate_ValidationTest()
        {
            try
            {
                test = extent.CreateTest("ContactPage_Populate_Validation").Info("Test Started");
                test.Log(Status.Pass, "ContactPage_Populate_Validation Test is called");

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
            catch (Exception ex)
            {
                test.Log(Status.Fail, ex.StackTrace.ToString());
                test.Fail("Test Failed");

            }

        }
       
    }
}
