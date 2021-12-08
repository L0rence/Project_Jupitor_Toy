using System;
using System.IO;
using System.Text;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using static Jupitor_Toy_Project.Utilities.CommonMethods;

namespace Jupitor_Toy_Project.Utilities
{
    public class Driver
    {
        //Initialize the browser
        public static IWebDriver driver;
        public static ExtentReports extent;
        public static ExtentHtmlReporter hTMLReporter;
        public static ExtentTest test;

        [OneTimeSetUp]
        public void Initialize()
        {
            //hTMLReporter = new ExtentHtmlReporter(ConstantHelpers.ReportsPath);
            hTMLReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(hTMLReporter);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.DataFilePath, "Credentials");
            //ExcelLibHelper.PopulateInCollection(ConstantHelpers.DataFilePath, "Credentials");   

        }
        [TearDown]
        public void CloseBrowser()
        {
            // close the driver
            driver.Close();
            driver.Quit();
        }
        [OneTimeTearDown]
        public void FinalSteps()
        {
            extent.Flush();
            File.Move("/Users/chriselyn/Projects/Jupitor_Toy_Project/Jupitor_Toy_Project/ExtentReport/index.html", "/Users/chriselyn/Projects/Jupitor_Toy_Project/Jupitor_Toy_Project/ExtentReport/ExtentReport_" + DateTime.Now.ToString("MMM-dd-yyyy hh-mm-ss") + ".html");
        }
        /*
        public void Setup(string browserName)
        {

            //Defining the browser
            if (browserName.Equals("chrome"))
                driver = new ChromeDriver();
            else if (browserName.Equals("ie"))
                driver = new InternetExplorerDriver();
            else if (browserName.Equals("safari"))
                driver = new SafariDriver();
            else
                driver = new FirefoxDriver();

            //Maximise the window
            driver.Manage().Window.Maximize();

            NavigateUrl();
        }

        public static string BaseUrl
        {
            get { return ConstantHelpers.Url; }
        }


        public static void NavigateUrl()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }

         //public static IEnumerable<string> BrowserToRunWith()
         //{
         //   string[] browsers = AutomationSettings.browsersToRunWith.Split(',');
         //    foreach (String b in browsers)
         //   {
         //        yield return b;
         //    }

         //}
       
        [OneTimeTearDown]
        public void FinalSteps()
        {
            extent.Flush();
            File.Move("/Users/chriselyn/Projects/Jupitor_Toy_Project/Jupitor_Toy_Project/ExtentReport/index.html", "/Users/chriselyn/Projects/Jupitor_Toy_Project/Jupitor_Toy_Project/ExtentReport/ExtentReport_" + DateTime.Now.ToString("MMM-dd-yyyy hh-mm-ss") + ".html");
        }
        */



    }
}
