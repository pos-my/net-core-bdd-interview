using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowDemo.Hooks
{
    public static class ActionClass
    {
        public static IWebDriver MyDriver { get; set; }

        // custom method for entering a text in to a field
        public static void EnterText(this IWebElement element, string value)
        {
            element.Click();
            element.Clear();
            element.SendKeys(value);
        }

        public static void ScrollintoView(this IWebElement Element)
        {
            IJavaScriptExecutor js = MyDriver as IJavaScriptExecutor;
            // Run the javascript command 'scrollintoview on the element
            js.ExecuteScript("arguments[0].scrollIntoView(true);", Element);
            Wait(2);
        }

        // Method to click and verify page navigation 
        public static void ClickPageNavigation(IWebElement hyperlink, IWebElement landingPageObj)
        {
            try
            {
                hyperlink.Click();
                Wait(5);
                AssertionClass.AssertElementIsPresent(landingPageObj);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not able to navigate : {0}", ex.Message);
                throw ex;
            }

        }

        public static void Wait(int Time)
        {
            System.Threading.Thread.Sleep(Time * 1000);
        }

    }
}
