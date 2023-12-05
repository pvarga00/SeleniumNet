using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Remote;


namespace SeleniumNet
{
    [TestFixture()]
    public class SeleniumTests
    {
        private IWebDriver WebBrowser;

        [OneTimeSetUp]
        public void Init()
        {

        }

        [OneTimeTearDown]
        public void Cleanup()
        {

        }


        [Test()]
        public void TestLoginSeleniumTestCase()
        {
            //WebBrowser = new FirefoxDriver();
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--test-type");

            WebBrowser = new ChromeDriver(options);

            //WebBrowser = new ChromeDriver();
            WebBrowser.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            WebBrowser.Navigate().GoToUrl("http://the-internet.herokuapp.com/login");
            var usernameField = WebBrowser.FindElement(By.Id("username"));
            var passwordField = WebBrowser.FindElement(By.Id("password"));
            var loginButton = WebBrowser.FindElement(By.ClassName("radius"));
            usernameField.SendKeys("tomsmith");
            passwordField.SendKeys("SuperSecretPassword!");
            loginButton.Click();
            Assert.IsTrue(WebBrowser.FindElement(By.Id("flash")).GetAttribute("class").Equals("flash success"));
            WebBrowser.Quit();
        }


        [Test()]
        public void SeleniumRemoteDriverTest()
        {
            String browser = "firefox";
            String seleniumUri = "http://10.2.5.38:4444/wd/hub/";
            String os = "Windows 7";

            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, browser);
            capabilities.SetCapability(CapabilityType.Platform, os);

            WebBrowser = new RemoteWebDriver(new Uri(seleniumUri), capabilities, TimeSpan.FromSeconds(600));

            WebBrowser.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            WebBrowser.Navigate().GoToUrl("http://the-internet.herokuapp.com/login");
            var usernameField = WebBrowser.FindElement(By.Id("username"));
            var passwordField = WebBrowser.FindElement(By.Id("password"));
            var loginButton = WebBrowser.FindElement(By.ClassName("radius"));
            usernameField.SendKeys("tomsmith");
            passwordField.SendKeys("SuperSecretPassword!");
            loginButton.Click();
            Assert.IsTrue(WebBrowser.FindElement(By.Id("flash")).GetAttribute("class").Equals("flash success"));

            WebBrowser.Quit();
        }


        [Test()]
        public void SeleniumRemoteDriverTest2()
        {

            String browser = "chrome";
            String version = "40";
            String os = "Windows 7";
            String deviceName = "";
            String deviceOrientation = "";

            //WebBrowser = new RemoteWebDriver(new Uri("http://10.2.5.38:4444/wd/hub"), new DesiredCapabilities("firefox", "", new Platform(PlatformType.Windows)));

            WebBrowser = new RemoteWebDriver(new Uri("http://10.2.5.97:5555/wd/hub"), DesiredCapabilities.Chrome());

            //WebBrowser = new RemoteWebDriver(new Uri("http://10.2.5.225:4444/wd/hub"), DesiredCapabilities.Firefox());

            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, browser);
            capabilities.SetCapability(CapabilityType.Version, version);
            capabilities.SetCapability(CapabilityType.Platform, os);
            capabilities.SetCapability("deviceName", deviceName);
            capabilities.SetCapability("deviceOrientation", deviceOrientation);

            WebBrowser.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            WebBrowser.Navigate().GoToUrl("http://the-internet.herokuapp.com/login");
            var usernameField = WebBrowser.FindElement(By.Id("username"));
            var passwordField = WebBrowser.FindElement(By.Id("password"));
            var loginButton = WebBrowser.FindElement(By.ClassName("radius"));
            usernameField.SendKeys("tomsmith");
            passwordField.SendKeys("SuperSecretPassword!");
            loginButton.Click();
            Assert.IsTrue(WebBrowser.FindElement(By.Id("flash")).GetAttribute("class").Equals("flash success"));

            WebBrowser.Quit();

        }


        [Test()]
        public void ConfluenceLogin()
        {
            //String browser = "chrome";
            //String version = "40";
            //String os = "Windows 10";

            //WebBrowser = new RemoteWebDriver(new Uri("http://10.2.5.97:5555/wd/hub"), DesiredCapabilities.Chrome());

            WebBrowser = new FirefoxDriver();

            WebBrowser.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            WebBrowser.Navigate().GoToUrl("http://confluence/");
            var usernameField = WebBrowser.FindElement(By.Id("os_username"));
            var passwordField = WebBrowser.FindElement(By.Id("os_password"));
            var loginButton = WebBrowser.FindElement(By.Id("loginButton"));
            usernameField.SendKeys("XXXX");
            passwordField.SendKeys("XXXX");
            loginButton.Click();

            WebBrowser.Quit();
        }
    }
}
