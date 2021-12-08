using System;
using System.Threading;
using Jupitor_Toy_Project.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using static Jupitor_Toy_Project.Utilities.CommonMethods;

namespace Jupitor_Toy_Project.Pages
{
    public class ContactPage
    {
        private readonly IWebDriver driver;

        public ContactPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Page factory design
        IWebElement SubmitBtn => driver.FindElement(By.XPath("//a[normalize-space()='Submit']"));
        IWebElement Forename_Txt => driver.FindElement(By.XPath("//input[@id='forename']"));
        IWebElement Forename_err => driver.FindElement(By.XPath("//span[@id='forename-err']"));
        IWebElement EmailTxt => driver.FindElement(By.XPath("//input[@id='email']"));
        IWebElement Email_err => driver.FindElement(By.XPath("//span[@id='email-err']"));
        IWebElement MessageTxt => driver.FindElement(By.XPath("//textarea[@id='message']"));
        IWebElement Message_err => driver.FindElement(By.XPath("//span[@id='message-err']"));
        IWebElement SuccessMessage => driver.FindElement(By.XPath("//div[@class='alert alert-success']"));
        

        public void ClickSubmitBtn()
        {
            SubmitBtn.Click();
        }

        public void ForenameValidation()
        {
            var ForenameText = Forename_err.Text;
            Console.WriteLine("Forename error is =====>>>>" + ForenameText);
            bool isForenameDisplayed = Forename_Txt.Displayed;
            Assert.IsTrue(isForenameDisplayed);
        }

        public void EmailValidation()
        {
            var EmailText = Email_err.Text;
            Console.WriteLine("Email error is =====>>>>" +  EmailText);
            bool isEmailDisplayed = EmailTxt.Displayed;
            Assert.IsTrue(isEmailDisplayed);
        }
        public void MessageValidation()
        {
           var MessageText = Message_err.Text;
            Console.WriteLine("Message erro is =====>>>>" + MessageText );
            bool isMessageDisplayed = MessageTxt.Displayed;
            Assert.IsTrue(isMessageDisplayed);
        }

        public void EnterForename()
        {
            Forename_Txt.SendKeys(ExcelLibHelper.ReadData(1, "Forename"));
            Console.WriteLine("Enter ForeName ====> " + ExcelLibHelper.ReadData(1, "Forename"));
        }
         
        public void EnterEmail()
        {
            EmailTxt.SendKeys(ExcelLibHelper.ReadData(1, "Email"));
            Console.WriteLine("Enter Email ====> " + ExcelLibHelper.ReadData(1, "Email"));
        }
         
        public void EnterMessage()
        {
            MessageTxt.SendKeys(ExcelLibHelper.ReadData(1, "Message"));
            Console.WriteLine("Enter Message ====> " + ExcelLibHelper.ReadData(1, "Message"));
        }
        public void SuccessMessageTxt()
        {
            var Succ_txt = SuccessMessage.Text;
            Console.WriteLine("Sucess Message is ======>>> " + Succ_txt);
            bool isDisplayed = SuccessMessage.Displayed;
            Assert.IsTrue(isDisplayed);
        }

        
    }
}
