using GWRepository.BaseObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GWRepository.PageObjects.PC
{
    public class NewSubmissionsPage : PageBase
    {
        public NewSubmissionsPage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        // TOP NAVIGATION SECTION
        public IWebElement btnCancel => _webDriver.FindElementByCssSelector("span[id*=Cancel-btn][class=x-btn-wrap]");

        // SELECTORS SECTION
        public IWebElement selAgentNumber => _webDriver.FindElementByCssSelector("input[id*='ProducerSelectionInputSet']");
        public IWebElement selQuoteType => _webDriver.FindElementByCssSelector("input[id*='QuoteType']");
        public IWebElement selState => _webDriver.FindElementByCssSelector("input[id*='DefaultBaseState']");
        public IWebElement selEffectiveDate => _webDriver.FindElementByCssSelector("input[id*='DefaultPPEffDate']");

        // TABLE SECTION
        public IWebElement btnSquireProduct => _webDriver.FindElementByXPath("//div[contains(text(), 'Squire')]//parent::td/preceding-sibling::td/div/a[contains(@id, 'ProductSelection')]");
        public IWebElement btnBusinessownersProduct => _webDriver.FindElementByXPath("//div[contains(text(), 'Businessowners')]//parent::td/preceding-sibling::td/div/a[contains(@id, 'ProductSelection')]");
        public IWebElement btnStandardInlandMarineProduct => _webDriver.FindElementByXPath("//div[contains(text(), 'Standard Inland Marine')]//parent::td/preceding-sibling::td/div/a[contains(@id, 'ProductSelection')]");
        public IWebElement btnStandardFireAndLiabilityProduct => _webDriver.FindElementByXPath("//div[contains(text(), 'Standard Fire & Liability')]//parent::td/preceding-sibling::td/div/a[contains(@id, 'ProductSelection')]");
        #endregion

        #region Page Methods
        // TOP NAVIGATION SECTION
        public bool ClickCancel()
        {
            return sClick(btnCancel);
        }

        // SELECTORS SECTION
        public bool SelectAgentNumber(string agentNumber)
        {
            return sSelectorSelect(selAgentNumber, agentNumber);
        }
        public bool SetQuoteType(string quoteType)
        {
            return sSendKeys(selQuoteType, quoteType);
        }
        public bool SetState(string state)
        {
            return sSendKeys(selState, state);
        }
        public bool SetEffectiveDate(string effectiveDate)
        { 
            return sSendKeys(selEffectiveDate, effectiveDate);
        }
        public string GetCenterDate() // TODO: Remove when GW APIs figured out
        {
            return ResourcesBase.PCDate = selEffectiveDate.GetAttribute("value");
        }

        // TABLE SECTION
        public bool ClickSquireProduct()
        {
            return sClick(btnSquireProduct);
        }
        public bool ClickBusinessownersProduct()
        {
            return sClick(btnBusinessownersProduct);
        }
        public bool ClickStandardInlandMarineProduct()
        {
            return sClick(btnStandardInlandMarineProduct);
        }
        public bool ClickStandardFireAndLiabilityProduct()
        {
            return sClick(btnStandardFireAndLiabilityProduct);
        }

        public bool ClickProduct(string Product)
        {
            switch (Product)
            {
                case (ResourcesBase.Enums.ProductType.Squire):
                    return ClickSquireProduct();
                case (ResourcesBase.Enums.ProductType.Businessowners):
                    return ClickBusinessownersProduct();
                case (ResourcesBase.Enums.ProductType.StandardInlandMarine):
                    return ClickStandardInlandMarineProduct();
                case (ResourcesBase.Enums.ProductType.StandardFireAndLiability):
                    return ClickStandardFireAndLiabilityProduct();
            }

            return false;
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("New Submission");
        }
        #endregion
    }
}
