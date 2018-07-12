using GWRepository.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Threading;

namespace GWRepository.BaseObjects
{
    public class PageBase
    {
        public RemoteWebDriver _webDriver;
        public PagesBase Pages;

        public bool sClick(IWebElement element)
        {
            //WaitUtilities.WaitForPostBack(_webDriver);


            if (!element.Displayed && !element.GetAttribute("class").Contains("disabled"))
            {
                Debug.WriteLine("ERROR: Button Is not available to click");
                Debug.WriteLine("Button ID: " + element.GetAttribute("id"));
                return false;
            }

            try
            {
                element.Click();
            }
            catch (WebDriverException)
            {
                try
                {
                    Thread.Sleep(25);
                    element.Click();
                }
                catch (WebDriverException)
                {
                    try
                    {
                        Thread.Sleep(25);
                        element.Click();
                    }
                    catch (WebDriverException)
                    {
                        try
                        {
                            WaitUtilities.WaitForPostBack(_webDriver);
                            element.Click();
                        }
                        catch (WebDriverException)
                        {
                            try
                            {
                                WaitUtilities.WaitForPostBack(_webDriver);
                                element.Click();
                            }
                            catch (WebDriverException)
                            {
                                try
                                {
                                    WaitUtilities.WaitForPostBack(_webDriver);
                                    element.Click();
                                }
                                catch (WebDriverException)
                                {
                                    try
                                    {
                                        WaitUtilities.WaitForPostBack(_webDriver);
                                        element.Click();
                                    }
                                    catch (WebDriverException)
                                    {
                                        WaitUtilities.WaitForPostBack(_webDriver);
                                        element.Click();
                                    }
                                }
                            }
                        }
                    }
                }
            }

            WaitUtilities.WaitForPostBack(_webDriver);
            return true;
        }

        public bool sRadioSelect(string xPath, bool yesNo)
        {
            //WaitUtilities.WaitForPostBack(_webDriver);


            string originalXpath = xPath;
            if (!_webDriver.FindElementByXPath(xPath).Displayed)
            {
                Debug.WriteLine("ERROR: Radio Is not available to select");
                Debug.WriteLine("Radio ID: " + _webDriver.FindElementByXPath(xPath).GetAttribute("id"));
                return false;
            }

            // TODO: GW is wonky and may have different types of radios, watch this
            if (yesNo)
            {
                xPath += "/parent::td/following-sibling::td/descendant::label/preceding-sibling::input[contains(@id, 'true')]";
            }
            else
            {
                xPath += "/parent::td/following-sibling::td/descendant::label/preceding-sibling::input[contains(@id, 'false')]";
            }

            try // Alternate XPATH case check
            {
                _webDriver.FindElementByXPath(xPath).Displayed.Equals(true);
            }
            catch (NoSuchElementException e)
            {
                if (yesNo)
                {
                    xPath = originalXpath + "/parent::td/following-sibling::td/descendant::label[1]/preceding-sibling::input";
                }
                else
                {
                    xPath = originalXpath + "/parent::td/following-sibling::td/descendant::label[2]/preceding-sibling::input";
                }
            }

            try
            {
                if (_webDriver.FindElementByXPath(xPath + "/parent::td[contains(@class, 'checked')]").Displayed)
                    return true;
            }
            catch (NoSuchElementException e)
            {
                sClick(_webDriver.FindElementByXPath(xPath));
                return true;
            }
            return false;
        }

        public bool sCheckboxCheck(string xPath, bool yesNo)
        {
            //WaitUtilities.WaitForPostBack(_webDriver);


            if (!_webDriver.FindElementByXPath(xPath).Displayed)
            {
                Debug.WriteLine("ERROR: checkbox Is not available to check");
                Debug.WriteLine("Checkbox ID: " + _webDriver.FindElementByXPath(xPath).GetAttribute("id"));
                return false;
            }

            // TODO: GW is wonky and may have different types of checks, watch this
            if (!xPath.Contains("/img"))
            {
                string checkXPath = xPath + "/parent::td/following-sibling::td/div/img";

                IWebElement checkBox = _webDriver.FindElementByXPath(checkXPath);
                if (yesNo && !checkBox.GetAttribute("class").Contains("checkcolumn-checked"))
                {
                    sClick(checkBox);
                }
                else if (!yesNo && checkBox.GetAttribute("class").Contains("checkcolumn-checked"))
                {
                    sClick(checkBox);
                }

                sClick(_webDriver.FindElementByXPath(xPath)); // TODO: Keep an eye on this, a bit of a hack-job... but GW is weird
                sClick(_webDriver.FindElementByXPath(xPath));
            }
            else // This else may be to specific
            {
                IWebElement checkBox = _webDriver.FindElementByXPath(xPath);
                if (yesNo && !checkBox.GetAttribute("class").Contains("checkcolumn-checked"))
                {
                    sClick(checkBox);
                }
                else if (!yesNo && checkBox.GetAttribute("class").Contains("checkcolumn-checked"))
                {
                    sClick(checkBox);
                }

                sClick(_webDriver.FindElementByXPath(xPath + "//following::img[1]")); // TODO: Keep an eye on this, a bit of a hack-job... but GW is weird
                sClick(_webDriver.FindElementByXPath(xPath + "//following::img[1]"));
            }

            return true;
        }

        public bool sSendKeys(IWebElement element, string text)
        {
            //WaitUtilities.WaitForPostBack(_webDriver);


            bool done = false;
            int numRetries = 0;
            while (!done && numRetries < 50)
            {
                try
                {
                    if (!element.Displayed)
                    {
                        element.Click();
                        Thread.Sleep(100);
                        if (!element.Displayed)
                        {
                            element.Click();
                            Thread.Sleep(100);
                            if (!element.Displayed)
                            {
                                WaitUtilities.WaitForPostBack(_webDriver);
                                element.Click();
                                Thread.Sleep(300);
                                if (!element.Displayed)
                                {
                                    Debug.WriteLine("ERROR: TextBox Is not available to fill");
                                    Debug.WriteLine("TextBox ID: " + element.GetAttribute("id"));
                                    return false;
                                }
                            }
                        }
                    }
                    done = true;
                }
                catch (WebDriverException)
                {
                    WaitUtilities.WaitForPostBack(_webDriver);
                    numRetries++;
                }
            }

            // Optimization to not enter if it's already set.. saves postback time!
            if (element.GetAttribute("value") == text || element.Text == text) // TODO: WATCH THIS, GW is wonky and it may not always be value
            {
                return true;
            }
            element.Clear();

            try
            {
                element.SendKeys(text);
            }
            catch (StaleElementReferenceException)
            {
                Thread.Sleep(500);
                element.SendKeys(text);
            }

            TriggerPostBack(element);
            return true;
        }

        public bool sSelectorSelect(IWebElement element, string text)
        {
            WaitUtilities.WaitForPostBack(_webDriver);


            if (!element.Displayed)
            {
                Debug.WriteLine("ERROR: Selector Is not available to fill");
                Debug.WriteLine("Selector ID: " + element.GetAttribute("id"));
                return false;
            }

            if (element.GetAttribute("value") == text || element.Text == text) // TODO: WATCH THIS, GW is wonky and it may not always be value
            {
                return true;
            }

            sClick(element);

            if (_webDriver.FindElementByXPath("//li[contains(text(), '" + text + "')]").Displayed)
            {
                sClick(_webDriver.FindElementByXPath("//li[contains(text(), '" + text + "')]"));
                Thread.Sleep(50);
            }

            return true;
        }

        // Use this selector when there are multiple selectors with the same set of values to choose from
        public bool sAltSelectorSelect(IWebElement element, string text)
        {
            WaitUtilities.WaitForPostBack(_webDriver);


            if (!element.Displayed)
            {
                Debug.WriteLine("ERROR: Selector Is not available to fill");
                Debug.WriteLine("Selector ID: " + element.GetAttribute("id"));
                return false;
            }

            if (element.GetAttribute("value") == text || element.Text == text) // TODO: WATCH THIS, GW is wonky and it may not always be value
            {
                return true;
            }

            WaitUtilities.WaitForPostBack(_webDriver);
            sClick(element);
            WaitUtilities.WaitForPostBack(_webDriver);
            sSendKeys(element, text);
            return true;
        }

        public void TriggerPostBack(IWebElement element)
        {
            WaitUtilities.WaitForPostBack(_webDriver);


            if (_webDriver.FindElementByXPath("//img[contains(@class,'product-logo')]").Displayed)
            {
                sClick(_webDriver.FindElementByXPath("//img[contains(@class,'product-logo')]"));
            }
            else
            {
                element.SendKeys(Keys.Tab);
                WaitUtilities.WaitForPostBack(_webDriver);
            }
        }
    }
}
