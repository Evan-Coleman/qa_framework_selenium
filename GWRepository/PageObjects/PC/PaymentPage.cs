using GWRepository.BaseObjects;
using GWRepository.Entities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GWRepository.PageObjects.PC
{
    public class PaymentPage : PageBase
    {
        public PaymentPage(RemoteWebDriver driver, PagesBase pages)
        {
            Pages = pages;
            _webDriver = driver;
        }

        #region Page Elements
        public IWebElement btnAddDownPayment => _webDriver.FindElementByCssSelector("span[id*='DownpaymentLV_tb:AddDownPaymentInstrument-btnInnerEl']");

        // Page technically "New Down Payment Method"
        public IWebElement txtStillOwing => _webDriver.FindElementByCssSelector("div[id*='AvailableAmount-inputEl']");
        public IWebElement txtDownPaymentAmount => _webDriver.FindElementByCssSelector("input[id='NewDownPaymentMethodPopup:Amount-inputEl']");
        public IWebElement selDownPaymentType => _webDriver.FindElementByCssSelector("input[id*='NewDownPaymentMethodPopup:Type-inputEl']");
        public IWebElement btnOk => _webDriver.FindElementByCssSelector("span[id*='NewDownPaymentMethodPopup:Update-btnInnerEl']");
        #endregion

        #region Page Methods
        public bool SelectPaymentPlanType(string paymentPlanType)
        {
            NavigateToPage();

            return sClick(_webDriver.FindElementByXPath($"//div[text()='{paymentPlanType}']/ancestor::td[1]/preceding-sibling::td[1]/div/div"));
        }

        public bool AddDownPayment(PolicyEntity policy)
        {
            NavigateToPage();

            sClick(btnAddDownPayment);
            string amountToPay =  txtStillOwing.Text;
            amountToPay = amountToPay.Substring(0, 6).Replace("$", "").Replace(",", "");
            sSendKeys(txtDownPaymentAmount, amountToPay);
            sSelectorSelect(selDownPaymentType, policy.DownPaymentType);
            return sClick(btnOk);
        }
        #endregion

        #region Standard Page Methods
        public bool IsAt()
        {
            return _webDriver.PageSource.Contains("SubmissionWizard_PaymentScreen:ttlBar");
        }

        public bool NavigateToPage()
        {
            if (IsAt())
            {
                return true;
            }
            else
            {
                Pages.SideMenu.ClickPayment();
                if (IsAt())
                {
                    return true;
                }
                else
                {
                    Assert.Fail("Could not get to Quote page");
                    return false;
                }
            }
        }
        #endregion
    }
}
