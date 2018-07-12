using GWRepository.BaseObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GWRepository.PageObjects.PC.NonPages
{
    public class CommonTopButtonsElement : PageBase
    {
        public CommonTopButtonsElement(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        public IWebElement btnNext => _webDriver.FindElementByCssSelector("span[id*='SubmissionWizard:Next-btnWrap']");
        public IWebElement btnQuote => _webDriver.FindElementByCssSelector("a[id$='ButtonSet:InsBridgeQuoute']");
        public IWebElement btnQuoteBlockingStep => _webDriver.FindElementByCssSelector("span[id*='InsBridgeQuouteCheck-btnInnerEl']");
        public IWebElement btnSaveDraft => _webDriver.FindElementByCssSelector("span[id*='Draft-btnInnerEl']");
        public IWebElement btnConvertToFullApp => _webDriver.FindElementByCssSelector("span[id*='ConvertToFullApp-btnInnerEl']");
        public IWebElement btnCloseOptions => _webDriver.FindElementByCssSelector("span[id*='CloseOptions-btnInnerEl']");
        public IWebElement btnNotTakenCloseOption => _webDriver.FindElementByCssSelector("span[id*='NotTakenJob-textEl']");
        public IWebElement btnPrintDocuments => _webDriver.FindElementByXPath("//span[contains(@id, 'ToolbarButton-btnInnerEl')][contains(text(), 'Print Documents')]");
        public IWebElement errorMessage => _webDriver.FindElementByCssSelector("img[class*=error_icon]");
        public IWebElement errorMessageText => _webDriver.FindElementByCssSelector("div[id*=':_msgs'] div");
        public IWebElement btnSubmitOptionsArrow => _webDriver.FindElementByCssSelector("span[id*='ButtonSet:BindOptions-btnInnerEl']");
        public IWebElement btnSubmit => _webDriver.FindElementByCssSelector("span[id*='BindOptions:BindOnly-textEl']");
        public IWebElement btnIssuePolicyChange => _webDriver.FindElementByCssSelector("span[id*='BindPolicyChange-btnInnerEl']");
        public IWebElement btnIssuePolicyArrow => _webDriver.FindElementByCssSelector("span[id*='ButtonSet:Issue-btnInnerEl']");
        public IWebElement btnIssueFollowedByPolicyChange => _webDriver.FindElementByCssSelector("span[id*='Issue:PolicyChange-textEl']");
        public IWebElement btnIssueFollowedByPolicyCancel => _webDriver.FindElementByCssSelector("span[id*='Issue:PolicyCancel-textEl']");
        public IWebElement btnIssueNoActionRequired => _webDriver.FindElementByCssSelector("span[id*='Issue:NoActionRequired-textEl']");
        public IWebElement btnIssueOk => _webDriver.FindElementByXPath("//div[contains(text(), 'Are you sure you want to issue this policy?')]/following::span/span[contains(text(), 'OK')]");
        public IWebElement btn => _webDriver.FindElementByCssSelector("");
        #endregion

        #region Page Methods
        public bool ClickNext()
        {
            try
            {
                if (errorMessage.Displayed) // TODO: Should this be here, or in ClickNextWhileAvailable?
                {
                    Debug.WriteLine(string.Format("ERROR: {0}", errorMessageText.Text));
                    return false;
                }
                return sClick(btnNext);
            }
            catch (NoSuchElementException e)
            {
                return sClick(btnNext);
            }
        }

        public bool ClickQuote()
        {
            return sClick(btnQuote);
        }

        public bool ClickQuoteBlockingStep()
        {
            return sClick(btnQuoteBlockingStep);
        }

        public bool ClickSaveDraft()
        {
            return sClick(btnSaveDraft);
        }

        public bool ClickConvertToFullApp()
        {
            return sClick(btnConvertToFullApp);
        }

        public bool ClickNotTakenCloseOption()
        {
            if (sClick(btnCloseOptions))
                return sClick(btnNotTakenCloseOption);
            return false;
        }

        public bool ClickPrintDocuments()
        {
            return sClick(btnPrintDocuments);
        }

        public bool ClickNextWhileAvailable()
        {
            while (!errorMessage.Displayed && ClickNext());
            return true;
        }
        public bool ClickSubmit()
        {
            if (sClick(btnSubmitOptionsArrow))
                return sClick(btnSubmit);
            else return false;
        }
        public bool ClickIssueNoActionRequired()
        {
            if (sClick(btnIssuePolicyArrow))
                if (sClick(btnIssueNoActionRequired))
                    return sClick(btnIssueOk);
            return false;
        }

        public bool ClickIssuePolicyChange()
        {
            if (sClick(btnIssuePolicyChange))
                return sClick(btnIssueOk);
            return false;
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            List<string> listOfStrings = new List<string>() { "Next &gt", "InsBridgeQuoute", "InsBridgeQuouteCheck", "ButtonSet:Draft" };
            return listOfStrings.All(_webDriver.PageSource.ToString().Contains);
        }
        #endregion
    }
}
