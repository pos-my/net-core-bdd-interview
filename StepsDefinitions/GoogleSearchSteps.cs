using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SpecFlowDemo.Hooks;
using SpecFlowDemo.PageObjects;
using SpecFlowDemo.TestData;
using TechTalk.SpecFlow;

namespace SpecFlowDemo.StepsDefinitions
{
    [Binding]
    public class GoogleSearchSteps
    {
        public string currentWebAddress = "";

        #region Given
        [Given(@"""(.*)"" wants to have a vacation in Malaysia")]
        public void GivenWantsToHaveAVacationInMalaysia(string p0)
        {
            try
            {
                DriverClass.TestInit(TestConfig.externalUrl);
                SearchResultPage searchPage = new SearchResultPage(ActionClass.MyDriver);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Test Failed: could not load the application : {0}", ex.Message);
                DriverClass.TestEnd();
                throw;
            }
        }

        #endregion

        #region When
        [When(@"I perform a Google Search for ""(.*)""")]
        public void WhenIPerformAGoogleSearchFor(string searchText)
        {
            SearchPage searchPage = new SearchPage(ActionClass.MyDriver);
            searchPage.Enter(searchText);
        }

        #endregion


        #region Then
        [Then(@"the user will see Advertisement on top of search result")]
        public void ThenTheUserWillSeeAdvertisementOnTopOfSearchResult(Table table)
        {
            SearchResultPage searchPage = new SearchResultPage(ActionClass.MyDriver);
            List<string> listOfDestinations = new List<string>();

            foreach (TableRow row in table.Rows)
            {
                listOfDestinations.Add(row["Destinations"]);
            }

            AssertionClass.AssertElementsWithTitleIsPresentInTable(listOfDestinations);
        }



        [Then(@"the section titled details")]
        public void ThenTheSectionTitledDetails(Table table)
        {
            SearchResultPage searchPage = new SearchResultPage(ActionClass.MyDriver);
            List<string> listOfSections = new List<string>();

            foreach (TableRow row in table.Rows)
            {
                listOfSections.Add(row["Titles"]);
            }

            AssertionClass.AssertTextElementPresent(listOfSections);
        }


        [Then(@"has Southeast Asia countries")]
        public void ThenHasSoutheastAsiaCountries(Table table)
        {
            SearchResultPage searchPage = new SearchResultPage(ActionClass.MyDriver);
            List<string> listOfCountries = new List<string>();

            foreach (TableRow row in table.Rows)
            {
                listOfCountries.Add(row["Countries"]);
            }

            AssertionClass.AssertElementsArePresentInTable(listOfCountries);
        }


        [Then(@"I will see related searches suggestions")]
        public void ThenIWillSeeRelatedSearchesSuggestions()
        {
            SearchResultPage searchPage = new SearchResultPage(ActionClass.MyDriver);
            ActionClass.Wait(5);
            AssertionClass.AssertElementIsPresent(searchPage.searchesRelatedText);
        }

        [Then(@"I will click on that suggest Top Places to visit")]
        public void ThenIWillClickOnThatSuggestTopPlacesToVisit()
        {
            SearchResultPage searchResultPage = new SearchResultPage(ActionClass.MyDriver);

            searchResultPage.NavigateTo(searchResultPage.topPlacesLink);
        }


        [Then(@"I will see that the browser no longer on Google page")]
        public void ThenIWillSeeThatTheBrowserNoLongerOnGooglePage()
        {
            string currentUrl = DriverClass.GetCurrentURL();

            AssertionClass.CompareSites(currentWebAddress, currentUrl);

            DriverClass.TestEnd();
        }
        #endregion

    }
}
