using System;
using System.Threading;
using Jupitor_Toy_Project.Utilities;
using OpenQA.Selenium;

namespace Jupitor_Toy_Project.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;

        //Constructor
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Page factory design
        IWebElement ContactPage => driver.FindElement(By.XPath("//a[normalize-space()='Contact']"));
        IWebElement ShopPage => driver.FindElement(By.XPath("//a[normalize-space()='Shop']"));

        public void NavigateToContactPage()
        {
            //Navigate to ContactPage
            ContactPage.Click();
            
        }
        public void NavigateToShopPage()
        {
            ShopPage.Click();
        }

        
    }
}
