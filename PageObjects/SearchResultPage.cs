using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowDemo.PageObjects
{
    public class SearchResultPage
    {
        IWebDriver driver;
        public SearchResultPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string aseanCountriesLink => "#kp-wp-tab-overview > div:nth-child(3) > div > div > div > div > div.zVvuGd.MRfBrb";

        public string popularDestinationsLink = "//*[@id='ZpxfC']/div/div[1]/table/tbody/tr/";

        public string topPlacesLink = ".g:nth-child(2) > .tF2Cxc:nth-child(2) .LC20lb > span";

        public IWebElement searchesRelatedText => driver.FindElement(By.CssSelector("#brs > g-section-with-header > div.e2BEnf.U7izfe.mfMhoc > h3 > span"));

        public SearchResultPage NavigateTo(string path)
        {
            var link = driver.FindElement(By.CssSelector(path));
            link.Click();
            return this;
        }

    }
}
