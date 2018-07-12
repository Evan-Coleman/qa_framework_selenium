using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace GWRepository.BaseObjects
{
    public class BrowserBase
    {
        public RemoteWebDriver webDriver { get; set; }
        public void Initialize(RemoteWebDriver driver, string center)
        {
            webDriver = driver;
            Goto(center);
        }

        public string Title
        {
            get { return webDriver.Title; }
        }

        public void Goto(string center)
        {
            webDriver.Url = ResourcesBase.ServerAddress + center;
        }

        public void Close()
        {
            webDriver.Close();
        }
    }
}
