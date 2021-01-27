using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;

namespace SpecFlowDemo.Hooks
{
    public static class DriverClass
    {
        public static void TestInit(string BaseURL)
        {
            try
            {
                var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var relativePath = @"..\..\Debug\netcoreapp3.1\Drivers";
                var chromeDriverPath = Path.GetFullPath(Path.Combine(outPutDirectory, relativePath));

                ChromeOptions ChromeOptions = new ChromeOptions();
                ChromeOptions.AddAdditionalCapability("useAutomationExtension", false);

                ActionClass.MyDriver = new ChromeDriver(ChromeOptions);
                ActionClass.MyDriver.Manage().Window.Maximize();
                ActionClass.MyDriver.Navigate().GoToUrl(BaseURL);
            }
            catch (Exception testInitiationException)
            {
                Console.WriteLine("Failed Initiation : {0}", testInitiationException.Message);

                Assert.Fail();
            }
        }

        // This method makes sure the page is fully loaded before test is executed
        public static void PageLoaded(string ObjectID)
        {
            try
            {
                WebDriverWait waitForElement = new WebDriverWait(ActionClass.MyDriver, TimeSpan.FromSeconds(60));
                waitForElement.Until(ExpectedConditions.ElementIsVisible(By.Id(ObjectID)));
            }
            catch (Exception ErrorPageLoad)
            {
                Console.WriteLine("Taking too much time: {0}", ErrorPageLoad.Message);
                throw ErrorPageLoad;
            }
        }

        // Tears down test and throws exception
        public static void TestEnd()
        {
            try
            {
                ActionClass.MyDriver.Quit();
                Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");

                foreach (var chromeDriverProcess in chromeDriverProcesses)
                {
                    chromeDriverProcess.Kill();
                }
                Console.WriteLine("Test Completes successfully");
            }
            catch (WebDriverException testClosingException)
            {
                Console.WriteLine("Driver Failed to close the browser: {0}", testClosingException.Message);
            }

        }

        public static string GetCurrentURL()
        {
            return ActionClass.MyDriver.Url;
        }
    }
}
