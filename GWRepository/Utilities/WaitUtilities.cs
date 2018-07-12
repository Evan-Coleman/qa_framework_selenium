using GWRepository.BaseObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GWRepository.Utilities
{
    public static class WaitUtilities
    {
        

        public static void WaitForPostBack(RemoteWebDriver _webDriver)
        {
            Thread.Sleep(ResourcesBase.WaitUtilsBaseWaitInMiliSeconds);

            WebDriverWait initialWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
            initialWait.Until((x) =>
            {
                return ((IJavaScriptExecutor)_webDriver).ExecuteScript("return document.readyState").Equals("complete");
            });

            WebDriverWait wait = new WebDriverWait(_webDriver, new TimeSpan(0, ResourcesBase.WaitUtilsDefaultValueInMinutes, 0));
            var waitElement = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = _webDriver.FindElement(By.CssSelector("body[class*=x-mask]"));
                    return !elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException e)
                {
                    return false;
                }
                catch (NoSuchElementException e)
                {
                    return true;
                }
            });
        }

        public static void WaitForPostBack(RemoteWebDriver _webDriver, int minutes, int seconds)
        {
            Thread.Sleep(ResourcesBase.WaitUtilsBaseWaitInMiliSeconds);

            WebDriverWait initialWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
            initialWait.Until((x) =>
            {
                return ((IJavaScriptExecutor)_webDriver).ExecuteScript("return document.readyState").Equals("complete");
            });

            WebDriverWait wait = new WebDriverWait(_webDriver, new TimeSpan(0, minutes, seconds));
            var waitElement = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = _webDriver.FindElement(By.CssSelector("body[class*=x-mask]"));
                    return !elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }
    }
}
