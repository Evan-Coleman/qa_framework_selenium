using GWRepository.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GWRepository.BaseObjects
{
    [TestFixture]
    public class TestBase
    {
        public BrowserBase Browser { get; set; }
        public PagesBase Pages { get; set; }
        public BaseObjects.WorkFlowsBase WorkFlows { get; set; }
        public RemoteWebDriver _webDriver { get; set; }
        //[OneTimeSetUp]
        public void Initialize(string center)
        {
            Browser = new BrowserBase();
            Pages = new PagesBase(Browser);
            WorkFlows = new WorkFlowsBase(Pages);
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            //options.AddArgument("--log-level=3");
            //options.AddArgument("--silent");
            //options.AddArgument("--disable-logging");
            //options.AddArgument("sync-short-nudge-delay-for-test");
            options.Proxy = null;
            ChromeDriver driver = new ChromeDriver(ResourcesBase.ChromeDriverPath, options);
            Browser.Initialize(driver, center);
            _webDriver = driver;
            Thread.Sleep(RandomNumberGeneratorUtilities.GetRandomNumber(10) * 100 + 3000);
            WaitUtilities.WaitForPostBack(_webDriver);
        }

        [OneTimeSetUp]
        public void Init()
        {
            Thread.Sleep(RandomNumberGeneratorUtilities.GetRandomNumber(30) * 100 + 3000);
        }

        [OneTimeTearDown]
        public void TextFixtureTeardown()
        {
            
        }

        [TearDown]
        public void TearDown()
        {
            //Browser.Close();
        }
    }
}
