using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SpecFlowDemo.Hooks
{
    public static class AssertionClass
    {
        #region StandardMethod
        public static void AssertTextElementPresent(List<string> list)
        {
            int count = 0;
            try
            {
                foreach(string text in list)
                {
                    var  m = ActionClass.MyDriver.FindElements(By.XPath("//*[contains(text(), '" + text + "\')]"));
                    if(m != null)
                    {
                        count++;
                    }
                }

                Assert.AreEqual(list.Count, count);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Test Failed, No of element {0} is found ", count);
                throw ex;
            }
        }

        public static void AssertElementIsPresent(this IWebElement element)
        {
            try
            {
                Assert.AreEqual(true, IsElementPresent(element));

            }

            catch (Exception ex)
            {
                Console.WriteLine("Test Failed, No element {0} is found ", ex.Message);
                throw ex;
            }
        }

        // Makes sure that the test case will not fail unless its absolutely necessary. Returns a true or false to AssertElement is Presesent Method
        public static bool IsElementPresent(IWebElement element)
        {
            bool Present = false;
            try
            {
                ActionClass.MyDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                if (element.Displayed)
                {
                    Present = true;
                    Console.WriteLine("Element Is Seen");
                }

                else
                {
                    ActionClass.MyDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                    if (element.Displayed)
                    {
                        Present = true;
                    }
                }
                return Present;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("No Such Element : {0}", ex.Message);
                Assert.Fail("No Such Element");
                return false;
            }
        }


        // Checks for Text and confirms its a match
        public static void ContainsString(IWebElement element, string neededText)
        {
            string actualText = element.Text;
            try
            {
                if (actualText.Contains(neededText))
                {
                    Console.WriteLine("Text Matched");
                }
                else
                    Assert.Fail("Text mismatch");
            }
            catch (Exception e)
            {
                Console.WriteLine("Text Mismatched : {0}", e.Message);
                throw e;
            }
        }

        #endregion


        #region custom method
        public static void CompareSites(string currentUrl, string previousUrl)
        {
            Assert.AreNotEqual(currentUrl, previousUrl);
        }

        public static void AssertElementsWithTitleIsPresentInTable(List<string> list)
        {
            var elements = ActionClass.MyDriver.FindElements(By.CssSelector("#ZpxfC > div > div.gws-trips__tile-row > table > tbody > tr > td"));
            int count = 0;
            int value = 1;
            foreach (var ele in elements)
            {
                string title = ele.FindElement(By.XPath("//*[@id='ZpxfC']/div/div[1]/table/tbody/tr/td[" + value + "]/div/a/div/div/div[1]")).Text;
                value++;
                if (list.Contains(title))
                {
                    count += 1;
                }
            }

            try
            {
                Assert.AreEqual(list.Count, count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Test Failed, expecting {0} asean countries", list.Count);
                throw ex;
            }
        }

        public static void AssertElementsArePresentInTable(List<string> list)
        {
            var elements = ActionClass.MyDriver.FindElements(By.CssSelector("#kp-wp-tab-overview > div:nth-child(3) > div > div > div > div > div.zVvuGd.MRfBrb > div:nth-child(n)"));
            int count = 0;
            int value = 1;
            foreach (var ele in elements)
            {
                string title = ele.FindElement(By.CssSelector("#kp-wp-tab-overview > div:nth-child(3) > div > div > div > div > div.zVvuGd.MRfBrb > div:nth-child(" + value + ") > a")).Text;
                value++;
                if (list.Contains(title))
                {
                    count += 1;
                }
            }

            try
            {
                Assert.AreEqual(list.Count, count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Test Failed, expecting {0} asean countries", list.Count);
                throw ex;
            }
        }

        #endregion
    }
}
