using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowDemo.PageObjects
{
    public class SearchPage
    {
        IWebDriver driver;

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement searchesRelatedText => driver.FindElement(By.CssSelector("#tsf > div:nth-child(2) > div.A8SBwf > div.RNNXgb > div > div.a4bIc > input"));

        public IWebElement searchesEnterButton => driver.FindElement(By.CssSelector("#tsf > div:nth-child(2) > div.A8SBwf > div.FPdoLc.tfB0Bf > center > input.gNO89b"));
        public SearchPage Enter(string search)
        {
            ClearText();
            searchesRelatedText.SendKeys(search);
            searchesRelatedText.SendKeys(Keys.Enter);
            return this;
        }

        public void ClearText()
        {
            searchesRelatedText.Clear();
        }

    }
}
