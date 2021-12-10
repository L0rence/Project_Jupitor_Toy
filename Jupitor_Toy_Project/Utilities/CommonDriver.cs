using System;
using System.IO;
using System.Text;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Jupitor_Toy_Project.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static Jupitor_Toy_Project.Utilities.CommonMethods;

namespace Jupitor_Toy_Project.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver;
        public static ExtentReports extent;
        public static ExtentHtmlReporter hTMLReporter;
        public static ExtentTest test;

        [OneTimeSetUp]
        public void Initialize()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"/Users/chriselyn/Projects/Jupitor_Toy_Project/ExtentReport/Report.html");
            ///Users/chriselyn/Projects/Trademe_project/Trademe_project/Report
            extent.AttachReporter(htmlReporter);

            //hTMLReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            //extent = new ExtentReports();
            //extent.AttachReporter(hTMLReporter);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //ExcelLibHelper.PopulateInCollection(ConstantHelpers.DataFilePath, "Credentials");
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.DataFilePath, "ContactPageTestData");
            //File.Move("/Users/chriselyn/Projects/Jupitor_Toy_Project/Jupitor_Toy_Project/ExtentReport/index.html", "/Users/chriselyn/Projects/Jupitor_Toy_Project/Jupitor_Toy_Project/ExtentReport/ExtentReport_" + DateTime.Now.ToString("MMM-dd-yyyy hh-mm-ss") + ".html");
        }

        [SetUp]
        public void NavigateHomePage()
        {
            driver = new ChromeDriver();

            //Maximize the browser
            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            //Navigate to Website
            driver.Navigate().GoToUrl("https://jupiter.cloud.planittesting.com/#/");
            
        }

        [TearDown]
        public void FinalSteps()
        {
            //close driver
            driver.Close();
        }
        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
            //File.Move("/Users/chriselyn/Projects/Jupitor_Toy_Project/Jupitor_Toy_Project/ExtentReport/index.html", "/Users/chriselyn/Projects/Jupitor_Toy_Project/Jupitor_Toy_Project/ExtentReport/ExtentReport_" + DateTime.Now.ToString("MMM-dd-yyyy hh-mm-ss") + ".html");
        }
    }
}
